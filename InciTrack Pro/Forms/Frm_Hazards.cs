using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;
using MD = InciTrack_Pro.Base_Classes.ModelData;

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
            pb_exit.Click += Pb_exit_Click;
            pb_minimize.Click += Pb_minimize_Click;
            cb_apReports.CheckedChanged += Cb_apReports_CheckedChanged;
            txt_search.TextChanged += Txt_search_TextChanged;
            dgv_hazardsList.CellDoubleClick += Dgv_hazardsList_CellDoubleClick;
            dgv_hazardsList.CellClick += Dgv_hazardsList_CellClick;
        }

        private void Frm_Hazards_Load(object? sender, EventArgs e)
        {
            flpKpiControls();

            cb_apReports.Checked = false;

            LoadDgvHazardsList();
        }

        private void Pb_exit_Click(object? sender, EventArgs e)
        {
            Form? frm = Application.OpenForms["Frm_Main"];
            if (frm != null)
            {
                frm.Show();
                frm.BringToFront();
                this.Close();
            }
            else
            {

            }
        }

        private void Pb_minimize_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cb_apReports_CheckedChanged(object? sender, EventArgs e)
        {
            txt_search.Text = string.Empty;
            LoadDgvHazardsList();
        }

        private void Txt_search_TextChanged(object? sender, EventArgs e)
        {
            dgv_hazardsList.ClearSelection();
            dgv_hazardsList.CurrentCell = null;
            ApplySearchFilter();
        }

        private void Dgv_hazardsList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgv_hazardsList.Columns["Edit"].Index) { return; }

            int hazardIdx = Convert.ToInt32(dgv_hazardsList.Rows[e.RowIndex].Cells["Idx"].Value);

            //Call method to read first aid data from sqlite
            GetHazardDetails(hazardIdx);
        }

        private void Dgv_hazardsList_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==
             dgv_hazardsList.Columns["Edit"].Index)
            {
                MD.Instance.hazardIdx = Convert.ToInt32(
                dgv_hazardsList.Rows[e.RowIndex]
                .Cells["Idx"].Value);

                Frm_HazardUpdate frm = new Frm_HazardUpdate();

                this.Hide();
                frm.ShowDialog();
            }
        }
        private void GetHazardDetails(int hazardIdx)
        {
            using SqliteConnection conn = new SqliteConnection(GV.shesDB);

            conn.Open();

            string sql = @"
                        SELECT Title, Date, Reported_By AS 'Reported By', Incident_type AS 'Incident Type', Area, Injury_Category AS 'Potential Injury', Environment_Category AS 'Potential Environmental Impact', Damage_Category AS 'Potential Property Damage / Loss', Incident_Description AS 'Incident Description', Corrective_Action AS 'Corrective Action', Notes, Status, AP_Report AS 'AP Report', Risk_Level AS 'Risk Level'
                        FROM Hazards
                        WHERE Idx = @Idx";

            using SqliteCommand cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Idx", hazardIdx);

            using SqliteDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
                return;

            //create Popup form
            Form popup = new Form();
            popup.BackColor = Color.FromArgb(45, 45, 48);
            popup.Text = "Hazard Incident";
            popup.Size = new Size(900, 400);
            popup.ShowIcon = false;
            popup.StartPosition = FormStartPosition.CenterParent;


            TableLayoutPanel tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.Transparent,
                ColumnCount = 2
            };

            tbl.ColumnStyles.Add(
            new ColumnStyle(SizeType.Absolute, 180));

            tbl.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 100));

            popup.Controls.Add(tbl);

            for (int i = 0; i < dr.FieldCount; i++)
            {
                string columnName = dr.GetName(i);
                string value = dr[i]?.ToString() ?? "";

                AddDetailRow(tbl, columnName, value);
            }

            popup.ShowDialog();

        }

        private void AddDetailRow(TableLayoutPanel tbl, string label, string value)
        {
            int row = tbl.RowCount;

            tbl.RowCount++;

            tbl.RowStyles.Add(
            new RowStyle(SizeType.AutoSize));

            Label lblField = new Label
            {
                Text = label + ":",
                ForeColor = Color.White,
                AutoSize = true,
                Padding = new Padding(5),
                Font = new Font("Calibri", 12, FontStyle.Bold)
            };

            Control valueControl;

            bool useRichText =
                        label == "Potential Injury" ||
                        label == "Potential Environmental Impact" ||
                        label == "Potential Property Damage / Loss" ||
                        label == "Incident Description";

            if(useRichText)
            {
                // Split category values onto separate lines
                if (label == "Potential Injury" || label == "Potential Environmental Impact" || label == "Potential Property Damage / Loss")
                {
                    value = FormatCategoryText(value);
                }

                valueControl = new RichTextBox
                {
                    Text = value,
                    ReadOnly = true,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.FromArgb(45, 45, 48),
                    ForeColor = Color.White,
                    Dock = DockStyle.Fill,
                    Height = 80
                };
            }
            else
            {
                valueControl = new TextBox
                {
                    Text = value,
                    ReadOnly = true,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.FromArgb(45, 45, 48),
                    ForeColor = Color.White,
                    Multiline = value.Length > 20,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
            }
                
            tbl.Controls.Add(lblField, 0, row);
            tbl.Controls.Add(valueControl, 1, row);
        }

        private string FormatCategoryText(string value)
        {
            const string slipTripPlaceholder = "__SLIPTRIPFALL__";
            const string physicalPlaceholder = "__PHYSICAL__";

            value = value.Replace(
            "Slip, Trip, and / or Fall",
            slipTripPlaceholder);

            value = value.Replace(
            "Physical (Cuts, Burns, Crushing, Pinching)",
            physicalPlaceholder);

            value = "- " + value.Replace(",",Environment.NewLine + "- " );

            value = value.Replace(
            slipTripPlaceholder,
            "Slip, Trip, and / or Fall");

            value = value.Replace(physicalPlaceholder,"Physical (Cuts, Burns, Crushing, Pinching)");

            return value.Trim();
        }

        internal void ApplySearchFilter()
        {
            


            string search = txt_search.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgv_hazardsList.Rows)
            {
                if (row.IsNewRow) { continue; }

                if (string.IsNullOrWhiteSpace(search))
                {
                    row.Visible = true;
                    continue;
                }

                row.Visible = row.Cells
                .Cast<DataGridViewCell>()
                .Any(c =>
                c.Value != null &&
                c.Value.ToString()!
                .ToLower()
                .Contains(search));

                if (row.Cells["Idx"].Value != null && Convert.ToInt32(row.Cells["Idx"].Value) == MD.Instance.hazardIdx && row.Visible)
                {
                    dgv_hazardsList.ClearSelection();
                    row.Selected = true;
                    dgv_hazardsList.CurrentCell = row.Cells[1];
                }
            }

            FormatDgv();

    
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
                Text = "Top 3 Incident Types",
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
                    Name = "Hazards"
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
            tableLayoutPanel2.Controls.Add(pnlChart, 1, 0);
        }

        private Dictionary<string, int> GetTop3Areas()
        {
            Dictionary<string, int> areas = new();

            using SqliteConnection conn =
            new SqliteConnection(GV.shesDB);

            conn.Open();

            string sql = @"
                            SELECT
                            Incident_type,
                            COUNT(*) AS Total
                            FROM HAZARDS
                            WHERE strftime('%Y',[Date]) =
                            strftime('%Y','now')
                            GROUP BY Incident_type
                            ORDER BY Total DESC
                            LIMIT 3;";

            using SqliteCommand cmd = new SqliteCommand(sql, conn);

            using SqliteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                areas.Add(
                dr["Incident_type"].ToString()!,
                Convert.ToInt32(dr["Total"]));
            }

            return areas;
        }

        internal void LoadDgvHazardsList()
        {
            dgv_hazardsList.Columns.Clear();
            dgv_hazardsList.DataSource = null;

            DataTable dt = new DataTable();

            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                string query = cb_apReports.Checked ? @"SELECT
                                  Idx, Date, Title, Incident_type AS 'Incident Type', Corrective_Action As 'Corrective Action', Status, AP_Report AS 'AP Report'
                                  FROM Hazards
                                  WHERE AP_Report = 'Yes'
                                  ORDER BY Date Desc"
                                  :
                                  @"SELECT
                                  Idx, Date, Title, Incident_type AS 'Incident Type', Corrective_Action, Status, AP_Report AS 'AP Report'
                                  FROM Hazards
                                  ORDER BY Date Desc"
                                  ;

                using (SqliteCommand cmd = new SqliteCommand(query, conn))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {

                        dt.Load(reader);

                    }

                    if (dt.Rows.Count == 0)
                    {

                        dgv_hazardsList.DataSource = dt;

                    }


                }
            }

            dgv_hazardsList.DataSource = dt;

            if (!dgv_hazardsList.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

                btnEdit.Name = "Edit";
                btnEdit.Text = "Edit";
                btnEdit.UseColumnTextForButtonValue = true;

                dgv_hazardsList.Columns.Add(btnEdit);
                dgv_hazardsList.Columns["Edit"].FillWeight = 10;

                dgv_hazardsList.Columns["Edit"].DisplayIndex = dgv_hazardsList.Columns.Count - 1;
            }

            FormatDgv();


            
        }

        private void FormatDgv()
        {
            dgv_hazardsList.ScrollBars = ScrollBars.Vertical;
            dgv_hazardsList.AutoGenerateColumns = true;
            //dgv_firstAidsList.Dock = DockStyle.Fill;
            dgv_hazardsList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv_hazardsList.RowTemplate.Height = 30;
            dgv_hazardsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_hazardsList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_hazardsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_hazardsList.RowHeadersVisible = false;
            dgv_hazardsList.AllowUserToAddRows = false;
            dgv_hazardsList.ReadOnly = true;
            dgv_hazardsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_hazardsList.EnableHeadersVisualStyles = false;
            dgv_hazardsList.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
            dgv_hazardsList.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.Window;
            dgv_hazardsList.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlDarkDark;
            dgv_hazardsList.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.Window;
            dgv_hazardsList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_hazardsList.RowsDefaultCellStyle.BackColor = Color.White;
            dgv_hazardsList.RowsDefaultCellStyle.Font = new Font("Calibri", 10);
            dgv_hazardsList.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgv_hazardsList.Columns["Idx"].Visible = false;

            dgv_hazardsList.Columns["Date"].Width = 115;
            dgv_hazardsList.Columns["Title"].Width = 390;
            dgv_hazardsList.Columns["Incident Type"].Width = 250;
            dgv_hazardsList.Columns["Corrective_Action"].Width = 160;
            dgv_hazardsList.Columns["Status"].Width = 115;
            dgv_hazardsList.Columns["AP Report"].Width = 115;
            dgv_hazardsList.Columns["Edit"].Width = 105;

            foreach (DataGridViewRow row in dgv_hazardsList.Rows)
            {
                if (DateTime.TryParse(row.Cells["Date"].Value?.ToString(), out DateTime dt))
                {
                    if (dt.Date.Year == DateTime.Now.Year)
                    {
                        row.DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                }
            }

        }
    }
}
