using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TP.control;

namespace TP
{
    public partial class rateofreturn : Form
    {
        DataTable currentYearData = new DataTable();
        DataTable lastYearData = new DataTable();
        salesfiguresController salesfiguresController = new salesfiguresController();
        DateTime today = DateTime.Today;

        public rateofreturn()
        {
            InitializeComponent();
            int thisYear = today.Year;
            currentYearData = salesfiguresController.getMargin(thisYear);
            lastYearData = salesfiguresController.getMargin(thisYear - 1);
            chart1.ChartAreas.Add(new ChartArea());

            Series currentYearSeries = new Series("이번 년도");
            currentYearSeries.ChartType = SeriesChartType.Line;
            Series lastYearSeries = new Series("저번 년도");
            lastYearSeries.ChartType = SeriesChartType.Line;

            foreach (DataRow row in currentYearData.Rows)
            {
                int month = (int)row["월"];
                decimal totalSales = (decimal)row["총판매액"];
                decimal totalCost = (decimal)row["총원가"];
                decimal profit = totalSales - totalCost;
                decimal profitRate = totalSales != 0 ? profit / totalSales * 100 : 0;

                currentYearSeries.Points.AddXY(month, profitRate); // 또는 profit
            }

            foreach (DataRow row in lastYearData.Rows)
            {
                int month = (int)row["월"];
                decimal totalSales = (decimal)row["총판매액"];
                decimal totalCost = (decimal)row["총원가"];
                decimal profit = totalSales - totalCost;
                decimal profitRate = totalSales != 0 ? profit / totalSales * 100 : 0;

                lastYearSeries.Points.AddXY(month, profitRate); // 또는 profit
            }
            chart1.Series.Add(currentYearSeries);
            chart1.Series.Add(lastYearSeries);
        }

    }
}
