using DanMarDev.Identification;
using FontAwesome.Sharp;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using InciTrack_Pro.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.Themes;
using Microsoft.Data.Sqlite;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.DirectoryServices.AccountManagement;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;
namespace InciTrack_Pro
{
    public partial class Frm_Main : Form
    {
        
        public Frm_Main()
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
            UpdateStyles();
            EnableDoubleBuffer(tableLayoutPanel1);
            EnableDoubleBuffer(flp_menu);
            EnableDoubleBuffer(flp_Kpi);
            InitializeEvents();
        }

        public static void EnableDoubleBuffer(Control control)
        {
            typeof(Control)
            .GetProperty(
            "DoubleBuffered",
            BindingFlags.NonPublic |
            BindingFlags.Instance)
            ?.SetValue(control, true);
        }
        private void InitializeEvents()
        {
            this.Load += Frm_Main_Load;
            pb_exit.Click += Pb_exit_Click;
            pb_minimize.Click += Pb_minimize_Click;
            
        }

    
        private void Pb_minimize_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Pb_exit_Click(object? sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x0014;

            if (m.Msg == WM_ERASEBKGND)
                return;

            base.WndProc(ref m);
        }


        private void Frm_Main_Load(object? sender, EventArgs e)
        {
            string currentUser = UserPrincipal.Current.DisplayName;
            EmployeeSearch.ListResult officeStaff = EmployeeSearch.GetOfficeStaffList();
            if (!officeStaff.IsSuccess)
            {
                Console.WriteLine(officeStaff.ErrorMessage);
                return;
            }

            bool isOfficeStaff = officeStaff.FullNames.Contains(currentUser);

            if (!isOfficeStaff)
            {
                MessageBox.Show("Error: You are not an authorized user for this application.", "Authorized User Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            //Look for any new incidents reported
            if(currentUser == "Angel Lively" || currentUser == "Vincent Jackson")
            {
                string updateIncidents = "";
                updateIncidents = Helper_Classes.HazardRetrieval.GetHazards();
                updateIncidents += "\n\n" + Helper_Classes.FirstAidRetrieval.GetFirstAids();
                MessageBox.Show(updateIncidents, "New Incident Retrieval", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("New incident records may be available that are not currently displayed. SHES Manager/Lead should run the application to check for and retrieve the latest submissions.", "New Incident Retrieval", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            flpKpiControls();

            Label lblTitle = new Label
            {
                Text = "Menu",
                Font = new Font("Calibri", 14, FontStyle.Bold),
                Width = 200,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            flp_menu.Controls.Add(lblTitle);

            LoadButtons();

            tableLayoutPanel1.SuspendLayout();
            CreateHazardsVsFirstAidsChart();
            CreateHazardTypeChart();
            CreateHazardYoYChart();
            CreateFirstAidYoYChart();
            tableLayoutPanel1.ResumeLayout();
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
            AddMenuButton("Summary",
            (s, e) => new Frm_Hazards().ShowDialog(), IconChar.ClipboardList);

            AddMenuButton("Hazards",
            (s, e) => new Frm_Hazards().ShowDialog(), IconChar.TriangleExclamation);

            AddMenuButton("First Aids",
            (s, e) => new Frm_FirstAids().ShowDialog(), IconChar.BandAid);

            AddMenuButton("Corrective Actions",
            (s, e) => MessageBox.Show("Corrective Actions"), IconChar.ListCheck);
        }

        private void AddMenuButton(string text,EventHandler clickEvent, IconChar icon)
        {
            Guna2Button btn = CreateMenuButton(text);

            btn.Image = IconCharToImage(icon);
            btn.ImageAlign = HorizontalAlignment.Left;

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
                Font = new Font("Calibri", 12, FontStyle.Bold),
                Margin = new Padding(5, 5, 0, 5),
                Cursor = Cursors.Hand,
                TextAlign = HorizontalAlignment.Left,
                ImageSize = new Size(20, 20)
            };
        }

        private Image IconCharToImage(IconChar iconChar)
        {
            using IconPictureBox icon = new IconPictureBox();

            icon.IconChar = iconChar;
            icon.IconColor = Color.White;
            icon.IconSize = 24;

            return icon.Image!;
        }

        private void CreateHazardsVsFirstAidsChart()
        {
            string[] months =
            {
                "Jan","Feb","Mar","Apr",
                "May","Jun","Jul","Aug",
                "Sep","Oct","Nov","Dec"
            };

            int year = DateTime.Now.Year;

            int[] hazards =
            GetMonthlyCounts("Hazards", year);

            int[] firstAids =
            GetMonthlyCounts("First_Aids", year);

            CartesianChart chart = new CartesianChart
            {
                Dock = DockStyle.Fill
            };

            chart.Title = new LabelVisual
            {
                Text = $"Hazards vs First Aids ({year})",
                TextSize = 20
            };

            chart.Series = new ISeries[]
            {
                    new ColumnSeries<int>
                    {
                        Name = "Hazards",
                        Values = hazards
                    },

                    new ColumnSeries<int>
                    {
                        Name = "First Aids",
                        Values = firstAids
                    }
            };

            chart.XAxes =
            [
                new Axis
                {
                    Labels = months
                }
            ];

            tableLayoutPanel1.Controls.Add(chart, 0, 0);
        }

        private void CreateHazardTypeChart()
        {
            
            var data = GetHazardsByType();

            CartesianChart chart = new CartesianChart
            {
                Dock = DockStyle.Fill
            };

            //chart.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Hidden;
            //string[] labels = data.Keys.ToArray();
            string[] labels = data.Keys
                .Select(x =>
                x.Replace("Hazard Share (", "")
                .Replace(")", "")
                .Replace(" ", "\n"))
                .ToArray();
            int[] values = data.Values.ToArray();

            chart.Title = new LabelVisual
            {
                Text = "Hazards By Type" + $" ({DateTime.Now.Year.ToString()})",
                TextSize = 20
            };

            chart.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name = "Hazards",
                    Values = values
                }
            };

            chart.XAxes =
            [
                new Axis
                {
                   Labels = labels,
                   TextSize = 11
                   
                }
            ];

            tableLayoutPanel1.Controls.Add(chart, 1, 0);
        }

        private void CreateHazardYoYChart()
        {
            string[] months =
            {
                "Jan","Feb","Mar","Apr",
                "May","Jun","Jul","Aug",
                "Sep","Oct","Nov","Dec"
            };

            int year = DateTime.Now.Year;

            int[] currentYear =
            GetMonthlyCounts("Hazards", year);

            int[] previousYear =
            GetMonthlyCounts("Hazards", year - 1);

            CartesianChart chart = new CartesianChart
            {
                Dock = DockStyle.Fill
            };

            chart.Title = new LabelVisual
            {
                Text = $"Hazards ({year - 1} vs {year})",
                TextSize = 20
            };

            chart.Series = new ISeries[]
            {
                new LineSeries<int>
                {
                    Name = (year - 1).ToString(),
                    Values = previousYear,
                    GeometrySize = 10
                },

                new LineSeries<int>
                {
                    Name = year.ToString(),
                    Values = currentYear,
                    GeometrySize = 10
                }
            };

            chart.XAxes =
            [
                new Axis
                {
                 Labels = months
                }
            ];

            tableLayoutPanel1.Controls.Add(chart, 0, 1);
        }

        private void CreateFirstAidYoYChart()
        {
            string[] months =
            {
                "Jan","Feb","Mar","Apr",
                "May","Jun","Jul","Aug",
                "Sep","Oct","Nov","Dec"
            };

            int year = DateTime.Now.Year;

            int[] currentYear =
            GetMonthlyCounts("First_Aids", year);

            int[] previousYear =
            GetMonthlyCounts("First_Aids", year - 1);

            CartesianChart chart = new CartesianChart
            {
                Dock = DockStyle.Fill
            };

            chart.Title = new LabelVisual
            {
                Text = $"First Aids ({year - 1} vs {year})",
                TextSize = 20
            };

            chart.Series = new ISeries[]
            {
                new LineSeries<int>
                {
                    Name = (year - 1).ToString(),
                    Values = previousYear,
                    GeometrySize = 10
                },

                new LineSeries<int>
                {
                    Name = year.ToString(),
                    Values = currentYear,
                    GeometrySize = 10
                }
            };

            chart.XAxes =
            [
                new Axis
                {
                    Labels = months
                }
            ];

            tableLayoutPanel1.Controls.Add(chart, 1, 1);
        }

        private int[] GetMonthlyCounts(string tableName, int year)
        {
            int[] counts = new int[12];

            using SqliteConnection conn = new SqliteConnection(GV.shesDB);

            conn.Open();

            string sql = $@"
                            SELECT
                            strftime('%m', [Date]) AS Month,
                            COUNT(*) AS Total
                            FROM {tableName}
                            WHERE strftime('%Y', [Date]) = @Year
                            GROUP BY strftime('%m', [Date]);";

            using SqliteCommand cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Year", year.ToString());

            using SqliteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int monthIndex =
                Convert.ToInt32(dr["Month"]) - 1;

                counts[monthIndex] =
                Convert.ToInt32(dr["Total"]);
            }

            return counts;
        }

        private Dictionary<string, int> GetHazardsByType()
        {
            Dictionary<string, int> data = new();

            using SqliteConnection conn =
            new SqliteConnection(GV.shesDB);

            conn.Open();

            string sql = @"
                            SELECT
                            Incident_type,
                            COUNT(*) AS Total
                            FROM Hazards
                            Where strftime('%Y', [Date]) = @Year
                            GROUP BY Incident_type
                            ORDER BY Total DESC";

            using SqliteCommand cmd =
            new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year.ToString());
           

            using SqliteDataReader dr =
            cmd.ExecuteReader();

            while (dr.Read())
            {
                data.Add(
                dr["Incident_type"].ToString()!,
                Convert.ToInt32(dr["Total"]));
            }

            return data;
        }
    }
}

