using CafeShopManagement.Models;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CafeShopManagement.Utils
{
    /// <summary>
    /// 80mm thermal receipt for the *simple* Receipt model:
    /// ShopName, ShopAddress, SaleId, PrintedAt, Lines, Total, DiscountPercent, GrandTotal, FooterNote.
    /// </summary>
    public sealed class ReceiptPrinter
    {
        private static PaperSize Thermal80(int h = 500) => new PaperSize("80mm", 300, h);

        // 👇 just the width we use for the Amount column (header + values)
        private const float AmountColWidth = 65f; // was 50f

        public void Preview(Receipt r)
        {
            using var dlg = new PrintPreviewDialog { Document = Build(r), Width = 900, Height = 700 };
            dlg.ShowDialog();
        }

        public void Print(Receipt r)
        {
            using var dlg = new PrintDialog { Document = Build(r), UseEXDialog = true };
            if (dlg.ShowDialog() == DialogResult.OK) dlg.Document.Print();
        }

        private PrintDocument Build(Receipt r)
        {
            var doc = new PrintDocument
            {
                DefaultPageSettings = new PageSettings
                {
                    PaperSize = Thermal80(),
                    Margins = new Margins(10, 10, 10, 10)
                }
            };
            doc.PrintPage += (_, e) => Draw(e, r);
            return doc;
        }

        private static void Draw(PrintPageEventArgs e, Receipt r)
        {
            var g = e.Graphics;
            float xL = e.MarginBounds.Left;
            float xR = e.MarginBounds.Right;
            float y = e.MarginBounds.Top;

            using var fTitle = new Font("Segoe UI", 12, FontStyle.Bold);
            using var fB = new Font("Segoe UI", 9, FontStyle.Bold);
            using var f = new Font("Segoe UI", 9);

            // Header
            Center(g, r.ShopName, fTitle, xL, xR, ref y);
            Center(g, r.ShopAddress, f, xL, xR, ref y);
            y += 4;

            // Meta
            DrawLeft(g, $"Receipt: #{r.SaleId}", f, xL, ref y);
            DrawLeft(g, $"Date: {r.PrintedAt:dd/MM/yyyy HH:mm}", f, xL, ref y);
            y = Sep(g, xL, xR, y);

            // Table header
            DrawLeft(g, "Item", fB, xL, ref y);
            DrawCenter(g, "Qty", fB, xL + 110, 40, y - fB.GetHeight(g));
            DrawRight(g, "Price", fB, xR - 80, 40, y - fB.GetHeight(g));
            DrawRight(g, "Amount", fB, xR - 10, AmountColWidth, y - fB.GetHeight(g)); // width widened
            y += 2;
            y = Sep(g, xL, xR, y);

            // Lines
            foreach (var line in r.Lines)
            {
                // Item name wraps; numbers align to the same row baseline
                float rowTop = y;
                var usedH = DrawWrapped(g, line.ProductName, f, xL, 160, y);
                var baseY = rowTop + (usedH - f.GetHeight(g)) / 2f;

                DrawCenter(g, line.Quantity.ToString(), f, xL + 110, 40, baseY);
                DrawRight(g, line.Price.ToString("C2"), f, xR - 80, 40, baseY);
                DrawRight(g, line.Subtotal.ToString("C2"), f, xR - 10, AmountColWidth, baseY); // width widened

                y = rowTop + usedH + 2;
            }

            y = Sep(g, xL, xR, y);

            // Totals
            DrawRight(g, "Total:", fB, xR - 80, 70, y);
            DrawRight(g, r.Total.ToString("C2"), fB, xR - 10, 80, y);
            y += fB.GetHeight(g) + 4;

            var discountAmt = r.Total * (r.DiscountPercent / 100m);
            DrawRight(g, $"Discount ({r.DiscountPercent:0.#}%):", f, xR - 80, 70, y);
            DrawRight(g, discountAmt == 0 ? "$0.00" : $"-{discountAmt:C2}", f, xR - 10, 80, y);
            y += f.GetHeight(g) + 4;

            DrawRight(g, "Grand Total:", fB, xR - 80, 70, y);
            DrawRight(g, r.GrandTotal.ToString("C2"), fB, xR - 10, 80, y);
            y += fB.GetHeight(g) + 8;

            y = Sep(g, xL, xR, y);

            // Footer
            Center(g, r.FooterNote, f, xL, xR, ref y);
        }

        // ---- small drawing helpers ----
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
            y += f.GetHeight(g);
        }

        private static void DrawCenter(Graphics g, string text, Font f, float x, float w, float y)
        {
            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near, Trimming = StringTrimming.Word };
            g.DrawString(text, f, Brushes.Black, new RectangleF(x, y, w, f.GetHeight(g) + 2), sf);
        }

        private static void DrawRight(Graphics g, string text, Font f, float x, float w, float y)
        {
            using var sf = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near, Trimming = StringTrimming.Word };
            g.DrawString(text, f, Brushes.Black, new RectangleF(x - w, y, w, f.GetHeight(g) + 2), sf);
        }

        private static float DrawWrapped(Graphics g, string text, Font f, float x, float w, float y)
        {
            using var sf = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near, Trimming = StringTrimming.Word };
            var size = g.MeasureString(text, f, new SizeF(w, 1000), sf);
            g.DrawString(text, f, Brushes.Black, new RectangleF(x, y, w, size.Height), sf);
            return size.Height;
        }

        private static float Sep(Graphics g, float xL, float xR, float y)
        {
            g.DrawLine(Pens.Black, xL, y, xR, y);
            return y + 6;
        }
    }
}
