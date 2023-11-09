namespace Critical_Path_Project_Manager_NEA_MS_Access.UIForms
{
    partial class ImportProjectForm
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
            this.BackToLoginButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ImportTextBox = new System.Windows.Forms.TextBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ImportInfoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BackToLoginButton
            // 
            this.BackToLoginButton.Location = new System.Drawing.Point(20, 21);
            this.BackToLoginButton.Name = "BackToLoginButton";
            this.BackToLoginButton.Size = new System.Drawing.Size(87, 30);
            this.BackToLoginButton.TabIndex = 0;
            this.BackToLoginButton.Text = "Back to Login";
            this.BackToLoginButton.UseVisualStyleBackColor = true;
            this.BackToLoginButton.Click += new System.EventHandler(this.BackToLoginButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(713, 21);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 30);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ImportTextBox
            // 
            this.ImportTextBox.AcceptsReturn = true;
            this.ImportTextBox.AcceptsTab = true;
            this.ImportTextBox.Location = new System.Drawing.Point(282, 67);
            this.ImportTextBox.Multiline = true;
            this.ImportTextBox.Name = "ImportTextBox";
            this.ImportTextBox.Size = new System.Drawing.Size(455, 274);
            this.ImportTextBox.TabIndex = 2;
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(474, 388);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ImportButton.TabIndex = 3;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // ImportInfoTextBox
            // 
            this.ImportInfoTextBox.Location = new System.Drawing.Point(59, 139);
            this.ImportInfoTextBox.Multiline = true;
            this.ImportInfoTextBox.Name = "ImportInfoTextBox";
            this.ImportInfoTextBox.ReadOnly = true;
            this.ImportInfoTextBox.Size = new System.Drawing.Size(161, 120);
            this.ImportInfoTextBox.TabIndex = 4;
            this.ImportInfoTextBox.Text = "\r\nPaste your encrypted export project data into the text box on the right \r\n\r\nCli" +
    "ck Import to create a new project with the imported data\r\n";
            this.ImportInfoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ImportProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.ImportInfoTextBox);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.ImportTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BackToLoginButton);
            this.Name = "ImportProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackToLoginButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TextBox ImportTextBox;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.TextBox ImportInfoTextBox;
    }
}