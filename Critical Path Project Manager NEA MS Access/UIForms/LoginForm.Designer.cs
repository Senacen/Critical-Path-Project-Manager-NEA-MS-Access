using System.Drawing;
using System.Windows.Forms;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LoginButton = new System.Windows.Forms.Button();
            this.OpenProjectGroupBox = new System.Windows.Forms.GroupBox();
            this.LoadRadioButton = new System.Windows.Forms.RadioButton();
            this.CreateNewRadioButton = new System.Windows.Forms.RadioButton();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.CreateAccountButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.OpenProjectGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoginButton.Location = new System.Drawing.Point(134, 181);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(64, 27);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // OpenProjectGroupBox
            // 
            this.OpenProjectGroupBox.Controls.Add(this.LoadRadioButton);
            this.OpenProjectGroupBox.Controls.Add(this.CreateNewRadioButton);
            this.OpenProjectGroupBox.Location = new System.Drawing.Point(300, 54);
            this.OpenProjectGroupBox.Name = "OpenProjectGroupBox";
            this.OpenProjectGroupBox.Size = new System.Drawing.Size(115, 81);
            this.OpenProjectGroupBox.TabIndex = 1;
            this.OpenProjectGroupBox.TabStop = false;
            this.OpenProjectGroupBox.Text = "Open Project";
            // 
            // LoadRadioButton
            // 
            this.LoadRadioButton.AutoSize = true;
            this.LoadRadioButton.Checked = true;
            this.LoadRadioButton.Location = new System.Drawing.Point(18, 49);
            this.LoadRadioButton.Name = "LoadRadioButton";
            this.LoadRadioButton.Size = new System.Drawing.Size(49, 17);
            this.LoadRadioButton.TabIndex = 1;
            this.LoadRadioButton.TabStop = true;
            this.LoadRadioButton.Text = "Load";
            this.LoadRadioButton.UseVisualStyleBackColor = true;
            // 
            // CreateNewRadioButton
            // 
            this.CreateNewRadioButton.AutoSize = true;
            this.CreateNewRadioButton.Location = new System.Drawing.Point(18, 26);
            this.CreateNewRadioButton.Name = "CreateNewRadioButton";
            this.CreateNewRadioButton.Size = new System.Drawing.Size(84, 17);
            this.CreateNewRadioButton.TabIndex = 0;
            this.CreateNewRadioButton.TabStop = true;
            this.CreateNewRadioButton.Text = "Create New ";
            this.CreateNewRadioButton.UseVisualStyleBackColor = true;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(79, 75);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(180, 20);
            this.UsernameTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(79, 115);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(180, 20);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UsernameLabel.Location = new System.Drawing.Point(13, 80);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(60, 15);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(20, 122);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.Location = new System.Drawing.Point(229, 181);
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.Size = new System.Drawing.Size(115, 27);
            this.CreateAccountButton.TabIndex = 6;
            this.CreateAccountButton.Text = "Create Account";
            this.CreateAccountButton.UseVisualStyleBackColor = true;
            this.CreateAccountButton.Click += new System.EventHandler(this.CreateAccountButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(378, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(64, 23);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(454, 259);
            this.ControlBox = false;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CreateAccountButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.OpenProjectGroupBox);
            this.Controls.Add(this.LoginButton);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.OpenProjectGroupBox.ResumeLayout(false);
            this.OpenProjectGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button LoginButton;
        private GroupBox OpenProjectGroupBox;
        private RadioButton LoadRadioButton;
        private RadioButton CreateNewRadioButton;
        private TextBox UsernameTextBox;
        private TextBox PasswordTextBox;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private Button CreateAccountButton;
        private Button ExitButton;
        private ImageList imageList1;
    }
}

