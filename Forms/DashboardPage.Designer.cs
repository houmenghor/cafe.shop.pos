namespace CafeShopManagement.Forms
{
    partial class DashboardPage
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

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTime = new Label();
            lblTitle = new Label();
            flowCards = new FlowLayoutPanel();
            panelSales = new Panel();
            lblSalesValue = new Label();
            lblSalesTitle = new Label();
            panelOrders = new Panel();
            lblOrdersValue = new Label();
            lblOrdersTitle = new Label();
            panelCustomers = new Panel();
            lblCustomersValue = new Label();
            lblCustomersTitle = new Label();
            panelProducts = new Panel();
            lblProductsValue = new Label();
            lblProductsTitle = new Label();
            panelChart = new Panel();
            panelHeader.SuspendLayout();
            flowCards.SuspendLayout();
            panelSales.SuspendLayout();
            panelOrders.SuspendLayout();
            panelCustomers.SuspendLayout();
            panelProducts.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            panelHeader.Controls.Add(lblTime);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1143, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 10F);
            lblTime.ForeColor = Color.WhiteSmoke;
            lblTime.Location = new Point(914, 27);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(207, 23);
            lblTime.TabIndex = 1;
            lblTime.Text = "Tuesday, 21 October 2025";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(157, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dashboard";
            // 
            // flowCards
            // 
            flowCards.BackColor = Color.Transparent;
            flowCards.Controls.Add(panelSales);
            flowCards.Controls.Add(panelOrders);
            flowCards.Controls.Add(panelCustomers);
            flowCards.Controls.Add(panelProducts);
            flowCards.Dock = DockStyle.Top;
            flowCards.Location = new Point(0, 80);
            flowCards.Margin = new Padding(23, 13, 23, 13);
            flowCards.Name = "flowCards";
            flowCards.Padding = new Padding(23, 13, 23, 13);
            flowCards.Size = new Size(1143, 200);
            flowCards.TabIndex = 1;
            // 
            // panelSales
            // 
            panelSales.BackColor = Color.White;
            panelSales.BorderStyle = BorderStyle.FixedSingle;
            panelSales.Controls.Add(lblSalesValue);
            panelSales.Controls.Add(lblSalesTitle);
            panelSales.Location = new Point(34, 26);
            panelSales.Margin = new Padding(11, 13, 11, 13);
            panelSales.Name = "panelSales";
            panelSales.Size = new Size(251, 133);
            panelSales.TabIndex = 0;
            // 
            // lblSalesValue
            // 
            lblSalesValue.AutoSize = true;
            lblSalesValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSalesValue.ForeColor = Color.FromArgb(44, 62, 80);
            lblSalesValue.Location = new Point(11, 60);
            lblSalesValue.Name = "lblSalesValue";
            lblSalesValue.Size = new Size(120, 37);
            lblSalesValue.TabIndex = 1;
            lblSalesValue.Text = "$12,000";
            // 
            // lblSalesTitle
            // 
            lblSalesTitle.AutoSize = true;
            lblSalesTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSalesTitle.ForeColor = Color.Gray;
            lblSalesTitle.Location = new Point(11, 13);
            lblSalesTitle.Name = "lblSalesTitle";
            lblSalesTitle.Size = new Size(94, 23);
            lblSalesTitle.TabIndex = 0;
            lblSalesTitle.Text = "Total Sales";
            // 
            // panelOrders
            // 
            panelOrders.BackColor = Color.White;
            panelOrders.BorderStyle = BorderStyle.FixedSingle;
            panelOrders.Controls.Add(lblOrdersValue);
            panelOrders.Controls.Add(lblOrdersTitle);
            panelOrders.Location = new Point(307, 26);
            panelOrders.Margin = new Padding(11, 13, 11, 13);
            panelOrders.Name = "panelOrders";
            panelOrders.Size = new Size(251, 133);
            panelOrders.TabIndex = 1;
            // 
            // lblOrdersValue
            // 
            lblOrdersValue.AutoSize = true;
            lblOrdersValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblOrdersValue.ForeColor = Color.FromArgb(44, 62, 80);
            lblOrdersValue.Location = new Point(11, 60);
            lblOrdersValue.Name = "lblOrdersValue";
            lblOrdersValue.Size = new Size(49, 37);
            lblOrdersValue.TabIndex = 1;
            lblOrdersValue.Text = "90";
            // 
            // lblOrdersTitle
            // 
            lblOrdersTitle.AutoSize = true;
            lblOrdersTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOrdersTitle.ForeColor = Color.Gray;
            lblOrdersTitle.Location = new Point(11, 13);
            lblOrdersTitle.Name = "lblOrdersTitle";
            lblOrdersTitle.Size = new Size(108, 23);
            lblOrdersTitle.TabIndex = 0;
            lblOrdersTitle.Text = "Total Orders";
            // 
            // panelCustomers
            // 
            panelCustomers.BackColor = Color.White;
            panelCustomers.BorderStyle = BorderStyle.FixedSingle;
            panelCustomers.Controls.Add(lblCustomersValue);
            panelCustomers.Controls.Add(lblCustomersTitle);
            panelCustomers.Location = new Point(580, 26);
            panelCustomers.Margin = new Padding(11, 13, 11, 13);
            panelCustomers.Name = "panelCustomers";
            panelCustomers.Size = new Size(251, 133);
            panelCustomers.TabIndex = 2;
            // 
            // lblCustomersValue
            // 
            lblCustomersValue.AutoSize = true;
            lblCustomersValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCustomersValue.ForeColor = Color.FromArgb(44, 62, 80);
            lblCustomersValue.Location = new Point(11, 60);
            lblCustomersValue.Name = "lblCustomersValue";
            lblCustomersValue.Size = new Size(49, 37);
            lblCustomersValue.TabIndex = 1;
            lblCustomersValue.Text = "84";
            // 
            // lblCustomersTitle
            // 
            lblCustomersTitle.AutoSize = true;
            lblCustomersTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomersTitle.ForeColor = Color.Gray;
            lblCustomersTitle.Location = new Point(11, 13);
            lblCustomersTitle.Name = "lblCustomersTitle";
            lblCustomersTitle.Size = new Size(95, 23);
            lblCustomersTitle.TabIndex = 0;
            lblCustomersTitle.Text = "Items Sold\r\n";
            // 
            // panelProducts
            // 
            panelProducts.BackColor = Color.White;
            panelProducts.BorderStyle = BorderStyle.FixedSingle;
            panelProducts.Controls.Add(lblProductsValue);
            panelProducts.Controls.Add(lblProductsTitle);
            panelProducts.Location = new Point(853, 26);
            panelProducts.Margin = new Padding(11, 13, 11, 13);
            panelProducts.Name = "panelProducts";
            panelProducts.Size = new Size(251, 133);
            panelProducts.TabIndex = 3;
            // 
            // lblProductsValue
            // 
            lblProductsValue.AutoSize = true;
            lblProductsValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblProductsValue.ForeColor = Color.FromArgb(44, 62, 80);
            lblProductsValue.Location = new Point(11, 60);
            lblProductsValue.Name = "lblProductsValue";
            lblProductsValue.Size = new Size(49, 37);
            lblProductsValue.TabIndex = 1;
            lblProductsValue.Text = "45";
            // 
            // lblProductsTitle
            // 
            lblProductsTitle.AutoSize = true;
            lblProductsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProductsTitle.ForeColor = Color.Gray;
            lblProductsTitle.Location = new Point(11, 13);
            lblProductsTitle.Name = "lblProductsTitle";
            lblProductsTitle.Size = new Size(124, 23);
            lblProductsTitle.TabIndex = 0;
            lblProductsTitle.Text = "Total Products";
            // 
            // panelChart
            // 
            panelChart.BackColor = Color.White;
            panelChart.Dock = DockStyle.Fill;
            panelChart.Location = new Point(0, 280);
            panelChart.Margin = new Padding(3, 4, 3, 4);
            panelChart.Name = "panelChart";
            panelChart.Padding = new Padding(23, 27, 23, 27);
            panelChart.Size = new Size(1143, 520);
            panelChart.TabIndex = 2;
            // 
            // DashboardPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1143, 800);
            Controls.Add(panelChart);
            Controls.Add(flowCards);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "DashboardPage";
            Text = "DashboardPage";
            Load += DashboardPage_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            flowCards.ResumeLayout(false);
            panelSales.ResumeLayout(false);
            panelSales.PerformLayout();
            panelOrders.ResumeLayout(false);
            panelOrders.PerformLayout();
            panelCustomers.ResumeLayout(false);
            panelCustomers.PerformLayout();
            panelProducts.ResumeLayout(false);
            panelProducts.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowCards;
        private System.Windows.Forms.Panel panelSales;
        private System.Windows.Forms.Label lblSalesValue;
        private System.Windows.Forms.Label lblSalesTitle;
        private System.Windows.Forms.Panel panelOrders;
        private System.Windows.Forms.Label lblOrdersValue;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Panel panelCustomers;
        private System.Windows.Forms.Label lblCustomersValue;
        private System.Windows.Forms.Label lblCustomersTitle;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Label lblProductsValue;
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.Panel panelChart;
    }
}
