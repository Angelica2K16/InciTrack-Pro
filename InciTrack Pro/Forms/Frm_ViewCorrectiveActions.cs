using Microsoft.Data.Sqlite;
using Sunny.UI;
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
            dgv_caList.CellDoubleClick += Dgv_caList_CellDoubleClick;
            dgv_caList.CellClick += Dgv_caList_CellClick;
            txt_search.TextChanged += Txt_search_TextChanged;
        }

        private void Btn_addCa_Click(object? sender, EventArgs e)
        {
            if (dgv_hazardList.RowCount == 0) { return; }

            if (dgv_hazardList.SelectedRows.Count == 0) 
            { 
                MessageBox.Show("You must select a hazard from the list first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return; 
            }


            ClearMD();
            SetMD();

            this.Hide();

            using (Frm_AddCorrectiveAction frm = new Frm_AddCorrectiveAction(this))
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

        internal void Btn_ViewAllActions_Click(object? sender, EventArgs e)
        {
            txt_search.Text = string.Empty;
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

            dgv_caList.Columns.Clear();
            dgv_caList.DataSource = null;

        }

        private void Dgv_caList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgv_caList.Columns["Edit"].Index) { return; }

            int caIdx = Convert.ToInt32(dgv_caList.Rows[e.RowIndex].Cells["Idx"].Value);

            //Call method to read first aid data from sqlite
            GetCaDetails(caIdx);
        }

        private void Dgv_caList_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            MD.Instance.caIdx = Convert.ToInt32(
                dgv_caList.Rows[e.RowIndex]
                .Cells["Idx"].Value);

            if (e.ColumnIndex ==
             dgv_caList.Columns["Edit"].Index)
            {

                PullCorrectiveActionInfo();

                Frm_UpdateCorrectiveAction frm = new Frm_UpdateCorrectiveAction();

                this.Hide();
                frm.ShowDialog();
                this.Show();
            }

           
        }

        private void Txt_search_TextChanged(object? sender, EventArgs e)
        {
            dgv_hazardList.ClearSelection();
            dgv_hazardList.CurrentCell = null;
            ApplySearchFilter();
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

            
            FormatDgv(dgv_hazardList, null);
        }

        private void LoadCaList(string? hazIdx)
        {
            dgv_caList.Columns.Clear();
            dgv_caList.DataSource = null;

            List<string> conditions = new();

           

            if (!string.IsNullOrEmpty(hazIdx))
            {
                conditions.Add($"ca.Hazard_Idx = {hazIdx}");
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

            if (!dgv_caList.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

                btnEdit.Name = "Edit";
                btnEdit.Text = "Edit";
                btnEdit.UseColumnTextForButtonValue = true;

                dgv_caList.Columns.Add(btnEdit);
                dgv_caList.Columns["Edit"].FillWeight = 10;

                dgv_caList.Columns["Edit"].DisplayIndex = dgv_caList.Columns.Count - 1;
            }



            FormatDgv(dgv_caList, hazIdx);

            
        }

        private void FormatDgv(DataGridView dgv, string? hazIdx)
        {
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
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
                if(string.IsNullOrEmpty(hazIdx))
                {
                    dgv.Columns["Hazard Title"].Width = 150;
                    dgv.Columns["Action"].Width = 215;
                    dgv.Columns["Edit"].Width = 90;
                }
                else
                {
                    dgv.Columns["Hazard Title"].Visible = false;
                    dgv.Columns["Action"].Width = 355;
                    dgv.Columns["Edit"].Width = 105;
                }

                dgv.Columns["Idx"].Visible = false;
                dgv.Columns["Hazard_Idx"].Visible = false;
              



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

        private void GetCaDetails(int caIdx)
        {
            using SqliteConnection conn = new SqliteConnection(GV.shesDB);

            conn.Open();

            string sql = @"
                        SELECT Action, Action_Owner AS 'Action Owner', Due_Date AS 'Due Date', Completion_Date AS 'Completion Date', Notes, Status
                        FROM Corrective_Actions
                        WHERE Idx = @Idx";

            using SqliteCommand cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Idx", caIdx);

            using SqliteDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
                return;

            //create Popup form
            Form popup = new Form();
            popup.BackColor = Color.FromArgb(45, 45, 48);
            popup.Text = "Corrective Action Info";
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

            if(label == "Action" || label == "Notes")
            {


                RichTextBox rtb = new RichTextBox
                {
                    Text = value,
                    ReadOnly = true,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.FromArgb(45, 45, 48),
                    ForeColor = Color.White,
                    Multiline = value.Length > 20,
                    // Dock = DockStyle.Fill,
                    Margin = new Padding(5),
                    ScrollBars = RichTextBoxScrollBars.None,
                    WordWrap = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top

                };

               

                valueControl = rtb;

                
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

            if (valueControl is RichTextBox rtbx)
            {
                rtbx.Width = tbl.GetColumnWidths()[1] - 10;

                int height =
                rtbx.GetPositionFromCharIndex(Math.Max(0, rtbx.TextLength - 1)).Y +
                rtbx.Font.Height + 10;

                rtbx.Height = Math.Max(height, 25);
            }

        }

        private void PullCorrectiveActionInfo()
        {
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
                                SELECT Hazard_Idx, Action, Action_Owner, Due_Date, Completion_Date, Notes, Status From Corrective_Actions Where Idx = @Idx";

                using (SqliteCommand cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Idx", MD.Instance.caIdx);

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            MD.Instance.caDueDate = Convert.ToDateTime(reader["Due_Date"]);
                            MD.Instance.caCompDate = reader["Completion_Date"] == DBNull.Value ? null : Convert.ToDateTime(reader["Completion_Date"]);
                            MD.Instance.caActionOwner = reader["Action_Owner"].ToString();
                            MD.Instance.caAction = reader["Action"].ToString();
                            MD.Instance.caStatus = reader["Status"].ToString();
                            MD.Instance.caNotes = reader["Notes"].ToString();
                        }
                        

                    }

                    if (dt.Rows.Count == 0)
                    {

                        dgv_hazardList.DataSource = dt;

                    }


                }
            }
        }

        internal void ApplySearchFilter()
        {



            string search = txt_search.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgv_hazardList.Rows)
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
                    dgv_hazardList.ClearSelection();
                    row.Selected = true;
                    dgv_hazardList.CurrentCell = row.Cells[1];
                }
            }

            FormatDgv(dgv_hazardList, null);
        }
        //private void EditCaDetails(int caIdx)
        //{
        //    using SqliteConnection conn = new SqliteConnection(GV.shesDB);

        //    conn.Open();

        //    string sql = @"
        //                SELECT Action, Action_Owner AS 'Action Owner', Due_Date AS 'Due Date', Completion_Date AS 'Completion Date', Notes, Status
        //                FROM Corrective_Actions
        //                WHERE Idx = @Idx";

        //    using SqliteCommand cmd = new SqliteCommand(sql, conn);

        //    cmd.Parameters.AddWithValue("@Idx", caIdx);

        //    using SqliteDataReader dr = cmd.ExecuteReader();

        //    if (!dr.Read())
        //        return;

        //    //create Popup form
        //    Form popup = new Form();
        //    popup.BackColor = Color.FromArgb(45, 45, 48);
        //    popup.Text = "Corrective Action Info";
        //    popup.Size = new Size(900, 400);
        //    popup.ShowIcon = false;
        //    popup.StartPosition = FormStartPosition.CenterParent;


        //    TableLayoutPanel tbl = new TableLayoutPanel
        //    {
        //        Dock = DockStyle.Fill,
        //        AutoScroll = true,
        //        BackColor = Color.Transparent,
        //        ColumnCount = 2
        //    };

        //    tbl.ColumnStyles.Add(
        //    new ColumnStyle(SizeType.Absolute, 180));

        //    tbl.ColumnStyles.Add(
        //    new ColumnStyle(SizeType.Percent, 100));

        //    popup.Controls.Add(tbl);

        //    for (int i = 0; i < dr.FieldCount; i++)
        //    {
        //        string columnName = dr.GetName(i);
        //        string value = dr[i]?.ToString() ?? "";

        //        AddEditDetailRow(tbl, columnName, value);
        //    }



        //    int row = tbl.RowCount;
        //    tbl.RowCount++;

        //    UIButton btnSave = new UIButton
        //    {
        //        Text = "Save",
        //        Width = 190,
        //        Height = 45,
        //        FillColor = Color.Firebrick,
        //        FillHoverColor = Color.IndianRed,
        //        FillPressColor = Color.DarkRed,
        //        ForeColor = Color.White,
        //        Font = new Font("Calibri", 12, FontStyle.Bold),
        //        Radius = 8,
        //        Cursor = Cursors.Hand,
        //        Margin = new Padding(5)
        //    };

        //    btnSave.Click += (s, e) =>
        //    {
        //        SaveCorrectiveAction(caIdx, tbl);
        //    };

        //    tbl.Controls.Add(btnSave, 0, row);
        //    tbl.SetColumnSpan(btnSave, 2);
        //    btnSave.Anchor = AnchorStyles.None;

        //    popup.ShowDialog();
        //}

        //        private void SaveCorrectiveAction(int caIdx, TableLayoutPanel tbl)
        //        {
        //            string action = 
        //            ((RichTextBox)tbl.Controls.Find("Action", true)[0]).Text;

        //            string actionOwner =
        //            ((TextBox)tbl.Controls.Find("ActionOwner", true)[0]).Text;

        //            string dueDate =
        //            ((TextBox)tbl.Controls.Find("DueDate", true)[0]).Text;

        //            string completionDate =
        //            ((TextBox)tbl.Controls.Find("CompletionDate", true)[0]).Text;

        //            string notes =
        //            ((RichTextBox)tbl.Controls.Find("Notes", true)[0]).Text;

        //            string status =
        //            ((TextBox)tbl.Controls.Find("Status", true)[0]).Text;


        //            //SQLITE Function
        //            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
        //            {
        //                conn.Open();
        //                using (SqliteTransaction transaction = conn.BeginTransaction())
        //                {
        //                    try
        //                    {
        //                        string sql = $@"
        //                            UPDATE HAZARDS SET

        //                                Action = @Action,
        //Action_Owner = @Action_Owner,
        //Due_Date

        //                            WHERE Idx  = @caIdx
        //                           ";

        //                        using (SqliteCommand cmd = new SqliteCommand(sql, conn, transaction))
        //                        {

        //                            cmd.Parameters.AddWithValue("@hazardIdx", MD.Instance.hazardIdx);
        //                            cmd.Parameters.AddWithValue("@title", MD.Instance.hazTitle);
        //                            cmd.Parameters.AddWithValue("@incidentType", MD.Instance.hazIncidentType);
        //                            cmd.Parameters.AddWithValue("@riskLevel", MD.Instance.hazRiskMatrix);
        //                            cmd.Parameters.AddWithValue("@apReport", MD.Instance.hazApReport);
        //                            cmd.Parameters.AddWithValue("@injuryCat", MD.Instance.hazInjury);
        //                            cmd.Parameters.AddWithValue("@envCat", MD.Instance.hazEnv);
        //                            cmd.Parameters.AddWithValue("@damageCat", MD.Instance.hazDamage);
        //                            cmd.Parameters.AddWithValue("@descr", MD.Instance.hazDescr);
        //                            cmd.Parameters.AddWithValue("@notes", MD.Instance.hazNotes);
        //                            cmd.Parameters.AddWithValue("@status", MD.Instance.hazStatus);


        //                            cmd.ExecuteNonQuery();
        //                        }

        //                        transaction.Commit();

        //                        Frm_Hazards? frm = Application.OpenForms["Frm_Hazards"] as Frm_Hazards;

        //                        if (frm != null)
        //                        {
        //                            frm.LoadDgvHazardsList();
        //                            frm.ApplySearchFilter();
        //                            frm.Show();
        //                            frm.BringToFront();
        //                            this.Close();
        //                        }

        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        transaction.Rollback();
        //                        MessageBox.Show(ex.Message);
        //                    }
        //                }

        //            }
        //        }

        //private void AddEditDetailRow(TableLayoutPanel tbl, string label, string value)
        //{
        //    int row = tbl.RowCount;

        //    tbl.RowCount++;

        //    tbl.RowStyles.Add(
        //    new RowStyle(SizeType.AutoSize));

        //    Label lblField = new Label
        //    {
        //        Text = label + ":",
        //        ForeColor = Color.White,
        //        AutoSize = true,
        //        Padding = new Padding(5),
        //        Font = new Font("Calibri", 12, FontStyle.Bold)
        //    };

        //    Control valueControl;

        //    if (label == "Action" || label == "Notes")
        //    {


        //        RichTextBox rtb = new RichTextBox
        //        {
        //            Name = label.Replace(" ", ""),
        //            Text = value,
        //            ReadOnly = false,
        //            BorderStyle = BorderStyle.None,
        //            BackColor = Color.FromArgb(45, 45, 48),
        //            ForeColor = Color.White,
        //            Multiline = value.Length > 20,
        //            // Dock = DockStyle.Fill,
        //            Margin = new Padding(5),
        //            ScrollBars = RichTextBoxScrollBars.None,
        //            WordWrap = true,
        //            Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top

        //        };



        //        valueControl = rtb;


        //    }
        //    else
        //    {
        //        valueControl = new TextBox
        //        {
        //            Name = label.Replace(" ", ""),
        //            Text = value,
        //            ReadOnly = false,
        //            BorderStyle = BorderStyle.None,
        //            BackColor = Color.FromArgb(45, 45, 48),
        //            ForeColor = Color.White,
        //            Multiline = value.Length > 20,
        //            Dock = DockStyle.Fill,
        //            Margin = new Padding(5)
        //        };
        //    }



        //    tbl.Controls.Add(lblField, 0, row);
        //    tbl.Controls.Add(valueControl, 1, row);

        //    if (valueControl is RichTextBox rtbx)
        //    {
        //        rtbx.Width = tbl.GetColumnWidths()[1] - 10;

        //        int height =
        //        rtbx.GetPositionFromCharIndex(Math.Max(0, rtbx.TextLength - 1)).Y +
        //        rtbx.Font.Height + 10;

        //        rtbx.Height = Math.Max(height, 25);
        //    }

        //}



    }
}
