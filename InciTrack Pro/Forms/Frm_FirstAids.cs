using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.Themes;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;
using MD = InciTrack_Pro.Base_Classes.ModelData;

namespace InciTrack_Pro.Forms
{
    public partial class Frm_FirstAids : Form
    {
        public Frm_FirstAids()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_FirstAids_Load;
            pb_exit.Click += Pb_exit_Click;
            pb_minimize.Click += Pb_minimize_Click;
            txt_search.TextChanged += txtSearch_TextChanged;
            cb_apReports.CheckedChanged += Cb_apReports_CheckedChanged;
            dgv_firstAidsList.CellDoubleClick += Dgv_firstAidsList_CellDoubleClick;
            dgv_firstAidsList.CellClick += dgvFirstAids_CellClick;
        }

        private void Pb_exit_Click(object? sender, EventArgs e)
        {
            //go back to main dashboard form
        }
        private void Pb_minimize_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Dgv_firstAidsList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;
            if(e.ColumnIndex == dgv_firstAidsList.Columns["Edit"].Index) { return; }

            int firstAidIdx = Convert.ToInt32(dgv_firstAidsList.Rows[e.RowIndex].Cells["Idx"].Value);


            GetFADetails(firstAidIdx);
        }

        private void GetFADetails(int firstAidIdx)
        {
            using SqliteConnection conn = new SqliteConnection(GV.shesDB);

            conn.Open();

            string sql = @"
                        SELECT Title, Date, Time, Employee_Name AS 'Employee', Area, Incident_Description AS 'Description', Cause, Details, Investigation AS 'Investigation Required', AP_Report AS 'Reported to AP', Notes
                        FROM FIRST_AIDS
                        WHERE Idx = @Idx";

            using SqliteCommand cmd =new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Idx", firstAidIdx);

            using SqliteDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
                return;

            //create Popup form
            Form popup = new Form();
            popup.BackColor = Color.FromArgb(45,45,48);
            popup.Text = "First Aid Incident";
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

        private void AddDetailRow(TableLayoutPanel tbl,string label,string value)
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
                Font = new Font("Calibri",12,FontStyle.Bold)
            };

            TextBox txtValue = new TextBox
            {
                Text = value,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor= Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                Multiline = value.Length > 75,
                Dock = DockStyle.Fill
            };

            tbl.Controls.Add(lblField, 0, row);
            tbl.Controls.Add(txtValue, 1, row);
        }


        private void Cb_apReports_CheckedChanged(object? sender, EventArgs e)
        {
            txt_search.Text = string.Empty;
            LoadDgvFirstAidList();
        }

        private void Frm_FirstAids_Load(object? sender, EventArgs e)
        {
            flpKpiControls();

            cb_apReports.Checked = false;

            LoadDgvFirstAidList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txt_search.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgv_firstAidsList.Rows)
            {
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
            }
        }

        private void flpKpiControls()
        {
            flp_Kpi.Controls.Clear();

            var (FAYtdCount,FAMonthCount, lastFACount) = GetCountData();

            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month);

            flp_Kpi.Controls.Add(CreateKpiCard(DateTime.Now.Year + " First Aids", FAYtdCount, Color.Firebrick));
            flp_Kpi.Controls.Add(CreateKpiCard($"{monthName} First Aids", FAMonthCount, Color.Firebrick));
            flp_Kpi.Controls.Add(CreateKpiCard("Days Since Last First Aid", lastFACount, Color.Firebrick));
            CreateTop3AreasChart();

        }

        private (int FAYtdCount, int FAMonthCount, int lastFACount) GetCountData()
        {
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                string sql = @"
                                SELECT
                                (
                                    SELECT
                                    COUNT(*)
                                    FROM FIRST_AIDS
                                    WHERE strftime('%Y',Date) = strftime('%Y', 'now')
                                ) AS FAYtdCount,
                                (
                                     SELECT
                                     COUNT(*)
                                     FROM FIRST_AIDS
                                     WHERE strftime('%m',Date) = strftime('%Y-%m', 'now')
                                ) AS FAMonthCount,
                                (
                                      SELECT CAST (
                                      julianday ('now') -
                                      julianday (MAX(Date))
                                      AS Integer
                                      )
                                      FROM FIRST_AIDS
                                ) AS lastFACount;
                            ";



                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    using (SqliteDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                        {
                            return (
                                    Convert.ToInt32(dr["FAYtdCount"]),
                                    Convert.ToInt32(dr["FAMonthCount"]),
                                    Convert.ToInt32(dr["lastFACount"])
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
            var data = GetTop5Areas();

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

            //chart.Title = new LabelVisual
            //{
            //    Text = "Top 3 Areas",
            //    TextSize = 14
            //};

            pnlChart.Controls.Add(chart);
            pnlChart.Controls.Add(lblTitle);
            tableLayoutPanel1.Controls.Add(pnlChart, 1, 0);
        }

        private Dictionary<string, int> GetTop5Areas()
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
        private void LoadDgvFirstAidList()
        {
            dgv_firstAidsList.Columns.Clear();
            dgv_firstAidsList.DataSource = null;

            DataTable dt = new DataTable();

            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                string query = cb_apReports.Checked ? @"SELECT
                                  Idx, Date, Title, Employee_Name AS 'Employee', Area, Incident_Description AS 'Description'
                                  FROM FIRST_AIDS
                                  WHERE AP_Report = 'Yes'
                                  ORDER BY Date Desc"
                                  :
                                  @"SELECT
                                  Idx, Date, Title, Employee_Name AS 'Employee', Area, Incident_Description AS 'Description'
                                  FROM FIRST_AIDS
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

                        dgv_firstAidsList.DataSource = dt;

                    }


                }
            }

            dgv_firstAidsList.DataSource = dt;

            if(!dgv_firstAidsList.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

                btnEdit.Name = "Edit";
                btnEdit.Text = "Edit";
                btnEdit.UseColumnTextForButtonValue = true;

                dgv_firstAidsList.Columns.Add(btnEdit);
                dgv_firstAidsList.Columns["Edit"].FillWeight = 10;

                dgv_firstAidsList.Columns["Edit"].DisplayIndex = dgv_firstAidsList.Columns.Count - 1;
            }




           

            FormatDgv();
        }

        private void FormatDgv()
        {
            dgv_firstAidsList.AutoGenerateColumns = true;
            //dgv_firstAidsList.Dock = DockStyle.Fill;
            dgv_firstAidsList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv_firstAidsList.RowTemplate.Height = 30;
            dgv_firstAidsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_firstAidsList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_firstAidsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_firstAidsList.RowHeadersVisible = false;
            dgv_firstAidsList.AllowUserToAddRows = false;
            dgv_firstAidsList.ReadOnly = true;
            dgv_firstAidsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_firstAidsList.EnableHeadersVisualStyles = false;
            dgv_firstAidsList.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
            dgv_firstAidsList.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.Window;
            dgv_firstAidsList.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlDarkDark;
            dgv_firstAidsList.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.Window;
            dgv_firstAidsList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_firstAidsList.RowsDefaultCellStyle.BackColor = Color.White;
            dgv_firstAidsList.RowsDefaultCellStyle.Font = new Font("Calibri", 10);
            dgv_firstAidsList.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgv_firstAidsList.Columns["Idx"].Visible = false;
           
            dgv_firstAidsList.Columns["Date"].FillWeight = 10;
            dgv_firstAidsList.Columns["Title"].FillWeight = 15;
            dgv_firstAidsList.Columns["Employee"].FillWeight = 8;
            dgv_firstAidsList.Columns["Area"].FillWeight = 20;
            dgv_firstAidsList.Columns["Description"].FillWeight = 27;

            foreach (DataGridViewRow row in dgv_firstAidsList.Rows)
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

        

        private void dgvFirstAids_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==
            dgv_firstAidsList.Columns["Edit"].Index)
            {
                MD.Instance.firstAidIdx = Convert.ToInt32(
                dgv_firstAidsList.Rows[e.RowIndex]
                .Cells["Idx"].Value);

                Frm_FirstAidUpdate frm = new Frm_FirstAidUpdate();

                frm.ShowDialog();

                //LoadGrid();
            }
        }
    }
}
