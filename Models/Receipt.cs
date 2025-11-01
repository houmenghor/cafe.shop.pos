using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeShopManagement.Models
{
    /// <summary>
    /// Simple receipt model used by SalesForm and ReceiptPrinter.
    /// </summary>
    public sealed class Receipt
    {
        // Branding (your printer reads these; defaults are fine if you don't set them)
        public string ShopName { get; set; } = "Cafe Shop";
        public string ShopAddress { get; set; } = "Phnom Penh";
        public string FooterNote { get; set; } = "Thank you! See you again.";

        // Identity / time
        public int SaleId { get; set; }
        public DateTime PrintedAt { get; set; } = DateTime.Now;

        // Money
        public decimal Total { get; set; }                 // before discount
        public decimal DiscountPercent { get; set; }       // 0..100
        public decimal GrandTotal { get; set; }            // after discount

        // Lines
        public List<ReceiptLine> Lines { get; set; } = new();

        // Convenience (not required by SalesForm, but handy)
        public decimal DiscountAmount => Math.Round(Total * (DiscountPercent / 100m), 2);

        public sealed class ReceiptLine
        {
            public string ProductName { get; set; } = "";
            public int Quantity { get; set; }
            public decimal Price { get; set; }              // unit price
            public decimal Subtotal => Price * Quantity;    // computed
        }
    }
}
