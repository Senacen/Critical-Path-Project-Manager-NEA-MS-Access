using System.Drawing;
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPAForm));
            ExitButton = new Button();
            BackToEditProjectButton = new Button();
            CPADataGrid = new DataGridView();
            CPAGroupBox = new GroupBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            TotalDurationTextBox = new TextBox();
            TotalDurationLabel = new Label();
            CPTextBox = new TextBox();
            CPLabel = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)CPADataGrid).BeginInit();
            CPAGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(1221, 12);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 23);
            ExitButton.TabIndex = 0;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // BackToEditProjectButton
            // 
            BackToEditProjectButton.Location = new Point(12, 12);
            BackToEditProjectButton.Name = "BackToEditProjectButton";
            BackToEditProjectButton.Size = new Size(130, 23);
            BackToEditProjectButton.TabIndex = 1;
            BackToEditProjectButton.Text = "Back to Edit Project";
            BackToEditProjectButton.UseVisualStyleBackColor = true;
            BackToEditProjectButton.Click += BackToEditProjectButton_Click;
            // 
            // CPADataGrid
            // 
            CPADataGrid.AllowUserToAddRows = false;
            CPADataGrid.AllowUserToDeleteRows = false;
            CPADataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            CPADataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CPADataGrid.Location = new Point(438, 51);
            CPADataGrid.Name = "CPADataGrid";
            CPADataGrid.ReadOnly = true;
            CPADataGrid.RowTemplate.Height = 25;
            CPADataGrid.Size = new Size(858, 688);
            CPADataGrid.TabIndex = 2;
            //CPADataGrid.AutoGenerateColumns = true;

            // 
            // CPAGroupBox
            // 
            CPAGroupBox.Controls.Add(textBox1);
            CPAGroupBox.Controls.Add(CPLabel);
            CPAGroupBox.Controls.Add(CPTextBox);
            CPAGroupBox.Controls.Add(TotalDurationLabel);
            CPAGroupBox.Controls.Add(TotalDurationTextBox);
            CPAGroupBox.Location = new Point(45, 51);
            CPAGroupBox.Name = "CPAGroupBox";
            CPAGroupBox.Size = new Size(332, 688);
            CPAGroupBox.TabIndex = 3;
            CPAGroupBox.TabStop = false;
            CPAGroupBox.Text = "Project";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // TotalDurationTextBox
            // 
            TotalDurationTextBox.Location = new Point(116, 91);
            TotalDurationTextBox.Name = "TotalDurationTextBox";
            TotalDurationTextBox.ReadOnly = true;
            TotalDurationTextBox.Size = new Size(100, 23);
            TotalDurationTextBox.TabIndex = 0;
            TotalDurationTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TotalDurationLabel
            // 
            TotalDurationLabel.AutoSize = true;
            TotalDurationLabel.Location = new Point(125, 57);
            TotalDurationLabel.Name = "TotalDurationLabel";
            TotalDurationLabel.Size = new Size(81, 15);
            TotalDurationLabel.TabIndex = 1;
            TotalDurationLabel.Text = "Total Duration";
            // 
            // CPTextBox
            // 
            CPTextBox.Location = new Point(6, 175);
            CPTextBox.Multiline = true;
            CPTextBox.Name = "CPTextBox";
            CPTextBox.ReadOnly = true;
            CPTextBox.Size = new Size(320, 331);
            CPTextBox.TabIndex = 2;
            CPTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // CPLabel
            // 
            CPLabel.AutoSize = true;
            CPLabel.Location = new Point(125, 141);
            CPLabel.Name = "CPLabel";
            CPLabel.Size = new Size(81, 15);
            CPLabel.TabIndex = 3;
            CPLabel.Text = "Critical Path/s";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 512);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(320, 170);
            textBox1.TabIndex = 4;
            textBox1.Text = resources.GetString("textBox1.Text");
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // CPAForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1308, 830);
            ControlBox = false;
            Controls.Add(CPAGroupBox);
            Controls.Add(CPADataGrid);
            Controls.Add(BackToEditProjectButton);
            Controls.Add(ExitButton);
            Name = "CPAForm";
            Text = "Critical Path Analysis";
            ((System.ComponentModel.ISupportInitialize)CPADataGrid).EndInit();
            CPAGroupBox.ResumeLayout(false);
            CPAGroupBox.PerformLayout();
            ResumeLayout(false);
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
    }
}