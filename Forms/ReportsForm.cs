using CafeShopManagement.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CafeShopManagement.Forms
{
    public partial class ReportsForm : Form
    {
        private List<PeriodRow> _summary = new();
        private List<TopProductRow> _topProducts = new();

        private DateTime _from;
        private DateTime _to;
        private string _groupLabel = "Daily";

        private readonly ReportPrinter _printer = new ReportPrinter();

        public ReportsForm()
        {
            InitializeComponent();

            // defaults
            _from = DateTime.Today;
            _to = DateTime.Today;

            cbGroup.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly" });
            cbGroup.SelectedIndex = 0;

            dtFrom.Value = _from;
            dtTo.Value = _to;

            btnLoad.Click += (_, __) => LoadReport();
            btnPrint.Click += (_, __) => PrintReport();
        }

        private void LoadReport()
        {
            _from = dtFrom.Value.Date;
            _to = dtTo.Value.Date;
            _groupLabel = cbGroup.SelectedItem?.ToString() ?? "Daily";

            using var conn = Data.Connection.Open();

            // ---- summary
            using (var cmd = new NpgsqlCommand(@"
                SELECT to_char(sale_date, CASE
                    WHEN @grp='Daily'   THEN 'YYYY-MM-DD'
                    WHEN @grp='Weekly'  THEN 'IYYY-IW'
                    WHEN @grp='Monthly' THEN 'YYYY-MM'
                    ELSE 'YYYY'
                END) AS period,
                COUNT(*) AS receipts,
                COALESCE(SUM( (SELECT COALESCE(SUM(si.quantity),0)
                                FROM sale_items si WHERE si.sale_id=s.id)),0) AS items,
                COALESCE(SUM(total),0) AS total,
                COALESCE(SUM(discount),0) AS discount,
                COALESCE(SUM(grand_total), SUM(total)) AS grand_total
                FROM sales s
                WHERE sale_date::date BETWEEN @from AND @to
                GROUP BY period
                ORDER BY period;", conn))
            {
                cmd.Parameters.AddWithValue("@from", _from);
                cmd.Parameters.AddWithValue("@to", _to);
                cmd.Parameters.AddWithValue("@grp", _groupLabel);

                using var rd = cmd.ExecuteReader();
                var tmp = new List<PeriodRow>();
                while (rd.Read())
                {
                    tmp.Add(new PeriodRow
                    {
                        Period = rd.GetString(0),
                        Receipts = Convert.ToInt32(rd.GetValue(1)),
                        Items = Convert.ToInt32(rd.GetValue(2)),
                        Total = rd.IsDBNull(3) ? 0 : rd.GetDecimal(3),
                        Discount = rd.IsDBNull(4) ? 0 : rd.GetDecimal(4),
                        GrandTotal = rd.IsDBNull(5) ? 0 : rd.GetDecimal(5)
                    });
                }
                _summary = tmp;
            }

            // ---- top products
            using (var cmd = new NpgsqlCommand(@"
                SELECT p.name, SUM(si.quantity) AS qty, SUM(si.subtotal) AS amount
                FROM sale_items si
                JOIN sales s ON s.id = si.sale_id
                JOIN products p ON p.id = si.product_id
                WHERE s.sale_date::date BETWEEN @from AND @to
                GROUP BY p.name
                ORDER BY amount DESC;", conn))
            {
                cmd.Parameters.AddWithValue("@from", _from);
                cmd.Parameters.AddWithValue("@to", _to);

                using var rd = cmd.ExecuteReader();
                var tmp = new List<TopProductRow>();
                while (rd.Read())
                {
                    tmp.Add(new TopProductRow
                    {
                        Product = rd.GetString(0),
                        Qty = Convert.ToInt32(rd.GetValue(1)),
                        Amount = rd.IsDBNull(2) ? 0 : rd.GetDecimal(2)
                    });
                }
                _topProducts = tmp;
            }

            // bind to grids
            dgvSummary.AutoGenerateColumns = true;
            dgvSummary.DataSource = new BindingList<PeriodRow>(_summary);

            dgvTop.AutoGenerateColumns = true;
            dgvTop.DataSource = new BindingList<TopProductRow>(_topProducts);
        }

        private void PrintReport()
        {
            if (_summary.Count == 0 && _topProducts.Count == 0)
            {
                MessageBox.Show("No data to print. Load a report first.");
                return;
            }

            var model = new ReportModel
            {
                From = _from,
                To = _to,
                GroupLabel = _groupLabel,
                Summary = _summary.ToList(),
                TopProducts = _topProducts.ToList()
            };

            _printer.Print(model); // or _printer.Preview(model);
        }
    }
}
