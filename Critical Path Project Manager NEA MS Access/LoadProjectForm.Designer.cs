using System.Drawing;
using System.Windows.Forms;
namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    partial class LoadProjectForm
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
            LoadButton = new Button();
            BackToLoginButton = new Button();
            ExitButton = new Button();
            ProjectListBox = new ListBox();
            SuspendLayout();
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(163, 366);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(75, 23);
            LoadButton.TabIndex = 0;
            LoadButton.Text = "Load";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // BackToLoginButton
            // 
            BackToLoginButton.Location = new Point(12, 12);
            BackToLoginButton.Name = "BackToLoginButton";
            BackToLoginButton.Size = new Size(104, 23);
            BackToLoginButton.TabIndex = 1;
            BackToLoginButton.Text = "Back to Login";
            BackToLoginButton.UseVisualStyleBackColor = true;
            BackToLoginButton.Click += BackToLoginButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(310, 12);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 23);
            ExitButton.TabIndex = 2;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // ProjectListBox
            // 
            ProjectListBox.FormattingEnabled = true;
            ProjectListBox.ItemHeight = 15;
            ProjectListBox.Location = new Point(92, 77);
            ProjectListBox.Name = "ProjectListBox";
            ProjectListBox.Size = new Size(219, 244);
            ProjectListBox.TabIndex = 3;
            // 
            // LoadProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 450);
            ControlBox = false;
            Controls.Add(ProjectListBox);
            Controls.Add(ExitButton);
            Controls.Add(BackToLoginButton);
            Controls.Add(LoadButton);
            Name = "LoadProjectForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Load Project";
            ResumeLayout(false);
        }

        #endregion

        private Button LoadButton;
        private Button BackToLoginButton;
        private Button ExitButton;
        private ListBox ProjectListBox;
    }
}