using Critical_Path_Project_Manager_NEA_MS_Access.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Critical_Path_Project_Manager_NEA_MS_Access.UIForms
{
    public partial class ImportProjectForm : Form
    {
        string username;
        public ImportProjectForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            string importStringWithCheckSumAndSquareParantheses = ImportTextBox.Text;
            if (importStringWithCheckSumAndSquareParantheses.Length < 4)
            {
                MessageBox.Show("Import data is too short", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Remove bounding square parentheses
            string importStringWithCheckSum = StringEncryptionFunction.removeSquareParantheses(importStringWithCheckSumAndSquareParantheses);
            // Check the data has not been corrupted
            if (!StringEncryptionFunction.checkCheckSum(importStringWithCheckSum))
            {
                MessageBox.Show("Data imported failed check sum - it is corrupted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Decrypt the data
            string importString = StringEncryptionFunction.decrypt(importStringWithCheckSum.Substring(1, importStringWithCheckSum.Length - 2));
            ImportTextBox.Text = "";

            // Try and create new project
            string projectName = ImportProjectNameTextBox.Text;
            ImportProjectNameTextBox.Text = "";
            if (!DatabaseFunctions.createProject(projectName, username)) return;

            // Import the data
            if (!importData(projectName, importString)) // If there was an error importing the data
            {
                DatabaseFunctions.deleteProject(projectName); // Get rid of everything done so far before the error
                File.Delete(projectName + ".mdb");
                MessageBox.Show("An error occurred in importing the data - it is corrupted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If all successful, go to EditProjectForm
            EditProjectForm editProjectForm = new EditProjectForm(projectName, username);
            editProjectForm.Show();
            this.Close();
        }

        private bool importData(string projectName, string importString)
        {
            // Split the text by new line or carriage return characters
            List<string> importList = importString.Split(';').ToList();

            
            try
            {
                List<string> taskNames = new List<string>();
                List<List<string>> predecessorNamesLists = new List<List<string>>();

                int index = 1;
                for (int i = 0; i < int.Parse(importList[0]); i++)
                {
                    // Retrieve task data and create task
                    string name = importList[index++];
                    int duration = int.Parse(importList[index++]);
                    int numWorkers = int.Parse(importList[index++]);
                    taskNames.Add(name);
                    DatabaseFunctions.addTask(projectName, name, duration, numWorkers);

                    // Retrieve task successors
                    int numPredecessors = int.Parse(importList[index++]);
                    List<string> currentPredecessorNames = new List<string>();
                    for (int predecessors = 0; predecessors < numPredecessors; predecessors++)
                    {
                        currentPredecessorNames.Add(importList[index++]);
                    }
                    predecessorNamesLists.Add(currentPredecessorNames);
                }

                // Add dependencies now all tasks have been added
                for (int i = 0; i < taskNames.Count; i++)
                {
                    foreach (string predecessor in predecessorNamesLists[i])
                    {
                        DatabaseFunctions.addDependency(projectName, taskNames[i], predecessor);
                    }
                }

                // Return that the data was imported successfully
                return true;
            }
            catch (Exception)
            {
                // If an error occurred, return that the data was not imported successfully
                return false;
            }
        }
        private void BackToLoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
