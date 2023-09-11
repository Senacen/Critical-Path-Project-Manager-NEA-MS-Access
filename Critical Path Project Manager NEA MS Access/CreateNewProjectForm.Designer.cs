using System.Drawing;
using System.Windows.Forms;
namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    partial class CreateNewProjectForm
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
            CreateButton = new Button();
            ProjectNameTextBox = new TextBox();
            ProjectNameLabel = new Label();
            BackToLoginButton = new Button();
            ExitButton = new Button();
            SuspendLayout();
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(193, 219);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(75, 23);
            CreateButton.TabIndex = 0;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.Location = new Point(86, 139);
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.Size = new Size(288, 23);
            ProjectNameTextBox.TabIndex = 1;
            ProjectNameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ProjectNameLabel
            // 
            ProjectNameLabel.AutoSize = true;
            ProjectNameLabel.Location = new Point(193, 104);
            ProjectNameLabel.Name = "ProjectNameLabel";
            ProjectNameLabel.Size = new Size(79, 15);
            ProjectNameLabel.TabIndex = 2;
            ProjectNameLabel.Text = "Project Name";
            // 
            // BackToLoginButton
            // 
            BackToLoginButton.Location = new Point(12, 12);
            BackToLoginButton.Name = "BackToLoginButton";
            BackToLoginButton.Size = new Size(104, 23);
            BackToLoginButton.TabIndex = 3;
            BackToLoginButton.Text = "Back to Login";
            BackToLoginButton.UseVisualStyleBackColor = true;
            BackToLoginButton.Click += BackToLoginButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(356, 12);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 23);
            ExitButton.TabIndex = 4;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // CreateNewProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 301);
            ControlBox = false;
            Controls.Add(ExitButton);
            Controls.Add(BackToLoginButton);
            Controls.Add(ProjectNameLabel);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(CreateButton);
            Name = "CreateNewProjectForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create New Project";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateButton;
        private TextBox ProjectNameTextBox;
        private Label ProjectNameLabel;
        private Button BackToLoginButton;
        private Button ExitButton;
    }
}