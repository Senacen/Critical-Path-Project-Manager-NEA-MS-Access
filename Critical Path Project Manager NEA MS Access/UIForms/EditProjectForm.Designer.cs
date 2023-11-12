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
            this.AddTaskGroupBox = new System.Windows.Forms.GroupBox();
            this.DurationNumeric = new System.Windows.Forms.NumericUpDown();
            this.NumWorkersNumeric = new System.Windows.Forms.NumericUpDown();
            this.EditTaskGroupBox = new System.Windows.Forms.GroupBox();
            this.EditDurationNumeric = new System.Windows.Forms.NumericUpDown();
            this.EditNumWorkersNumeric = new System.Windows.Forms.NumericUpDown();
            this.DeleteTaskButton = new System.Windows.Forms.Button();
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
            this.ExportProjectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGrid)).BeginInit();
            this.AddTaskGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWorkersNumeric)).BeginInit();
            this.EditTaskGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditDurationNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditNumWorkersNumeric)).BeginInit();
            this.UpdateDependenciesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(1185, 10);
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
            this.TasksDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksDataGrid.Location = new System.Drawing.Point(585, 59);
            this.TasksDataGrid.Name = "TasksDataGrid";
            this.TasksDataGrid.ReadOnly = true;
            this.TasksDataGrid.RowTemplate.Height = 25;
            this.TasksDataGrid.Size = new System.Drawing.Size(645, 633);
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
            // AddTaskGroupBox
            // 
            this.AddTaskGroupBox.Controls.Add(this.DurationNumeric);
            this.AddTaskGroupBox.Controls.Add(this.NumWorkersNumeric);
            this.AddTaskGroupBox.Controls.Add(this.NameTextBox);
            this.AddTaskGroupBox.Controls.Add(this.NumWorkersLabel);
            this.AddTaskGroupBox.Controls.Add(this.DurationLabel);
            this.AddTaskGroupBox.Controls.Add(this.NameLabel);
            this.AddTaskGroupBox.Controls.Add(this.AddTaskButton);
            this.AddTaskGroupBox.Location = new System.Drawing.Point(100, 59);
            this.AddTaskGroupBox.Name = "AddTaskGroupBox";
            this.AddTaskGroupBox.Size = new System.Drawing.Size(211, 237);
            this.AddTaskGroupBox.TabIndex = 9;
            this.AddTaskGroupBox.TabStop = false;
            this.AddTaskGroupBox.Text = "Add Task";
            // 
            // DurationNumeric
            // 
            this.DurationNumeric.Location = new System.Drawing.Point(55, 96);
            this.DurationNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DurationNumeric.Name = "DurationNumeric";
            this.DurationNumeric.Size = new System.Drawing.Size(94, 20);
            this.DurationNumeric.TabIndex = 10;
            this.DurationNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DurationNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumWorkersNumeric
            // 
            this.NumWorkersNumeric.Location = new System.Drawing.Point(55, 147);
            this.NumWorkersNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumWorkersNumeric.Name = "NumWorkersNumeric";
            this.NumWorkersNumeric.Size = new System.Drawing.Size(94, 20);
            this.NumWorkersNumeric.TabIndex = 9;
            this.NumWorkersNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumWorkersNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EditTaskGroupBox
            // 
            this.EditTaskGroupBox.Controls.Add(this.EditDurationNumeric);
            this.EditTaskGroupBox.Controls.Add(this.EditNumWorkersNumeric);
            this.EditTaskGroupBox.Controls.Add(this.DeleteTaskButton);
            this.EditTaskGroupBox.Controls.Add(this.EditNameTextBox);
            this.EditTaskGroupBox.Controls.Add(this.EditNumWorkersLabel);
            this.EditTaskGroupBox.Controls.Add(this.EditDurationLabel);
            this.EditTaskGroupBox.Controls.Add(this.EditNameLabel);
            this.EditTaskGroupBox.Controls.Add(this.EditTaskButton);
            this.EditTaskGroupBox.Location = new System.Drawing.Point(348, 59);
            this.EditTaskGroupBox.Name = "EditTaskGroupBox";
            this.EditTaskGroupBox.Size = new System.Drawing.Size(211, 237);
            this.EditTaskGroupBox.TabIndex = 10;
            this.EditTaskGroupBox.TabStop = false;
            this.EditTaskGroupBox.Text = "Edit Task";
            // 
            // EditDurationNumeric
            // 
            this.EditDurationNumeric.Location = new System.Drawing.Point(55, 96);
            this.EditDurationNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.EditDurationNumeric.Name = "EditDurationNumeric";
            this.EditDurationNumeric.Size = new System.Drawing.Size(94, 20);
            this.EditDurationNumeric.TabIndex = 13;
            this.EditDurationNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EditDurationNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EditNumWorkersNumeric
            // 
            this.EditNumWorkersNumeric.Location = new System.Drawing.Point(55, 147);
            this.EditNumWorkersNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EditNumWorkersNumeric.Name = "EditNumWorkersNumeric";
            this.EditNumWorkersNumeric.Size = new System.Drawing.Size(94, 20);
            this.EditNumWorkersNumeric.TabIndex = 12;
            this.EditNumWorkersNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EditNumWorkersNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.UpdateDependenciesCheckedListBox.Size = new System.Drawing.Size(234, 394);
            this.UpdateDependenciesCheckedListBox.TabIndex = 12;
            this.UpdateDependenciesCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateDependenciesCheckedListBox_SelectedIndexChanged);
            // 
            // UpdateDependenciesGroupBox
            // 
            this.UpdateDependenciesGroupBox.Controls.Add(this.DependenciesInfoTextBox);
            this.UpdateDependenciesGroupBox.Controls.Add(this.UpdateDependenciesCheckedListBox);
            this.UpdateDependenciesGroupBox.Location = new System.Drawing.Point(100, 302);
            this.UpdateDependenciesGroupBox.Name = "UpdateDependenciesGroupBox";
            this.UpdateDependenciesGroupBox.Size = new System.Drawing.Size(459, 424);
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
            this.CPAButton.Location = new System.Drawing.Point(817, 721);
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
            // ExportProjectButton
            // 
            this.ExportProjectButton.Location = new System.Drawing.Point(585, 721);
            this.ExportProjectButton.Name = "ExportProjectButton";
            this.ExportProjectButton.Size = new System.Drawing.Size(96, 28);
            this.ExportProjectButton.TabIndex = 17;
            this.ExportProjectButton.Text = "Export Project";
            this.ExportProjectButton.UseVisualStyleBackColor = true;
            this.ExportProjectButton.Click += new System.EventHandler(this.ExportProjectButton_Click);
            // 
            // EditProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 785);
            this.ControlBox = false;
            this.Controls.Add(this.ExportProjectButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWorkersNumeric)).EndInit();
            this.EditTaskGroupBox.ResumeLayout(false);
            this.EditTaskGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditDurationNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditNumWorkersNumeric)).EndInit();
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
        private GroupBox AddTaskGroupBox;
        private GroupBox EditTaskGroupBox;
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
        private NumericUpDown NumWorkersNumeric;
        private NumericUpDown EditNumWorkersNumeric;
        private NumericUpDown DurationNumeric;
        private NumericUpDown EditDurationNumeric;
        private Button ExportProjectButton;
    }
}