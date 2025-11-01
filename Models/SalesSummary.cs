using System;

namespace CafeShopManagement.Models
{
    public enum ReportBucket { Daily, Weekly, Monthly, Yearly }

    public sealed class SalesSummaryRow
    {
        public DateTime Period { get; set; }          // start of day/week/month/year
        public int Receipts { get; set; }        // number of receipts
        public int Items { get; set; }           // total items sold
        public decimal Total { get; set; }           // before discount
        public decimal Discount { get; set; }        // discount amount (money)
        public decimal GrandTotal { get; set; }      // after discount
    }

    public sealed class TopProductRow
    {
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal Amount { get; set; }           // sum of subtotals
    }
}
