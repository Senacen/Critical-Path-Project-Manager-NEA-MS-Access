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
            ExitButton = new Button();
            TasksDataGrid = new DataGridView();
            AddTaskButton = new Button();
            NameLabel = new Label();
            DurationLabel = new Label();
            NumWorkersLabel = new Label();
            NameTextBox = new TextBox();
            DurationTextBox = new TextBox();
            NumWorkersTextBox = new TextBox();
            AddTaskGroupBox = new GroupBox();
            EditTaskGroupBox = new GroupBox();
            EditNumWorkersTextBox = new TextBox();
            DeleteTaskButton = new Button();
            EditDurationTextBox = new TextBox();
            EditNameTextBox = new TextBox();
            EditNumWorkersLabel = new Label();
            EditDurationLabel = new Label();
            EditNameLabel = new Label();
            EditTaskButton = new Button();
            UpdateDependenciesCheckedListBox = new CheckedListBox();
            UpdateDependenciesGroupBox = new GroupBox();
            DependenciesInfoTextBox = new TextBox();
            CPAButton = new Button();
            BackButton = new Button();
            ((System.ComponentModel.ISupportInitialize)TasksDataGrid).BeginInit();
            AddTaskGroupBox.SuspendLayout();
            EditTaskGroupBox.SuspendLayout();
            UpdateDependenciesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(1156, 12);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 23);
            ExitButton.TabIndex = 0;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // TasksDataGrid
            // 
            TasksDataGrid.AllowUserToAddRows = false;
            TasksDataGrid.AllowUserToDeleteRows = false;
            TasksDataGrid.BackgroundColor = SystemColors.Control;
            TasksDataGrid.BorderStyle = BorderStyle.None;
            TasksDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TasksDataGrid.Location = new Point(682, 12);
            TasksDataGrid.Name = "TasksDataGrid";
            TasksDataGrid.ReadOnly = true;
            TasksDataGrid.RowTemplate.Height = 25;
            TasksDataGrid.Size = new Size(468, 696);
            TasksDataGrid.TabIndex = 1;
            // 
            // AddTaskButton
            // 
            AddTaskButton.Location = new Point(83, 218);
            AddTaskButton.Name = "AddTaskButton";
            AddTaskButton.Size = new Size(75, 23);
            AddTaskButton.TabIndex = 2;
            AddTaskButton.Text = "Add Task";
            AddTaskButton.UseVisualStyleBackColor = true;
            AddTaskButton.Click += AddTaskButton_Click;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(96, 39);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(39, 15);
            NameLabel.TabIndex = 3;
            NameLabel.Text = "Name";
            // 
            // DurationLabel
            // 
            DurationLabel.AutoSize = true;
            DurationLabel.Location = new Point(96, 92);
            DurationLabel.Name = "DurationLabel";
            DurationLabel.Size = new Size(53, 15);
            DurationLabel.TabIndex = 4;
            DurationLabel.Text = "Duration";
            // 
            // NumWorkersLabel
            // 
            NumWorkersLabel.AutoSize = true;
            NumWorkersLabel.Location = new Point(45, 151);
            NumWorkersLabel.Name = "NumWorkersLabel";
            NumWorkersLabel.Size = new Size(155, 15);
            NumWorkersLabel.TabIndex = 5;
            NumWorkersLabel.Text = "Number of Workers Needed";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(35, 57);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(176, 23);
            NameTextBox.TabIndex = 6;
            NameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // DurationTextBox
            // 
            DurationTextBox.Location = new Point(64, 110);
            DurationTextBox.Name = "DurationTextBox";
            DurationTextBox.Size = new Size(109, 23);
            DurationTextBox.TabIndex = 7;
            DurationTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // NumWorkersTextBox
            // 
            NumWorkersTextBox.Location = new Point(64, 169);
            NumWorkersTextBox.Name = "NumWorkersTextBox";
            NumWorkersTextBox.Size = new Size(109, 23);
            NumWorkersTextBox.TabIndex = 8;
            NumWorkersTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // AddTaskGroupBox
            // 
            AddTaskGroupBox.Controls.Add(NumWorkersTextBox);
            AddTaskGroupBox.Controls.Add(DurationTextBox);
            AddTaskGroupBox.Controls.Add(NameTextBox);
            AddTaskGroupBox.Controls.Add(NumWorkersLabel);
            AddTaskGroupBox.Controls.Add(DurationLabel);
            AddTaskGroupBox.Controls.Add(NameLabel);
            AddTaskGroupBox.Controls.Add(AddTaskButton);
            AddTaskGroupBox.Location = new Point(117, 12);
            AddTaskGroupBox.Name = "AddTaskGroupBox";
            AddTaskGroupBox.Size = new Size(246, 273);
            AddTaskGroupBox.TabIndex = 9;
            AddTaskGroupBox.TabStop = false;
            AddTaskGroupBox.Text = "Add Task";
            // 
            // EditTaskGroupBox
            // 
            EditTaskGroupBox.Controls.Add(EditNumWorkersTextBox);
            EditTaskGroupBox.Controls.Add(DeleteTaskButton);
            EditTaskGroupBox.Controls.Add(EditDurationTextBox);
            EditTaskGroupBox.Controls.Add(EditNameTextBox);
            EditTaskGroupBox.Controls.Add(EditNumWorkersLabel);
            EditTaskGroupBox.Controls.Add(EditDurationLabel);
            EditTaskGroupBox.Controls.Add(EditNameLabel);
            EditTaskGroupBox.Controls.Add(EditTaskButton);
            EditTaskGroupBox.Location = new Point(406, 12);
            EditTaskGroupBox.Name = "EditTaskGroupBox";
            EditTaskGroupBox.Size = new Size(246, 273);
            EditTaskGroupBox.TabIndex = 10;
            EditTaskGroupBox.TabStop = false;
            EditTaskGroupBox.Text = "Edit Task";
            // 
            // EditNumWorkersTextBox
            // 
            EditNumWorkersTextBox.Location = new Point(64, 169);
            EditNumWorkersTextBox.Name = "EditNumWorkersTextBox";
            EditNumWorkersTextBox.Size = new Size(109, 23);
            EditNumWorkersTextBox.TabIndex = 8;
            EditNumWorkersTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // DeleteTaskButton
            // 
            DeleteTaskButton.Location = new Point(125, 218);
            DeleteTaskButton.Name = "DeleteTaskButton";
            DeleteTaskButton.Size = new Size(75, 23);
            DeleteTaskButton.TabIndex = 11;
            DeleteTaskButton.Text = "Delete Task";
            DeleteTaskButton.UseVisualStyleBackColor = true;
            DeleteTaskButton.Click += DeleteTaskButton_Click;
            // 
            // EditDurationTextBox
            // 
            EditDurationTextBox.Location = new Point(64, 110);
            EditDurationTextBox.Name = "EditDurationTextBox";
            EditDurationTextBox.Size = new Size(109, 23);
            EditDurationTextBox.TabIndex = 7;
            EditDurationTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // EditNameTextBox
            // 
            EditNameTextBox.Location = new Point(35, 57);
            EditNameTextBox.Name = "EditNameTextBox";
            EditNameTextBox.ReadOnly = true;
            EditNameTextBox.Size = new Size(176, 23);
            EditNameTextBox.TabIndex = 6;
            EditNameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // EditNumWorkersLabel
            // 
            EditNumWorkersLabel.AutoSize = true;
            EditNumWorkersLabel.Location = new Point(45, 151);
            EditNumWorkersLabel.Name = "EditNumWorkersLabel";
            EditNumWorkersLabel.Size = new Size(155, 15);
            EditNumWorkersLabel.TabIndex = 5;
            EditNumWorkersLabel.Text = "Number of Workers Needed";
            // 
            // EditDurationLabel
            // 
            EditDurationLabel.AutoSize = true;
            EditDurationLabel.Location = new Point(96, 92);
            EditDurationLabel.Name = "EditDurationLabel";
            EditDurationLabel.Size = new Size(53, 15);
            EditDurationLabel.TabIndex = 4;
            EditDurationLabel.Text = "Duration";
            // 
            // EditNameLabel
            // 
            EditNameLabel.AutoSize = true;
            EditNameLabel.Location = new Point(96, 39);
            EditNameLabel.Name = "EditNameLabel";
            EditNameLabel.Size = new Size(39, 15);
            EditNameLabel.TabIndex = 3;
            EditNameLabel.Text = "Name";
            // 
            // EditTaskButton
            // 
            EditTaskButton.Location = new Point(45, 218);
            EditTaskButton.Name = "EditTaskButton";
            EditTaskButton.Size = new Size(75, 23);
            EditTaskButton.TabIndex = 2;
            EditTaskButton.Text = "Edit Task";
            EditTaskButton.UseVisualStyleBackColor = true;
            EditTaskButton.Click += EditTaskButton_Click;
            // 
            // UpdateDependenciesCheckedListBox
            // 
            UpdateDependenciesCheckedListBox.CheckOnClick = true;
            UpdateDependenciesCheckedListBox.FormattingEnabled = true;
            UpdateDependenciesCheckedListBox.Location = new Point(6, 22);
            UpdateDependenciesCheckedListBox.Name = "UpdateDependenciesCheckedListBox";
            UpdateDependenciesCheckedListBox.Size = new Size(269, 382);
            UpdateDependenciesCheckedListBox.TabIndex = 12;
            UpdateDependenciesCheckedListBox.SelectedIndexChanged += UpdateDependenciesCheckedListBox_SelectedIndexChanged;
            // 
            // UpdateDependenciesGroupBox
            // 
            UpdateDependenciesGroupBox.Controls.Add(DependenciesInfoTextBox);
            UpdateDependenciesGroupBox.Controls.Add(UpdateDependenciesCheckedListBox);
            UpdateDependenciesGroupBox.Location = new Point(117, 352);
            UpdateDependenciesGroupBox.Name = "UpdateDependenciesGroupBox";
            UpdateDependenciesGroupBox.Size = new Size(535, 413);
            UpdateDependenciesGroupBox.TabIndex = 14;
            UpdateDependenciesGroupBox.TabStop = false;
            UpdateDependenciesGroupBox.Text = "Update Dependencies";
            // 
            // DependenciesInfoTextBox
            // 
            DependenciesInfoTextBox.Location = new Point(328, 22);
            DependenciesInfoTextBox.Multiline = true;
            DependenciesInfoTextBox.Name = "DependenciesInfoTextBox";
            DependenciesInfoTextBox.ReadOnly = true;
            DependenciesInfoTextBox.Size = new Size(161, 169);
            DependenciesInfoTextBox.TabIndex = 14;
            DependenciesInfoTextBox.Text = "\r\nSelect a task in the data grid\r\n\r\nTick which tasks are a prerequisite for the selected task\r\n\r\nI.E. Which tasks must be complete before the selected task is started\r\n\r\n";
            DependenciesInfoTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // CPAButton
            // 
            CPAButton.Location = new Point(825, 733);
            CPAButton.Name = "CPAButton";
            CPAButton.Size = new Size(186, 23);
            CPAButton.TabIndex = 15;
            CPAButton.Text = "Perform Critical Path Analysis";
            CPAButton.UseVisualStyleBackColor = true;
            CPAButton.Click += CPAButton_Click;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 12);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 16;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // EditProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1243, 821);
            ControlBox = false;
            Controls.Add(BackButton);
            Controls.Add(CPAButton);
            Controls.Add(UpdateDependenciesGroupBox);
            Controls.Add(EditTaskGroupBox);
            Controls.Add(AddTaskGroupBox);
            Controls.Add(TasksDataGrid);
            Controls.Add(ExitButton);
            Name = "EditProjectForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Project";
            ((System.ComponentModel.ISupportInitialize)TasksDataGrid).EndInit();
            AddTaskGroupBox.ResumeLayout(false);
            AddTaskGroupBox.PerformLayout();
            EditTaskGroupBox.ResumeLayout(false);
            EditTaskGroupBox.PerformLayout();
            UpdateDependenciesGroupBox.ResumeLayout(false);
            UpdateDependenciesGroupBox.PerformLayout();
            ResumeLayout(false);
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