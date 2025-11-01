using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace CafeShopManagement.Utils
{
    // Immutable snapshot sent to the printer
    public sealed class ReportModel
    {
        public DateTime From { get; init; }
        public DateTime To { get; init; }
        public string GroupLabel { get; init; } = "Daily";
        public IReadOnlyList<PeriodRow> Summary { get; init; } = Array.Empty<PeriodRow>();
        public IReadOnlyList<TopProductRow> TopProducts { get; init; } = Array.Empty<TopProductRow>();
    }

    public sealed class PeriodRow
    {
        public string Period { get; init; } = "";
        public int Receipts { get; init; }
        public int Items { get; init; }
        public decimal Total { get; init; }
        public decimal Discount { get; init; }
        public decimal GrandTotal { get; init; }
    }

    public sealed class TopProductRow
    {
        public string Product { get; init; } = "";
        public int Qty { get; init; }
        public decimal Amount { get; init; }
    }

    public sealed class ReportPrinter
    {
        public void Preview(ReportModel model)
        {
            using var dlg = new PrintPreviewDialog
            {
                Document = Build(model),
                Width = 900,
                Height = 700
            };
            dlg.ShowDialog();
        }

        public void Print(ReportModel model)
        {
            using var dlg = new PrintDialog { UseEXDialog = true, Document = Build(model) };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Optional: doc.PrintController = new StandardPrintController(); // silent
                dlg.Document.Print();
            }
        }

        private static PaperSize A4Portrait() => new PaperSize("A4", 827, 1169); // ~96dpi

        private PrintDocument Build(ReportModel model)
        {
            var doc = new PrintDocument
            {
                DefaultPageSettings = new PageSettings
                {
                    PaperSize = A4Portrait(),
                    Margins = new Margins(60, 60, 60, 60)
                }
            };
            doc.PrintPage += (_, e) => Draw(e, model);
            return doc;
        }

        private static void Draw(PrintPageEventArgs e, ReportModel m)
        {
            var g = e.Graphics;
            float xL = e.MarginBounds.Left;
            float xR = e.MarginBounds.Right;
            float y = e.MarginBounds.Top;

            using var fTitle = new Font("Segoe UI", 12, FontStyle.Bold);
            using var fB = new Font("Segoe UI", 9, FontStyle.Bold);
            using var f = new Font("Segoe UI", 9);

            // Title
            Center(g, "Café Shop — Reports", fTitle, xL, xR, ref y);
            y += 6;

            // Range + group
            DrawLeft(g, $"Range: {m.From:yyyy-MM-dd} → {m.To:yyyy-MM-dd}   •   Group: {m.GroupLabel}", f, xL, ref y);
            y = Sep(g, xL, xR, y);

            // Sales summary
            DrawLeft(g, "Sales Summary", fB, xL, ref y);
            var cols1 = new[] { 170f, 75f, 75f, 90f, 90f, 100f };
            TableHeader(g, new[] { "Period", "Receipts", "Items", "Total", "Discount", "Grand Total" }, fB, f, xL, xR, ref y, cols1);

            foreach (var r in m.Summary)
            {
                TableRow(g, new[]
                {
                    r.Period,
                    r.Receipts.ToString(),
                    r.Items.ToString(),
                    r.Total.ToString("C2"),
                    r.Discount.ToString("C2"),
                    r.GrandTotal.ToString("C2")
                }, f, xL, xR, ref y, cols1);
            }

            y = Sep(g, xL, xR, y);

            // Top products
            DrawLeft(g, "Top Products", fB, xL, ref y);
            var cols2 = new[] { 380f, 60f, 90f }; // give enough width for “Amount”
            TableHeader(g, new[] { "Product", "Qty", "Amount" }, fB, f, xL, xR, ref y, cols2);

            foreach (var p in m.TopProducts)
            {
                TableRow(g, new[]
                {
                    p.Product,
                    p.Qty.ToString(),
                    p.Amount.ToString("C2")
                }, f, xL, xR, ref y, cols2);
            }
        }

        // -------------- drawing helpers -----------------

        private static void Center(Graphics g, string text, Font f, float xL, float xR, ref float y)
        {
            var size = g.MeasureString(text, f, (int)(xR - xL));
            float x = xL + ((xR - xL) - size.Width) / 2f;
            g.DrawString(text, f, Brushes.Black, x, y);
            y += size.Height;
        }

        private static void DrawLeft(Graphics g, string text, Font f, float x, ref float y)
        {
            g.DrawString(text, f, Brushes.Black, x, y);
            y += f.GetHeight(g) + 2;
        }

        private static float Sep(Graphics g, float xL, float xR, float y)
        {
            g.DrawLine(Pens.Black, xL, y, xR, y);
            return y + 6;
        }

        private static void TableHeader(Graphics g, string[] headers, Font fB, Font f, float xL, float xR, ref float y, float[] widths)
        {
            float x = xL;
            for (int i = 0; i < headers.Length; i++)
            {
                using var sf = new StringFormat
                {
                    Alignment = i == 0 ? StringAlignment.Near : StringAlignment.Far,
                    LineAlignment = StringAlignment.Near
                };
                g.DrawString(headers[i], fB, Brushes.Black, new RectangleF(x, y, widths[i], fB.GetHeight(g) + 4), sf);
                x += widths[i];
            }
            y += fB.GetHeight(g) + 4;
            g.DrawLine(Pens.Black, xL, y, xR, y);
            y += 4;
        }

        private static void TableRow(Graphics g, string[] cells, Font f, float xL, float xR, ref float y, float[] widths)
        {
            float x = xL;
            for (int i = 0; i < cells.Length; i++)
            {
                using var sf = new StringFormat
                {
                    Alignment = i == 0 ? StringAlignment.Near : StringAlignment.Far,
                    LineAlignment = StringAlignment.Near,
                    Trimming = StringTrimming.EllipsisCharacter
                };
                g.DrawString(cells[i], f, Brushes.Black, new RectangleF(x, y, widths[i], f.GetHeight(g) + 4), sf);
                x += widths[i];
            }
            y += f.GetHeight(g) + 4;
        }
    }
}
