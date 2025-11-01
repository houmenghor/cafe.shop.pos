using CafeShopManagement.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace CafeShopManagement.Data
{
    public interface IReportsRepository
    {
        List<SalesSummaryRow> GetSalesSummary(DateTime fromInclusive, DateTime toExclusive, ReportBucket bucket);
        List<TopProductRow> GetTopProducts(DateTime fromInclusive, DateTime toExclusive, int topN = 10);
    }

    public sealed class ReportsRepository : IReportsRepository
    {
        public List<SalesSummaryRow> GetSalesSummary(DateTime fromInclusive, DateTime toExclusive, ReportBucket bucket)
        {
            string bucketText = bucket switch
            {
                ReportBucket.Daily => "day",
                ReportBucket.Weekly => "week",
                ReportBucket.Monthly => "month",
                ReportBucket.Yearly => "year",
                _ => "day"
            };

            string sql = $@"
                SELECT
                    date_trunc('{bucketText}', s.sale_date)::date AS period,
                    COUNT(DISTINCT s.id) AS receipts,
                    COALESCE(SUM(si.quantity), 0) AS items,
                    SUM(s.total)        AS total,
                    SUM(s.discount)     AS discount,
                    SUM(s.grand_total)  AS grand_total
                FROM sales s
                LEFT JOIN sale_items si ON si.sale_id = s.id
                WHERE s.sale_date >= @from AND s.sale_date < @to
                GROUP BY 1
                ORDER BY 1;";

            using var conn = Connection.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@from", fromInclusive);
            cmd.Parameters.AddWithValue("@to", toExclusive);

            using var rd = cmd.ExecuteReader();
            var list = new List<SalesSummaryRow>();
            while (rd.Read())
            {
                list.Add(new SalesSummaryRow
                {
                    Period = rd.GetDateTime(0),
                    Receipts = rd.GetInt32(1),
                    Items = rd.GetInt32(2),
                    Total = rd.IsDBNull(3) ? 0m : rd.GetDecimal(3),
                    Discount = rd.IsDBNull(4) ? 0m : rd.GetDecimal(4),
                    GrandTotal = rd.IsDBNull(5) ? 0m : rd.GetDecimal(5),
                });
            }
            return list;
        }

        public List<TopProductRow> GetTopProducts(DateTime fromInclusive, DateTime toExclusive, int topN = 10)
        {
            const string sql = @"
                SELECT p.name,
                       SUM(si.quantity) AS qty,
                       SUM(si.subtotal) AS amount
                FROM sale_items si
                JOIN sales    s ON s.id = si.sale_id
                JOIN products p ON p.id = si.product_id
                WHERE s.sale_date >= @from AND s.sale_date < @to
                GROUP BY p.name
                ORDER BY qty DESC, amount DESC
                LIMIT @top;";

            using var conn = Connection.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@from", fromInclusive);
            cmd.Parameters.AddWithValue("@to", toExclusive);
            cmd.Parameters.AddWithValue("@top", topN);

            using var rd = cmd.ExecuteReader();
            var list = new List<TopProductRow>();
            while (rd.Read())
            {
                list.Add(new TopProductRow
                {
                    ProductName = rd.GetString(0),
                    Quantity = rd.IsDBNull(1) ? 0 : rd.GetInt32(1),
                    Amount = rd.IsDBNull(2) ? 0m : rd.GetDecimal(2),
                });
            }
            return list;
        }
    }
}
