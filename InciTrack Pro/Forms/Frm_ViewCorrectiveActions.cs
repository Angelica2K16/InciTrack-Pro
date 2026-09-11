using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;
using MD = InciTrack_Pro.Base_Classes.ModelData;


namespace InciTrack_Pro.Forms
{
    public partial class Frm_ViewCorrectiveActions : Form
    {
        public Frm_ViewCorrectiveActions()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_ViewCorrectiveActions_Load;
            cb_includeAll.CheckedChanged += Cb_includeAll_CheckedChanged;
            dgv_hazardList.SelectionChanged += Dgv_hazardList_SelectionChanged;
            btn_ViewAllActions.Click += Btn_ViewAllActions_Click;
            btn_viewHazards.Click += Btn_viewHazards_Click;
            pb_exit.Click += Pb_exit_Click;
            pb_minimize.Click += Pb_minimize_Click;
            btn_addCa.Click += Btn_addCa_Click;
        }

        private void Btn_addCa_Click(object? sender, EventArgs e)
        {
            //title, date, type
            ClearMD();
            SetMD();

            this.Hide();

            using (Frm_AddCorrectiveAction frm = new Frm_AddCorrectiveAction())
            {
                frm.ShowDialog();
            }

            this.Show();

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

        private void Btn_viewHazards_Click(object? sender, EventArgs e)
        {
            cb_includeAll.Enabled = true;
            LoadHazardList();
        }

        private void Btn_ViewAllActions_Click(object? sender, EventArgs e)
        {
            cb_includeAll.Enabled = false;
            dgv_hazardList.DataSource = null;
            LoadCaList(null);
        }

        private void Dgv_hazardList_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgv_hazardList.CurrentRow == null)
                return;

            if (dgv_hazardList.CurrentRow.Cells["Idx"].Value == null)
                return;

            string? hazIdx = dgv_hazardList.CurrentRow.Cells["Idx"].Value.ToString();

            LoadCaList(hazIdx);
        }

        private void Cb_includeAll_CheckedChanged(object? sender, EventArgs e)
        {
            LoadHazardList();
        }

        private void Frm_ViewCorrectiveActions_Load(object? sender, EventArgs e)
        {
            LoadHazardList();
            dgv_caList.DataSource = null;

        }

        private void LoadHazardList()
        {
            List<string> conditions = new();

            if (cb_includeAll.Checked)
            {
                conditions.Add("Status IN ('Open', 'Closed')");
            }
            else
            {
                conditions.Add("Status = 'Open'");
            }

            dgv_hazardList.Columns.Clear();
            dgv_hazardList.DataSource = null;

            DataTable dt = new DataTable();

            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                //string query = cb_apReports.Checked ? @"SELECT
                //                  Idx, Date, Title, Incident_type AS 'Incident Type', Corrective_Action As 'Corrective Action', Status, AP_Report AS 'AP Report'
                //                  FROM Hazards
                //                  WHERE AP_Report = 'Yes'
                //                  ORDER BY Date Desc"
                //                  :
                //                  @"SELECT
                //                  Idx, Date, Title, Incident_type AS 'Incident Type', Corrective_Action, Status, AP_Report AS 'AP Report'
                //                  FROM Hazards
                //                  ORDER BY Date Desc"
                //                  ;

                string query = @"
                                SELECT
                                Idx,
                                Date,
                                Title,
                                Incident_type AS 'Incident Type',
                                Corrective_Action AS 'Corrective Action',
                                Status
                                FROM Hazards";

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                query += " ORDER BY Date DESC";

                using (SqliteCommand cmd = new SqliteCommand(query, conn))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {

                        dt.Load(reader);

                    }

                    if (dt.Rows.Count == 0)
                    {

                        dgv_hazardList.DataSource = dt;

                    }


                }
            }

            dgv_hazardList.DataSource = dt;
            FormatDgv(dgv_hazardList);
        }

        private void LoadCaList(string? hazIdx)
        {
            List<string> conditions = new();

           

            if (!string.IsNullOrEmpty(hazIdx))
            {
                conditions.Add($"Hazard_Idx = {hazIdx}");
            }
            conditions.Add("ca.Status = 'Open'");

            DataTable dt = new DataTable();

            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                //string query = @"
                //                SELECT
                //                Idx,
                //                Hazard_Idx,
                //                Action,
                //                Action_Owner AS 'Action Owner',
                //                Due_Date AS 'Due Date',
                //                Completion_Date AS 'Completion Date', 
                //                Notes,
                //                Status
                //               FROM CORRECTIVE_ACTIONS";

                string query = @"
SELECT
ca.Idx,
ca.Hazard_Idx,
h.Title AS 'Hazard Title',
ca.Action,
ca.Action_Owner AS 'Action Owner',
ca.Due_Date AS 'Due Date',
ca.Completion_Date AS 'Completion Date',
ca.Notes,
ca.Status
FROM Corrective_Actions ca
LEFT JOIN Hazards h
ON h.Idx = ca.Hazard_Idx";

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                query += " ORDER BY Due_Date DESC";

                using (SqliteCommand cmd = new SqliteCommand(query, conn))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {

                        dt.Load(reader);

                    }

                    if (dt.Rows.Count == 0)
                    {

                        dgv_caList.DataSource = dt;

                    }


                }
            }

            dgv_caList.DataSource = dt;

            FormatDgv(dgv_caList);
        }

        private void FormatDgv(DataGridView dgv)
        {
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.AllowUserToResizeColumns = false;
            
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.RowTemplate.Height = 30;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.Window;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlDarkDark;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.Window;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.Font = new Font("Calibri", 10);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            if(dgv.Name == "dgv_hazardList")
            {
                dgv.Columns["Idx"].Visible = false;

                dgv.Columns["Date"].Width = 115;
                dgv.Columns["Title"].Width = 400;
                dgv.Columns["Incident Type"].Width = 250;
                dgv.Columns["Corrective Action"].Width = 160;
                dgv.Columns["Status"].Width = 115;

                foreach (DataGridViewRow row in dgv.Rows)
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
            else
            {
                dgv.Columns["Idx"].Visible = false;
                dgv.Columns["Hazard_Idx"].Visible = false;

                dgv.Columns["Hazard Title"].Width = 200;
                dgv.Columns["Action"].Width = 255;
                dgv.Columns["Action Owner"].Width = 115;
                dgv.Columns["Due Date"].Width = 90;
                dgv.Columns["Completion Date"].Width = 90;
                dgv.Columns["Notes"].Width = 200;
                dgv.Columns["Status"].Width = 90;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (DateTime.TryParse(row.Cells["Due Date"].Value?.ToString(), out DateTime dt))
                    {
                        if (dt.Date <= DateTime.Now)
                        {
                            row.DefaultCellStyle.BackColor = Color.IndianRed;
                        }
                    }
                }
            }

        }

        private void ClearMD()
        {
            MD.Instance.hazIncidentType = null;
            MD.Instance.hazRiskMatrix = null;
            MD.Instance.hazApReport = null;
            MD.Instance.hazDescr = null;
            MD.Instance.hazNotes = null;
            MD.Instance.hazStatus = null;
            MD.Instance.hazTitle = null;
            MD.Instance.hazInjury = null;
            MD.Instance.hazEnv = null;
            MD.Instance.hazDamage = null;
            MD.Instance.hazDate = DateTime.Now;
        }

        private void SetMD()
        {
            MD.Instance.hazardIdx = Convert.ToInt32(dgv_hazardList.CurrentRow.Cells["Idx"].Value);
            MD.Instance.hazTitle = dgv_hazardList.CurrentRow.Cells["Title"].Value.ToString();
            MD.Instance.hazIncidentType = dgv_hazardList.CurrentRow.Cells["Incident Type"].Value.ToString();
            MD.Instance.hazDate = Convert.ToDateTime(dgv_hazardList.CurrentRow.Cells["Date"].Value);
        }
    }
}
