using InciTrack_Pro.Helper_Classes;
using InciTrack_Pro.UserControls;
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


namespace InciTrack_Pro.Forms
{
    public partial class Frm_Summary : Form
    {
        private bool _loading = true;

        private KpiCard? cardAPHpnm;
        private KpiCard? cardAPFirstAid;
        private KpiCard? cardAPUnsafeAct;
        private KpiCard? cardAPUnsafeCondition;

        private KpiCard? cardSHESHpnm;
        private KpiCard? cardSHESFirstAid;
        private KpiCard? cardSHESUnsafeAct;
        private KpiCard? cardSHESUnsafeCondition;
        private KpiCard? cardClosedActions;
        private KpiCard? cardAudits;
        private KpiCard? cardMinimalHazards;

        public Frm_Summary()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_Summary_Load;
            pb_exit.Click += Pb_exit_Click;
            pb_minimize.Click += Pb_minimize_Click;
            combo_Year.SelectedIndexChanged += FiltersChanged;
            combo_Quarter.SelectedIndexChanged += FiltersChanged;
            combo_month.SelectedIndexChanged += FiltersChanged;
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

        private void Frm_Summary_Load(object? sender, EventArgs e)
        {
            LoadFilterCombos();

            CreateCards();

            SetDefaultFilters();

            _loading = false;

            LoadDashboard();
        }

        private void FiltersChanged(object? sender, EventArgs e)
        {
            if (_loading)
                return;

            if (combo_Year.SelectedItem == null)
                return;

            LoadDashboard();
        }

        private void LoadFilterCombos()
        {
            //Populate the year combobox
            for(int year = DateTime.Now.Year - 3; year <= DateTime.Now.Year; year++)
            {
                combo_Year.Items.Add(year.ToString());
            }

            //Populate the Quarter comboBox
            List<string> qList = new List<string>();
            qList.AddRange(new List<string> { "All Quarters", "Q1", "Q2", "Q3", "Q4" });
            foreach(string quarter in qList)
            {
                combo_Quarter.Items.Add(quarter.ToString());
            }

            //Populate the Month comboBox
            combo_month.Items.Add("All Months");

            for (int month = 1; month <= 12; month++)
            {
                combo_month.Items.Add(
                new DateTime(2000, month, 1).ToString("MMMM"));
            }
        }

        private void SetDefaultFilters()
        {
            combo_Year.SelectedItem = DateTime.Now.Year.ToString();

            int quarter = ((DateTime.Now.Month - 1) / 3) + 1;
            combo_Quarter.SelectedItem = $"Q{quarter}";

            combo_month.SelectedIndex = DateTime.Now.Month;
        }

        private void CreateCards()
        {
            // AP Section
            cardAPHpnm = new KpiCard("HPNM");
            cardAPFirstAid = new KpiCard("First Aids");
            cardAPUnsafeAct = new KpiCard("Unsafe Acts");
            cardAPUnsafeCondition = new KpiCard("Unsafe Conditions");

            flow_AP.Controls.Add(cardAPHpnm);
            flow_AP.Controls.Add(cardAPFirstAid);
            flow_AP.Controls.Add(cardAPUnsafeAct);
            flow_AP.Controls.Add(cardAPUnsafeCondition);

            // SHES Section
            cardSHESHpnm = new KpiCard("HPNM");
            cardSHESFirstAid = new KpiCard("First Aids");
            cardSHESUnsafeAct = new KpiCard("Unsafe Acts");
            cardSHESUnsafeCondition = new KpiCard("Unsafe Conditions");
            cardClosedActions = new KpiCard("Closed Actions");
            cardAudits = new KpiCard("SHES Team Audits");
            cardMinimalHazards = new KpiCard("Minimal Hazards");

            flow_SHES.Controls.Add(cardSHESHpnm);
            flow_SHES.Controls.Add(cardSHESFirstAid);
            flow_SHES.Controls.Add(cardSHESUnsafeAct);
            flow_SHES.Controls.Add(cardSHESUnsafeCondition);
            flow_SHES.Controls.Add(cardClosedActions);
            flow_SHES.Controls.Add(cardAudits);
            flow_SHES.Controls.Add(cardMinimalHazards);
        }

      

        
        private void LoadDashboard()
        {
            var range = GetDateRange();

            // AP
            cardAPHpnm?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM HAZARDS
WHERE Incident_type='HPNM'
AND AP_Report='Yes'
AND Date >= @Start
AND Date < @End",
            range.Start,
            range.End));

            cardAPUnsafeAct?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM HAZARDS
WHERE Incident_type='Hazard Share (Unsafe Act)'
AND AP_Report='Yes'
AND Date >= @Start
AND Date < @End",
            range.Start,
            range.End));

            cardAPUnsafeCondition?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM HAZARDS
WHERE Incident_type='Hazard Share (Unsafe Condition)'
AND AP_Report='Yes'
AND Date >= @Start
AND Date < @End",
            range.Start,
            range.End));

            cardAPFirstAid?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM FIRST_AIDS
WHERE AP_Report='Yes'
AND Date >= @Start
AND Date < @End",
            range.Start,
            range.End));

            // SHES
            cardSHESHpnm?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM HAZARDS
WHERE Incident_type='HPNM'
AND Date >= @Start
AND Date < @End",
            range.Start,
            range.End));

            cardSHESUnsafeAct?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM HAZARDS
WHERE Incident_type='Hazard Share (Unsafe Act)'
AND Date >= @Start
AND Date < @End",
            range.Start,
            range.End));

            cardSHESUnsafeCondition?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM HAZARDS
WHERE Incident_type='Hazard Share (Unsafe Condition)'
AND Date >= @Start
AND Date < @End",
            range.Start,
            range.End));

            cardSHESFirstAid?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM FIRST_AIDS
WHERE Date >= @Start
AND Date < @End",
            range.Start,
            range.End));

            cardClosedActions?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM CORRECTIVE_ACTIONS
WHERE Status='Closed'
AND Completion_Date >= @Start
AND Completion_Date < @End",
            range.Start,
            range.End));

            cardAudits?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM HAZARDS
WHERE Incident_type='SHES Team Audit'
AND Date >= @Start
AND Date < @End",
            range.Start,
            range.End));

            cardMinimalHazards?.SetValue(
            ExecuteCount(
            @"SELECT COUNT(*)
FROM HAZARDS
WHERE Incident_type='Minimal Hazard'
AND Date >= @Start
AND Date < @End",
            range.Start,
            range.End));
        }
        
        private (DateTime Start, DateTime End) GetDateRange()
        {
            if (combo_Year.SelectedItem == null)
            {
                throw new InvalidOperationException("No year selected.");
            }

            int year = int.Parse(combo_Year.SelectedItem.ToString()!);

            // Month selected
            if (combo_month.SelectedIndex > 0)
            {
                int month = combo_month.SelectedIndex;

                DateTime start = new DateTime(year, month, 1);
                DateTime end = start.AddMonths(1);

                return (start, end);
            }

            // Quarter selected
            string quarter = combo_Quarter.SelectedItem?.ToString() ?? "";

            if (quarter.StartsWith("Q"))
            {
                int q = int.Parse(quarter.Substring(1));

                int startMonth = ((q - 1) * 3) + 1;

                DateTime start = new DateTime(year, startMonth, 1);
                DateTime end = start.AddMonths(3);

                return (start, end);
            }

            // Entire year
            return
            (
            new DateTime(year, 1, 1),
            new DateTime(year + 1, 1, 1)
            );
        }

        private int ExecuteCount(string query,
 DateTime startDate,
 DateTime endDate)
        {
            using SqliteConnection conn =
            new SqliteConnection(GV.shesDB);

            conn.Open();

            using SqliteCommand cmd =
            new SqliteCommand(query, conn);

            cmd.Parameters.AddWithValue(
            "@Start",
            startDate.ToString("yyyy-MM-dd"));

            cmd.Parameters.AddWithValue(
            "@End",
            endDate.ToString("yyyy-MM-dd"));

            object? result = cmd.ExecuteScalar();

            return result == DBNull.Value
            ? 0
            : Convert.ToInt32(result);
        }
    }
}
