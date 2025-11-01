using CafeShopManagement.Data;
using CafeShopManagement.Models;
using System;
using System.Windows.Forms;

namespace CafeShopManagement.Forms
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        // ✅ Called when the user clicks Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("⚠️ Please enter a product name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("⚠️ Please enter a valid price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("⚠️ Please enter a valid stock quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = new Product
            {
                Name = txtName.Text.Trim(),
                Price = price,
                Stock = stock
            };

            bool result;

            // If editing an existing product (Tag stores the ID)
            if (this.Tag != null && this.Tag is int id && id > 0)
            {
                product.Id = id;
                result = ProductRepository.Update(product);
            }
            else
            {
                result = ProductRepository.Add(product);
            }

            if (result)
            {
                MessageBox.Show("✅ Product saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("❌ Failed to save product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ❌ Cancel button — just close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ✏️ Used by Edit mode to load product data into textboxes
        public void SetProduct(Product product)
        {
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString("0.00");
            txtStock.Text = product.Stock.ToString();

            // store ID in Tag for update
            this.Tag = product.Id;
        }
    }
}
