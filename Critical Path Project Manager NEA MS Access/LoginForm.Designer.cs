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
            components = new System.ComponentModel.Container();
            LoginButton = new Button();
            OpenProjectGroupBox = new GroupBox();
            LoadRadioButton = new RadioButton();
            CreateNewRadioButton = new RadioButton();
            UsernameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            CreateAccountButton = new Button();
            ExitButton = new Button();
            imageList1 = new ImageList(components);
            OpenProjectGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.ForeColor = SystemColors.ActiveCaptionText;
            LoginButton.Location = new Point(86, 199);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(75, 23);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // OpenProjectGroupBox
            // 
            OpenProjectGroupBox.Controls.Add(LoadRadioButton);
            OpenProjectGroupBox.Controls.Add(CreateNewRadioButton);
            OpenProjectGroupBox.Location = new Point(274, 65);
            OpenProjectGroupBox.Name = "OpenProjectGroupBox";
            OpenProjectGroupBox.Size = new Size(120, 85);
            OpenProjectGroupBox.TabIndex = 1;
            OpenProjectGroupBox.TabStop = false;
            OpenProjectGroupBox.Text = "Open Project";
            // 
            // LoadRadioButton
            // 
            LoadRadioButton.AutoSize = true;
            LoadRadioButton.Location = new Point(15, 47);
            LoadRadioButton.Name = "LoadRadioButton";
            LoadRadioButton.Size = new Size(51, 19);
            LoadRadioButton.TabIndex = 1;
            LoadRadioButton.TabStop = true;
            LoadRadioButton.Text = "Load";
            LoadRadioButton.UseVisualStyleBackColor = true;
            // 
            // CreateNewRadioButton
            // 
            CreateNewRadioButton.AutoSize = true;
            CreateNewRadioButton.Location = new Point(15, 22);
            CreateNewRadioButton.Name = "CreateNewRadioButton";
            CreateNewRadioButton.Size = new Size(89, 19);
            CreateNewRadioButton.TabIndex = 0;
            CreateNewRadioButton.TabStop = true;
            CreateNewRadioButton.Text = "Create New ";
            CreateNewRadioButton.UseVisualStyleBackColor = true;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(86, 83);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(152, 23);
            UsernameTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(86, 124);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(152, 23);
            PasswordTextBox.TabIndex = 3;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            UsernameLabel.Location = new Point(23, 89);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(60, 15);
            UsernameLabel.TabIndex = 4;
            UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(23, 127);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(57, 15);
            PasswordLabel.TabIndex = 5;
            PasswordLabel.Text = "Password";
            // 
            // CreateAccountButton
            // 
            CreateAccountButton.Location = new Point(206, 199);
            CreateAccountButton.Name = "CreateAccountButton";
            CreateAccountButton.Size = new Size(134, 23);
            CreateAccountButton.TabIndex = 6;
            CreateAccountButton.Text = "Create Account";
            CreateAccountButton.UseVisualStyleBackColor = true;
            CreateAccountButton.Click += CreateAccountButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(352, 12);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 23);
            ExitButton.TabIndex = 7;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(439, 256);
            ControlBox = false;
            Controls.Add(ExitButton);
            Controls.Add(CreateAccountButton);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            Controls.Add(OpenProjectGroupBox);
            Controls.Add(LoginButton);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            OpenProjectGroupBox.ResumeLayout(false);
            OpenProjectGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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

