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
    public partial class CPAForm : Form
    {
        private string projectName, username;
        TaskGraph taskGraph;
        Dictionary<string, TaskNode> tasks;
        public CPAForm(string projectName, string username)
        {
            InitializeComponent();
            this.projectName = projectName;
            this.username = username;
            this.Text += " - " + projectName + " - " + username;
            taskGraph = new TaskGraph(projectName);
            tasks = taskGraph.getTasks();
            displayCPAResults();
            displayTasks();


        }

        private void displayCPAResults ()
        {
            TotalDurationTextBox.Text = taskGraph.getTotalDuration().ToString();

            List<string> criticalPath = taskGraph.getCriticalPath();
            StringBuilder criticalPathStringBuilder = new StringBuilder();
            foreach (string criticalTask in criticalPath)
            {
                criticalPathStringBuilder.AppendLine();
                criticalPathStringBuilder.AppendLine(criticalTask);
            }
            CPTextBox.Text = criticalPathStringBuilder.ToString();
        }

        private void displayTasks()
        {
            DataTable tasksDataTable = new DataTable();
            tasksDataTable.Columns.Add("Name", typeof(string));
            tasksDataTable.Columns.Add("Duration", typeof(int));
            tasksDataTable.Columns.Add("NumWorkers", typeof(int));
            tasksDataTable.Columns.Add("ES", typeof(int));
            tasksDataTable.Columns.Add("LS", typeof(int));
            tasksDataTable.Columns.Add("EF", typeof(int));
            tasksDataTable.Columns.Add("LF", typeof(int));
            tasksDataTable.Columns.Add("Total Float", typeof(int));
            tasksDataTable.Columns.Add("Ind Float", typeof(int));
            tasksDataTable.Columns.Add("Int Float", typeof(int));

            foreach (TaskNode task in tasks.Values)
            {
                if (task.name == "Start" || task.name == "End") continue;
                DataRow row = tasksDataTable.NewRow();
                row["Name"] = task.name;
                row["Duration"] = task.duration;
                row["NumWorkers"] = task.numWorkers;
                row["ES"] = task.earliestStartTime;
                row["LS"] = task.latestStartTime;
                row["EF"] = task.earliestFinishTime;
                row["LF"] = task.latestFinishTime;
                row["Total Float"] = task.totalFloat;
                row["Ind Float"] = task.independentFloat;
                row["Int Float"] = task.interferingFloat;

                tasksDataTable.Rows.Add(row);
            }

            // Bind the DataTable to the DataGridView
            CPADataGrid.DataSource = tasksDataTable;
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void BackToEditProjectButton_Click(object sender, EventArgs e)
        {
            EditProjectForm editProjectForm = new EditProjectForm(projectName, username);
            editProjectForm.Show();
            this.Close();
        }

    }
}
