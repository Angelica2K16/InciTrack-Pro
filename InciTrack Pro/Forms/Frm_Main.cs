using Guna.UI2.WinForms;
using InciTrack_Pro.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.Themes;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace InciTrack_Pro
{
    public partial class Frm_Main : Form
    {
        public static string shesDB = @"DataSource=G:\Public\Production Software\Released Applications\SHES\SQL DB\SHES_DataBoard.db";
        public Frm_Main()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_Main_Load;
        }

        private void Frm_Main_Load(object? sender, EventArgs e)
        {
            flpKpiControls();
            LoadButtons();
            LoadCharts();

        }

        private void flpKpiControls()
        {
            flp_Kpi.Controls.Clear();

            var (hazardCount, firstAidCount, ltiCount) = GetCountData();

            flp_Kpi.Controls.Add(CreateKpiCard(DateTime.Now.Year + " Hazards", hazardCount,Color.Firebrick,(s, e) =>{new Frm_Hazards().ShowDialog();}));
            flp_Kpi.Controls.Add(CreateKpiCard(DateTime.Now.Year + " First Aids", firstAidCount, Color.Firebrick, (s, e) => { new Frm_FirstAids().ShowDialog(); }));
            flp_Kpi.Controls.Add(CreateKpiCard("Days Since Last LTI", ltiCount, Color.ForestGreen, null));

        }

        private (int firstAidCount, int hazardCount, int ltiCount) GetCountData()
        {
            using (SqliteConnection conn = new SqliteConnection(shesDB))
            {
                conn.Open();

                string sql = @"
                                SELECT
                                (
                                    SELECT
                                    COUNT(*)
                                    FROM Hazards
                                    WHERE strftime('%Y',Date) = strftime('%Y', 'now')
                                ) AS HazardCount,
                                (
                                     SELECT
                                     COUNT(*)
                                     FROM FIRST_AIDS
                                     WHERE strftime('%Y',Date) = strftime('%Y', 'now')
                                ) AS FirstAidCount,
                                (
                                      SELECT CAST (
                                      julianday ('now') -
                                      julianday (MAX(Date))
                                      AS Integer
                                      )
                                      FROM LOST_TIME_INCIDENT
                                ) AS LtiCount;
                            ";

                            

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    using (SqliteDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                        {
                            return (
                                    Convert.ToInt32(dr["HazardCount"]),
                                    Convert.ToInt32(dr["FirstAidCount"]),
                                    Convert.ToInt32(dr["LtiCount"])
                                    );
                        }

                        
                    }

                }

            }
            return (0,0,0);
        }

        private Panel CreateKpiCard(string title, int value, Color cardColor, EventHandler? clickHandler)
        {
            Panel card = new Panel
            {
                Width = 220,
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

            card.Click += clickHandler;
            lblTitle.Click += clickHandler;
            lblValue.Click += clickHandler;

            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);

            return card;

        }

        private void LoadButtons()
        {
            AddMenuButton("Hazards",
(s, e) => new Frm_Hazards().ShowDialog());

            AddMenuButton("First Aids",
            (s, e) => new Frm_FirstAids().ShowDialog());

            AddMenuButton("Reports",
            (s, e) => MessageBox.Show("Reports"));

            AddMenuButton("Admin",
            (s, e) => MessageBox.Show("Admin"));
        }

        private void AddMenuButton(
string text,
EventHandler clickEvent)
        {
            Guna2Button btn = CreateMenuButton(text);

            btn.Click += clickEvent;

            flp_menu.Controls.Add(btn);
        }
        private Guna2Button CreateMenuButton(string text)
        {
            return new Guna2Button
            {
                Text = text,
                Width = 190,
                Height = 45,
                BorderRadius = 10,
                FillColor = Color.Firebrick,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Margin = new Padding(10, 5, 10, 5),
                Cursor = Cursors.Hand
            };
        }

        private void LoadCharts()
        {
            string[] monthNames =
            {
                "Jan", "Feb", "Mar", "Apr",
                "May", "Jun", "Jul", "Aug",
                "Sep", "Oct", "Nov", "Dec"
            };

            int[] hazardCounts =
            GetMonthlyCounts("Hazards");

            int[] firstAidCounts =
            GetMonthlyCounts("First_Aids");

            CreateChart(
            $"Hazards by Month ({DateTime.Now.Year})",
            monthNames,
            hazardCounts,
            0,
            0);

            CreateChart(
            $"First Aids by Month ({DateTime.Now.Year})",
            monthNames,
            firstAidCounts,
            1,
            0);
        }

        private int[] GetMonthlyCounts(string tableName)
        {
            int[] counts = new int[12];

            using (SqliteConnection conn = new SqliteConnection(shesDB))
            {
                conn.Open();

                string sql = $@"
                                SELECT
                                strftime('%m', Date) AS Month,
                                COUNT(*) AS Total
                                FROM {tableName}
                                WHERE strftime('%Y', Date) = @Year
                                GROUP BY strftime('%m', Date);";

                using SqliteCommand cmd = new SqliteCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                "@Year",
                DateTime.Now.Year.ToString());

                using SqliteDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int monthIndex =
                    Convert.ToInt32(dr["Month"]) - 1;

                    counts[monthIndex] =
                    Convert.ToInt32(dr["Total"]);
                }
            }

            return counts;
        }

        private void CreateChart(string title,string[] monthNames,int[] values,int column,int row)
        {
            CartesianChart chart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Title = new LabelVisual
                {
                    Text = title,
                    TextSize = 20
                }
            };

            chart.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Values = values
                }
            };

            chart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = monthNames
                }
            };

            tableLayoutPanel1.Controls.Add(chart, column, row);
        }

    }
}

/*
IconButton btnHazards = new IconButton();
btnHazards.IconChar = IconChar.TriangleExclamation;
btnHazards.Text = "Hazards";
btnHazards.IconColor = Color.White;
 */