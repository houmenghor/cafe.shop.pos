namespace CafeShopManagement.Forms
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;

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
            lblTitle = new Label();
            panelMain = new Panel();
            dgvSaleItems = new DataGridView();
            panelTop = new Panel();
            lblProduct = new Label();
            cbProducts = new ComboBox();
            lblQty = new Label();
            txtQuantity = new TextBox();
            btnAddItem = new Button();
            btnRemoveItem = new Button();
            panelBottom = new Panel();
            btnPrintReceipt = new Button();
            btnProcessSale = new Button();
            lblGrandTotalValue = new Label();
            lblGrandTotalTitle = new Label();
            lblTotalValue = new Label();
            lblTotal = new Label();
            txtDiscount = new TextBox();
            lblDiscount = new Label();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).BeginInit();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1250, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(187, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📝  New Sale";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.WhiteSmoke;
            panelMain.Controls.Add(dgvSaleItems);
            panelMain.Controls.Add(panelTop);
            panelMain.Controls.Add(panelBottom);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1250, 590);
            panelMain.TabIndex = 1;
            // 
            // dgvSaleItems
            // 
            dgvSaleItems.AllowUserToAddRows = false;
            dgvSaleItems.AllowUserToDeleteRows = false;
            dgvSaleItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSaleItems.BackgroundColor = Color.White;
            dgvSaleItems.BorderStyle = BorderStyle.None;
            dgvSaleItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSaleItems.Dock = DockStyle.Fill;
            dgvSaleItems.GridColor = Color.Gainsboro;
            dgvSaleItems.Location = new Point(0, 100);
            dgvSaleItems.MultiSelect = false;
            dgvSaleItems.Name = "dgvSaleItems";
            dgvSaleItems.RowHeadersVisible = false;
            dgvSaleItems.RowHeadersWidth = 51;
            dgvSaleItems.RowTemplate.Height = 28;
            dgvSaleItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSaleItems.Size = new Size(1250, 360);
            dgvSaleItems.TabIndex = 2;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblProduct);
            panelTop.Controls.Add(cbProducts);
            panelTop.Controls.Add(lblQty);
            panelTop.Controls.Add(txtQuantity);
            panelTop.Controls.Add(btnAddItem);
            panelTop.Controls.Add(btnRemoveItem);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(25);
            panelTop.Size = new Size(1250, 100);
            panelTop.TabIndex = 0;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProduct.Location = new Point(25, 35);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(94, 25);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Product :";
            // 
            // cbProducts
            // 
            cbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProducts.Font = new Font("Segoe UI", 11F);
            cbProducts.Location = new Point(122, 32);
            cbProducts.Name = "cbProducts";
            cbProducts.Size = new Size(340, 33);
            cbProducts.TabIndex = 1;
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQty.Location = new Point(470, 35);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(99, 25);
            lblQty.TabIndex = 2;
            lblQty.Text = "Quantity :";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI", 11F);
            txtQuantity.Location = new Point(569, 32);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(70, 32);
            txtQuantity.TabIndex = 3;
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.FromArgb(46, 204, 113);
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.ForeColor = Color.White;
            btnAddItem.Location = new Point(660, 30);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(90, 35);
            btnAddItem.TabIndex = 4;
            btnAddItem.Text = "+ Add";
            btnAddItem.UseVisualStyleBackColor = false;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.BackColor = Color.FromArgb(231, 76, 60);
            btnRemoveItem.FlatStyle = FlatStyle.Flat;
            btnRemoveItem.ForeColor = Color.White;
            btnRemoveItem.Location = new Point(760, 30);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(100, 35);
            btnRemoveItem.TabIndex = 5;
            btnRemoveItem.Text = "Remove";
            btnRemoveItem.UseVisualStyleBackColor = false;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.White;
            panelBottom.Controls.Add(btnPrintReceipt);
            panelBottom.Controls.Add(btnProcessSale);
            panelBottom.Controls.Add(lblGrandTotalValue);
            panelBottom.Controls.Add(lblGrandTotalTitle);
            panelBottom.Controls.Add(lblTotalValue);
            panelBottom.Controls.Add(lblTotal);
            panelBottom.Controls.Add(txtDiscount);
            panelBottom.Controls.Add(lblDiscount);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 460);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(25);
            panelBottom.Size = new Size(1250, 130);
            panelBottom.TabIndex = 3;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrintReceipt.BackColor = Color.FromArgb(46, 204, 113);
            btnPrintReceipt.FlatStyle = FlatStyle.Flat;
            btnPrintReceipt.ForeColor = Color.White;
            btnPrintReceipt.Location = new Point(1118, 35);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(110, 45);
            btnPrintReceipt.TabIndex = 7;
            btnPrintReceipt.Text = "Print";
            btnPrintReceipt.UseVisualStyleBackColor = false;
            // 
            // btnProcessSale
            // 
            btnProcessSale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProcessSale.BackColor = Color.FromArgb(52, 152, 219);
            btnProcessSale.FlatStyle = FlatStyle.Flat;
            btnProcessSale.ForeColor = Color.White;
            btnProcessSale.Location = new Point(911, 35);
            btnProcessSale.Name = "btnProcessSale";
            btnProcessSale.Size = new Size(150, 45);
            btnProcessSale.TabIndex = 6;
            btnProcessSale.Text = "Process Sale";
            btnProcessSale.UseVisualStyleBackColor = false;
            // 
            // lblGrandTotalValue
            // 
            lblGrandTotalValue.AutoSize = true;
            lblGrandTotalValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblGrandTotalValue.ForeColor = Color.FromArgb(41, 128, 185);
            lblGrandTotalValue.Location = new Point(727, 40);
            lblGrandTotalValue.Name = "lblGrandTotalValue";
            lblGrandTotalValue.Size = new Size(77, 32);
            lblGrandTotalValue.TabIndex = 5;
            lblGrandTotalValue.Text = "$0.00";
            // 
            // lblGrandTotalTitle
            // 
            lblGrandTotalTitle.AutoSize = true;
            lblGrandTotalTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblGrandTotalTitle.Location = new Point(588, 42);
            lblGrandTotalTitle.Name = "lblGrandTotalTitle";
            lblGrandTotalTitle.Size = new Size(133, 30);
            lblGrandTotalTitle.TabIndex = 4;
            lblGrandTotalTitle.Text = "Grand Total:";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalValue.Location = new Point(478, 40);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(77, 32);
            lblTotalValue.TabIndex = 3;
            lblTotalValue.Text = "$0.00";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblTotal.Location = new Point(408, 42);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(73, 30);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total :";
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 11F);
            txtDiscount.Location = new Point(162, 43);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(80, 32);
            txtDiscount.TabIndex = 1;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDiscount.Location = new Point(30, 45);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(136, 25);
            lblDiscount.TabIndex = 0;
            lblDiscount.Text = "Discount (%) :";
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 650);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SalesForm";
            Text = "SalesForm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cbProducts;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.DataGridView dgvSaleItems;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblGrandTotalTitle;
        private System.Windows.Forms.Label lblGrandTotalValue;
        private System.Windows.Forms.Button btnProcessSale;
        private System.Windows.Forms.Button btnPrintReceipt;

        #endregion
    }
}
