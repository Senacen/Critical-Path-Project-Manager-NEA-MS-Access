using Critical_Path_Project_Manager_NEA_MS_Access.UIForms;
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
             // Ensure UserAccounts has been created
            DatabaseFunctions.checkUserAccountsDatabaseExists();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadRadioButton.Checked = true;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Take in user input
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            // Reject blanks
            if (username == "" || password == "")
            {
                MessageBox.Show("Username or password cannot be blank. To access the guest account, just press Login with an username: 'guest' and password: 'guest'", "Invalid Details");
                return;
            }

            // Check the account details match
            if (!DatabaseFunctions.isValidAccount(username, password))
            {
                MessageBox.Show("Invalid Login Details. To access the guest account, just press Login with an username: 'guest' and password: 'guest'", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Open forms depending on which are selected
            if (CreateNewRadioButton.Checked)
            {
                CreateNewProjectForm createNewProjectForm = new CreateNewProjectForm(username);
                createNewProjectForm.Show();
            }
            else if (LoadRadioButton.Checked)
            {
                LoadProjectForm loadProjectForm = new LoadProjectForm(username);
                loadProjectForm.Show();
            }
            else
            {
                ImportProjectForm importProjectForm = new ImportProjectForm(username);
                importProjectForm.Show();
            }
            this.Close();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            // Take in user input
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            // Reject blanks
            if (username == "" || password == "")
            {
                MessageBox.Show("Username or password cannot be blank. To access the guest account, just press Login with an username: 'guest' and password: 'guest'", "Invalid Details");
                return;
            }
            // Create an account
            DatabaseFunctions.createAccount(username, password);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

