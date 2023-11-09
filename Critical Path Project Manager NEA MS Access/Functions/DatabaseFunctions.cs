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

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    static internal class DatabaseFunctions
    {
        private static string oledbConnectionString = @"Provider=Microsoft Jet 4.0 OLE DB Provider;Data Source = ";
        public static void createDatabase(string databaseName)
        {
            CatalogClass cat = new CatalogClass();
            cat.Create(oledbConnectionString + databaseName + ".mdb;");
            cat = null;
        }

        public static void checkUserAccountsDatabaseExists()
        {
            if (!File.Exists("CPPMUserAccounts.mdb"))
            {
                createDatabase("CPPMUserAccounts");

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
            // Check name is not a SQL Server reserved keyword
            using (StreamReader SR = new StreamReader("SQLServerReservedKeywords.txt"))
            {
                string keyword;
                while ((keyword = SR.ReadLine()) != null)
                {
                    if (name.ToUpper() == keyword.Replace("\n", "")) return false;
                }
            }
            return true;
        }

        private static void executeNonQuery(string databaseName, string nonQuery)
        {
            string databaseConnectionString = oledbConnectionString + databaseName + ".mdb;";
            using (OleDbConnection connection = new OleDbConnection(databaseConnectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(nonQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static DataTable executeQuery(string databaseName, string query)
        {
            DataTable dataTable = new DataTable();
            string databaseConnectionString = oledbConnectionString + databaseName + ".mdb;";
            using (OleDbConnection connection = new OleDbConnection(databaseConnectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
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
            DataTable dataTable = executeQuery(databaseName, executeStringListQuerySQL);
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
                int passwordHash = djb2HashFunction.djb2(password);
                string checkDetailsSQL = $"SELECT * FROM UserDetailsTbl WHERE Username = '{username}' AND PasswordHash = {passwordHash}";
                DataTable matchingAccountDataTable = executeQuery("CPPMUserAccounts", checkDetailsSQL);
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
                int passwordHash = djb2HashFunction.djb2(password);

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
                createDatabase(projectName);

                // Create TaskTbl
                string createTableSQL =
                    "CREATE TABLE TasksTbl (" +
                    "Name VARCHAR(100) PRIMARY KEY," +
                    "Duration INT," +
                    "NumWorkers INT)";
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
                MessageBox.Show($"Database {projectName} has been created.", "Success", MessageBoxButtons.OK);
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
                string projectNamesSQL = $"SELECT ProjectName FROM UserProjectsTbl WHERE Username = '{username}'";
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
            string getDataSQL = "SELECT * FROM TasksTbl";
            DataTable tasksDataTable = executeQuery(projectName, getDataSQL);
            return tasksDataTable;
        }

        public static void addTask(string projectName, string name, int duration, int numWorkers)
        {
            try
            {
                string addTaskSQL = "INSERT INTO TasksTbl (Name, Duration, NumWorkers)" +
                                    $"Values ('{name}', {duration}, {numWorkers})";
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

                // Deleting dependencies where the to be deleted task is the predecessor
                string deletePredecessorSQL = $"DELETE FROM DependenciesTbl WHERE PredecessorName = '{name}'";
                executeNonQuery(projectName, deletePredecessorSQL);

                // Deleting dependencies where the to be deleted task is the successor
                string deleteSuccessorSQL = $"DELETE FROM DependenciesTbl WHERE SuccessorName = '{name}'";
                executeNonQuery(projectName, deleteSuccessorSQL);

                // Delete task
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
                    throw new Exception("A cycle was created - check your dependencies to ensure no cycles are formed.");
                }
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
                Dictionary<string, int> tasksToIndex = new Dictionary<string, int>();
                List<List<int>> adjacencyList = new List<List<int>>();

                // Map the names to the index
                string taskNamesSQL = "SELECT Name FROM TasksTbl";
                List<string> taskNames = executeStringListQuery(projectName, taskNamesSQL);
                for (int i = 0; i < taskNames.Count; i++)
                {
                    tasksToIndex[taskNames[i]] = i;
                }

                // Represent the new graph as an adjacency list
                for (int i = 0; i < tasksToIndex.Count; i++)
                {
                    adjacencyList.Add(new List<int>());
                }
                string dependenciesSQL = "SELECT * FROM DependenciesTbl";
                DataTable dependenciesDataTable = executeQuery(projectName, dependenciesSQL);
                foreach (DataRow row in dependenciesDataTable.Rows)
                {
                    string pre = row["PredecessorName"].ToString();
                    string suc = row["SuccessorName"].ToString();
                    adjacencyList[tasksToIndex[pre]].Add(tasksToIndex[suc]);
                }
                // Add new dependency to the graph
                adjacencyList[tasksToIndex[predecessor]].Add(tasksToIndex[selectedTaskName]);
                // Start from the node that the new edge leads out of, which is the predecessor
                return dfsCycle(tasksToIndex[predecessor], ref adjacencyList);

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
            LinkedListStack<int> DFSStack = new LinkedListStack<int>();
            DFSStack.push(startNode);
            while (!DFSStack.isEmpty()) {
                int currentNode = DFSStack.pop();
                foreach (int successor in adjacencyList[currentNode])
                {
                    if (successor == startNode) return true; // As somehow we reached the start node again, a cycle must have formed.
                    DFSStack.push(successor);
                }
            }
            
            return false;
        }

        // Returns a dictionary storing all the tasks as a mapping of Name -> TaskNode
        public static Dictionary<string, TaskNode> tasksDict(string projectName)
        {
            Dictionary<string, TaskNode> tasks = new Dictionary<string, TaskNode>();
            try
            {
                string tasksDataSQL = "SELECT * FROM TasksTbl";
                DataTable tasksDataTable = executeQuery(projectName, tasksDataSQL);
                foreach (DataRow row in tasksDataTable.Rows)
                {
                    string name = row["Name"].ToString();
                    int duration = Convert.ToInt32(row["Duration"]);
                    int numWorkers = Convert.ToInt32(row["NumWorkers"]);
                    List<string> predecessorsNames = new List<string>();
                    List<string> successorsNames = new List<string>();
                    tasks[name] = new TaskNode(name, duration, numWorkers, predecessorsNames, successorsNames);
                }
                // Populate predecessorsNames and successorsNames in one SQL call to reduce bottleneck;
                string dependenciesDataSQL = "SELECT * FROM DependenciesTbl";
                DataTable dependenciesDataTable = executeQuery(projectName, dependenciesDataSQL);
                foreach (DataRow row in dependenciesDataTable.Rows)
                {
                    string pre = row["PredecessorName"].ToString();
                    string suc = row["SuccessorName"].ToString();                   
                    tasks[pre].successorNames.Add(suc);
                    tasks[suc].predecessorNames.Add(pre);
                }
                return tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return tasks;
            }

        }
    }
}

