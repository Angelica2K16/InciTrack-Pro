using DanMarDev.FormDragger;
using DanMarDev.FormManager;
using DanMarDev.Identification;
using DanMarDev.WinForms_CustomTools;
using Microsoft.Data.Sqlite;
using Sunny.UI;
using System.Diagnostics;
using System.Globalization;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;
using MD = InciTrack_Pro.Base_Classes.ModelData;
using static DanMarDev.WinForms_CustomTools.MsgBoxType;
using DanMarDev.WinForms_CustomTools;

namespace InciTrack_Pro.Forms
{
    public partial class Frm_AddCorrectiveAction : Form
    {
        #region Class Level Variables
        private List<string> activeEmpList = new List<string>();
        private Form _parentForm;
        #endregion

        #region Constructors
        public Frm_AddCorrectiveAction(Form parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            UIStyles.CultureInfo = CultureInfo.GetCultureInfo("en-US");
            InitializeEvents();

            FormDragger.EnableDrag(this, pnl_controlBox);
        }

        private void InitializeEvents()
        {
            this.Load += Frm_AddCorrectiveAction_Load;
            pb_exit.Click += Pb_exit_Click;
            pb_minimize.Click += Pb_minimize_Click;
            btn_saveCa.Click += Btn_saveCa_Click;
            
        }
        #endregion

        #region Custom Controlbox Events
        private void Pb_exit_Click(object? sender, EventArgs e)
        {
            Form? frm = Application.OpenForms["Frm_HazardUpdate"];

            if (frm != null)
            {
                frm.Show();
                frm.BringToFront();
                this.Close();
                FormManager.SetFormLocation(frm, this);
                return;
            }

            frm = Application.OpenForms["Frm_ViewCorrectiveActions"];

            if (frm != null)
            {
                frm.Show();
                frm.BringToFront();
                this.Close();
                FormManager.SetFormLocation(frm, this);
                return;
            }

            
        }

        private void Pb_minimize_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Form Load Event
        private void Frm_AddCorrectiveAction_Load(object? sender, EventArgs e)
        {
            GetEmpList();

            lbl_title.Text = "Title: " + MD.Instance.hazTitle;
            lbl_date.Text = "Date: " + MD.Instance.hazDate.ToString("yyyy-MM-dd");
            lbl_type.Text = "Hazard Type: " + MD.Instance.hazIncidentType;
        }
        #endregion

        #region Save Corrective Action
        private void Btn_saveCa_Click(object? sender, EventArgs e)
        {
            Debug.WriteLine(this.Font.Name);
            Debug.WriteLine(dtp_dueDate.Font.Name);

            foreach (Control c in this.Controls)
            {
                Debug.WriteLine($"{c.Name}: {c.Font.Name}");
            }

            if (!ValidateControls(out var errs, out var controlFocus))
            {
                // Build readable message text
                string message = string.Join("\n• ", errs);
                message = "Please correct the following:\n\n• " + message;

                MsgBox.Show(ErrorNoExit, message, "Validation Errors");

                // Optionally set focus to the first invalid control
                controlFocus?.Focus();
            }
            else
            {
                WriteToSql();
            }
        }
        #endregion

        #region Helper Methods

        #region Method - Get Employee List
        private void GetEmpList()
        {
            
            EmployeeSearch.ListResult empList = EmployeeSearch.GetAllActiveEmployeesList();
            if (!empList.IsSuccess)
            {
                Console.WriteLine(empList.ErrorMessage);
                return;
            }

            foreach(string item in empList.FullNames)
            {
                if(!item.Contains("Visitor") && !item.Contains("Contractor"))
                {
                    combo_empName.Items.Add(item);
                    activeEmpList.Add(item);
                }
            }

            combo_empName.Sorted = true;
        }
        #endregion

        #region Method - Validate Controls
        private bool ValidateControls(out List<string> errors, out Control? firstInvalid)
        {
            

            errors = new List<string>();
            firstInvalid = null;

            // Check DatePicker
            if (!CheckDatePicker(dtp_dueDate, "Due Date", errors))
            {
                if (firstInvalid == null) firstInvalid = dtp_dueDate;
            }

            //Check RichTextBoxes
            if (!CheckRichTextBox(rtxt_Ca, "Corrective Action Details", errors))
            {
                if (firstInvalid == null) firstInvalid = rtxt_Ca;
            }

            if (!CheckRichTextBox(rtxt_notes, "Notes", errors))
            {
                if (firstInvalid == null) firstInvalid = rtxt_notes;
            }

            //Check ComboBoxes
            if (!CheckComboBox(combo_empName, "Action Owner", errors))
            {
                if (firstInvalid == null) firstInvalid = combo_empName;
            }

            return errors.Count == 0;

        }

        private bool CheckDatePicker(UIDatePicker dtp, string label, List<string> errors)
        {
            bool filled = dtp.Value.Date >= DateTime.Today;
            dtp.FillColor = filled ? Color.White : Color.LightPink;
            if (!filled) errors.Add($"{label} cannot be in the past.");
            return filled;
        }
        private bool CheckRichTextBox(UIRichTextBox rtb, string label, List<string> errors)
        {
            bool filled = !string.IsNullOrWhiteSpace(rtb.Text);
            rtb.FillColor = filled ? Color.White : Color.LightPink;
            if (!filled) errors.Add($"{label} is required.");
            return filled;
        }

        private bool CheckComboBox(UIComboBox comboB, string label, List<string> errors)
        {
            bool filled = activeEmpList.Any(x =>
                x.Equals(comboB.Text.Trim(),
                StringComparison.OrdinalIgnoreCase));

            comboB.FillColor = filled ? SystemColors.Window : Color.LightPink;

            if (!filled)
                errors.Add($"{label} is required and must be selected from the provided list.");

            return filled;
        }
        #endregion

        #region Method - SQLite Write to Tables
        private void WriteToSql()
        {
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();
                using (SqliteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = $@"
                            INSERT INTO CORRECTIVE_ACTIONS
                            (
                                Hazard_Idx,
                                Action,
                                Action_Owner, 
                                Due_Date, 
                                Notes, 
                                Completion_Date,
                                Status 
                            )
                            VALUES
                            (
                                @Hazard_Idx,
                                @Action,
                                @Action_Owner, 
                                @Due_Date, 
                                @Notes, 
                                @Completion_Date,            
                                @Status 
                            )";

                        using (SqliteCommand cmd = new SqliteCommand(sql, conn, transaction))
                        {

                            cmd.Parameters.AddWithValue("@Hazard_Idx", MD.Instance.hazardIdx);
                            cmd.Parameters.AddWithValue("@Action", rtxt_Ca.Text);
                            cmd.Parameters.AddWithValue("@Action_Owner", combo_empName.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Due_Date", dtp_dueDate.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Notes", rtxt_notes.Text);
                            cmd.Parameters.AddWithValue("@Status", "Open");
                            cmd.Parameters.AddWithValue("@Completion_Date", DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        Form? frm = Application.OpenForms["Frm_HazardUpdate"];

                        if (frm != null)
                        {
                            frm.Show();
                            frm.BringToFront();
                            this.Close();
                            FormManager.SetFormLocation(frm, this);
                            return;
                        }

                        frm = Application.OpenForms["Frm_ViewCorrectiveActions"];

                        if (frm != null)
                        {
                            frm.Show();
                            frm.BringToFront();
                            this.Close();
                            FormManager.SetFormLocation(frm, this);
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MsgBox.Show(ErrorNoExit, ex.Message);
                    }
                }

            }
        }
        #endregion

        #endregion
    }
}
