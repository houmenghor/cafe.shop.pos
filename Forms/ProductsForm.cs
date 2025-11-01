using CafeShopManagement.Data;
using CafeShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CafeShopManagement.Forms
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        // 🟢 Load all products (sorted by ID)
        private void LoadProducts()
        {
            dgvProducts.DataSource = null;
            var products = ProductRepository.GetAll();

            // Sort by ID ascending to make numbering correct
            products.Sort((a, b) => a.Id.CompareTo(b.Id));

            // Create a DataTable for display (without real Id)
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Stock", typeof(int));
            dt.Columns.Add("Created At", typeof(DateTime));

            int counter = 1;
            foreach (var p in products)
            {
                dt.Rows.Add(counter++, p.Name, p.Price, p.Stock, p.CreatedAt);
            }

            dgvProducts.DataSource = dt;

            // Style the grid
            dgvProducts.Columns["No"].Width = 60;
            dgvProducts.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        }

        // 🔍 Live search with sorting
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var products = string.IsNullOrEmpty(keyword)
                ? ProductRepository.GetAll()
                : ProductRepository.SearchByName(keyword);

            // Sort by ID ascending before numbering
            products.Sort((a, b) => a.Id.CompareTo(b.Id));

            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Stock", typeof(int));
            dt.Columns.Add("Created At", typeof(DateTime));

            int counter = 1;
            foreach (var p in products)
            {
                dt.Rows.Add(counter++, p.Name, p.Price, p.Stock, p.CreatedAt);
            }

            dgvProducts.DataSource = dt;
        }

        // 🟩 Add new product
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddProductForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        // ✏️ Update product
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Please select a product to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = dgvProducts.SelectedRows[0].Cells["Name"].Value.ToString();

            // Get real product from DB
            var product = ProductRepository.GetByName(name);
            if (product == null)
            {
                MessageBox.Show("❌ Could not find product in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var editForm = new AddProductForm())
            {
                editForm.Text = "Edit Product";
                editForm.SetProduct(product);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        // 🗑 Delete product
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Please select a product to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = dgvProducts.SelectedRows[0].Cells["Name"].Value.ToString();
            var product = ProductRepository.GetByName(name);

            if (product == null)
            {
                MessageBox.Show("❌ Could not find product in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete '{product.Name}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (ProductRepository.Delete(product.Id))
                {
                    MessageBox.Show("✅ Product deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("❌ Failed to delete product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
