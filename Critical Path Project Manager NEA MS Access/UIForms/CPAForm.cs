using Critical_Path_Project_Manager_NEA_MS_Access.Functions;
using Critical_Path_Project_Manager_NEA_MS_Access.UIForms;
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
        private TaskGraph taskGraph;
        private Dictionary<string, TaskNode> tasks;
        private List<string> sortedTaskNames;
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

        private void displayCPAResults()
        {
            TotalDurationTextBox.Text = taskGraph.getTotalDuration().ToString();

            List<string> criticalPath = taskGraph.getCriticalPath();
            StringBuilder criticalPathStringBuilder = new StringBuilder();
            for (int i = 0; i < criticalPath.Count(); i++)
            {
                string criticalTask = criticalPath[i];
                if (i != 0)
                {
                    criticalPathStringBuilder.AppendLine();
                    criticalPathStringBuilder.AppendLine("↓");
                }
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
            tasksDataTable.Columns.Add("EF", typeof(int));
            tasksDataTable.Columns.Add("LS", typeof(int));
            tasksDataTable.Columns.Add("LF", typeof(int));
            tasksDataTable.Columns.Add("Total Float", typeof(int));
            tasksDataTable.Columns.Add("Ind. Float", typeof(int));
            tasksDataTable.Columns.Add("Int. Float", typeof(int));

            // Display tasks sorted by Earliest Start Time as default

            // Create taskNames list
            List<string> taskNames = tasks.Keys.ToList<string>();

            // Sort by merge sort with Earliest Start Time of the task as the comparison value
            sortedTaskNames = MergeSortTasks.sort(taskNames, tasks);

            foreach (string taskName in sortedTaskNames)
            {
                TaskNode task = tasks[taskName];
                if (task.getName() == "Start" || task.getName() == "End") continue;
                DataRow row = tasksDataTable.NewRow();
                row["Name"] = task.getName();
                row["Duration"] = task.getDuration();
                row["NumWorkers"] = task.getNumWorkers();
                row["ES"] = task.getEarliestStartTime();
                row["EF"] = task.getEarliestFinishTime();
                row["LS"] = task.getLatestStartTime();
                row["LF"] = task.getLatestFinishTime();
                row["Total Float"] = task.getTotalFloat();
                row["Ind. Float"] = task.getIndependentFloat();
                row["Int. Float"] = task.getInterferingFloat();

                tasksDataTable.Rows.Add(row);
            }


            // Bind the DataTable to the DataGridView
            CPADataGrid.DataSource = tasksDataTable;
        }

        private void BackToEditProjectButton_Click(object sender, EventArgs e)
        {
            EditProjectForm editProjectForm = new EditProjectForm(projectName, username);
            editProjectForm.Show();
            this.Close();
        }

        private void ProjectTrackerButton_Click(object sender, EventArgs e)
        {
            ProjectTrackerForm projectTrackerForm = new ProjectTrackerForm(projectName, username);
            projectTrackerForm.Show();
            this.Close();
        }

        private void DrawCascadeDiagramButton_Click(object sender, EventArgs e)
        {
            CascadeDiagramForm cascadeDiagramForm = new CascadeDiagramForm(sortedTaskNames, tasks);
            cascadeDiagramForm.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
