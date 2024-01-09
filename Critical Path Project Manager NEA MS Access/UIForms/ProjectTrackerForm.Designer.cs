namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    partial class ProjectTrackerForm
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
            this.BackToCPAFormButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.IncompleteDataGrid = new System.Windows.Forms.DataGridView();
            this.AvailableDataGrid = new System.Windows.Forms.DataGridView();
            this.CompletedDataGrid = new System.Windows.Forms.DataGridView();
            this.MarkCompletedButton = new System.Windows.Forms.Button();
            this.MarkIncompleteButton = new System.Windows.Forms.Button();
            this.CompletedTasksLabel = new System.Windows.Forms.Label();
            this.AvailableTasksLabel = new System.Windows.Forms.Label();
            this.IncompleteTasksLabel = new System.Windows.Forms.Label();
            this.CompletedTasksInfoLabel = new System.Windows.Forms.Label();
            this.AvailableTasksInfoLabel = new System.Windows.Forms.Label();
            this.IncompleteTasksInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IncompleteDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompletedDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // BackToCPAFormButton
            // 
            this.BackToCPAFormButton.Location = new System.Drawing.Point(12, 12);
            this.BackToCPAFormButton.Name = "BackToCPAFormButton";
            this.BackToCPAFormButton.Size = new System.Drawing.Size(120, 41);
            this.BackToCPAFormButton.TabIndex = 0;
            this.BackToCPAFormButton.Text = "Back To Critical Path Analysis";
            this.BackToCPAFormButton.UseVisualStyleBackColor = true;
            this.BackToCPAFormButton.Click += new System.EventHandler(this.BackToCPAFormButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(1283, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(59, 28);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // IncompleteDataGrid
            // 
            this.IncompleteDataGrid.AllowUserToAddRows = false;
            this.IncompleteDataGrid.AllowUserToDeleteRows = false;
            this.IncompleteDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IncompleteDataGrid.Location = new System.Drawing.Point(925, 118);
            this.IncompleteDataGrid.MultiSelect = false;
            this.IncompleteDataGrid.Name = "IncompleteDataGrid";
            this.IncompleteDataGrid.Size = new System.Drawing.Size(398, 402);
            this.IncompleteDataGrid.TabIndex = 2;
            // 
            // AvailableDataGrid
            // 
            this.AvailableDataGrid.AllowUserToAddRows = false;
            this.AvailableDataGrid.AllowUserToDeleteRows = false;
            this.AvailableDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableDataGrid.Location = new System.Drawing.Point(473, 118);
            this.AvailableDataGrid.MultiSelect = false;
            this.AvailableDataGrid.Name = "AvailableDataGrid";
            this.AvailableDataGrid.Size = new System.Drawing.Size(371, 402);
            this.AvailableDataGrid.TabIndex = 3;
            // 
            // CompletedDataGrid
            // 
            this.CompletedDataGrid.AllowUserToAddRows = false;
            this.CompletedDataGrid.AllowUserToDeleteRows = false;
            this.CompletedDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompletedDataGrid.Location = new System.Drawing.Point(39, 118);
            this.CompletedDataGrid.MultiSelect = false;
            this.CompletedDataGrid.Name = "CompletedDataGrid";
            this.CompletedDataGrid.Size = new System.Drawing.Size(352, 402);
            this.CompletedDataGrid.TabIndex = 4;
            // 
            // MarkCompletedButton
            // 
            this.MarkCompletedButton.Location = new System.Drawing.Point(601, 591);
            this.MarkCompletedButton.Name = "MarkCompletedButton";
            this.MarkCompletedButton.Size = new System.Drawing.Size(115, 28);
            this.MarkCompletedButton.TabIndex = 5;
            this.MarkCompletedButton.Text = "Mark Completed";
            this.MarkCompletedButton.UseVisualStyleBackColor = true;
            this.MarkCompletedButton.Click += new System.EventHandler(this.MarkCompletedButton_Click);
            // 
            // MarkIncompleteButton
            // 
            this.MarkIncompleteButton.Location = new System.Drawing.Point(145, 591);
            this.MarkIncompleteButton.Name = "MarkIncompleteButton";
            this.MarkIncompleteButton.Size = new System.Drawing.Size(137, 28);
            this.MarkIncompleteButton.TabIndex = 6;
            this.MarkIncompleteButton.Text = "Mark Incomplete";
            this.MarkIncompleteButton.UseVisualStyleBackColor = true;
            this.MarkIncompleteButton.Click += new System.EventHandler(this.MarkIncompleteButton_Click);
            // 
            // CompletedTasksLabel
            // 
            this.CompletedTasksLabel.AutoSize = true;
            this.CompletedTasksLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompletedTasksLabel.Location = new System.Drawing.Point(156, 80);
            this.CompletedTasksLabel.Name = "CompletedTasksLabel";
            this.CompletedTasksLabel.Size = new System.Drawing.Size(126, 21);
            this.CompletedTasksLabel.TabIndex = 7;
            this.CompletedTasksLabel.Text = "Completed Tasks";
            // 
            // AvailableTasksLabel
            // 
            this.AvailableTasksLabel.AutoSize = true;
            this.AvailableTasksLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableTasksLabel.Location = new System.Drawing.Point(603, 80);
            this.AvailableTasksLabel.Name = "AvailableTasksLabel";
            this.AvailableTasksLabel.Size = new System.Drawing.Size(113, 21);
            this.AvailableTasksLabel.TabIndex = 8;
            this.AvailableTasksLabel.Text = "Available Tasks";
            // 
            // IncompleteTasksLabel
            // 
            this.IncompleteTasksLabel.AutoSize = true;
            this.IncompleteTasksLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncompleteTasksLabel.Location = new System.Drawing.Point(1066, 80);
            this.IncompleteTasksLabel.Name = "IncompleteTasksLabel";
            this.IncompleteTasksLabel.Size = new System.Drawing.Size(127, 21);
            this.IncompleteTasksLabel.TabIndex = 9;
            this.IncompleteTasksLabel.Text = "Incomplete Tasks";
            // 
            // CompletedTasksInfoLabel
            // 
            this.CompletedTasksInfoLabel.AutoSize = true;
            this.CompletedTasksInfoLabel.Location = new System.Drawing.Point(73, 523);
            this.CompletedTasksInfoLabel.Name = "CompletedTasksInfoLabel";
            this.CompletedTasksInfoLabel.Size = new System.Drawing.Size(296, 52);
            this.CompletedTasksInfoLabel.TabIndex = 10;
            this.CompletedTasksInfoLabel.Text = "Completed Tasks are those that you have already completed.\r\n\r\n\r\nMark a task to in" +
    "complete if you marked it complete in error\r\n";
            this.CompletedTasksInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AvailableTasksInfoLabel
            // 
            this.AvailableTasksInfoLabel.AutoSize = true;
            this.AvailableTasksInfoLabel.Location = new System.Drawing.Point(528, 523);
            this.AvailableTasksInfoLabel.Name = "AvailableTasksInfoLabel";
            this.AvailableTasksInfoLabel.Size = new System.Drawing.Size(248, 52);
            this.AvailableTasksInfoLabel.TabIndex = 11;
            this.AvailableTasksInfoLabel.Text = "Available Tasks are those that are available to start\r\n as all their predecessors" +
    " have been completed.\r\n\r\nMark Completed if you have finished it.\r\n";
            this.AvailableTasksInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncompleteTasksInfoLabel
            // 
            this.IncompleteTasksInfoLabel.AutoSize = true;
            this.IncompleteTasksInfoLabel.Location = new System.Drawing.Point(981, 523);
            this.IncompleteTasksInfoLabel.Name = "IncompleteTasksInfoLabel";
            this.IncompleteTasksInfoLabel.Size = new System.Drawing.Size(302, 26);
            this.IncompleteTasksInfoLabel.TabIndex = 12;
            this.IncompleteTasksInfoLabel.Text = "Incomplete Tasks are tasks that have not been completed yet \r\nbut cannot be start" +
    "ed until their predecessors are completed.";
            this.IncompleteTasksInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 658);
            this.ControlBox = false;
            this.Controls.Add(this.IncompleteTasksInfoLabel);
            this.Controls.Add(this.AvailableTasksInfoLabel);
            this.Controls.Add(this.CompletedTasksInfoLabel);
            this.Controls.Add(this.IncompleteTasksLabel);
            this.Controls.Add(this.AvailableTasksLabel);
            this.Controls.Add(this.CompletedTasksLabel);
            this.Controls.Add(this.MarkIncompleteButton);
            this.Controls.Add(this.MarkCompletedButton);
            this.Controls.Add(this.CompletedDataGrid);
            this.Controls.Add(this.AvailableDataGrid);
            this.Controls.Add(this.IncompleteDataGrid);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BackToCPAFormButton);
            this.Name = "ProjectTrackerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Tracker ";
            ((System.ComponentModel.ISupportInitialize)(this.IncompleteDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompletedDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackToCPAFormButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.DataGridView IncompleteDataGrid;
        private System.Windows.Forms.DataGridView AvailableDataGrid;
        private System.Windows.Forms.DataGridView CompletedDataGrid;
        private System.Windows.Forms.Button MarkCompletedButton;
        private System.Windows.Forms.Button MarkIncompleteButton;
        private System.Windows.Forms.Label CompletedTasksLabel;
        private System.Windows.Forms.Label AvailableTasksLabel;
        private System.Windows.Forms.Label IncompleteTasksLabel;
        private System.Windows.Forms.Label CompletedTasksInfoLabel;
        private System.Windows.Forms.Label AvailableTasksInfoLabel;
        private System.Windows.Forms.Label IncompleteTasksInfoLabel;
    }
}