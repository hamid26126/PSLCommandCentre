using PSLCommandCentre.Helpers;
using PSLCommandCentre.Services;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PSLCommandCentre.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Test DB connection on startup
            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show(
                    "Cannot connect to the database.\nPlease ensure MySQL is running.",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // 1. Validate inputs
            var validation = Validator.ValidateLogin(username, password);
            if (!validation.IsValid)
            {
                lblError.Text = validation.Message;
                lblError.Visible = true;
                return;
            }

            // 2. Attempt login
            lblError.Visible = false;
            bool success = _authService.Login(username, password);

            if (success)
            {
                Logger.LogMessage("LoginForm",
                    $"User '{username}' logged in successfully.");

                // Open dashboard, hide login
                var dashboard = new DashboardForm();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                lblError.Text = "Invalid username or password.";
                lblError.Visible = true;
                Logger.LogMessage("LoginForm",
                    $"Failed login attempt for username: '{username}'");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow pressing Enter in password field to trigger login
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click_1(sender, e);
        }
    }
}