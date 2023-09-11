using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    public partial class CreateNewProjectForm : Form
    {
        private string username;
        public CreateNewProjectForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string projectName = ProjectNameTextBox.Text;
            if (DatabaseFunctions.isValidDatabaseName(projectName))
            {
                if (DatabaseFunctions.createDatabase(projectName, username))
                {
                    EditProjectForm editProjectForm = new EditProjectForm(projectName, username);
                    editProjectForm.Show();
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("The name must start with a letter, be made of only letters, numbers, and underscores, and be no longer than 128 characters. " +
                                "It also may not be a SQL Server reserved keyword.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BackToLoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
