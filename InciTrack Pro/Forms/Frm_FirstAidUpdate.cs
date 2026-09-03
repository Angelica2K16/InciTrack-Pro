using FontAwesome.Sharp;
using Microsoft.Data.Sqlite;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
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
        #region Class Level Variables
        public Dictionary<string, string> controlValues = new Dictionary<string, string>();
        private TableLayoutPanel? _hazardTable;
        #endregion

        #region Constructors
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
        #endregion

        #region Load Form Event
        private void Frm_FirstAidUpdate_Load(object? sender, EventArgs e)
        {
            lbl_header.Text = "First Aid Incident Update";
            //lbl_header.Image = IconCharToImage(IconChar.Bandage);
            //lbl_header.ImageAlign = ContentAlignment.BottomRight;
            lbl_header.TextAlign = ContentAlignment.MiddleCenter;

            GetFirstAidIncidentDataFromSQL();
            SetControlsWithMdData();
        }
        #endregion

        #region Button Events - Save and Cancel First Aid Update
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
            Form?  frm = Application.OpenForms["Frm_FirstAids"];
            if( frm != null )
            {
                frm.Show();
                frm.BringToFront();
                this.Close();
            }
            else
            {

            }
           
        }
        #endregion

        #region Create Hazard From First Aid Incident

        #region Button Click Event - Create First Aid Hazard
        private void Btn_createHazard_Click(object? sender, EventArgs e)
        {
            #region Create Form and Controls 
            //create Popup form
            Form popup = new Form();
            popup.BackColor = Color.FromArgb(45, 45, 48);
            popup.Text = "Create a Hazard";
            popup.Size = new Size(900, 400);
            popup.ShowIcon = false;
            popup.StartPosition = FormStartPosition.CenterParent;


            TableLayoutPanel tbl = new TableLayoutPanel
            {
                Name = "tbl_FaUpdateMain",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.Transparent,
                ColumnCount = 2
            };
            _hazardTable = tbl;

            tbl.ColumnStyles.Add(
            new ColumnStyle(SizeType.Absolute, 180));

            tbl.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 100));

            popup.Controls.Add(tbl);
            #endregion

            #region Add Controls to TableLayoutPanel
            List<string> labels = new List<string>
            { 
                "Title",
                "Date",
                "Name",
                "Area",
                "Description",
                "Report to AP",
                "Notes",
                "Incident Type",
                "Injury Category",
                "Environment Category",
                "Damage Category",
                "Corrective Action",
                "Risk Level"

            };


            foreach (string label in labels )
            {
                //string columnName = dr.GetName(i);
                //string value = dr[i]?.ToString() ?? "";

                //AddDetailRow(tbl, columnName, value);
                AddDetailRow(tbl, label);
            }
            #endregion

            #region Add Save Button to TableLayoutPanel
            int row = tbl.RowCount;
            tbl.RowCount++;

            UIButton btn_saveFaHazard = new UIButton
            {
                Text = "Save",
                Width = 100,
                Height = 45,
                

                FillColor = Color.Firebrick,
                FillHoverColor = Color.IndianRed,
                FillPressColor = Color.DarkRed,

                ForeColor = Color.White,
                Font = new Font("Calibri", 12, FontStyle.Bold),

                Radius = 8,
                Cursor = Cursors.Hand,

                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Right,

                
            };
            
            btn_saveFaHazard.Click += Btn_saveFaHazard_Click;

            tbl.Controls.Add(btn_saveFaHazard, 1, row);
            #endregion

            #region Show Popup Form 
            this.Hide();
            popup.ShowDialog();
            #endregion
        }

        #endregion

        #region Button Click Event - Save First Aid Hazard
        private void Btn_saveFaHazard_Click(object? sender, EventArgs e)
        {
            #region Clear Previous Control Values
            controlValues.Clear();
            #endregion region 

            #region Loop Through Controls and Store TValues
            foreach (Control control in _hazardTable.Controls)
            {
                switch (control)
                {
                    case Label lbl:
                        controlValues[lbl.Name] = lbl.Text;
                        break;

                    case TextBox txt:
                        controlValues[txt.Name] = txt.Text;
                        break;

                    case RichTextBox rtb:
                        controlValues[rtb.Name] = rtb.Text;
                        break;

                    case ComboBox cbo:
                        controlValues[cbo.Name] =
                        cbo.SelectedItem?.ToString() ?? "";
                        break;


                }
            }

            #region Get Selected Categories from CheckBoxes
            #region Injury Categories
            Panel pnl1 =_hazardTable.Controls["pnlInjuryCategories"] as Panel;

            TableLayoutPanel catTable1 =
            pnl1.Controls.OfType<TableLayoutPanel>().First();

            List<string> selected1 = new();

            foreach (CheckBox chk in catTable1.Controls.OfType<CheckBox>())
            {
                if (chk.Checked)
                    selected1.Add(chk.Text);
            }

            string injuryCategories = string.Join(", ", selected1);
            #endregion

            #region Environment Categories
            Panel pnl2 = _hazardTable.Controls["pnlEnviromentCategories"] as Panel;

            TableLayoutPanel catTable2 =
            pnl2.Controls.OfType<TableLayoutPanel>().First();

            List<string> selected2 = new();

            foreach (CheckBox chk in catTable2.Controls.OfType<CheckBox>())
            {
                if (chk.Checked)
                    selected2.Add(chk.Text);
            }

            string environmentCategories = string.Join(", ", selected2);
            #endregion

            #region Damage Categories
            Panel pnl3 = _hazardTable.Controls["pnlDamageCategory"] as Panel;

            TableLayoutPanel catTable3 =
            pnl3.Controls.OfType<TableLayoutPanel>().First();

            List<string> selected3 = new();

            foreach (CheckBox chk in catTable3.Controls.OfType<CheckBox>())
            {
                if (chk.Checked)
                    selected3.Add(chk.Text);
            }

            string damageCategories = string.Join(", ", selected3);
            #endregion

            #region Store Selected Categories in Control Values
            controlValues.Add("Injury Category", injuryCategories);
            controlValues.Add("Environment Category", environmentCategories);
            controlValues.Add("Damage Category", damageCategories);
            #endregion
            #endregion

            #endregion

            #region SQL - Insert Data into HAZARDS Table
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();
                using (SqliteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = $@"
                            INSERT INTO HAZARDS
                            (
                                Date,
                                Title,
                                Reported_By, 
                                Incident_type, 
                                Area, 
                                Injury_Category, 
                                Environment_Category,
                                Damage_Category,
                                Incident_Description,
                                Notes, 
                                Status,
                                AP_Report,
                                Risk_Level
                            )
                            VALUES
                            (
                                @Date,
                                @Title,
                                @Reported_By, 
                                @Incident_type, 
                                @Area, 
                                @Injury_Category, 
                                @Environment_Category,
                                @Damage_Category,
                                @Incident_Description,
                                @Notes, 
                                @Status,
                                @AP_Report,
                                @Risk_Level
                            )
                          
                           ";

                        using (SqliteCommand cmd = new SqliteCommand(sql, conn, transaction))
                        {

                            cmd.Parameters.AddWithValue("@Date", controlValues["lbl_date"]);
                            cmd.Parameters.AddWithValue("@Title", controlValues["lbl_title"]);
                            cmd.Parameters.AddWithValue("@Reported_By", controlValues["lbl_empName"]);
                            cmd.Parameters.AddWithValue("@Incident_type", controlValues["combo_incidentType"]);
                            cmd.Parameters.AddWithValue("@Area", controlValues["lbl_area"]);
                            cmd.Parameters.AddWithValue("@Injury_Category", controlValues["Injury Category"]);
                            cmd.Parameters.AddWithValue("@Environment_Category", controlValues["Environment Category"]);
                            cmd.Parameters.AddWithValue("@Damage_Category", controlValues["Damage Category"]);
                            cmd.Parameters.AddWithValue("@Incident_Description", controlValues["rtxt_descr"]);
                            cmd.Parameters.AddWithValue("@Notes", controlValues["rtxt_notes"]);
                            cmd.Parameters.AddWithValue("@Status", "Open");
                            cmd.Parameters.AddWithValue("@AP_Report", controlValues["combo_apReport"]);
                            cmd.Parameters.AddWithValue("@Risk_Level", "0");

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        Frm_FirstAids? frm = Application.OpenForms["Frm_FirstAids"] as Frm_FirstAids;

                        if (frm != null)
                        {
                            frm.LoadDgvFirstAidList();
                            frm.ApplySearchFilter();
                            frm.Show();
                            frm.BringToFront();
                            this.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            #endregion
        }
        #endregion

        #region Method - Add Controls to TableLayoutPanel (Create First Aid Hazard)
        private void AddDetailRow(TableLayoutPanel tbl, string label)
        {
           
            int row = tbl.RowCount;

            tbl.RowCount++;

            tbl.RowStyles.Add(
            new RowStyle(SizeType.AutoSize));

            #region Create Label Control for Field Name
            Label lblField = new Label
            {
                Name = "lblField_" + label,
                Text = label + ":",
                ForeColor = Color.White,
                AutoSize = true,
                Font = new Font("Calibri", 12, FontStyle.Bold)
            };
            #endregion

            #region Create TableLayoutPanel for Category CheckBoxes
            TableLayoutPanel tblCatPnl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.Transparent,
                ColumnCount = 1
            };

            tblCatPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            #endregion

            Control valueControl = new Label();
            valueControl.Margin = new Padding(3, 8, 3, 8);

            #region Switch Code to p[lace correct control based on label
            switch (label)
            {
                #region Title Field
                case "Title":
                    valueControl = new Label
                    {
                        Name = "lbl_title",
                        Text = MD.Instance.title + "_FA" + MD.Instance.firstAidIdx,
                        
                        ForeColor = Color.White,
                        AutoSize = true,
                        Font = new Font("Calibri", 12)
                    };
                    //controlValues.Add("Title", valueControl.Text);
                    break;
                #endregion

                #region Date Field
                case "Date":
                    valueControl = new Label
                    {
                        Name = "lbl_date",
                        Text = MD.Instance.date.ToString("yyyy-MM-dd"),
                        ForeColor = Color.White,
                        AutoSize = true,
                        Font = new Font("Calibri", 12)
                    };
                    //controlValues.Add("Date", valueControl.Text);
                    break;
                #endregion

                #region Name Field
                case "Name":
                    valueControl = new Label
                    {
                        Name = "lbl_empName",
                        Text = UserPrincipal.Current.DisplayName,
                        ForeColor = Color.White,
                        AutoSize = true,
                        Font = new Font("Calibri", 12)
                    };
                    //controlValues.Add("Name", valueControl.Text);
                    break;
                #endregion

                #region Area Field
                case "Area":
                    valueControl = new Label
                    {
                        Name = "lbl_area",
                        Text = MD.Instance.area,
                        ForeColor = Color.White,
                        AutoSize = true,
                        Font = new Font("Calibri", 12)
                    };
                    //controlValues.Add("Area", valueControl.Text);
                    break;
                #endregion

                #region Description Field
                case "Description":
                    valueControl = new RichTextBox
                    {
                        Name = "rtxt_descr",
                        Text = "First-Aid Description:\n" + MD.Instance.descr + "\n\nHazard Description:\n",
                        ReadOnly = false,
                        BorderStyle = BorderStyle.Fixed3D,
                        BackColor = Color.FromArgb(55, 55, 58),
                        ForeColor = Color.White,
                        Multiline = true,
                        Dock = DockStyle.Fill
                    };
                   // controlValues.Add("Incident Description", valueControl.Text);
                    break;
                #endregion

                #region Report to AP Field
                case "Report to AP":
                    valueControl = new ComboBox
                    {
                        Name = "combo_apReport",
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Dock = DockStyle.Fill
                        
                    };

                    ComboBox comboAP = (ComboBox)valueControl;
                    comboAP.Items.AddRange(new string[] { "Yes", "No" });
                    comboAP.SelectedItem = MD.Instance.apReport;
                    //controlValues.Add("AP Report", comboAP.SelectedItem.ToString());
                    break;
                #endregion

                #region Notes Field
                case "Notes":
                    valueControl = new RichTextBox
                    {
                        Name = "rtxt_notes",
                        Text = MD.Instance.notes,
                        ReadOnly = false,
                        BorderStyle = BorderStyle.Fixed3D,
                        BackColor = Color.FromArgb(55, 55, 58),
                        ForeColor = Color.White,
                        Multiline = MD.Instance.notes.Length > 75,
                        Dock = DockStyle.Fill
                    };
                    //controlValues.Add("Notes", valueControl.Text);
                    break;
                #endregion

                #region Incident Type Field
                case "Incident Type":
                    valueControl = new ComboBox
                    {
                        Name = "combo_incidentType",
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Dock = DockStyle.Fill

                    };

                    ComboBox comboType = (ComboBox)valueControl;
                    comboType.Items.AddRange(new string[] { "HPNM", "Hazard Share (Unsafe Act)", "Hazard Share (Unsafe Condition)","Minimal Hazard"});
                    comboType.SelectedIndex = -1;
                    //controlValues.Add("Type", comboType.SelectedItem.ToString());
                    break;
                #endregion

                #region Injury Category Field
                case "Injury Category":

                    List<string> injCatList = new List<string>
                                {
                                    "Chemical Hazard",
                                    "Electrical Hazard",
                                    "Heavy Lifting",
                                     "Physical (Cuts, Burns, Crushing, Pinching)",
                                     "Repetitive Motion",
                                     "Slip, Trip, and/or Fall"

                                };

                    valueControl = createCheckBoxes(injCatList, tblCatPnl, valueControl, "pnlInjuryCategories");
                    break;
                #endregion

                #region Environment Category Field
                case "Environment Category":
                    List<string> envCatList = new List<string>
                                {
                                    "Release to Air",
                                    "Release to Ground",
                                    "Release to Water"
                                };

                    valueControl = createCheckBoxes(envCatList, tblCatPnl, valueControl, "pnlEnviromentCategories");
                    break;
                #endregion

                #region Damage Category Field
                case "Damage Category":
                    List<string> damageCatList = new List<string>
                                {
                                    "Crimminal Damage",
                                    "Equipment Damage",
                                    "Fire Damage",
                                    "Water Damage"
                                };

                    valueControl = createCheckBoxes(damageCatList, tblCatPnl, valueControl, "pnlDamageCategory");
                    break;
                #endregion

                #region Corrective Action Field
                case "Corrective Action":
                    valueControl = new Button
                    {
                        Text = "Add",
                        AutoSize = true,
                        BackColor = Color.DodgerBlue,
                        ForeColor = Color.White
                    };
                    break;
                #endregion

                #region Risk Level Field
                //case "Risk Level":
                //controlValues.Add("Notes", valueControl.Text);
                //  break;
                #endregion

                #region Switch Default
                default:
                    valueControl = new Label
                    {
                        Name = "lbl_error",
                        Text = "Error",
                        ForeColor = Color.White,
                        AutoSize = true,
                        Font = new Font("Calibri", 12)
                    };
                    break;
                #endregion
            }
            #endregion

            #region Add All Controls to TableLayoutPanel
            tbl.Controls.Add(lblField, 0, row);
            tbl.Controls.Add(valueControl, 1, row);
            #endregion
        }

        #region Method - Create Controls for Category sections
        private Control createCheckBoxes(List<string> catDescr, TableLayoutPanel tblCatPnl, Control valueControl, string panelName)
        {
            #region Create Section Panels - Visual Effect
            Panel pnl = new Panel
            {
                Name = panelName,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(75, 75, 78),
                //Padding = new Padding(10),
                //Margin = new Padding(0, 10, 0, 5)
            };
            #endregion

            #region Create Checkboxes 
            foreach (string item in catDescr)
            {
                int catRow = tblCatPnl.RowCount;

                tblCatPnl.RowCount++;

                tblCatPnl.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

                valueControl = new CheckBox
                {
                    Name = "cb_" + item.Replace(" ", ""),
                    Text = item,
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(75, 75, 78),
                    Font = new Font("Calibri", 12),
                    Dock = DockStyle.Fill

                };
                tblCatPnl.Controls.Add(valueControl, 0, catRow);
                pnl.Controls.Add(tblCatPnl);
            };
            #endregion

            #region Return Panel with added checkboxes
            return pnl;
            #endregion
        }
        #endregion

        #endregion

        #endregion

        #region Helper Methods

        #region Method - SQL Data Retrieval
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
        #endregion

        #region Method - Set Controls with Data From ModelData Class
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
        #endregion

        #region Method -Validate Controls to Save First Aid
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
        #endregion

        #region Method - Set ModelData Class with Data from Controls 
        private void SetModelDataClass()
        {
            MD.Instance.title = txt_Title.Text;
            MD.Instance.investigation = combo_investigation.SelectedItem?.ToString();
            MD.Instance.apReport = combo_apReport.SelectedItem?.ToString();
            MD.Instance.descr = rtxt_descr.Text;
            MD.Instance.cause = rtxt_cause.Text;
            MD.Instance.notes = rtxt_notes.Text;
        }
        #endregion

        #region Method - SQL Data Update
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
                            frm.Show();
                            frm.BringToFront();
                            this.Close();
                        }

                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }
        #endregion

        #endregion

    }
}
