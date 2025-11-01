using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CafeShopManagement.Data
{
    internal static class DashboardRepository
    {
        // 💰 Total sales amount
        public static decimal GetTotalSales()
        {
            using (var conn = Connection.Open())
            using (var cmd = new NpgsqlCommand("SELECT COALESCE(SUM(total), 0) FROM sales;", conn))
            {
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        // 🧾 Total number of orders (receipts)
        public static int GetTotalOrders()
        {
            using (var conn = Connection.Open())
            using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM sales;", conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // 📦 Total products in menu
        public static int GetTotalProducts()
        {
            using (var conn = Connection.Open())
            using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM products;", conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // 🧮 Total number of individual items sold
        public static int GetTotalProductsSold()
        {
            using var conn = Connection.Open();
            using var cmd = new NpgsqlCommand("SELECT COALESCE(SUM(quantity), 0) FROM sale_items;", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // 📊 Daily sales and quantity chart (Full Week: Monday → Sunday)
        public static (string[] labels, double[] salesValues, double[] qtyValues) GetSalesAndQuantityPerDay()
        {
            // All 7 days in order
            string[] weekDays = new[]
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };

            // Initialize all days with 0 values
            var salesMap = new Dictionary<string, double>();
            var qtyMap = new Dictionary<string, double>();
            foreach (var day in weekDays)
            {
                salesMap[day] = 0;
                qtyMap[day] = 0;
            }

            using var conn = Connection.Open();
            string query = @"
                SELECT 
                    TO_CHAR(s.sale_date, 'FMDay') AS day_name,
                    COALESCE(SUM(s.total), 0) AS total_amount,
                    COALESCE(SUM(si.quantity), 0) AS total_qty
                FROM sales s
                LEFT JOIN sale_items si ON s.id = si.sale_id
                WHERE s.sale_date >= NOW() - INTERVAL '7 days'
                GROUP BY day_name, EXTRACT(DOW FROM s.sale_date)
                ORDER BY EXTRACT(DOW FROM s.sale_date);
            ";

            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            // Fill data for existing sales
            while (reader.Read())
            {
                string dayName = reader.GetString(0).Trim();
                dayName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dayName.ToLower()); // Format properly
                double totalSales = Convert.ToDouble(reader.GetDecimal(1));
                double totalQty = Convert.ToDouble(reader.GetDecimal(2));

                if (salesMap.ContainsKey(dayName))
                {
                    salesMap[dayName] = totalSales;
                    qtyMap[dayName] = totalQty;
                }
            }

            // Return ordered data
            var labels = new List<string>();
            var salesValues = new List<double>();
            var qtyValues = new List<double>();

            foreach (var day in weekDays)
            {
                labels.Add(day);
                salesValues.Add(salesMap[day]);
                qtyValues.Add(qtyMap[day]);
            }

            return (labels.ToArray(), salesValues.ToArray(), qtyValues.ToArray());
        }
    }
}
