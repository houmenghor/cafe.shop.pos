using CafeShopManagement.Data;
using CafeShopManagement.Forms;
using Npgsql;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CafeShopManagement
{
    public partial class DashboardForm : Form
    {
        private Button? currentButton; // Track active sidebar button

        public DashboardForm()
        {
            InitializeComponent();

            // When the main shell closes, end the message loop (exit app)
            FormClosed += (s, e) => Application.Exit();

            // Add margin under the logo
            btnDashboard.Margin = new Padding(0, 20, 0, 0);

            // Apply hover effect to all buttons
            ApplyHover(btnDashboard);
            ApplyHover(btnProducts);
            ApplyHover(btnSales);
            ApplyHover(btnReports);
            ApplyHover(btnLogout);

            // Ensure logout handler is wired
            btnLogout.Click += btnLogout_Click_1;
        }

        // 🔹 When Form Loads
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                using var conn = Connection.Open();

                // Default view — show Dashboard first
                ActivateButton(btnDashboard);
                LoadForm(new DashboardPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Connection Failed: " + ex.Message);
            }
        }

        // 🔹 Hover effect for buttons (ignore active)
        private void ApplyHover(Button btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                if (btn != currentButton)
                    btn.BackColor = Color.DarkCyan;
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn != currentButton)
                    btn.BackColor = Color.Teal;
            };
        }

        // 🔹 Load target form inside content panel
        private void LoadForm(Form form)
        {
            panelContent.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
        }

        // 🔹 Highlight the active button
        private void ActivateButton(Button button)
        {
            // Reset all buttons
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.Teal;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }

            // Mark selected button as active
            currentButton = button;
            button.BackColor = Color.White;
            button.ForeColor = Color.Teal;
        }

        // 🔹 Button click events
        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
            LoadForm(new DashboardPage());
        }

        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            ActivateButton(btnProducts);
            LoadForm(new ProductsForm());
        }

        private void btnSales_Click_1(object sender, EventArgs e)
        {
            ActivateButton(btnSales);
            LoadForm(new SalesForm());
        }

        private void btnReports_Click_1(object sender, EventArgs e)
        {
            ActivateButton(btnReports);
            LoadForm(new ReportsForm());
        }

        // 🔹 Logout — ask, then close all forms and exit cleanly
        private void btnLogout_Click_1(object? sender, EventArgs e)
        {
            var ask = MessageBox.Show(
                "Do you want to logout and close the application?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ask != DialogResult.Yes) return;

            // Close any other open forms first (if any)
            foreach (Form f in Application.OpenForms.Cast<Form>().ToList())
            {
                if (f != this) f.Close();
            }

            // This triggers FormClosed -> Application.Exit()
            Close();
        }
    }
}
