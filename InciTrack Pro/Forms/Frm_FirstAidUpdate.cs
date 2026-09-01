using FontAwesome.Sharp;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static OfficeOpenXml.ExcelErrorValue;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;
using MD = InciTrack_Pro.Base_Classes.ModelData;

namespace InciTrack_Pro.Forms
{
    public partial class Frm_FirstAidUpdate : Form
    {
        public Frm_FirstAidUpdate()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_FirstAidUpdate_Load;
            btn_save.Click += Btn_save_Click;
            btn_cancel.Click += Btn_cancel_Click;
            btn_createHazard.Click += Btn_createHazard_Click;
        }

       

        private void Frm_FirstAidUpdate_Load(object? sender, EventArgs e)
        {
            lbl_header.Text = "First Aid Incident Update";
            //lbl_header.Image = IconCharToImage(IconChar.Bandage);
            //lbl_header.ImageAlign = ContentAlignment.BottomRight;
            lbl_header.TextAlign = ContentAlignment.MiddleCenter;

            GetFirstAidIncidentDataFromSQL();
            SetControlsWithMdData();
        }

        private void Btn_save_Click(object? sender, EventArgs e)
        {
            if(!ValidateControls(out var errs, out var controlFocus))
            {
                // Build readable message text
                string message = string.Join("\n• ", errs);
                message = "Please correct the following:\n\n• " + message;

                MessageBox.Show(
                    message,
                    "Validation Errors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                // Optionally set focus to the first invalid control
                controlFocus?.Focus();
            }
            else
            {
                SetModelDataClass();
                UpdateSqlData();
            }
                
        }

        private void Btn_cancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_createHazard_Click(object? sender, EventArgs e)
        {
            //create Popup form
            Form popup = new Form();
            popup.BackColor = Color.FromArgb(45, 45, 48);
            popup.Text = "Create a Hazard";
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

            for (int i = 0; i <= 15; i++)
            {
                //string columnName = dr.GetName(i);
                //string value = dr[i]?.ToString() ?? "";

                //AddDetailRow(tbl, columnName, value);
                AddDetailRow(tbl, null, null);
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
                Font = new Font("Calibri", 12, FontStyle.Bold)
            };

            TextBox txtValue = new TextBox
            {
                Text = "Test",
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                //Multiline = value.Length > 75,
                Dock = DockStyle.Fill
            };

            tbl.Controls.Add(lblField, 0, row);
            tbl.Controls.Add(txtValue, 1, row);
        }

        //private Image IconCharToImage(IconChar iconChar)
        //{
        //    using IconPictureBox icon = new IconPictureBox();

        //    icon.IconChar = iconChar;
        //    icon.IconColor = Color.White;
        //    icon.IconSize = 24;

        //    return icon.Image!;
        //}

        private void GetFirstAidIncidentDataFromSQL()
        {
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                string sql = $@"
                            SELECT *
                            FROM FIRST_AIDS
                            WHERE Idx  = @firstAidIdx
                           ";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@firstAidIdx", MD.Instance.firstAidIdx);

                    using (SqliteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            MD.Instance.title = dr["Title"].ToString();
                            MD.Instance.date = Convert.ToDateTime(dr["Date"]);
                            MD.Instance.time = Convert.ToDateTime(dr["Time"]);
                            MD.Instance.empName = dr["Employee_Name"].ToString();
                            MD.Instance.area = dr["Area"].ToString();
                            MD.Instance.descr = dr["Incident_Description"].ToString();
                            MD.Instance.cause = dr["Cause"].ToString();
                            MD.Instance.investigation = dr["Investigation"].ToString();
                            MD.Instance.apReport = dr["AP_Report"].ToString();
                            MD.Instance.notes = dr["Notes"].ToString();

                        }
                    }
                }
            }
        }

        private void SetControlsWithMdData()
        {
            lbl_date.Text = MD.Instance.date.ToString("yyyy-MM-dd");
            lbl_time.Text = MD.Instance.time.ToString("hh:mm tt");
            lbl_empName.Text = MD.Instance.empName;
            lbl_area.Text = MD.Instance.area;
            txt_Title.Text = MD.Instance.title;
            combo_investigation.SelectedItem = MD.Instance.investigation;
            combo_apReport.SelectedItem = MD.Instance.apReport;
            rtxt_descr.Text = MD.Instance.descr;
            rtxt_cause.Text = MD.Instance.cause;
            rtxt_notes.Text = MD.Instance.notes;
        }

        private bool ValidateControls(out List<string> errors, out Control? firstInvalid)
        {
           errors = new List<string>();
           firstInvalid = null;

            // Check TextBoxes
            if (!CheckTextBox(txt_Title, "Title", errors))
            {
                if (firstInvalid == null) firstInvalid = txt_Title;
            }

            //Check RichTextBoxes
            if(!CheckRichTextBox(rtxt_descr, "Description", errors))
            {
                if (firstInvalid == null) firstInvalid = rtxt_descr;
            }

            //Check ComboBoxes
            if(!CheckComboBox(combo_apReport, "Reported to AP", errors))
            {
                if (firstInvalid == null) firstInvalid = combo_apReport;
            }

            if (!CheckComboBox(combo_investigation, "Investigation Required", errors))
            {
                if (firstInvalid == null) firstInvalid = combo_investigation;
            }
            return errors.Count == 0;

        }

        private bool CheckTextBox(TextBox tb, string label, List<string> errors)
        {

            bool filled = !string.IsNullOrWhiteSpace(tb.Text);
            tb.BackColor = filled ? SystemColors.Window : Color.LightPink;
            if (!filled) errors.Add($"{label} is required.");
            return filled;
        }

        private bool CheckRichTextBox(RichTextBox rtb, string label, List<string> errors)
        {

            bool filled = !string.IsNullOrWhiteSpace(rtb.Text);
            rtb.BackColor = filled ? SystemColors.Window : Color.LightPink;
            if (!filled) errors.Add($"{label} is required.");
            return filled;
        }

        private bool CheckComboBox(ComboBox comboB, string label, List<string> errors)
        {

            bool filled = (comboB.SelectedIndex > 0);
            comboB.BackColor = filled ? SystemColors.Window : Color.LightPink;
            if (!filled) errors.Add($"{label} is required.");
            return filled;
        }

        private void SetModelDataClass()
        {
            MD.Instance.title = txt_Title.Text;
            MD.Instance.investigation = combo_investigation.SelectedItem?.ToString();
            MD.Instance.apReport = combo_apReport.SelectedItem?.ToString();
            MD.Instance.descr = rtxt_descr.Text;
            MD.Instance.cause = rtxt_cause.Text;
            MD.Instance.notes = rtxt_notes.Text;
        }

        private void UpdateSqlData()
        {
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();
                using (SqliteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = $@"
                            UPDATE FIRST_AIDS SET
                            
                                Title = @title,
                                Investigation = @investigation,
                                AP_Report = @apReport,
                                Incident_Description = @descr,
                                Cause = @cause,
                                Notes = @notes
                            
                            WHERE Idx  = @firstAidIdx
                           ";

                        using (SqliteCommand cmd = new SqliteCommand(sql, conn, transaction))
                        {
                            
                            cmd.Parameters.AddWithValue("@firstAidIdx", MD.Instance.firstAidIdx);
                            cmd.Parameters.AddWithValue("@title", MD.Instance.title);
                            cmd.Parameters.AddWithValue("@investigation", MD.Instance.investigation);
                            cmd.Parameters.AddWithValue("@apReport", MD.Instance.apReport);
                            cmd.Parameters.AddWithValue("@descr", MD.Instance.descr);
                            cmd.Parameters.AddWithValue("@cause", MD.Instance.cause);
                            cmd.Parameters.AddWithValue("@notes", MD.Instance.notes);


                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        Frm_FirstAids? frm = Application.OpenForms["Frm_FirstAids"] as Frm_FirstAids;

                        if(frm != null)
                        {
                            frm.LoadDgvFirstAidList();
                            frm.ApplySearchFilter();
                        }

                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }

            }

            
        }
    }
}
