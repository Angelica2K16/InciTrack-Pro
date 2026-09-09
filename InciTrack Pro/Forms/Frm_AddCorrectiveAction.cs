using DanMarDev.Identification;
using LiveChartsCore.Kernel.Sketches;
using Microsoft.Data.Sqlite;
using Sunny.UI;
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
using MD = InciTrack_Pro.Base_Classes.ModelData;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;

namespace InciTrack_Pro.Forms
{
    public partial class Frm_AddCorrectiveAction : Form
    {
        private List<string> activeEmpList = new List<string>();

        public Frm_AddCorrectiveAction()
        {
            InitializeComponent();
            UIStyles.CultureInfo = CultureInfo.GetCultureInfo("en-US");
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_AddCorrectiveAction_Load;
            pb_exit.Click += Pb_exit_Click;
            pb_minimize.Click += Pb_minimize_Click;
            btn_saveCa.Click += Btn_saveCa_Click;
        }

       

        private void Pb_exit_Click(object? sender, EventArgs e)
        {
            Form? frm = Application.OpenForms["Frm_HazardUpdate"];
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

        private void Frm_AddCorrectiveAction_Load(object? sender, EventArgs e)
        {
            

            GetEmpList();

            lbl_title.Text = "Title: " + MD.Instance.hazTitle;
            lbl_date.Text = "Date: " + MD.Instance.hazDate.ToString("yyyy-MM-dd");
            lbl_type.Text = "Hazard Type: " + MD.Instance.hazIncidentType;
        }

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
                WriteToSql();
            }
        }





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

                        Frm_HazardUpdate? frm = Application.OpenForms["Frm_HazardUpdate"] as Frm_HazardUpdate;

                        if (frm != null)
                        {
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
