using DanMarDev.FormDragger;
using DanMarDev.FormManager;
using Microsoft.Data.Sqlite;
using Sunny.UI;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;
using MD = InciTrack_Pro.Base_Classes.ModelData;

namespace InciTrack_Pro.Forms
{
    public partial class Frm_HazardUpdate : Form
    {
        #region Class Level Variables
        public Dictionary<string, string> controlValues = new Dictionary<string, string>();
        private Panel? pnlHelp;
        #endregion

        #region Constructors
        public Frm_HazardUpdate()
        {
            InitializeComponent();
            InitializeEvents();
            FormDragger.EnableDrag(this, pnl_controlBox);
        }

        private void InitializeEvents()
        {
            this.Load += Frm_HazardUpdate_Load;
            pb_exit.Click += Pb_exit_Click;
            pb_minimize.Click += Pb_minimize_Click;
            btn_save.Click += Btn_save_Click;
            btn_cancel.Click += Btn_cancel_Click;
            btn_createCa.Click += Btn_createCa_Click;
            pb_riskMatrix.MouseEnter += Pb_riskMatrix_MouseEnter;
            pb_riskMatrix.MouseLeave += Pb_riskMatrix_MouseLeave;
            
        }
        #endregion

        #region Load Form Event
        private void Frm_HazardUpdate_Load(object? sender, EventArgs e)
        {
            lbl_header.Text = "Hazard Incident Update";
            
            lbl_header.TextAlign = ContentAlignment.MiddleCenter;

            CreateHelpPanel();
            GetHazardDataFromSQL();
            SetControlsWithMdData();
        }
        #endregion

        #region Custom Control Box Events
        private void Pb_exit_Click(object? sender, EventArgs e)
        {
            Form? frm = Application.OpenForms["Frm_Hazards"];
            if (frm != null)
            {
                frm.Show();
                frm.BringToFront();
                this.Close();
                FormManager.SetFormLocation(frm, this);
            }
            else
            {

            }
        }

        private void Pb_minimize_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Risk Matrix PictureBox Events
        private void Pb_riskMatrix_MouseEnter(object? sender, EventArgs e)
        {
            pnlHelp!.Location = new Point(
            pb_riskMatrix.Right + 200,
            pb_riskMatrix.Top + 100);

            pnlHelp?.BringToFront();
            pnlHelp!.Visible = true;
        }
        private void Pb_riskMatrix_MouseLeave(object? sender, EventArgs e)
        {
            pnlHelp!.Visible = false;
        }
        private void CreateHelpPanel()
        {
            pnlHelp = new Panel
            {
                Size = new Size(450, 350),
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            PictureBox pbMatrix = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 250,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Properties.Resources.RiskMatrix
            };

            Label lblLegend = new Label
            {
                Dock = DockStyle.Fill,
                Text =
            "1 = Minimal Hazard\r\n" +
            "2 = Hazard SHare\r\n" +
            "3/4 = HPNM / AP Report\r\n"
            
            };

            pnlHelp.Controls.Add(lblLegend);
            pnlHelp.Controls.Add(pbMatrix);

            Controls.Add(pnlHelp);
        }
        #endregion

        #region Button Events - Save and Cancel Hazard Update
        private void Btn_save_Click(object? sender, EventArgs e)
        {
           

            if (!ValidateControls(out var errs, out var controlFocus))
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
            Form?  frm = Application.OpenForms["Frm_Hazards"];
            if( frm != null )
            {
                frm.Show();
                frm.BringToFront();
                this.Close();
                FormManager.SetFormLocation(frm, this);
            }
            else
            {

            }
           
        }
        #endregion

        #region Button Click Event - Create Hazard Action
        private void Btn_createCa_Click(object? sender, EventArgs e)
        {
            SetModelDataClass();

            Frm_AddCorrectiveAction frm = new Frm_AddCorrectiveAction(this);

            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        #endregion

        #region Helper Methods

        #region Method - SQL Data Retrieval
        private void GetHazardDataFromSQL()
        {
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                string sql = $@"
                            SELECT *
                            FROM HAZARDS
                            WHERE Idx  = @hazardIdx
                           ";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hazardIdx", MD.Instance.hazardIdx);

                    using (SqliteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            MD.Instance.hazTitle = dr["Title"].ToString();
                            MD.Instance.hazDate = Convert.ToDateTime(dr["Date"]);
                            MD.Instance.hazReportedBy = dr["Reported_By"].ToString();
                            MD.Instance.hazArea = dr["Area"].ToString();
                            MD.Instance.hazDescr = dr["Incident_Description"].ToString();
                            MD.Instance.hazApReport = dr["AP_Report"].ToString();
                            MD.Instance.hazNotes = dr["Notes"].ToString();
                            MD.Instance.hazIncidentType = dr["Incident_type"].ToString();
                            MD.Instance.hazRiskMatrix = dr["Risk_Level"].ToString();
                            MD.Instance.hazInjury = dr["Injury_Category"].ToString();
                            MD.Instance.hazEnv = dr["Environment_Category"].ToString();
                            MD.Instance.hazDamage = dr["Damage_Category"].ToString();
                            MD.Instance.hazStatus = dr["Status"].ToString();


                        }
                    }
                }
            }
        }
        #endregion

        #region Method - Set Controls with Data From ModelData Class
        private void SetControlsWithMdData()
        {
            lbl_date.Text = MD.Instance.hazDate.ToString("yyyy-MM-dd");
            lbl_emp.Text= MD.Instance.hazReportedBy;
            lbl_area.Text = MD.Instance.hazArea;
            txt_Title.Text = MD.Instance.hazTitle;
            combo_apReport.SelectedItem = MD.Instance.hazApReport;
            rtxt_descr.Text = MD.Instance.hazDescr;
            rtxt_notes.Text = MD.Instance.hazNotes;
            combo_incidentType.SelectedItem = MD.Instance.hazIncidentType;
            combo_riskMatrix.SelectedItem = MD.Instance.hazRiskMatrix;
            combo_status.SelectedItem = MD.Instance.hazStatus;

            SetCheckedValues(cbg_injury, MD.Instance.hazInjury ?? "");
            SetCheckedValues(cbg_env, MD.Instance.hazEnv ?? "");
            SetCheckedValues(cbg_damage, MD.Instance.hazDamage ?? "");

        }

        private void SetCheckedValues(UICheckBoxGroup group, string categoryString)
        {

            var selectedValues = ParseCategories(categoryString).ToHashSet(StringComparer.OrdinalIgnoreCase);

            List<int> indexes = new();

            for (int i = 0; i < group.Items.Count; i++)
            {
                string item = group.Items[i].ToString() ?? "";

                if (selectedValues.Contains(item))
                {
                    indexes.Add(i);
                }
            }

            group.SelectedIndexes = indexes;


        }

        private List<string> ParseCategories(string value)
        {
            value = value.Replace(
            "Slip, Trip, and / or Fall",
            "__SLIP__");

            value = value.Replace(
            "Physical (Cuts, Burns, Crushing, Pinching)",
            "__PHYSICAL__");

            var categories = value
            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .ToList();

            for (int i = 0; i < categories.Count; i++)
            {
                categories[i] = categories[i]
                .Replace("__SLIP__", "Slip, Trip, and / or Fall")
                .Replace("__PHYSICAL__", "Physical (Cuts, Burns, Crushing, Pinching)");
            }

            return categories;
        }

      
        #endregion

        #region Method -Validate Controls to Save Hazard
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
            if (!CheckComboBox(combo_apReport, "Reported to AP", errors))
            {
                if (firstInvalid == null) firstInvalid = combo_apReport;
            }

            if (!CheckComboBox(combo_riskMatrix, "Risk Matrix Level", errors))
            {
                if (firstInvalid == null) firstInvalid = combo_riskMatrix;
            }

            if (!CheckComboBox(combo_status, "Status", errors))
            {
                if (firstInvalid == null) firstInvalid = combo_status;
            }

            if (!CheckComboBox(combo_incidentType, "Hazard Incident Type", errors))
            {
                if (firstInvalid == null) firstInvalid = combo_incidentType;
            }

            //Check checkboxes
            if (!CheckAnyCategorySelected(errors))
            {
                if (firstInvalid == null)
                    firstInvalid = tableLayoutPanel1.Controls["cbg_injury"];
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

            if(Form.ActiveForm?.Name != "Frm_firstAidHazard")
            {
                rtb.BackColor = filled ? SystemColors.Window : Color.LightPink;
            }
            else
            {
                rtb.BackColor = filled ? Color.FromArgb(55,55,58) : Color.LightPink;
            }

            if (!filled) errors.Add($"{label} is required.");
            return filled;
        }

        private bool CheckComboBox(ComboBox comboB, string label, List<string> errors)
        {
            bool filled = (comboB.SelectedIndex >= 0);
            comboB.BackColor = filled ? SystemColors.Window : Color.LightPink;
            if (!filled) errors.Add($"{label} is required.");
            return filled;
        }

        private bool CheckAnyCategorySelected(List<string> errors)
        {
            var groups = tableLayoutPanel1.Controls.OfType<UICheckBoxGroup>().ToList();
            bool anyChecked = groups.Any(g => g.SelectedItems.Count > 0);

           
            if (!anyChecked)
            {
                errors.Add("At least one category must be selected.");

                foreach (var group in groups)
                {
                    group.FillColor = Color.IndianRed;
                    group.RectColor = Color.Red;
                }

            }
            else
            {
                foreach (var group in groups)
                {
                    group.FillColor = Color.FromArgb(243, 249, 255);
                    group.RectColor = Color.FromArgb(80, 160, 255);
                }
            }

            return anyChecked;
        }
        #endregion

        #region Method - Set ModelData Class with Data from Controls 
        private void SetModelDataClass()
        {
           MD.Instance.hazIncidentType = combo_incidentType.SelectedItem?.ToString() ?? "";
           MD.Instance.hazRiskMatrix = combo_riskMatrix.SelectedItem?.ToString() ?? "";
           MD.Instance.hazApReport = combo_apReport.SelectedItem?.ToString() ?? "";
           MD.Instance.hazDescr = rtxt_descr.Text;
           MD.Instance.hazNotes = rtxt_notes.Text;
           MD.Instance.hazStatus = combo_status.SelectedItem?.ToString() ?? "";
           MD.Instance.hazTitle = txt_Title.Text;
           MD.Instance.hazInjury = string.Join(", ", cbg_injury.SelectedItems);
           MD.Instance.hazEnv = string.Join(", ", cbg_env.SelectedItems);
           MD.Instance.hazDamage = string.Join(", ", cbg_damage.SelectedItems);
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
                            UPDATE HAZARDS SET
                            
                                Title = @title,
                                Incident_type = @incidentType,
                                Risk_Level = @riskLevel,
                                AP_Report = @apReport,
                                Injury_Category = @injuryCat,
                                Environment_Category = @envCat, 
                                Damage_Category = @damageCat,
                                Incident_Description = @descr,
                                Notes = @notes,
                                Status = @status            
                            
                            WHERE Idx  = @hazardIdx
                           ";

                        using (SqliteCommand cmd = new SqliteCommand(sql, conn, transaction))
                        {
                            
                            cmd.Parameters.AddWithValue("@hazardIdx", MD.Instance.hazardIdx);
                            cmd.Parameters.AddWithValue("@title", MD.Instance.hazTitle);
                            cmd.Parameters.AddWithValue("@incidentType", MD.Instance.hazIncidentType);
                            cmd.Parameters.AddWithValue("@riskLevel", MD.Instance.hazRiskMatrix);
                            cmd.Parameters.AddWithValue("@apReport", MD.Instance.hazApReport);
                            cmd.Parameters.AddWithValue("@injuryCat", MD.Instance.hazInjury);
                            cmd.Parameters.AddWithValue("@envCat", MD.Instance.hazEnv);
                            cmd.Parameters.AddWithValue("@damageCat", MD.Instance.hazDamage);
                            cmd.Parameters.AddWithValue("@descr", MD.Instance.hazDescr);
                            cmd.Parameters.AddWithValue("@notes", MD.Instance.hazNotes);
                            cmd.Parameters.AddWithValue("@status", MD.Instance.hazStatus);


                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        Frm_Hazards? frm = Application.OpenForms["Frm_Hazards"] as Frm_Hazards;

                        if(frm != null)
                        {
                            frm.LoadDgvHazardsList();
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
