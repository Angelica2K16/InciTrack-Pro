using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;

namespace InciTrack_Pro.Forms
{
    public partial class Frm_Hazards : Form
    {
        public Frm_Hazards()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_Hazards_Load;
        }

        private void Frm_Hazards_Load(object? sender, EventArgs e)
        {
            flpKpiControls();

            cb_apReports.Checked = false;

            //LoadDgvHazardsList();
        }

        private void flpKpiControls()
        {
            flp_Kpi.Controls.Clear();

            var (HazardsYtdCount, HazardsMonthCount, lastHazardCount) = GetCountData();

            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month);

            flp_Kpi.Controls.Add(CreateKpiCard(DateTime.Now.Year + " Hazards Reported", HazardsYtdCount, Color.Firebrick));
            flp_Kpi.Controls.Add(CreateKpiCard($"{monthName} Hazards Reported", HazardsMonthCount, Color.Firebrick));
            flp_Kpi.Controls.Add(CreateKpiCard("Days Since Last Hazard Reported", lastHazardCount, Color.Firebrick));
            CreateTop3AreasChart();

        }

        private (int HazardsYtdCount, int HazardsMonthCount, int lastHazardCount) GetCountData()
        {
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                string sql = @"
                                SELECT
                                (
                                    SELECT
                                    COUNT(*)
                                    FROM Hazards
                                    WHERE strftime('%Y',Date) = strftime('%Y', 'now')
                                ) AS HazardsYtdCount,
                                (
                                     SELECT
                                     COUNT(*)
                                     FROM Hazards
                                     WHERE strftime('%Y-%m',Date) = strftime('%Y-%m', 'now')
                                ) AS HazardsMonthCount,
                                (
                                      SELECT CAST (
                                      julianday ('now') -
                                      julianday (MAX(Date))
                                      AS Integer
                                      )
                                      FROM Hazards
                                      WHERE Date <= date('now')
                                ) AS lastHazardCount;
                            ";



                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    using (SqliteDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                        {
                            return (
                                    Convert.ToInt32(dr["HazardsYtdCount"]),
                                    Convert.ToInt32(dr["HazardsMonthCount"]),
                                    Convert.ToInt32(dr["lastHazardCount"])
                                    );
                        }


                    }

                }

            }
            return (0, 0, 0);
        }

        private Panel CreateKpiCard(string title, int value, Color cardColor)
        {
            Panel card = new Panel
            {
                Width = 175,
                Height = 100,
                BackColor = cardColor,
                Margin = new Padding(10),
                Cursor = Cursors.Hand

            };

            Label lblTitle = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 30,
                ForeColor = Color.White,
                Font = new Font("Calibri", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblValue = new Label
            {
                Text = value.ToString(),
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Calibri", 24, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };


            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);

            return card;

        }

        private void CreateTop3AreasChart()
        {
            var data = GetTop3Areas();

            string[] labels = data.Keys.ToArray();
            int[] values = data.Values.ToArray();

            Panel pnlChart = new Panel
            {
                Dock = DockStyle.Fill
            };

            Label lblTitle = new Label
            {
                Text = "Top 3 Areas",
                Dock = DockStyle.Top,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Calibri", 14, FontStyle.Bold),
                ForeColor = Color.White
            };

            CartesianChart chart = new CartesianChart
            {
                Dock = DockStyle.Fill
            };

            chart.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Values = values,
                    Name = "First Aids"
                }
            };

            chart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels,
                    TextSize = 12
                }
            };

            pnlChart.Controls.Add(chart);
            pnlChart.Controls.Add(lblTitle);
            tableLayoutPanel2.Controls.Add(pnlChart, 0, 1);
        }

        private Dictionary<string, int> GetTop3Areas()
        {
            Dictionary<string, int> areas = new();

            using SqliteConnection conn =
            new SqliteConnection(GV.shesDB);

            conn.Open();

            string sql = @"
                            SELECT
                            Area,
                            COUNT(*) AS Total
                            FROM FIRST_AIDS
                            WHERE strftime('%Y',[Date]) =
                            strftime('%Y','now')
                            GROUP BY Area
                            ORDER BY Total DESC
                            LIMIT 3;";

            using SqliteCommand cmd = new SqliteCommand(sql, conn);

            using SqliteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                areas.Add(
                dr["Area"].ToString()!,
                Convert.ToInt32(dr["Total"]));
            }

            return areas;
        }
    }
}
