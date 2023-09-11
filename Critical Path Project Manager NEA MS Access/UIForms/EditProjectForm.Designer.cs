using System.Drawing;
using System.Windows.Forms;
namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    partial class EditProjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExitButton = new System.Windows.Forms.Button();
            this.TasksDataGrid = new System.Windows.Forms.DataGridView();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.NumWorkersLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DurationTextBox = new System.Windows.Forms.TextBox();
            this.NumWorkersTextBox = new System.Windows.Forms.TextBox();
            this.AddTaskGroupBox = new System.Windows.Forms.GroupBox();
            this.EditTaskGroupBox = new System.Windows.Forms.GroupBox();
            this.EditNumWorkersTextBox = new System.Windows.Forms.TextBox();
            this.DeleteTaskButton = new System.Windows.Forms.Button();
            this.EditDurationTextBox = new System.Windows.Forms.TextBox();
            this.EditNameTextBox = new System.Windows.Forms.TextBox();
            this.EditNumWorkersLabel = new System.Windows.Forms.Label();
            this.EditDurationLabel = new System.Windows.Forms.Label();
            this.EditNameLabel = new System.Windows.Forms.Label();
            this.EditTaskButton = new System.Windows.Forms.Button();
            this.UpdateDependenciesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.UpdateDependenciesGroupBox = new System.Windows.Forms.GroupBox();
            this.DependenciesInfoTextBox = new System.Windows.Forms.TextBox();
            this.CPAButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGrid)).BeginInit();
            this.AddTaskGroupBox.SuspendLayout();
            this.EditTaskGroupBox.SuspendLayout();
            this.UpdateDependenciesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(991, 10);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(64, 24);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // TasksDataGrid
            // 
            this.TasksDataGrid.AllowUserToAddRows = false;
            this.TasksDataGrid.AllowUserToDeleteRows = false;
            this.TasksDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TasksDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TasksDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksDataGrid.Location = new System.Drawing.Point(585, 10);
            this.TasksDataGrid.Name = "TasksDataGrid";
            this.TasksDataGrid.ReadOnly = true;
            this.TasksDataGrid.RowTemplate.Height = 25;
            this.TasksDataGrid.Size = new System.Drawing.Size(401, 603);
            this.TasksDataGrid.TabIndex = 1;
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Location = new System.Drawing.Point(71, 189);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(64, 31);
            this.AddTaskButton.TabIndex = 2;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(82, 34);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Name";
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(82, 80);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(47, 13);
            this.DurationLabel.TabIndex = 4;
            this.DurationLabel.Text = "Duration";
            // 
            // NumWorkersLabel
            // 
            this.NumWorkersLabel.AutoSize = true;
            this.NumWorkersLabel.Location = new System.Drawing.Point(39, 131);
            this.NumWorkersLabel.Name = "NumWorkersLabel";
            this.NumWorkersLabel.Size = new System.Drawing.Size(140, 13);
            this.NumWorkersLabel.TabIndex = 5;
            this.NumWorkersLabel.Text = "Number of Workers Needed";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(30, 49);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(151, 20);
            this.NameTextBox.TabIndex = 6;
            this.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.Location = new System.Drawing.Point(55, 95);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.Size = new System.Drawing.Size(94, 20);
            this.DurationTextBox.TabIndex = 7;
            this.DurationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NumWorkersTextBox
            // 
            this.NumWorkersTextBox.Location = new System.Drawing.Point(55, 146);
            this.NumWorkersTextBox.Name = "NumWorkersTextBox";
            this.NumWorkersTextBox.Size = new System.Drawing.Size(94, 20);
            this.NumWorkersTextBox.TabIndex = 8;
            this.NumWorkersTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddTaskGroupBox
            // 
            this.AddTaskGroupBox.Controls.Add(this.NumWorkersTextBox);
            this.AddTaskGroupBox.Controls.Add(this.DurationTextBox);
            this.AddTaskGroupBox.Controls.Add(this.NameTextBox);
            this.AddTaskGroupBox.Controls.Add(this.NumWorkersLabel);
            this.AddTaskGroupBox.Controls.Add(this.DurationLabel);
            this.AddTaskGroupBox.Controls.Add(this.NameLabel);
            this.AddTaskGroupBox.Controls.Add(this.AddTaskButton);
            this.AddTaskGroupBox.Location = new System.Drawing.Point(100, 10);
            this.AddTaskGroupBox.Name = "AddTaskGroupBox";
            this.AddTaskGroupBox.Size = new System.Drawing.Size(211, 237);
            this.AddTaskGroupBox.TabIndex = 9;
            this.AddTaskGroupBox.TabStop = false;
            this.AddTaskGroupBox.Text = "Add Task";
            // 
            // EditTaskGroupBox
            // 
            this.EditTaskGroupBox.Controls.Add(this.EditNumWorkersTextBox);
            this.EditTaskGroupBox.Controls.Add(this.DeleteTaskButton);
            this.EditTaskGroupBox.Controls.Add(this.EditDurationTextBox);
            this.EditTaskGroupBox.Controls.Add(this.EditNameTextBox);
            this.EditTaskGroupBox.Controls.Add(this.EditNumWorkersLabel);
            this.EditTaskGroupBox.Controls.Add(this.EditDurationLabel);
            this.EditTaskGroupBox.Controls.Add(this.EditNameLabel);
            this.EditTaskGroupBox.Controls.Add(this.EditTaskButton);
            this.EditTaskGroupBox.Location = new System.Drawing.Point(348, 10);
            this.EditTaskGroupBox.Name = "EditTaskGroupBox";
            this.EditTaskGroupBox.Size = new System.Drawing.Size(211, 237);
            this.EditTaskGroupBox.TabIndex = 10;
            this.EditTaskGroupBox.TabStop = false;
            this.EditTaskGroupBox.Text = "Edit Task";
            // 
            // EditNumWorkersTextBox
            // 
            this.EditNumWorkersTextBox.Location = new System.Drawing.Point(55, 146);
            this.EditNumWorkersTextBox.Name = "EditNumWorkersTextBox";
            this.EditNumWorkersTextBox.Size = new System.Drawing.Size(94, 20);
            this.EditNumWorkersTextBox.TabIndex = 8;
            this.EditNumWorkersTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DeleteTaskButton
            // 
            this.DeleteTaskButton.Location = new System.Drawing.Point(107, 189);
            this.DeleteTaskButton.Name = "DeleteTaskButton";
            this.DeleteTaskButton.Size = new System.Drawing.Size(74, 31);
            this.DeleteTaskButton.TabIndex = 11;
            this.DeleteTaskButton.Text = "Delete Task";
            this.DeleteTaskButton.UseVisualStyleBackColor = true;
            this.DeleteTaskButton.Click += new System.EventHandler(this.DeleteTaskButton_Click);
            // 
            // EditDurationTextBox
            // 
            this.EditDurationTextBox.Location = new System.Drawing.Point(55, 95);
            this.EditDurationTextBox.Name = "EditDurationTextBox";
            this.EditDurationTextBox.Size = new System.Drawing.Size(94, 20);
            this.EditDurationTextBox.TabIndex = 7;
            this.EditDurationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditNameTextBox
            // 
            this.EditNameTextBox.Location = new System.Drawing.Point(30, 49);
            this.EditNameTextBox.Name = "EditNameTextBox";
            this.EditNameTextBox.ReadOnly = true;
            this.EditNameTextBox.Size = new System.Drawing.Size(151, 20);
            this.EditNameTextBox.TabIndex = 6;
            this.EditNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditNumWorkersLabel
            // 
            this.EditNumWorkersLabel.AutoSize = true;
            this.EditNumWorkersLabel.Location = new System.Drawing.Point(39, 131);
            this.EditNumWorkersLabel.Name = "EditNumWorkersLabel";
            this.EditNumWorkersLabel.Size = new System.Drawing.Size(140, 13);
            this.EditNumWorkersLabel.TabIndex = 5;
            this.EditNumWorkersLabel.Text = "Number of Workers Needed";
            // 
            // EditDurationLabel
            // 
            this.EditDurationLabel.AutoSize = true;
            this.EditDurationLabel.Location = new System.Drawing.Point(82, 80);
            this.EditDurationLabel.Name = "EditDurationLabel";
            this.EditDurationLabel.Size = new System.Drawing.Size(47, 13);
            this.EditDurationLabel.TabIndex = 4;
            this.EditDurationLabel.Text = "Duration";
            // 
            // EditNameLabel
            // 
            this.EditNameLabel.AutoSize = true;
            this.EditNameLabel.Location = new System.Drawing.Point(82, 34);
            this.EditNameLabel.Name = "EditNameLabel";
            this.EditNameLabel.Size = new System.Drawing.Size(35, 13);
            this.EditNameLabel.TabIndex = 3;
            this.EditNameLabel.Text = "Name";
            // 
            // EditTaskButton
            // 
            this.EditTaskButton.Location = new System.Drawing.Point(23, 189);
            this.EditTaskButton.Name = "EditTaskButton";
            this.EditTaskButton.Size = new System.Drawing.Size(80, 31);
            this.EditTaskButton.TabIndex = 2;
            this.EditTaskButton.Text = "Edit Task";
            this.EditTaskButton.UseVisualStyleBackColor = true;
            this.EditTaskButton.Click += new System.EventHandler(this.EditTaskButton_Click);
            // 
            // UpdateDependenciesCheckedListBox
            // 
            this.UpdateDependenciesCheckedListBox.CheckOnClick = true;
            this.UpdateDependenciesCheckedListBox.FormattingEnabled = true;
            this.UpdateDependenciesCheckedListBox.Location = new System.Drawing.Point(6, 19);
            this.UpdateDependenciesCheckedListBox.Name = "UpdateDependenciesCheckedListBox";
            this.UpdateDependenciesCheckedListBox.Size = new System.Drawing.Size(234, 334);
            this.UpdateDependenciesCheckedListBox.TabIndex = 12;
            this.UpdateDependenciesCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateDependenciesCheckedListBox_SelectedIndexChanged);
            // 
            // UpdateDependenciesGroupBox
            // 
            this.UpdateDependenciesGroupBox.Controls.Add(this.DependenciesInfoTextBox);
            this.UpdateDependenciesGroupBox.Controls.Add(this.UpdateDependenciesCheckedListBox);
            this.UpdateDependenciesGroupBox.Location = new System.Drawing.Point(100, 305);
            this.UpdateDependenciesGroupBox.Name = "UpdateDependenciesGroupBox";
            this.UpdateDependenciesGroupBox.Size = new System.Drawing.Size(459, 358);
            this.UpdateDependenciesGroupBox.TabIndex = 14;
            this.UpdateDependenciesGroupBox.TabStop = false;
            this.UpdateDependenciesGroupBox.Text = "Update Dependencies";
            // 
            // DependenciesInfoTextBox
            // 
            this.DependenciesInfoTextBox.Location = new System.Drawing.Point(271, 19);
            this.DependenciesInfoTextBox.Multiline = true;
            this.DependenciesInfoTextBox.Name = "DependenciesInfoTextBox";
            this.DependenciesInfoTextBox.ReadOnly = true;
            this.DependenciesInfoTextBox.Size = new System.Drawing.Size(158, 163);
            this.DependenciesInfoTextBox.TabIndex = 14;
            this.DependenciesInfoTextBox.Text = "\r\nSelect a task in the data grid\r\n\r\nTick which tasks are a prerequisite for the s" +
    "elected task\r\n\r\nI.E. Which tasks must be complete before the selected task is st" +
    "arted\r\n\r\n";
            this.DependenciesInfoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CPAButton
            // 
            this.CPAButton.Location = new System.Drawing.Point(707, 635);
            this.CPAButton.Name = "CPAButton";
            this.CPAButton.Size = new System.Drawing.Size(159, 28);
            this.CPAButton.TabIndex = 15;
            this.CPAButton.Text = "Perform Critical Path Analysis";
            this.CPAButton.UseVisualStyleBackColor = true;
            this.CPAButton.Click += new System.EventHandler(this.CPAButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(10, 10);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(64, 24);
            this.BackButton.TabIndex = 16;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // EditProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 712);
            this.ControlBox = false;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CPAButton);
            this.Controls.Add(this.UpdateDependenciesGroupBox);
            this.Controls.Add(this.EditTaskGroupBox);
            this.Controls.Add(this.AddTaskGroupBox);
            this.Controls.Add(this.TasksDataGrid);
            this.Controls.Add(this.ExitButton);
            this.Name = "EditProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Project";
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGrid)).EndInit();
            this.AddTaskGroupBox.ResumeLayout(false);
            this.AddTaskGroupBox.PerformLayout();
            this.EditTaskGroupBox.ResumeLayout(false);
            this.EditTaskGroupBox.PerformLayout();
            this.UpdateDependenciesGroupBox.ResumeLayout(false);
            this.UpdateDependenciesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button ExitButton;
        private DataGridView TasksDataGrid;
        private Button AddTaskButton;
        private Label NameLabel;
        private Label DurationLabel;
        private Label NumWorkersLabel;
        private TextBox NameTextBox;
        private TextBox DurationTextBox;
        private TextBox NumWorkersTextBox;
        private GroupBox AddTaskGroupBox;
        private GroupBox EditTaskGroupBox;
        private TextBox EditNumWorkersTextBox;
        private TextBox EditDurationTextBox;
        private TextBox EditNameTextBox;
        private Label EditNumWorkersLabel;
        private Label EditDurationLabel;
        private Label EditNameLabel;
        private Button EditTaskButton;
        private Button DeleteTaskButton;
        private CheckedListBox UpdateDependenciesCheckedListBox;
        private GroupBox UpdateDependenciesGroupBox;
        private TextBox DependenciesInfoTextBox;
        private Button CPAButton;
        private Button BackButton;
    }
}