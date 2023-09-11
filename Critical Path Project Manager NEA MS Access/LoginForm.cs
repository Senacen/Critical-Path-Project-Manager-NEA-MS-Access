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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadRadioButton.Checked = true;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            if (!DatabaseFunctions.isValidAccount(username, password))
            {
                MessageBox.Show("Invalid Login Details. To access the guest account, just press Login with an empty username and password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CreateNewRadioButton.Checked)
            {
                CreateNewProjectForm createNewProjectForm = new CreateNewProjectForm(username);
                createNewProjectForm.Show();
            }
            else
            {
                LoadProjectForm loadProjectForm = new LoadProjectForm(username);
                loadProjectForm.Show();
            }
            this.Close();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            DatabaseFunctions.createAccount(username, password);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

