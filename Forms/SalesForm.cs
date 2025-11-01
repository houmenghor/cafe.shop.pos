using CafeShopManagement.Data;
using CafeShopManagement.Models;      // Product + Receipt
using CafeShopManagement.Utils;       // ReceiptPrinter
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace CafeShopManagement.Forms
{
    public partial class SalesForm : Form
    {
        // infra
        private readonly IProductRepository _productRepo;
        private readonly ISaleService _saleService;

        // domain
        private readonly SaleCart _cart = new();

        // printing
        private readonly ReceiptPrinter _printer = new ReceiptPrinter();
        private Receipt? _lastReceipt;

        private static bool InDesignMode =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime
            || (Process.GetCurrentProcess().ProcessName == "devenv");

        public SalesForm()
        {
            InitializeComponent();
            if (InDesignMode) return;

            // infrastructure
            _productRepo = new NpgsqlProductRepository();
            _saleService = new NpgsqlSaleService();

            // grid binding (purely UI)
            ConfigureGrid();

            // hook UI events
            HookEvents();

            // load & paint
            LoadProducts();
            UpdateTotals();

            // cosmetic
            this.ApplyRoundedCorners(btnAddItem);
            this.ApplyRoundedCorners(btnRemoveItem);
            this.ApplyRoundedCorners(btnProcessSale);
            this.ApplyRoundedCorners(btnPrintReceipt);

            btnPrintReceipt.Enabled = false; // only after a sale
        }

        // -----------------------
        // UI wiring
        // -----------------------
        private void ConfigureGrid()
        {
            dgvSaleItems.AutoGenerateColumns = false;
            dgvSaleItems.DataSource = _cart.Lines;
            dgvSaleItems.Columns.Clear();

            dgvSaleItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product",
                DataPropertyName = nameof(SaleLine.ProductName),
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvSaleItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                DataPropertyName = nameof(SaleLine.Price),
                DefaultCellStyle = { Format = "C2" },
                ReadOnly = true,
                Width = 100
            });
            dgvSaleItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Qty",
                DataPropertyName = nameof(SaleLine.Quantity),
                ReadOnly = true,
                Width = 60
            });
            dgvSaleItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Subtotal",
                DataPropertyName = nameof(SaleLine.Subtotal),
                DefaultCellStyle = { Format = "C2" },
                ReadOnly = true,
                Width = 120
            });
        }

        private void HookEvents()
        {
            btnAddItem.Click += (_, __) => AddItem();
            btnRemoveItem.Click += (_, __) => RemoveSelectedLine();
            btnProcessSale.Click += (_, __) => ProcessSale();
            btnPrintReceipt.Click += (_, __) => PrintLastReceipt();

            txtDiscount.TextChanged += (_, __) => UpdateTotals();
            txtQuantity.KeyPress += (_, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };
        }

        // -----------------------
        // UI actions
        // -----------------------
        private void LoadProducts()
        {
            var products = _productRepo.GetAll();
            cbProducts.DataSource = products
                .Select(p => new ComboItem(p.Id, $"{p.Name} — {p.Price:C2} (Stock: {p.Stock})"))
                .ToList();
            cbProducts.DisplayMember = nameof(ComboItem.Text);
            cbProducts.ValueMember = nameof(ComboItem.Id);
        }

        private void AddItem()
        {
            Guard.True(cbProducts.SelectedItem is ComboItem, "Please select a product.");
            Guard.True(int.TryParse(txtQuantity.Text.Trim(), out var qty) && qty > 0, "Enter a valid quantity (> 0).");

            var item = (ComboItem)cbProducts.SelectedItem!;
            var product = _productRepo.GetById(item.Id);
            Guard.NotNull(product, "Product not found.");

            var already = _cart.QuantityOf(product!.Id);
            Guard.True(qty + already <= product.Stock, $"Not enough stock. Available: {product.Stock - already}");

            _cart.Add(product, qty);
            UpdateTotals();

            txtQuantity.Clear();
            txtQuantity.Focus();
        }

        private void RemoveSelectedLine()
        {
            if (dgvSaleItems.CurrentRow?.DataBoundItem is not SaleLine line)
            {
                MessageBox.Show("Select a row to remove.");
                return;
            }

            _cart.Remove(line.ProductId);
            UpdateTotals();
        }

        private void ProcessSale()
        {
            if (_cart.IsEmpty) { MessageBox.Show("No items to process."); return; }

            decimal.TryParse(txtDiscount.Text, out var discount);
            discount = Math.Clamp(discount, 0, 100);

            try
            {
                // save to DB
                var result = _saleService.Process(_cart, discount);

                // build receipt (OOP – separate builder)
                _lastReceipt = new ReceiptBuilder()
                    .WithSaleId(result.SaleId)
                    .WithPrintedAt(DateTime.Now)
                    .WithTotals(_cart.Total, discount, _cart.GrandTotal(discount))
                    .WithLines(_cart.Lines.Select(l => new Receipt.ReceiptLine
                    {
                        ProductName = l.ProductName,
                        Quantity = l.Quantity,
                        Price = l.Price
                    }))
                    .Build();

                btnPrintReceipt.Enabled = true;

                MessageBox.Show($"✅ Sale processed. Receipt #{result.SaleId}");

                _cart.Clear();
                UpdateTotals();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Failed to process sale: {ex.Message}");
            }
        }

        private void PrintLastReceipt()
        {
            if (_lastReceipt is null)
            {
                MessageBox.Show("No receipt to print. Please process a sale first.");
                return;
            }

            // preview (or call _printer.Print(_lastReceipt) to send to printer)
            _printer.Preview(_lastReceipt);
        }

        private void UpdateTotals()
        {
            decimal.TryParse(txtDiscount.Text, out var discount);
            discount = Math.Clamp(discount, 0, 100);

            lblTotalValue.Text = _cart.Total.ToString("C2");
            lblGrandTotalValue.Text = _cart.GrandTotal(discount).ToString("C2");
        }
    }

    // ============================================================
    // Domain model & services (kept in-file for easy drop-in)
    // ============================================================
    #region Domain

    public sealed class SaleLine
    {
        public int ProductId { get; }
        public string ProductName { get; }
        public decimal Price { get; }
        public int Quantity { get; private set; }
        public decimal Subtotal => Price * Quantity;

        public SaleLine(Product p, int qty)
        {
            ProductId = p.Id;
            ProductName = p.Name;
            Price = p.Price;
            Quantity = qty;
        }

        public void AddQty(int qty) => Quantity += qty;
    }

    public sealed class SaleCart
    {
        public BindingList<SaleLine> Lines { get; } = new();
        public bool IsEmpty => Lines.Count == 0;
        public decimal Total => Lines.Sum(l => l.Subtotal);

        public decimal GrandTotal(decimal discountPercent)
        {
            var d = Math.Clamp(discountPercent, 0, 100);
            return Total - (Total * d / 100m);
        }

        public int QuantityOf(int productId) =>
            Lines.Where(l => l.ProductId == productId).Sum(l => l.Quantity);

        public void Add(Product p, int qty)
        {
            var line = Lines.FirstOrDefault(l => l.ProductId == p.Id);
            if (line is null) Lines.Add(new SaleLine(p, qty));
            else line.AddQty(qty);
            Lines.ResetBindings();
        }

        public void Remove(int productId)
        {
            var line = Lines.FirstOrDefault(l => l.ProductId == productId);
            if (line is not null) Lines.Remove(line);
        }

        public void Clear() => Lines.Clear();
    }

    public readonly struct ProcessResult
    {
        public int SaleId { get; }
        public ProcessResult(int saleId) => SaleId = saleId;
    }

    #endregion

    #region Repositories & Services

    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
    }

    public sealed class NpgsqlProductRepository : IProductRepository
    {
        public List<Product> GetAll()
        {
            using var conn = Connection.Open();
            using var cmd = new NpgsqlCommand("SELECT id, name, price, stock FROM products ORDER BY name;", conn);
            using var rd = cmd.ExecuteReader();
            var list = new List<Product>();
            while (rd.Read())
            {
                list.Add(new Product
                {
                    Id = rd.GetInt32(0),
                    Name = rd.GetString(1),
                    Price = rd.GetDecimal(2),
                    Stock = rd.GetInt32(3)
                });
            }
            return list;
        }

        public Product? GetById(int id)
        {
            using var conn = Connection.Open();
            using var cmd = new NpgsqlCommand("SELECT id, name, price, stock FROM products WHERE id=@id;", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return null;

            return new Product
            {
                Id = rd.GetInt32(0),
                Name = rd.GetString(1),
                Price = rd.GetDecimal(2),
                Stock = rd.GetInt32(3)
            };
        }
    }

    public interface ISaleService
    {
        ProcessResult Process(SaleCart cart, decimal discountPercent);
    }

    public sealed class NpgsqlSaleService : ISaleService
    {
        public ProcessResult Process(SaleCart cart, decimal discountPercent)
        {
            if (cart.IsEmpty) throw new InvalidOperationException("Cart empty.");

            using var conn = Connection.Open();
            using var tx = conn.BeginTransaction();

            var total = cart.Total;
            var discount = Math.Clamp(discountPercent, 0, 100);
            var grand = cart.GrandTotal(discount);

            int saleId;
            using (var cmd = new NpgsqlCommand(
                "INSERT INTO sales(sale_date,total,discount,grand_total) VALUES (NOW(),@t,@d,@g) RETURNING id;",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@t", total);
                cmd.Parameters.AddWithValue("@d", discount);
                cmd.Parameters.AddWithValue("@g", grand);
                saleId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            foreach (var line in cart.Lines)
            {
                using var cmdItem = new NpgsqlCommand(
                    "INSERT INTO sale_items(sale_id,product_id,quantity,subtotal) VALUES (@s,@p,@q,@sub);",
                    conn, tx);
                cmdItem.Parameters.AddWithValue("@s", saleId);
                cmdItem.Parameters.AddWithValue("@p", line.ProductId);
                cmdItem.Parameters.AddWithValue("@q", line.Quantity);
                cmdItem.Parameters.AddWithValue("@sub", line.Subtotal);
                cmdItem.ExecuteNonQuery();

                using var cmdStock = new NpgsqlCommand(
                    "UPDATE products SET stock = stock - @q WHERE id=@p;", conn, tx);
                cmdStock.Parameters.AddWithValue("@q", line.Quantity);
                cmdStock.Parameters.AddWithValue("@p", line.ProductId);
                cmdStock.ExecuteNonQuery();
            }

            tx.Commit();
            return new ProcessResult(saleId);
        }
    }

    #endregion

    // ============================================================
    // Helpers (builders, UI extensions, guards)
    // ============================================================
    #region Builders & Helpers

    /// <summary>Creates your simple receipt model from form/cart values.</summary>
    public sealed class ReceiptBuilder
    {
        private int _saleId;
        private DateTime _printedAt = DateTime.Now;
        private decimal _total;
        private decimal _discountPercent;
        private decimal _grandTotal;
        private readonly List<Receipt.ReceiptLine> _lines = new();

        public ReceiptBuilder WithSaleId(int saleId) { _saleId = saleId; return this; }
        public ReceiptBuilder WithPrintedAt(DateTime at) { _printedAt = at; return this; }
        public ReceiptBuilder WithTotals(decimal total, decimal discountPercent, decimal grandTotal)
        {
            _total = total; _discountPercent = discountPercent; _grandTotal = grandTotal;
            return this;
        }
        public ReceiptBuilder WithLines(IEnumerable<Receipt.ReceiptLine> lines)
        {
            _lines.Clear();
            _lines.AddRange(lines);
            return this;
        }

        public Receipt Build() => new Receipt
        {
            SaleId = _saleId,
            PrintedAt = _printedAt,
            Total = _total,
            DiscountPercent = _discountPercent,
            GrandTotal = _grandTotal,
            Lines = _lines
        };
    }

    internal static class UIExtensions
    {
        /// <summary>Rounded corner buttons without flicker.</summary>
        public static void ApplyRoundedCorners(this Control owner, Button btn, int radius = 8)
        {
            btn.Resize += (_, __) =>
            {
                if (btn.Width <= 0 || btn.Height <= 0) return;
                using var gp = new GraphicsPath();
                gp.StartFigure();
                gp.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                gp.AddArc(new Rectangle(btn.Width - radius, 0, radius, radius), 270, 90);
                gp.AddArc(new Rectangle(btn.Width - radius, btn.Height - radius, radius, radius), 0, 90);
                gp.AddArc(new Rectangle(0, btn.Height - radius, radius, radius), 90, 90);
                gp.CloseFigure();
                btn.Region = new Region(gp);
            };
            // fire once for initial layout
            btn.PerformLayout();
        }

        public static void ApplyRoundedCorners(this Control owner) { /* reserved */ }
    }

    internal static class Guard
    {
        public static void True(bool condition, string message)
        {
            if (!condition) throw new InvalidOperationException(message);
        }

        public static void NotNull(object? obj, string message)
        {
            if (obj is null) throw new InvalidOperationException(message);
        }
    }

    public sealed class ComboItem
    {
        public int Id { get; }
        public string Text { get; }
        public ComboItem(int id, string text) { Id = id; Text = text; }
        public override string ToString() => Text;
    }

    #endregion
}
