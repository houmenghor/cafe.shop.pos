using CafeShopManagement.Data;
using CafeShopManagement.Utils;
using System;
using System.Windows.Forms;
using Npgsql;

namespace CafeShopManagement.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("⚠️ Please enter both username and password.",
                    "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = Connection.Open())
                {
                    string query = "SELECT id, username, password FROM users WHERE username = @username LIMIT 1;";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string dbPassword = reader.GetString(2);

                                // ✅ use PasswordHelper.Verify
                                if (PasswordHelper.Verify(password, dbPassword))
                                {
                                    MessageBox.Show($"✅ Welcome back, {username}!",
                                        "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    var dashboard = new DashboardForm();
                                    dashboard.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("❌ Incorrect password.",
                                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("❌ Username not found.",
                                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
        }
    }
}
