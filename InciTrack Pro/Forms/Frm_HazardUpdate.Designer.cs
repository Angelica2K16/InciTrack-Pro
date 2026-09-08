namespace InciTrack_Pro.Forms
{
    partial class Frm_HazardUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HazardUpdate));
            pnl_controlBox = new Panel();
            label1 = new Label();
            pb_dmLogo = new PictureBox();
            pb_minimize = new PictureBox();
            pb_exit = new PictureBox();
            pnl_header = new Panel();
            lbl_header = new Label();
            tbl_main = new TableLayoutPanel();
            combo_incidentType = new ComboBox();
            lbl_typeLbl = new Label();
            combo_apReport = new ComboBox();
            lbl_emp = new Label();
            lbl_date = new Label();
            lbl_datelbl = new Label();
            lbl_empLbl = new Label();
            lbl_apreportLbl = new Label();
            combo_riskMatrix = new ComboBox();
            lbl_areaLbl = new Label();
            lbl_area = new Label();
            lbl_riskLbl = new Label();
            lbl_title = new Label();
            txt_Title = new TextBox();
            lbl_description = new Label();
            lbl_notesLbl = new Label();
            rtxt_descr = new RichTextBox();
            rtxt_notes = new RichTextBox();
            lbl_statusLbl = new Label();
            combo_status = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            cbg_damage = new Sunny.UI.UICheckBoxGroup();
            cbg_injury = new Sunny.UI.UICheckBoxGroup();
            cbg_env = new Sunny.UI.UICheckBoxGroup();
            panel1 = new Panel();
            btn_createCa = new Sunny.UI.UIButton();
            btn_save = new Sunny.UI.UIButton();
            btn_cancel = new Sunny.UI.UIButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pb_riskMatrix = new PictureBox();
            pnl_controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).BeginInit();
            pnl_header.SuspendLayout();
            tbl_main.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_riskMatrix).BeginInit();
            SuspendLayout();
            // 
            // pnl_controlBox
            // 
            pnl_controlBox.Controls.Add(label1);
            pnl_controlBox.Controls.Add(pb_dmLogo);
            pnl_controlBox.Controls.Add(pb_minimize);
            pnl_controlBox.Controls.Add(pb_exit);
            pnl_controlBox.Dock = DockStyle.Top;
            pnl_controlBox.Location = new Point(0, 0);
            pnl_controlBox.Name = "pnl_controlBox";
            pnl_controlBox.Size = new Size(950, 37);
            pnl_controlBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(44, 9);
            label1.Name = "label1";
            label1.Size = new Size(158, 24);
            label1.TabIndex = 6;
            label1.Text = "InciTrack Pro";
            // 
            // pb_dmLogo
            // 
            pb_dmLogo.BackColor = Color.Transparent;
            pb_dmLogo.BackgroundImage = Properties.Resources.Dan_Mar_Logo_large;
            pb_dmLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pb_dmLogo.Location = new Point(1, 2);
            pb_dmLogo.Name = "pb_dmLogo";
            pb_dmLogo.Size = new Size(37, 34);
            pb_dmLogo.TabIndex = 5;
            pb_dmLogo.TabStop = false;
            // 
            // pb_minimize
            // 
            pb_minimize.BackColor = Color.Transparent;
            pb_minimize.BackgroundImage = Properties.Resources.minimize_14775;
            pb_minimize.BackgroundImageLayout = ImageLayout.Zoom;
            pb_minimize.Location = new Point(867, 3);
            pb_minimize.Name = "pb_minimize";
            pb_minimize.Size = new Size(37, 34);
            pb_minimize.TabIndex = 3;
            pb_minimize.TabStop = false;
            // 
            // pb_exit
            // 
            pb_exit.BackColor = Color.Transparent;
            pb_exit.BackgroundImage = Properties.Resources.exit_close_error_15565;
            pb_exit.BackgroundImageLayout = ImageLayout.Zoom;
            pb_exit.Location = new Point(910, 3);
            pb_exit.Name = "pb_exit";
            pb_exit.Size = new Size(37, 34);
            pb_exit.TabIndex = 2;
            pb_exit.TabStop = false;
            // 
            // pnl_header
            // 
            pnl_header.BackColor = Color.IndianRed;
            pnl_header.Controls.Add(lbl_header);
            pnl_header.Dock = DockStyle.Top;
            pnl_header.Location = new Point(0, 37);
            pnl_header.Name = "pnl_header";
            pnl_header.Size = new Size(950, 40);
            pnl_header.TabIndex = 1;
            // 
            // lbl_header
            // 
            lbl_header.AutoSize = true;
            lbl_header.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_header.ForeColor = Color.White;
            lbl_header.Location = new Point(12, 12);
            lbl_header.Name = "lbl_header";
            lbl_header.Size = new Size(50, 19);
            lbl_header.TabIndex = 0;
            lbl_header.Text = "label2";
            // 
            // tbl_main
            // 
            tbl_main.BackColor = Color.Transparent;
            tbl_main.ColumnCount = 2;
            tbl_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 168F));
            tbl_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_main.Controls.Add(combo_incidentType, 1, 3);
            tbl_main.Controls.Add(lbl_typeLbl, 0, 3);
            tbl_main.Controls.Add(combo_apReport, 1, 6);
            tbl_main.Controls.Add(lbl_emp, 1, 1);
            tbl_main.Controls.Add(lbl_date, 1, 0);
            tbl_main.Controls.Add(lbl_datelbl, 0, 0);
            tbl_main.Controls.Add(lbl_empLbl, 0, 1);
            tbl_main.Controls.Add(lbl_apreportLbl, 0, 6);
            tbl_main.Controls.Add(lbl_areaLbl, 0, 2);
            tbl_main.Controls.Add(lbl_area, 1, 2);
            tbl_main.Controls.Add(lbl_riskLbl, 0, 5);
            tbl_main.Controls.Add(lbl_title, 0, 4);
            tbl_main.Controls.Add(txt_Title, 1, 4);
            tbl_main.Controls.Add(lbl_description, 0, 8);
            tbl_main.Controls.Add(lbl_notesLbl, 0, 9);
            tbl_main.Controls.Add(rtxt_descr, 1, 8);
            tbl_main.Controls.Add(rtxt_notes, 1, 9);
            tbl_main.Controls.Add(lbl_statusLbl, 0, 10);
            tbl_main.Controls.Add(combo_status, 1, 10);
            tbl_main.Controls.Add(tableLayoutPanel1, 1, 7);
            tbl_main.Controls.Add(flowLayoutPanel1, 1, 5);
            tbl_main.Dock = DockStyle.Fill;
            tbl_main.Location = new Point(0, 77);
            tbl_main.Name = "tbl_main";
            tbl_main.RowCount = 11;
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 245F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 73F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tbl_main.Size = new Size(950, 723);
            tbl_main.TabIndex = 2;
            // 
            // combo_incidentType
            // 
            combo_incidentType.FormattingEnabled = true;
            combo_incidentType.Items.AddRange(new object[] { "HPNM", "Hazard Share (Unsafe Act)", "Hazard Share (Unsafe Condition)", "SHES Team Audit", "Minimal Hazard" });
            combo_incidentType.Location = new Point(171, 108);
            combo_incidentType.Name = "combo_incidentType";
            combo_incidentType.Size = new Size(302, 27);
            combo_incidentType.TabIndex = 21;
            // 
            // lbl_typeLbl
            // 
            lbl_typeLbl.AutoSize = true;
            lbl_typeLbl.ForeColor = Color.White;
            lbl_typeLbl.Location = new Point(3, 105);
            lbl_typeLbl.Name = "lbl_typeLbl";
            lbl_typeLbl.Size = new Size(99, 19);
            lbl_typeLbl.TabIndex = 20;
            lbl_typeLbl.Text = "Incident Type:";
            // 
            // combo_apReport
            // 
            combo_apReport.FormattingEnabled = true;
            combo_apReport.Items.AddRange(new object[] { "Yes", "No" });
            combo_apReport.Location = new Point(171, 213);
            combo_apReport.Name = "combo_apReport";
            combo_apReport.Size = new Size(124, 27);
            combo_apReport.TabIndex = 16;
            // 
            // lbl_emp
            // 
            lbl_emp.AutoSize = true;
            lbl_emp.ForeColor = Color.White;
            lbl_emp.Location = new Point(171, 35);
            lbl_emp.Name = "lbl_emp";
            lbl_emp.Size = new Size(57, 19);
            lbl_emp.TabIndex = 8;
            lbl_emp.Text = "Deafult";
            // 
            // lbl_date
            // 
            lbl_date.AutoSize = true;
            lbl_date.ForeColor = Color.White;
            lbl_date.Location = new Point(171, 0);
            lbl_date.Name = "lbl_date";
            lbl_date.Padding = new Padding(0, 5, 0, 0);
            lbl_date.Size = new Size(57, 24);
            lbl_date.TabIndex = 7;
            lbl_date.Text = "Default";
            // 
            // lbl_datelbl
            // 
            lbl_datelbl.AutoSize = true;
            lbl_datelbl.ForeColor = Color.White;
            lbl_datelbl.Location = new Point(3, 0);
            lbl_datelbl.Name = "lbl_datelbl";
            lbl_datelbl.Padding = new Padding(0, 5, 0, 0);
            lbl_datelbl.Size = new Size(44, 24);
            lbl_datelbl.TabIndex = 0;
            lbl_datelbl.Text = "Date:";
            // 
            // lbl_empLbl
            // 
            lbl_empLbl.AutoSize = true;
            lbl_empLbl.ForeColor = Color.White;
            lbl_empLbl.Location = new Point(3, 35);
            lbl_empLbl.Name = "lbl_empLbl";
            lbl_empLbl.Size = new Size(92, 19);
            lbl_empLbl.TabIndex = 5;
            lbl_empLbl.Text = "Reported By:";
            // 
            // lbl_apreportLbl
            // 
            lbl_apreportLbl.AutoSize = true;
            lbl_apreportLbl.ForeColor = Color.White;
            lbl_apreportLbl.Location = new Point(3, 210);
            lbl_apreportLbl.Name = "lbl_apreportLbl";
            lbl_apreportLbl.Size = new Size(110, 19);
            lbl_apreportLbl.TabIndex = 6;
            lbl_apreportLbl.Text = "Reported to AP:";
            // 
            // combo_riskMatrix
            // 
            combo_riskMatrix.FormattingEnabled = true;
            combo_riskMatrix.Items.AddRange(new object[] { "0", "1", "2", "3", "4" });
            combo_riskMatrix.Location = new Point(3, 3);
            combo_riskMatrix.Name = "combo_riskMatrix";
            combo_riskMatrix.Size = new Size(121, 27);
            combo_riskMatrix.TabIndex = 15;
            // 
            // lbl_areaLbl
            // 
            lbl_areaLbl.AutoSize = true;
            lbl_areaLbl.ForeColor = Color.White;
            lbl_areaLbl.Location = new Point(3, 70);
            lbl_areaLbl.Name = "lbl_areaLbl";
            lbl_areaLbl.Size = new Size(43, 19);
            lbl_areaLbl.TabIndex = 2;
            lbl_areaLbl.Text = "Area:";
            // 
            // lbl_area
            // 
            lbl_area.AutoSize = true;
            lbl_area.ForeColor = Color.White;
            lbl_area.Location = new Point(171, 70);
            lbl_area.Name = "lbl_area";
            lbl_area.Size = new Size(57, 19);
            lbl_area.TabIndex = 10;
            lbl_area.Text = "Default";
            // 
            // lbl_riskLbl
            // 
            lbl_riskLbl.AutoSize = true;
            lbl_riskLbl.ForeColor = Color.White;
            lbl_riskLbl.Location = new Point(3, 175);
            lbl_riskLbl.Name = "lbl_riskLbl";
            lbl_riskLbl.Size = new Size(124, 19);
            lbl_riskLbl.TabIndex = 4;
            lbl_riskLbl.Text = "Risk Matrix Level:";
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.ForeColor = Color.White;
            lbl_title.Location = new Point(3, 140);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(42, 19);
            lbl_title.TabIndex = 3;
            lbl_title.Text = "Title:";
            // 
            // txt_Title
            // 
            txt_Title.Location = new Point(171, 143);
            txt_Title.Name = "txt_Title";
            txt_Title.Size = new Size(387, 27);
            txt_Title.TabIndex = 11;
            // 
            // lbl_description
            // 
            lbl_description.AutoSize = true;
            lbl_description.ForeColor = Color.White;
            lbl_description.Location = new Point(3, 490);
            lbl_description.Name = "lbl_description";
            lbl_description.Size = new Size(87, 19);
            lbl_description.TabIndex = 12;
            lbl_description.Text = "Description:";
            // 
            // lbl_notesLbl
            // 
            lbl_notesLbl.AutoSize = true;
            lbl_notesLbl.ForeColor = Color.White;
            lbl_notesLbl.Location = new Point(3, 564);
            lbl_notesLbl.Name = "lbl_notesLbl";
            lbl_notesLbl.Size = new Size(51, 19);
            lbl_notesLbl.TabIndex = 14;
            lbl_notesLbl.Text = "Notes:";
            // 
            // rtxt_descr
            // 
            rtxt_descr.Dock = DockStyle.Fill;
            rtxt_descr.Location = new Point(171, 493);
            rtxt_descr.Name = "rtxt_descr";
            rtxt_descr.Size = new Size(776, 68);
            rtxt_descr.TabIndex = 17;
            rtxt_descr.Text = "";
            // 
            // rtxt_notes
            // 
            rtxt_notes.Dock = DockStyle.Fill;
            rtxt_notes.Location = new Point(171, 567);
            rtxt_notes.Name = "rtxt_notes";
            rtxt_notes.Size = new Size(776, 64);
            rtxt_notes.TabIndex = 19;
            rtxt_notes.Text = "";
            // 
            // lbl_statusLbl
            // 
            lbl_statusLbl.AutoSize = true;
            lbl_statusLbl.ForeColor = Color.White;
            lbl_statusLbl.Location = new Point(3, 634);
            lbl_statusLbl.Name = "lbl_statusLbl";
            lbl_statusLbl.Size = new Size(53, 19);
            lbl_statusLbl.TabIndex = 22;
            lbl_statusLbl.Text = "Status:";
            // 
            // combo_status
            // 
            combo_status.FormattingEnabled = true;
            combo_status.Items.AddRange(new object[] { "Open", "Closed" });
            combo_status.Location = new Point(171, 637);
            combo_status.Name = "combo_status";
            combo_status.Size = new Size(159, 27);
            combo_status.TabIndex = 23;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.3955231F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.6044769F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 239F));
            tableLayoutPanel1.Controls.Add(cbg_damage, 2, 0);
            tableLayoutPanel1.Controls.Add(cbg_injury, 0, 0);
            tableLayoutPanel1.Controls.Add(cbg_env, 1, 0);
            tableLayoutPanel1.Location = new Point(171, 248);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(776, 239);
            tableLayoutPanel1.TabIndex = 24;
            // 
            // cbg_damage
            // 
            cbg_damage.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbg_damage.Items.AddRange(new object[] { "Criminal Damage", "Equipment Damage", "Fire Damage", "Water Damage" });
            cbg_damage.Location = new Point(540, 5);
            cbg_damage.Margin = new Padding(4, 5, 4, 5);
            cbg_damage.MinimumSize = new Size(1, 1);
            cbg_damage.Name = "cbg_damage";
            cbg_damage.Padding = new Padding(0, 32, 0, 0);
            cbg_damage.SelectedIndexes = (List<int>)resources.GetObject("cbg_damage.SelectedIndexes");
            cbg_damage.Size = new Size(232, 229);
            cbg_damage.TabIndex = 2;
            cbg_damage.Text = "Potential Property Damage / Loss";
            cbg_damage.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // cbg_injury
            // 
            cbg_injury.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbg_injury.Items.AddRange(new object[] { "Chemical Hazard", "Electrical Hazard", "Heavy Lifting ", "Physical (Cuts, Burns, Crushing, Pinching)", "Repetitive Motion", "Slip, Trip, and / or Fall" });
            cbg_injury.Location = new Point(4, 5);
            cbg_injury.Margin = new Padding(4, 5, 4, 5);
            cbg_injury.MinimumSize = new Size(1, 1);
            cbg_injury.Name = "cbg_injury";
            cbg_injury.Padding = new Padding(0, 32, 0, 0);
            cbg_injury.SelectedIndexes = (List<int>)resources.GetObject("cbg_injury.SelectedIndexes");
            cbg_injury.Size = new Size(305, 229);
            cbg_injury.TabIndex = 0;
            cbg_injury.Text = "Potential Injury";
            cbg_injury.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // cbg_env
            // 
            cbg_env.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbg_env.Items.AddRange(new object[] { "Release to Air", "Release to Ground", "Release to Water" });
            cbg_env.Location = new Point(317, 5);
            cbg_env.Margin = new Padding(4, 5, 4, 5);
            cbg_env.MinimumSize = new Size(1, 1);
            cbg_env.Name = "cbg_env";
            cbg_env.Padding = new Padding(0, 32, 0, 0);
            cbg_env.SelectedIndexes = (List<int>)resources.GetObject("cbg_env.SelectedIndexes");
            cbg_env.Size = new Size(215, 229);
            cbg_env.TabIndex = 1;
            cbg_env.Text = "Potential Environmental Impact";
            cbg_env.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btn_createCa);
            panel1.Controls.Add(btn_save);
            panel1.Controls.Add(btn_cancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 746);
            panel1.Name = "panel1";
            panel1.Size = new Size(950, 54);
            panel1.TabIndex = 3;
            // 
            // btn_createCa
            // 
            btn_createCa.BackColor = Color.Transparent;
            btn_createCa.FillColor = Color.IndianRed;
            btn_createCa.FillColor2 = Color.IndianRed;
            btn_createCa.FillHoverColor = Color.FromArgb(255, 192, 192);
            btn_createCa.FillPressColor = Color.FromArgb(255, 192, 192);
            btn_createCa.FillSelectedColor = Color.FromArgb(255, 192, 192);
            btn_createCa.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_createCa.Location = new Point(13, 7);
            btn_createCa.MinimumSize = new Size(1, 1);
            btn_createCa.Name = "btn_createCa";
            btn_createCa.Radius = 15;
            btn_createCa.RectColor = Color.Black;
            btn_createCa.RectHoverColor = Color.Black;
            btn_createCa.RectPressColor = Color.Black;
            btn_createCa.RectSelectedColor = Color.Black;
            btn_createCa.Size = new Size(100, 35);
            btn_createCa.TabIndex = 2;
            btn_createCa.Text = "Create Action";
            btn_createCa.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btn_save
            // 
            btn_save.BackColor = Color.Transparent;
            btn_save.FillColor = Color.IndianRed;
            btn_save.FillColor2 = Color.IndianRed;
            btn_save.FillHoverColor = Color.FromArgb(255, 192, 192);
            btn_save.FillPressColor = Color.FromArgb(255, 192, 192);
            btn_save.FillSelectedColor = Color.FromArgb(255, 192, 192);
            btn_save.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_save.Location = new Point(738, 7);
            btn_save.MinimumSize = new Size(1, 1);
            btn_save.Name = "btn_save";
            btn_save.Radius = 15;
            btn_save.RectColor = Color.Black;
            btn_save.RectHoverColor = Color.Black;
            btn_save.RectPressColor = Color.Black;
            btn_save.RectSelectedColor = Color.Black;
            btn_save.Size = new Size(100, 35);
            btn_save.TabIndex = 1;
            btn_save.Text = "Save";
            btn_save.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.Transparent;
            btn_cancel.FillColor = Color.IndianRed;
            btn_cancel.FillColor2 = Color.IndianRed;
            btn_cancel.FillHoverColor = Color.FromArgb(255, 192, 192);
            btn_cancel.FillPressColor = Color.FromArgb(255, 192, 192);
            btn_cancel.FillSelectedColor = Color.FromArgb(255, 192, 192);
            btn_cancel.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancel.Location = new Point(844, 7);
            btn_cancel.MinimumSize = new Size(1, 1);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Radius = 15;
            btn_cancel.RectColor = Color.Black;
            btn_cancel.RectHoverColor = Color.Black;
            btn_cancel.RectPressColor = Color.Black;
            btn_cancel.RectSelectedColor = Color.Black;
            btn_cancel.Size = new Size(100, 35);
            btn_cancel.TabIndex = 0;
            btn_cancel.Text = "Cancel";
            btn_cancel.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(combo_riskMatrix);
            flowLayoutPanel1.Controls.Add(pb_riskMatrix);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(171, 178);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(776, 29);
            flowLayoutPanel1.TabIndex = 25;
            // 
            // pb_riskMatrix
            // 
            pb_riskMatrix.BackgroundImage = Properties.Resources.questionhd_106121;
            pb_riskMatrix.BackgroundImageLayout = ImageLayout.Zoom;
            pb_riskMatrix.Location = new Point(130, 3);
            pb_riskMatrix.Name = "pb_riskMatrix";
            pb_riskMatrix.Size = new Size(20, 20);
            pb_riskMatrix.TabIndex = 16;
            pb_riskMatrix.TabStop = false;
            // 
            // Frm_HazardUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Black_Background_1920x1045_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(950, 800);
            Controls.Add(panel1);
            Controls.Add(tbl_main);
            Controls.Add(pnl_header);
            Controls.Add(pnl_controlBox);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Frm_HazardUpdate";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Frm_FirstAidUpdate";
            pnl_controlBox.ResumeLayout(false);
            pnl_controlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).EndInit();
            pnl_header.ResumeLayout(false);
            pnl_header.PerformLayout();
            tbl_main.ResumeLayout(false);
            tbl_main.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_riskMatrix).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_controlBox;
        private PictureBox pb_exit;
        private PictureBox pb_minimize;
        private Label label1;
        private PictureBox pb_dmLogo;
        private Panel pnl_header;
        private Label lbl_header;
        private TableLayoutPanel tbl_main;
        private Label lbl_datelbl;
        private Label lbl_employeeLbl;
        private Label lbl_areaLbl;
        private Label lbl_title;
        private Label lbl_riskLbl;
        private Label lbl_area;
        private Label lbl_empName;
        private Label lbl_emp;
        private Label lbl_date;
        private Label lbl_empLbl;
        private Label lbl_apreportLbl;
        private TextBox txt_Title;
        private Label lbl_description;
        private RichTextBox rtxt_notes;
        private ComboBox combo_apReport;
        private Label lbl_notesLbl;
        private ComboBox combo_riskMatrix;
        private RichTextBox rtxt_descr;
        private Panel panel1;
        private Sunny.UI.UIButton btn_cancel;
        private Sunny.UI.UIButton btn_save;
        private ComboBox combo_incidentType;
        private Label lbl_typeLbl;
        private Label lbl_statusLbl;
        private ComboBox combo_status;
        private Sunny.UI.UIButton btn_createCa;
        private TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UICheckBoxGroup cbg_damage;
        private Sunny.UI.UICheckBoxGroup cbg_env;
        private Sunny.UI.UICheckBoxGroup cbg_injury;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pb_riskMatrix;
        //private Guna.UI2.WinForms.Guna2Button btn_createHazard;
        //private Guna.UI2.WinForms.Guna2Button guna2Button2;
        //private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}