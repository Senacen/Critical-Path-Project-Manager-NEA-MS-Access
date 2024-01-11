using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.OleDb;
using System.IO;
using ADOX;
using Critical_Path_Project_Manager_NEA_MS_Access.Objects;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    static internal class DatabaseFunctions
    {
        private static string oledbConnectionString = @"Provider=Microsoft Jet 4.0 OLE DB Provider;Data Source = ";
        public static bool createDatabase(string databaseName)
        {
            // Check that the user input name is a valid name for a database
            if (!isValidDatabaseName(databaseName))
            { 
                // If not, display an info message and return that the database was not created
                MessageBox.Show("The name must start with a letter, be made of only letters, numbers, and underscores, and be no longer than 128 characters. " +
                                "It also may not be a MS Access reserved keyword.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // If it was valid, create the new database
            CatalogClass cat = new CatalogClass();
            cat.Create(oledbConnectionString + databaseName + ".mdb;");
            cat = null;

            // If there were no exceptions, return that the database was created
            return true;
        }

        public static void checkUserAccountsDatabaseExists()
        {
            // If the application CPPMUserAccounts database has not been created yet
            if (!File.Exists("CPPMUserAccounts.mdb"))
            {
                // Create it
                createDatabase("CPPMUserAccounts");

                // Then create all the tables in it to store the user details and their projects
                string createTableSQL = "CREATE TABLE UserDetailsTbl (" +
                                        "Username VARCHAR(100) PRIMARY KEY," +
                                        "PasswordHash INT)";
                executeNonQuery("CPPMUserAccounts", createTableSQL);
                createTableSQL = "CREATE TABLE UserProjectsTbl (" +
                                 "Username VARCHAR(100)," +
                                 "ProjectName VARCHAR(100)," +
                                 "PRIMARY KEY (Username, ProjectName)," +
                                 "FOREIGN KEY (Username) REFERENCES UserDetailsTbl(Username))";
                executeNonQuery("CPPMUserAccounts", createTableSQL);
            }
        }
        public static bool isValidDatabaseName(string name)
        {
            // Check length
            if (name.Length == 0 || name.Length > 128) return false;
            // Check first character is a letter and following characters are only letters, numbers, or underscore
            if (!Regex.IsMatch(name, "^[A-Za-z][A-Za-z0-9_]*$")) return false;
            // Check name is not a MS Access reserved keyword
            using (StreamReader SR = new StreamReader(@"..\..\MSAccessReservedKeywords.txt"))
            {
                string keyword;
                while ((keyword = SR.ReadLine()) != null)
                {
                    // If the name is any of the keywords, return false
                    if (name.ToUpper() == keyword.Replace("\n", "")) return false;
                }
            }
            return true;
        }

        private static void executeNonQuery(string databaseName, string nonQuery)
        {
            // Create the connection string
            string databaseConnectionString = oledbConnectionString + databaseName + ".mdb;";

            // Open the connection in a using statement so it is destroyed appropriately when exiting the using statement
            using (OleDbConnection connection = new OleDbConnection(databaseConnectionString))
            {
                connection.Open();

                // Create the command using the passed SQL statement
                using (OleDbCommand command = new OleDbCommand(nonQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static DataTable executeQuery(string databaseName, string query)
        {
            // Instantiate a data table to return the query results in
            DataTable dataTable = new DataTable();

            // Create the connection string
            string databaseConnectionString = oledbConnectionString + databaseName + ".mdb;";

            // Open the connection in a using statement so it is destroyed appropriately when exiting the using statement
            using (OleDbConnection connection = new OleDbConnection(databaseConnectionString))
            {
                connection.Open();

                // Create the command using the passed SQL query
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {

                    // Create an adapter to transfer the results into the data table
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        // Fill the DataTable with data from the query
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public static List<string> executeStringListQuery(string databaseName, string executeStringListQuerySQL)
        {
            List<string> result = new List<string>();

            // Retrieve the data table of results from the query
            DataTable dataTable = executeQuery(databaseName, executeStringListQuerySQL);

            // Transfer the results into the list of strings
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(row[0].ToString());
            }
            dataTable.Dispose();
            return result;
        }

        public static bool isValidAccount(string username, string password)
        {
            try
            {
                // Hash the password
                int passwordHash = djb2HashFunction.djb2(password);

                // SQL query to check that the user input username and password is correct by returning all records where the username and password hash value match the user input
                string checkDetailsSQL = $"SELECT * FROM UserDetailsTbl WHERE Username = '{username}' AND PasswordHash = {passwordHash}";
                DataTable matchingAccountDataTable = executeQuery("CPPMUserAccounts", checkDetailsSQL);

                // Return true if the datatable contains one matching record
                return matchingAccountDataTable.Rows.Count == 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public static void createAccount(string username, string password)
        {
            try
            {
                // Hash the password
                int passwordHash = djb2HashFunction.djb2(password);

                // SQL statement to add the details to UserDetailsTbl
                string addDetailsSQL = "INSERT INTO UserDetailsTbl (Username, PasswordHash)" +
                                        $"Values ('{username}', {passwordHash})";
                executeNonQuery("CPPMUserAccounts", addDetailsSQL);
                MessageBox.Show("Your account has been created and can be used to login.", "Success", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool createProject(string projectName, string username)
        {
            try
            {
                // Create Database
                if (File.Exists(projectName + ".mdb"))
                {
                    throw new Exception("This project already exists.");
                }
                // If the database creation failed, return that the project was not created
                if (!createDatabase(projectName)) return false;

                // Create TaskTbl
                string createTableSQL =
                    "CREATE TABLE TasksTbl (" +
                    "Name VARCHAR(100) PRIMARY KEY," +
                    "Duration INT," +
                    "NumWorkers INT," +
                    "Completed BIT)";
                executeNonQuery(projectName, createTableSQL);

                // Create DependenciesTbl
                createTableSQL =
                    "CREATE TABLE DependenciesTbl (" +
                    "PredecessorName VARCHAR(100)," +
                    "SuccessorName VARCHAR(100)," +
                    "PRIMARY KEY (PredecessorName, SuccessorName)," +
                    "FOREIGN KEY (PredecessorName) REFERENCES TasksTbl(Name)," +
                    "FOREIGN KEY (SuccessorName) REFERENCES TasksTbl(Name))";
                executeNonQuery(projectName, createTableSQL);

                // Add project to users projects
                string addProjectSQL = "INSERT INTO UserProjectsTbl(Username, ProjectName)" +
                                        $"Values ('{username}', '{projectName}')";
                executeNonQuery("CPPMUserAccounts", addProjectSQL);
                MessageBox.Show($"Project {projectName} has been created.", "Success", MessageBoxButtons.OK);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void deleteProject(string projectName)
        {
            try
            {
                // Delete database file
                File.Delete(projectName + ".mdb");
                // Delete in UserProjectsTbl
                string deleteProjectSQL = $"DELETE FROM UserProjectsTbl WHERE ProjectName = '{projectName}'";
                executeNonQuery("CPPMUserAccounts", deleteProjectSQL);
            } 
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Returns a list of all the project names belonging to a user
        public static List<string> projectNamesList(string username)
        {
            List<string> projectNames = new List<string>();
            try
            {
                // Select all projects that belong to the user
                string projectNamesSQL = $"SELECT ProjectName FROM UserProjectsTbl WHERE Username = '{username}'";

                // As a list of strings of the project names
                projectNames = executeStringListQuery("CPPMUserAccounts", projectNamesSQL);
                return projectNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return projectNames;
            }
        }

        // Returns the task details of the current project
        public static DataTable tasksData(string projectName)
        {
            // Return all data of all tasks
            string getDataSQL = "SELECT * FROM TasksTbl";
            DataTable tasksDataTable = executeQuery(projectName, getDataSQL);
            return tasksDataTable;
        }

        public static void addTask(string projectName, string name, int duration, int numWorkers)
        {
            try
            {
                // Add a record of the task with the user input data
                string addTaskSQL = "INSERT INTO TasksTbl (Name, Duration, NumWorkers, Completed)" +
                                    $"Values ('{name}', {duration}, {numWorkers}, 0)";
                executeNonQuery(projectName, addTaskSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void editTask(string projectName, string name, int newDuration, int newNumWorkers)
        {
            try
            {
                // Set the duration and the number of workers of a task to the user input data if the name of it matches the name of the to be edited task
                string editTaskSQL = $"UPDATE TasksTbl SET Duration = {newDuration}, NumWorkers = {newNumWorkers} WHERE Name = '{name}'";
                executeNonQuery(projectName, editTaskSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void deleteTask(string projectName, string name)
        {
            try
            {
                // Delete dependencies first
                // Deleting dependencies where the to be deleted task is the predecessor or successor
                string deletePredecessorSQL = $"DELETE FROM DependenciesTbl WHERE PredecessorName = '{name}' OR SuccessorName = '{name}'";
                executeNonQuery(projectName, deletePredecessorSQL);

                // Delete task from TasksTbl
                string deleteTaskSQL = $"DELETE FROM TasksTbl WHERE Name = '{name}'";
                executeNonQuery(projectName, deleteTaskSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<string> predecessorsList(string projectName, string selectedTaskName)
        {
            List<string> predecessors = new List<string>();
            try
            {
                // Return a list of the predecessor names of the selected task
                string predecessorsSQL = $"SELECT PredecessorName FROM DependenciesTbl WHERE SuccessorName = '{selectedTaskName}'";
                predecessors = executeStringListQuery(projectName, predecessorsSQL);
                return predecessors;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return predecessors;
            }

        }

        public static void deleteDependency(string projectName, string selectedTaskName, string predecessor)
        {
            try
            {
                // Delete the specific dependency 
                string deleteDependencySQL = $"DELETE FROM DependenciesTbl WHERE PredecessorName = '{predecessor}' AND SuccessorName = '{selectedTaskName}'";
                executeNonQuery(projectName, deleteDependencySQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void addDependency(string projectName, string selectedTaskName, string predecessor)
        {
            try
            {
                // Check if a cycle would be made
                if (dependenciesCycle(projectName, selectedTaskName, predecessor))
                {
                    // If a cycle would be made, reject the new dependency with an error message
                    throw new Exception("A cycle was created - check your dependencies to ensure no cycles are formed.");
                }

                // Otherwise add the dependency
                string addDependencySQL = $"INSERT INTO DependenciesTbl (PredecessorName, SuccessorName) VALUES ('{predecessor}', '{selectedTaskName}')";
                executeNonQuery(projectName, addDependencySQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool dependenciesCycle(string projectName, string selectedTaskName, string predecessor)
        {
            try
            {
                CustomDictionary<string, int> tasksToIndex = new CustomDictionary<string, int>();
                List<List<int>> adjacencyList = new List<List<int>>();

                // Map the names to the index
                string taskNamesSQL = "SELECT Name FROM TasksTbl";
                List<string> taskNames = executeStringListQuery(projectName, taskNamesSQL);
                for (int i = 0; i < taskNames.Count; i++)
                {
                    tasksToIndex.add(taskNames[i], i);
                }

                // Represent the new graph as an adjacency list
                for (int i = 0; i < tasksToIndex.keys.Count; i++)
                {
                    adjacencyList.Add(new List<int>());
                }
                string dependenciesSQL = "SELECT * FROM DependenciesTbl";
                DataTable dependenciesDataTable = executeQuery(projectName, dependenciesSQL);
                foreach (DataRow row in dependenciesDataTable.Rows)
                {
                    string pre = row["PredecessorName"].ToString();
                    string suc = row["SuccessorName"].ToString();
                    adjacencyList[tasksToIndex.getValue(pre)].Add(tasksToIndex.getValue(suc));
                }
                // Add new dependency to the graph
                adjacencyList[tasksToIndex.getValue(predecessor)].Add(tasksToIndex.getValue(selectedTaskName));
                // Start from the node that the new edge leads out of, which is the predecessor
                return dfsCycle(tasksToIndex.getValue(predecessor), ref adjacencyList);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        // dfsCycle does not require visited array as it assumes graph before adding new dependency is also acyclic so can never visit one already visited.
        // To check adding the new edge doesn't create a cycle, just run dfs from the start of the edge and check if it ever leads back to the start node.
        public static bool dfsCycle(int startNode, ref List<List<int>> adjacencyList)
        {

            // Instantiate a custom implementation of a stack to store the to be processed nodes
            LinkedListStack<int> DFSStack = new LinkedListStack<int>();
            DFSStack.push(startNode);

            // While there are still nodes unprocessed
            while (!DFSStack.isEmpty()) {
                int currentNode = DFSStack.pop();

                // Check each adjacent node and then push it to the stack to be processed next
                foreach (int successor in adjacencyList[currentNode])
                {
                    if (successor == startNode) return true; // As somehow we reached the start node again, a cycle must have formed.
                    DFSStack.push(successor);
                }
            }
            
            return false;
        }

        // Returns a CustomDictionary storing all the tasks as a mapping of Name -> TaskNode
        public static CustomDictionary<string, TaskNode> tasksDict(string projectName)
        {
            CustomDictionary<string, TaskNode> tasks = new CustomDictionary<string, TaskNode>();
            try
            {
                // Retrieve all the data from all the tasks in TasksTbl
                string tasksDataSQL = "SELECT * FROM TasksTbl";
                DataTable tasksDataTable = executeQuery(projectName, tasksDataSQL);
                foreach (DataRow row in tasksDataTable.Rows)
                {
                    // Type cast the data appropriately
                    string name = row["Name"].ToString();
                    int duration = Convert.ToInt32(row["Duration"]);
                    int numWorkers = Convert.ToInt32(row["NumWorkers"]);
                    bool completed = (bool)row["Completed"];
                    List<string> predecessorsNames = new List<string>();
                    List<string> successorsNames = new List<string>();

                    // Create a new TaskNode object to represent that task with the retrieved data
                    tasks.add(name, new TaskNode(name, duration, numWorkers, completed, predecessorsNames, successorsNames));
                }
                // Populate predecessorsNames and successorsNames in one SQL call (O(n)) to reduce bottleneck caused by a select query for each task (O(n^2))
                string dependenciesDataSQL = "SELECT * FROM DependenciesTbl";

                // DataTable containing all dependencies
                DataTable dependenciesDataTable = executeQuery(projectName, dependenciesDataSQL);
                foreach (DataRow row in dependenciesDataTable.Rows)
                {
                    string pre = row["PredecessorName"].ToString();
                    string suc = row["SuccessorName"].ToString();       
                    
                    // Add the successor in the dependency to the predecessor's successorNames list
                    tasks.getValue(pre).successorNames.Add(suc);

                    // Add the predecessor in the dependency to the successors's predecessorNames list
                    tasks.getValue(suc).predecessorNames.Add(pre);
                }
                return tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return tasks;
            }

        }

        public static DataTable completedTasks(string projectName)
        {
            DataTable completedTasksDataTable = new DataTable();
            try
            {
                // Retrieve all completed tasks
                string completedTasksSQL = "SELECT Name, Duration, NumWorkers FROM TasksTbl WHERE Completed = -1";
                completedTasksDataTable = executeQuery(projectName, completedTasksSQL);
                return completedTasksDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return completedTasksDataTable;
            }
        }

        public static DataTable incompleteTasks(string projectName)
        {
            // Instantiate a DataTable for all tasks that are not yet completed but also cannot be started yet
            DataTable incompleteTasksDataTable = new DataTable();
            try
            {
                string incompleteTasksSQL =
                    "SELECT Name, Duration, NumWorkers " + // Get all task data from tasks
                    "FROM TasksTbl t1 " +
                    "WHERE t1.Completed = 0 " + // That are not completed
                    "AND EXISTS ( " + // If there is a dependency
                        "SELECT 1 " + 
                        "FROM DependenciesTbl d " +
                        "WHERE d.SuccessorName = t1.Name " + // Where the current task is the successor
                        "AND EXISTS ( " + // And there is another task
                            "SELECT 1 " +
                            "FROM TasksTbl t2 " +
                            "WHERE t2.Name = d.PredecessorName " + // That is the predecessor
                            "AND t2.Completed = 0" + // That has not been completed
                        ")" +
                    ")";
                incompleteTasksDataTable = executeQuery(projectName, incompleteTasksSQL);
                return incompleteTasksDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return incompleteTasksDataTable;
            }
        }

        public static DataTable availableTasks(string projectName)
        {
            // Instantiate a DataTable for all tasks that are not yet completed but can be started 
            DataTable availableTasksDataTable = new DataTable();
            try
            {
                string availableTasksSQL =
                    "SELECT Name, Duration, NumWorkers " +  // Get all task data from tasks
                    "FROM TasksTbl t1 " +
                    "WHERE t1.Completed = 0 " +  // That are not completed
                    "AND NOT EXISTS ( " +  // If there are no dependencies
                        "SELECT 1 " +
                        "FROM DependenciesTbl d " +
                        "WHERE d.SuccessorName = t1.Name " +  // Where the current task is the successor
                        "AND EXISTS ( " +  // And there is another task
                            "SELECT 1 " +
                            "FROM TasksTbl t2 " +
                            "WHERE t2.Name = d.PredecessorName " +  // That is the predecessor
                            "AND t2.Completed = 0" +  // That has not been completed
                        ")" +
                    ")";
                availableTasksDataTable = executeQuery(projectName, availableTasksSQL);
                return availableTasksDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return availableTasksDataTable;
            }
        }

        public static void markTaskCompleted(string projectName, string taskName)
        {
            try
            {
                // Update a uncompleted task to completed
                string markTaskCompletedSQL = $"UPDATE TasksTbl SET Completed = -1 WHERE Name = '{taskName}'";
                executeNonQuery(projectName, markTaskCompletedSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void markTaskIncomplete(string projectName, string taskName)
        {
            try
            {
                // Update a completed task to uncompleted
                string markTaskIncompleteSQL = $"UPDATE TasksTbl SET Completed = 0 WHERE Name = '{taskName}'";
                executeNonQuery(projectName, markTaskIncompleteSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

