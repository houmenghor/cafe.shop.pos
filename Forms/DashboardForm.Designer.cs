namespace CafeShopManagement
{
    partial class DashboardForm
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
            panelSidebar = new Panel();
            panelIndicator = new Panel();
            btnLogout = new Button();
            btnReports = new Button();
            btnSales = new Button();
            btnProducts = new Button();
            btnDashboard = new Button();
            lblTitle = new Label();
            panelContent = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.Teal;
            panelSidebar.Controls.Add(panelIndicator);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnSales);
            panelSidebar.Controls.Add(btnProducts);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Controls.Add(lblTitle);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Padding = new Padding(20, 10, 10, 10);
            panelSidebar.Size = new Size(250, 786);
            panelSidebar.TabIndex = 1;
            // 
            // panelIndicator
            // 
            panelIndicator.BackColor = Color.White;
            panelIndicator.Location = new Point(23, 97);
            panelIndicator.Name = "panelIndicator";
            panelIndicator.Size = new Size(5, 45);
            panelIndicator.TabIndex = 7;
            panelIndicator.Visible = false;
            // 
            // btnLogout
            // 
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(7, 277);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(235, 40);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            btnReports.Cursor = Cursors.Hand;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(7, 232);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(235, 40);
            btnReports.TabIndex = 5;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click_1;
            // 
            // btnSales
            // 
            btnSales.Cursor = Cursors.Hand;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSales.ForeColor = Color.White;
            btnSales.Location = new Point(7, 187);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(235, 40);
            btnSales.TabIndex = 4;
            btnSales.Text = "Sales";
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click_1;
            // 
            // btnProducts
            // 
            btnProducts.Cursor = Cursors.Hand;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(7, 142);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(235, 40);
            btnProducts.TabIndex = 3;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click_1;
            // 
            // btnDashboard
            // 
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(7, 97);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(235, 40);
            btnDashboard.TabIndex = 2;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click_1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(197, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "☕ Café Shop";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(250, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1250, 786);
            panelContent.TabIndex = 2;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 786);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Name = "DashboardForm";
            Text = "Form1";
            Load += DashboardForm_Load;
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelContent;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Label lblTitle;
        private Button btnDashboard;
        private Button btnLogout;
        private Button btnReports;
        private Button btnSales;
        private Button btnProducts;
        private Panel panelIndicator;
    }
}
