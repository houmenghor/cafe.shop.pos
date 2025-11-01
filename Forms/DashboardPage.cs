using CafeShopManagement.Data;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CafeShopManagement.Forms
{
    public partial class DashboardPage : Form
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private void DashboardPage_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            LoadDashboardData();
            LoadSalesChart();
        }

        // 🧾 Load all top-card data (Total Sales, Orders, Products, etc.)
        private void LoadDashboardData()
        {
            try
            {
                lblSalesValue.Text = $"${DashboardRepository.GetTotalSales():N2}";
                lblOrdersValue.Text = DashboardRepository.GetTotalOrders().ToString();
                lblProductsValue.Text = DashboardRepository.GetTotalProducts().ToString();

                // Replace “Customers” with “Items Sold” for offline POS
                lblCustomersTitle.Text = "Items Sold";
                lblCustomersValue.Text = DashboardRepository.GetTotalProductsSold().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Failed to load dashboard data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 📊 Load daily sales chart (Sales $ + Quantity)
        private void LoadSalesChart()
        {
            try
            {
                var chart = new CartesianChart
                {
                    Dock = DockStyle.Fill
                };

                // Get both data sets
                var (labels, salesValues, qtyValues) = DashboardRepository.GetSalesAndQuantityPerDay();

                // Default empty view if no data
                if (labels.Length == 0)
                {
                    labels = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
                    salesValues = new double[] { 0, 0, 0, 0, 0, 0, 0 };
                    qtyValues = new double[] { 0, 0, 0, 0, 0, 0, 0 };
                }

                // Two-bar chart: Sales ($) and Items Sold
                chart.Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Name = "Sales ($)",
                        Values = salesValues,
                        Fill = new SolidColorPaint(new SKColor(0, 123, 255)), // blue
                        DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                        DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top
                    },
                    new ColumnSeries<double>
                    {
                        Name = "Items Sold",
                        Values = qtyValues,
                        Fill = new SolidColorPaint(new SKColor(40, 167, 69)), // green
                        DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                        DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top
                    }
                };

                chart.XAxes = new[]
                {
                    new Axis
                    {
                        Labels = labels,
                        Name = "Days",
                        LabelsPaint = new SolidColorPaint(SKColors.Black)
                    }
                };

                chart.YAxes = new[]
                {
                    new Axis
                    {
                        Name = "Total ($) / Qty",
                        LabelsPaint = new SolidColorPaint(SKColors.Black)
                    }
                };

                chart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;

                panelChart.Controls.Clear();
                panelChart.Controls.Add(chart);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Chart load error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
