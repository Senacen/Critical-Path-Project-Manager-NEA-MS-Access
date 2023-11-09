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
        string projectName;
        string username;
        public ImportProjectForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void BackToLoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            string importString = ImportTextBox.Text;
            if (importString == "") return;
            importString = StringEncryptionFunction.decrypt(importString);
            MessageBox.Show(importString);
            //return;
            ImportTextBox.Text = "";
            // Split the text by new line or carriage return characters
            List<string> importList = importString.Split(';').ToList();

            // Extract the project name, and create the new project - if this fails, exit the procedure
            projectName = importList[0];
            if (!DatabaseFunctions.createProject(projectName, username)) return;
            try
            {
                List<string> taskNames = new List<string>();
                List<List<string>> predecessorNamesLists = new List<List<string>>();

                int index = 2;
                for (int i = 0; i < int.Parse(importList[1]); i++)
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

                EditProjectForm editProjectForm = new EditProjectForm(projectName, username);
                editProjectForm.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                DatabaseFunctions.deleteProject(projectName); // Get rid of everything done so far before the error
                File.Delete(projectName + ".mdb");
                MessageBox.Show("An error occurred in importing the data, it is corrupted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
