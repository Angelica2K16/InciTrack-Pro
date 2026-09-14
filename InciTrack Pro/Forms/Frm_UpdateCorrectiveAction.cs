using DanMarDev.Identification;
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
using Microsoft.Data.Sqlite;

namespace InciTrack_Pro.Forms
{
    public partial class Frm_UpdateCorrectiveAction : Form
    {
        private List<string> activeEmpList = new List<string>();

        public Frm_UpdateCorrectiveAction()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_UpdateCorrectiveAction_Load;
            pb_exit.Click += Pb_exit_Click;
            pb_minimize.Click += Pb_minimize_Click;
            btn_cancel.Click += Btn_cancel_Click;
            btn_save.Click += Btn_save_Click;
            
        }

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
            Form? frm = Application.OpenForms["Frm_ViewCorrectiveActions"];
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

        #region Custom Control Box Events
        private void Pb_exit_Click(object? sender, EventArgs e)
        {
            Form? frm = Application.OpenForms["Frm_ViewCorrectiveActions"];
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

        #endregion
        private void Frm_UpdateCorrectiveAction_Load(object? sender, EventArgs e)
        {
            GetEmpList();
            LoadControls();
        }

       
        private void GetEmpList()
        {

            EmployeeSearch.ListResult empList = EmployeeSearch.GetAllActiveEmployeesList();
            if (!empList.IsSuccess)
            {
                Console.WriteLine(empList.ErrorMessage);
                return;
            }

            foreach (string item in empList.FullNames)
            {
                if (!item.Contains("Visitor") && !item.Contains("Contractor"))
                {
                    combo_actionOwner.Items.Add(item);
                    activeEmpList.Add(item);
                }
            }

            combo_actionOwner.Sorted = true;
        }

        private void LoadControls()
        {
            dtp_dueDate.Value = MD.Instance.caDueDate;

            if (MD.Instance.caCompDate.HasValue)
            {
                dtp_compDate.Value = MD.Instance.caCompDate.Value;
            }
            else
            {
                dtp_compDate.Text = "";
            }

            combo_actionOwner.SelectedItem = MD.Instance.caActionOwner;
            rtxt_action.Text = MD.Instance.caAction;
            rtxt_notes.Text = MD.Instance.caNotes;
        }

        private bool ValidateControls(out List<string> errors, out Control? firstInvalid)
        {

            errors = new List<string>();
            firstInvalid = null;

            //Check RichTextBoxes
            if (!CheckRichTextBox(rtxt_action, "Action Details", errors))
            {
                if (firstInvalid == null) firstInvalid = rtxt_action;
            }

            if (!CheckRichTextBox(rtxt_notes, "Notes", errors))
            {
                if (firstInvalid == null) firstInvalid = rtxt_notes;
            }

            if (!CheckComboBox(combo_actionOwner, "Action Owner", errors))
            {
                if (firstInvalid == null) firstInvalid = combo_actionOwner;
            }

            // Check DatePicker
            if (!CheckDatePicker(dtp_dueDate, "Due Date", errors))
            {
                if (firstInvalid == null) firstInvalid = dtp_dueDate;
            }

            return errors.Count == 0;

        }

        //Check ComboBoxes
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
        private bool CheckDatePicker(UIDatePicker dtp, string label, List<string> errors)
        {
            bool filled = !dtp.IsEmpty;

            dtp.FillColor = filled ? Color.White : Color.LightPink;

            if (!filled)
                errors.Add($"{label} is required.");

            return filled;
        }

        private bool CheckRichTextBox(UIRichTextBox rtb, string label, List<string> errors)
        {
            bool filled = !string.IsNullOrWhiteSpace(rtb.Text);

            if (Form.ActiveForm?.Name != "Frm_firstAidHazard")
            {
                rtb.BackColor = filled ? SystemColors.Window : Color.LightPink;
            }
            else
            {
                rtb.BackColor = filled ? Color.FromArgb(55, 55, 58) : Color.LightPink;
            }

            if (!filled) errors.Add($"{label} is required.");
            return filled;
        }

        private void SetModelDataClass()
        {
            MD.Instance.caDueDate = dtp_dueDate.Value;
            MD.Instance.caCompDate = dtp_compDate.IsEmpty ? null : dtp_compDate.Value;
            MD.Instance.caActionOwner = combo_actionOwner.SelectedItem.ToString();
            MD.Instance.caAction = rtxt_action.Text;

            if(dtp_compDate.IsEmpty)
            {
                MD.Instance.caStatus = "Open";
            }
            else
            {
                MD.Instance.caStatus = "Close";
            }
            MD.Instance.caNotes = rtxt_notes.Text;
        }

        private void UpdateSqlData()
        {
            //SQLITE Function
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();
                using (SqliteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = $@"
                                        UPDATE CORRECTIVE_ACTIONS SET
                                            Action = @Action,
                                            Action_Owner = @Action_Owner,
                                            Due_Date = @Due_Date,
                                            Completion_Date = @CompDate,
                                            Notes = @Notes,
                                            Status = @Status
                                        WHERE Idx  = @caIdx
                                       ";

                        using (SqliteCommand cmd = new SqliteCommand(sql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@caIdx", MD.Instance.caIdx);
                            cmd.Parameters.AddWithValue("@Action", MD.Instance.caAction);
                            cmd.Parameters.AddWithValue("@Action_Owner", MD.Instance.caActionOwner);
                            cmd.Parameters.AddWithValue("@Due_Date", MD.Instance.caDueDate);
                            cmd.Parameters.AddWithValue("@CompDate", MD.Instance.caCompDate);
                            cmd.Parameters.AddWithValue("@Notes", MD.Instance.caNotes);
                            cmd.Parameters.AddWithValue("@Status", MD.Instance.caStatus);
                            
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        Frm_ViewCorrectiveActions? frm = Application.OpenForms["Frm_ViewCorrectiveActions"] as Frm_ViewCorrectiveActions;

                        if (frm != null)
                        {
                            frm.Btn_ViewAllActions_Click(null, EventArgs.Empty);
                            
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
        }
    }

}
