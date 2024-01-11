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
            
            // Display the username and project name at the top of the window
            this.projectName = projectName;
            this.username = username;
            this.Text += " - " + projectName + " - " + username;

            // Set different properties I want in the TasksDataGrid
            TasksDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; 
            TasksDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            // Subscribe the custom shown event handler to the default shown event 
            this.Shown += EditProjectForm_Shown;

            // Subscribe the custom selection changed event handler to the default selection changed event
            TasksDataGrid.SelectionChanged += tasksDataGrid_SelectionChanged;

            // Refresh the tasks
            updateTasksDataGrid();
        }

        // Update tasks data grid when no row was previously selected
        // So upon load or when a task has just been deleted
        private void updateTasksDataGrid()
        {
            // Refresh TasksDataGrid by rebinding the data source and calling tasksData() again
            TasksDataGrid.DataSource = DatabaseFunctions.tasksData(projectName);

            // Refreshing dependencies checked list box when start up or task is deleted if a row exists
            if (TasksDataGrid.Rows.Count > 0)
            {
                // As top row is selected by default when rebinding, display top row's dependencies checked list box
                DataGridViewRow selectedTask = TasksDataGrid.Rows[0];
                string selectedName = selectedTask.Cells["Name"].Value.ToString();
                refreshUpdateDependenciesCheckedListBox(selectedName);
            }
        }

        // Overloaded update tasks data grid for when a row should stay selected after
        // Like when adding a task (select the just added task) or editing a task (select that edited task)
        private void updateTasksDataGrid(string selectedTaskName)
        {
            // Refresh TasksDataGrid by rebinding the data source and calling tasksData() again
            TasksDataGrid.DataSource = DatabaseFunctions.tasksData(projectName);

            // Select the task passed in the argument and deselect all other rows
            foreach (DataGridViewRow row in TasksDataGrid.Rows)
            {
                if (row.Cells["Name"].Value.ToString() == selectedTaskName)
                {
                    row.Selected = true;
                    continue;
                }
                row.Selected = false;
            }
        }

        // Event handler to refresh the top row's dependencies checked list box upon showing the form
        private void EditProjectForm_Shown(object sender, EventArgs e)
        {
            if (TasksDataGrid.Rows.Count > 0)
            {
                DataGridViewRow selectedTask = TasksDataGrid.Rows[0];
                string selectedName = selectedTask.Cells["Name"].Value.ToString();
                refreshUpdateDependenciesCheckedListBox(selectedName);
            }
        }
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Take the user input
                string name = NameTextBox.Text.Trim();

                // Check that the task name is not reserved for dummy nodes in CPA, or contains the semicolon delimiter used in serialisation
                if (name == "Start" || name == "End" || name.Contains(';'))
                {
                    throw new Exception("Task cannot be named after a reserved keyword: Start, End, or contain the reserved character ';'");
                }
                int duration = (int) DurationNumeric.Value;
                int numWorkers = (int) NumWorkersNumeric.Value;

                // Add the task to the database
                DatabaseFunctions.addTask(projectName, name, duration, numWorkers);

                // Refresh the tasks while selecting the just added task
                updateTasksDataGrid(name);
                NameTextBox.Text = "";
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
                // Check there is a task selected to edit
                if (TasksDataGrid.SelectedRows.Count == 0) throw new Exception("No row selected to edit.");

                // Note: Name cannot be changed due to issue with cascading - SQL Server flags infinite cascade loop when trying to cascade on update and delete for DependenciesTbl

                // Take in user input
                string name = EditNameTextBox.Text;
                int newDuration = (int)EditDurationNumeric.Value;
                int newNumWorkers = (int)EditNumWorkersNumeric.Value;

                // Edit the task
                DatabaseFunctions.editTask(projectName, name, newDuration, newNumWorkers);

                // Update the tasks data grid while keeping the currently selected row selected
                updateTasksDataGrid(name);
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
                //Check there is a task selected to delete
                if (TasksDataGrid.SelectedRows.Count == 0) throw new Exception("No row selected to delete.");
                string name = EditNameTextBox.Text;

                // Confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete this task and all dependencies with it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If no, exit
                if (result == DialogResult.No) return;

                // If yes, delete task
                DatabaseFunctions.deleteTask(projectName, name);

                // Update tasks data grid without a specified row to select
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
            // Clear the current contents
            UpdateDependenciesCheckedListBox.Items.Clear();

            // Iterate over every row
            foreach (DataGridViewRow row in TasksDataGrid.Rows)
            {
                // Add the names of all other tasks to the UpdateDependenciesCheckedListBox if they are not the currently selected task
                string name = row.Cells["Name"].Value.ToString();
                if (name == selectedTaskName) continue;
                UpdateDependenciesCheckedListBox.Items.Add(name);
            }

            // Iterate over every currently stored predecessor of the currently selected task
            foreach (string predecessor in DatabaseFunctions.predecessorsList(projectName, selectedTaskName))
            {
                // Mark them as already checked in the checked list box, as that dependency is already stored
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
                // Check there is a task selected to update the dependencies of
                if (TasksDataGrid.SelectedRows.Count == 0) throw new Exception("No task selected to update dependencies of.");
                string selectedTaskName = EditNameTextBox.Text;
                int changedIndex = UpdateDependenciesCheckedListBox.SelectedIndex;
                string predecessor = UpdateDependenciesCheckedListBox.Items[changedIndex].ToString();

                // If a dependency was ticked, add a dependency
                if (UpdateDependenciesCheckedListBox.GetItemCheckState(changedIndex) == CheckState.Checked)
                {
                    DatabaseFunctions.addDependency(projectName, selectedTaskName, predecessor);
                }
                else // If a dependency was unticked, delete the dependency
                {
                    DatabaseFunctions.deleteDependency(projectName, selectedTaskName, predecessor);
                }

                // Refresh the new dependencies
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
            CustomDictionary<string, TaskNode> tasks = DatabaseFunctions.tasksDict(projectName); // Retrieve all the task data

            // Semicolon is reserved so cannot be in task names, this custom serialisation protocol will use semicolon as delimiters
            string exportString = "";

            // Output how many tasks there are
            exportString += tasks.keys.Count.ToString() + ';';

            // Add task data
            foreach (TaskNode task in tasks.values)
            {
                exportString += task.getName() + ';';
                exportString += task.getDuration().ToString() + ';';
                exportString += task.getNumWorkers().ToString() + ';';
                exportString += task.getCompleted().ToString() + ';';

                // Output how many successors it has
                exportString += task.getPredecessorNames().Count().ToString() + ';';

                // Add the list of successors
                foreach (string predecessorName in task.getPredecessorNames())
                {
                    exportString += predecessorName + ';';
                }
            }
            
            // Encrypt the data
            string encryptedExportString = ExportProjectFunctions.encrypt(exportString);

            // Add a checksum
            string encryptedExportStringWithCheckSum = ExportProjectFunctions.addCheckSum(encryptedExportString);

            // Add bounding square parantheses
            string encryptedExportStringWithCheckSumAndSquareParentheses = ExportProjectFunctions.addSquareParantheses(encryptedExportStringWithCheckSum);
            Clipboard.SetText(encryptedExportStringWithCheckSumAndSquareParentheses);
            MessageBox.Show("The exported data has been copied to your clipboard and encrypted", "Successful Export", MessageBoxButtons.OK);
        }



        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}


