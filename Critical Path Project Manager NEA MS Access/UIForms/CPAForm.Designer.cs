﻿using System.Drawing;
using System.Windows.Forms;
namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    partial class CPAForm
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
            this.components = new System.ComponentModel.Container();
            this.ExitButton = new System.Windows.Forms.Button();
            this.BackToEditProjectButton = new System.Windows.Forms.Button();
            this.CPADataGrid = new System.Windows.Forms.DataGridView();
            this.CPAGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CPLabel = new System.Windows.Forms.Label();
            this.CPTextBox = new System.Windows.Forms.TextBox();
            this.TotalDurationLabel = new System.Windows.Forms.Label();
            this.TotalDurationTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ProjectTrackerButton = new System.Windows.Forms.Button();
            this.DrawCascadeDiagramButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CPADataGrid)).BeginInit();
            this.CPAGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(1513, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(64, 28);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // BackToEditProjectButton
            // 
            this.BackToEditProjectButton.Location = new System.Drawing.Point(10, 10);
            this.BackToEditProjectButton.Name = "BackToEditProjectButton";
            this.BackToEditProjectButton.Size = new System.Drawing.Size(111, 28);
            this.BackToEditProjectButton.TabIndex = 1;
            this.BackToEditProjectButton.Text = "Back to Edit Project";
            this.BackToEditProjectButton.UseVisualStyleBackColor = true;
            this.BackToEditProjectButton.Click += new System.EventHandler(this.BackToEditProjectButton_Click);
            // 
            // CPADataGrid
            // 
            this.CPADataGrid.AllowUserToAddRows = false;
            this.CPADataGrid.AllowUserToDeleteRows = false;
            this.CPADataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CPADataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CPADataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CPADataGrid.Location = new System.Drawing.Point(371, 44);
            this.CPADataGrid.Name = "CPADataGrid";
            this.CPADataGrid.ReadOnly = true;
            this.CPADataGrid.RowTemplate.Height = 25;
            this.CPADataGrid.Size = new System.Drawing.Size(1178, 712);
            this.CPADataGrid.TabIndex = 2;
            // 
            // CPAGroupBox
            // 
            this.CPAGroupBox.Controls.Add(this.textBox1);
            this.CPAGroupBox.Controls.Add(this.CPLabel);
            this.CPAGroupBox.Controls.Add(this.CPTextBox);
            this.CPAGroupBox.Controls.Add(this.TotalDurationLabel);
            this.CPAGroupBox.Controls.Add(this.TotalDurationTextBox);
            this.CPAGroupBox.Location = new System.Drawing.Point(39, 44);
            this.CPAGroupBox.Name = "CPAGroupBox";
            this.CPAGroupBox.Size = new System.Drawing.Size(285, 712);
            this.CPAGroupBox.TabIndex = 3;
            this.CPAGroupBox.TabStop = false;
            this.CPAGroupBox.Text = "Project";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 572);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(275, 134);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "\r\nThis Duration and Critical Path are assuming optimal conditions where there are" +
    " always workers, and no delays\r\n\r\n\r\nClick Project Tracker to start tracking the " +
    "progress of the project";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CPLabel
            // 
            this.CPLabel.AutoSize = true;
            this.CPLabel.Location = new System.Drawing.Point(107, 122);
            this.CPLabel.Name = "CPLabel";
            this.CPLabel.Size = new System.Drawing.Size(73, 13);
            this.CPLabel.TabIndex = 3;
            this.CPLabel.Text = "Critical Path/s";
            // 
            // CPTextBox
            // 
            this.CPTextBox.Location = new System.Drawing.Point(5, 152);
            this.CPTextBox.Multiline = true;
            this.CPTextBox.Name = "CPTextBox";
            this.CPTextBox.ReadOnly = true;
            this.CPTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CPTextBox.Size = new System.Drawing.Size(275, 414);
            this.CPTextBox.TabIndex = 2;
            this.CPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TotalDurationLabel
            // 
            this.TotalDurationLabel.AutoSize = true;
            this.TotalDurationLabel.Location = new System.Drawing.Point(90, 49);
            this.TotalDurationLabel.Name = "TotalDurationLabel";
            this.TotalDurationLabel.Size = new System.Drawing.Size(105, 13);
            this.TotalDurationLabel.TabIndex = 1;
            this.TotalDurationLabel.Text = "Total Duration (days)";
            // 
            // TotalDurationTextBox
            // 
            this.TotalDurationTextBox.Location = new System.Drawing.Point(93, 79);
            this.TotalDurationTextBox.Name = "TotalDurationTextBox";
            this.TotalDurationTextBox.ReadOnly = true;
            this.TotalDurationTextBox.Size = new System.Drawing.Size(102, 20);
            this.TotalDurationTextBox.TabIndex = 0;
            this.TotalDurationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ProjectTrackerButton
            // 
            this.ProjectTrackerButton.Location = new System.Drawing.Point(1008, 796);
            this.ProjectTrackerButton.Name = "ProjectTrackerButton";
            this.ProjectTrackerButton.Size = new System.Drawing.Size(115, 26);
            this.ProjectTrackerButton.TabIndex = 4;
            this.ProjectTrackerButton.Text = "Project Tracker";
            this.ProjectTrackerButton.UseVisualStyleBackColor = true;
            this.ProjectTrackerButton.Click += new System.EventHandler(this.ProjectTrackerButton_Click);
            // 
            // DrawCascadeDiagramButton
            // 
            this.DrawCascadeDiagramButton.Location = new System.Drawing.Point(842, 796);
            this.DrawCascadeDiagramButton.Name = "DrawCascadeDiagramButton";
            this.DrawCascadeDiagramButton.Size = new System.Drawing.Size(133, 26);
            this.DrawCascadeDiagramButton.TabIndex = 5;
            this.DrawCascadeDiagramButton.Text = "Draw Cascade Diagram";
            this.DrawCascadeDiagramButton.UseVisualStyleBackColor = true;
            this.DrawCascadeDiagramButton.Click += new System.EventHandler(this.DrawCascadeDiagramButton_Click);
            // 
            // CPAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1589, 865);
            this.ControlBox = false;
            this.Controls.Add(this.DrawCascadeDiagramButton);
            this.Controls.Add(this.ProjectTrackerButton);
            this.Controls.Add(this.CPAGroupBox);
            this.Controls.Add(this.CPADataGrid);
            this.Controls.Add(this.BackToEditProjectButton);
            this.Controls.Add(this.ExitButton);
            this.Name = "CPAForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Critical Path Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.CPADataGrid)).EndInit();
            this.CPAGroupBox.ResumeLayout(false);
            this.CPAGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button ExitButton;
        private Button BackToEditProjectButton;
        private DataGridView CPADataGrid;
        private GroupBox CPAGroupBox;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox CPTextBox;
        private Label TotalDurationLabel;
        private TextBox TotalDurationTextBox;
        private TextBox textBox1;
        private Label CPLabel;
        private Button ProjectTrackerButton;
        private Button DrawCascadeDiagramButton;
    }
}