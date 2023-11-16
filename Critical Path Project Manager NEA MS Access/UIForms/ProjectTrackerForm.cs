using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    public partial class ProjectTrackerForm : Form
    {
        private string projectName, username;

      
        public ProjectTrackerForm(string projectName, string username)
        {
            InitializeComponent();
            this.projectName = projectName;
            this.username = username;
            this.Text += " - " + projectName + " - " + username;
            CompletedDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            IncompleteDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AvailableDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CompletedDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            IncompleteDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AvailableDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            updateAllDataGrids();
        }

        private void updateAllDataGrids()
        {
            updateCompletedDataGrid();
            updateIncompleteDataGrid();
        }

        private void updateCompletedDataGrid()
        {
            CompletedDataGrid.DataSource = DatabaseFunctions.completedTasks(projectName);
        }

        private void updateIncompleteDataGrid()
        {
            IncompleteDataGrid.DataSource = DatabaseFunctions.incompleteTasks(projectName);
        }
        private void BackToCPAFormButton_Click(object sender, EventArgs e)
        {
            CPAForm cpaForm = new CPAForm(projectName, username);
            cpaForm.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
