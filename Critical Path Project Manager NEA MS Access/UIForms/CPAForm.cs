﻿using Critical_Path_Project_Manager_NEA_MS_Access.Functions;
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
        private CustomDictionary<string, TaskNode> tasks;
        private List<string> sortedTaskNames;
        public CPAForm(string projectName, string username)
        {
            InitializeComponent();

            // Display the username and project name at the top of the window
            this.projectName = projectName;
            this.username = username;
            this.Text += " - " + projectName + " - " + username;

            // Initialise the TaskGraph, which also runs all of the Critical Path Analysis
            taskGraph = new TaskGraph(projectName);

            // Get the CPA results from the TaskGraph in a custom dictionary of TaskNode objects
            tasks = taskGraph.getTasks();

            // Display the overall project CPA results
            displayCPAResults();

            // Display the individual task CPA results
            displayTasks();
        }

        private void displayCPAResults()
        {
            // Get the minimum possible duration of the project
            TotalDurationTextBox.Text = taskGraph.getTotalDuration().ToString();

            // Get the critical path
            List<string> criticalPath = taskGraph.getCriticalPath();

            // Display it with arrows inbetween each critical task
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
            // Initialise a DataTable to store every task's data
            DataTable tasksDataTable = new DataTable();
            tasksDataTable.Columns.Add("Name", typeof(string));
            tasksDataTable.Columns.Add("Duration (days)", typeof(int));
            tasksDataTable.Columns.Add("NumWorkers", typeof(int));
            tasksDataTable.Columns.Add("Earliest Start", typeof(int));
            tasksDataTable.Columns.Add("Earliest Finish", typeof(int));
            tasksDataTable.Columns.Add("Latest Start", typeof(int));
            tasksDataTable.Columns.Add("Latest Finish", typeof(int));
            tasksDataTable.Columns.Add("Total Float", typeof(int));
            tasksDataTable.Columns.Add("Independent Float", typeof(int));
            tasksDataTable.Columns.Add("Interfering Float", typeof(int));
            tasksDataTable.Columns.Add("Completed", typeof(bool));

            // Create taskNames list
            List<string> taskNames = tasks.keys.ToList<string>();

            // Sort by merge sort with Earliest Start Time of the task as the comparison value
            sortedTaskNames = MergeSortTasks.sort(taskNames, tasks);

            // Display tasks sorted by Earliest Start Time as default
            foreach (string taskName in sortedTaskNames)
            {
                TaskNode task = tasks.getValue(taskName);
                if (task.getName() == "Start" || task.getName() == "End") continue;
                DataRow row = tasksDataTable.NewRow();
                row["Name"] = task.getName();
                row["Duration (days)"] = task.getDuration();
                row["NumWorkers"] = task.getNumWorkers();
                row["Earliest Start"] = task.getEarliestStartTime();
                row["Earliest Finish"] = task.getEarliestFinishTime();
                row["Latest Start"] = task.getLatestStartTime();
                row["Latest Finish"] = task.getLatestFinishTime();
                row["Total Float"] = task.getTotalFloat();
                row["Independent Float"] = task.getIndependentFloat();
                row["Interfering Float"] = task.getInterferingFloat();
                row["Completed"] = task.getCompleted();

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
