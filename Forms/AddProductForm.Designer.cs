namespace CafeShopManagement.Forms
{
    partial class AddProductForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblName;
        private Label lblPrice;
        private Label lblStock;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtStock;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblName = new Label();
            lblPrice = new Label();
            lblStock = new Label();
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // Title
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(120, 20);
            lblTitle.Text = "Add New Product";

            // Name Label
            lblName.AutoSize = true;
            lblName.Location = new Point(40, 80);
            lblName.Text = "Product Name:";

            // Name TextBox
            txtName.Location = new Point(150, 75);
            txtName.Size = new Size(200, 25);

            // Price Label
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(40, 120);
            lblPrice.Text = "Price ($):";

            // Price TextBox
            txtPrice.Location = new Point(150, 115);
            txtPrice.Size = new Size(200, 25);

            // Stock Label
            lblStock.AutoSize = true;
            lblStock.Location = new Point(40, 160);
            lblStock.Text = "Stock:";

            // Stock TextBox
            txtStock.Location = new Point(150, 155);
            txtStock.Size = new Size(200, 25);

            // Save Button
            btnSave.Text = "Save";
            btnSave.BackColor = Color.FromArgb(0, 123, 255);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(80, 210);
            btnSave.Size = new Size(100, 35);
            btnSave.Click += btnSave_Click;

            // Cancel Button
            btnCancel.Text = "Cancel";
            btnCancel.BackColor = Color.Gray;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(210, 210);
            btnCancel.Size = new Size(100, 35);
            btnCancel.Click += btnCancel_Click;

            // Form Settings
            ClientSize = new Size(400, 280);
            Controls.Add(lblTitle);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblStock);
            Controls.Add(txtStock);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Product";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
