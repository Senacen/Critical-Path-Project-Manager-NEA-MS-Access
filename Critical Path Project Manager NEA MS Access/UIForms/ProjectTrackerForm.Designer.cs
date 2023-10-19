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
            this.CompleteDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.IncompleteDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompleteDataGrid)).BeginInit();
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
            this.IncompleteDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IncompleteDataGrid.Location = new System.Drawing.Point(922, 149);
            this.IncompleteDataGrid.Name = "IncompleteDataGrid";
            this.IncompleteDataGrid.Size = new System.Drawing.Size(398, 402);
            this.IncompleteDataGrid.TabIndex = 2;
            // 
            // AvailableDataGrid
            // 
            this.AvailableDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableDataGrid.Location = new System.Drawing.Point(470, 149);
            this.AvailableDataGrid.Name = "AvailableDataGrid";
            this.AvailableDataGrid.Size = new System.Drawing.Size(371, 402);
            this.AvailableDataGrid.TabIndex = 3;
            // 
            // CompleteDataGrid
            // 
            this.CompleteDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompleteDataGrid.Location = new System.Drawing.Point(36, 149);
            this.CompleteDataGrid.Name = "CompleteDataGrid";
            this.CompleteDataGrid.Size = new System.Drawing.Size(352, 402);
            this.CompleteDataGrid.TabIndex = 4;
            // 
            // ProjectTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 759);
            this.ControlBox = false;
            this.Controls.Add(this.CompleteDataGrid);
            this.Controls.Add(this.AvailableDataGrid);
            this.Controls.Add(this.IncompleteDataGrid);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BackToCPAFormButton);
            this.Name = "ProjectTrackerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Tracker ";
            ((System.ComponentModel.ISupportInitialize)(this.IncompleteDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompleteDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackToCPAFormButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.DataGridView IncompleteDataGrid;
        private System.Windows.Forms.DataGridView AvailableDataGrid;
        private System.Windows.Forms.DataGridView CompleteDataGrid;
    }
}