using Critical_Path_Project_Manager_NEA_MS_Access.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    public partial class EditProjectForm : Form
    {
        private string projectName, username;
        public EditProjectForm(string projectName, string username)
        {
            InitializeComponent();
            this.projectName = projectName;
            this.username = username;
            this.Text += " - " + projectName + " - " + username;
            TasksDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            updateTasksDataGrid();
            TasksDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TasksDataGrid.SelectionChanged += tasksDataGrid_SelectionChanged;
        }
        private void updateTasksDataGrid()
        {
            TasksDataGrid.DataSource = DatabaseFunctions.tasksData(projectName);
            
        }

       

        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = NameTextBox.Text.Trim();
                if (name == "Start" || name == "End" || name.Contains(';'))
                {
                    throw new Exception("Task cannot be named after a reserved keyword: Start, End, or contain the reserved character ';'");
                }
                int duration = (int) DurationNumeric.Value;
                int numWorkers = (int) NumWorkersNumeric.Value;
                DatabaseFunctions.addTask(projectName, name, duration, numWorkers);
                updateTasksDataGrid();
                NameTextBox.Text = "";
                // Refresh Update Dependencies Checked ListBox to include added task
                if (TasksDataGrid.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedTask = TasksDataGrid.SelectedRows[0];
                    refreshUpdateDependenciesCheckedListBox(selectedTask.Cells["Name"].Value.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void EditTaskButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TasksDataGrid.SelectedRows.Count == 0) throw new Exception("No row selected to edit.");
                // Name cannot be changed due to issue with cascading - SQL Server flags infinite cascade loop when trying to cascade on update and delete for DependenciesTbl
                string name = EditNameTextBox.Text;
                int newDuration = (int)EditDurationNumeric.Value;
                int newNumWorkers = (int)EditNumWorkersNumeric.Value;
                DatabaseFunctions.editTask(projectName, name, newDuration, newNumWorkers);
                updateTasksDataGrid();


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteTaskButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TasksDataGrid.SelectedRows.Count == 0) throw new Exception("No row selected to edit.");
                string name = EditNameTextBox.Text;
                DialogResult result = MessageBox.Show("Are you sure you want to delete this task and all dependencies with it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                DatabaseFunctions.deleteTask(projectName, name);
                updateTasksDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tasksDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (TasksDataGrid.SelectedRows.Count > 0)
            {
                // Change contents of Edit Task Group Box
                DataGridViewRow selectedTask = TasksDataGrid.SelectedRows[0];
                EditNameTextBox.Text = selectedTask.Cells["Name"].Value.ToString();
                EditDurationNumeric.Value = (int)selectedTask.Cells["Duration"].Value;
                EditNumWorkersNumeric.Value = (int)selectedTask.Cells["NumWorkers"].Value;

                // Change contents of Update Dependencies Checked ListBox
                refreshUpdateDependenciesCheckedListBox(EditNameTextBox.Text);
            }
        }

        private void refreshUpdateDependenciesCheckedListBox(string selectedTaskName)
        {
            UpdateDependenciesCheckedListBox.Items.Clear();
            foreach (DataGridViewRow row in TasksDataGrid.Rows)
            {
                string name = row.Cells["Name"].Value.ToString();
                if (name == selectedTaskName) continue;
                UpdateDependenciesCheckedListBox.Items.Add(name);
            }
            foreach (string predecessor in DatabaseFunctions.predecessorsList(projectName, selectedTaskName))
            {
                int index = UpdateDependenciesCheckedListBox.Items.IndexOf(predecessor);
                if (index >= 0)
                {
                    UpdateDependenciesCheckedListBox.SetItemChecked(index, true);
                }

            }
        }

        private void UpdateDependenciesCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TasksDataGrid.SelectedRows.Count == 0) throw new Exception("No task selected to update dependencies of.");
                string selectedTaskName = EditNameTextBox.Text;
                int changedIndex = UpdateDependenciesCheckedListBox.SelectedIndex;
                string predecessor = UpdateDependenciesCheckedListBox.Items[changedIndex].ToString();
                if (UpdateDependenciesCheckedListBox.GetItemCheckState(changedIndex) == CheckState.Checked)
                {
                    DatabaseFunctions.addDependency(projectName, selectedTaskName, predecessor);
                }
                else
                {
                    DatabaseFunctions.deleteDependency(projectName, selectedTaskName, predecessor);
                }

                refreshUpdateDependenciesCheckedListBox(selectedTaskName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CPAButton_Click(object sender, EventArgs e)
        {
            CPAForm cpaForm = new CPAForm(projectName, username);
            cpaForm.Show();
            this.Close();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            LoadProjectForm loadProjectForm = new LoadProjectForm(username);
            loadProjectForm.Show();
            this.Close();
        }

        private void ExportProjectButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, TaskNode> tasks = DatabaseFunctions.tasksDict(projectName); // Retrieve all the task data
            // Semicolon is reserved so cannot be in task names, this custom serialisation protocol will use semicolon as delimiters
            string exportString = "";
            // Output how many tasks there are
            exportString += tasks.Count.ToString() + ';';
            // Add task data
            foreach (TaskNode task in tasks.Values)
            {
                exportString += task.getName() + ';';
                exportString += task.getDuration().ToString() + ';';
                exportString += task.getNumWorkers().ToString() + ';';
                exportString += task.getCompleted().ToString() + ';';
                // Output how many successors it has
                exportString += task.getPredecessorNames().Count().ToString() + ';';
                foreach (string predecessorName in task.getPredecessorNames())
                {
                    exportString += predecessorName + ';';
                }
            }
            string encryptedExportString = StringEncryptionFunction.encrypt(exportString);
            string encryptedExportStringWithCheckSum = StringEncryptionFunction.addCheckSum(encryptedExportString);
            string encryptedExportStringWithCheckSumAndSquareParantheses = StringEncryptionFunction.addSquareParantheses(encryptedExportStringWithCheckSum);
            Clipboard.SetText(encryptedExportStringWithCheckSumAndSquareParantheses);
            MessageBox.Show("The exported data has been copied to your clipboard and encrypted", "Successful Export", MessageBoxButtons.OK);
        }



        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}


