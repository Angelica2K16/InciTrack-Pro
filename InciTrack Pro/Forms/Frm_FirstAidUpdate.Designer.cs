namespace InciTrack_Pro.Forms
{
    partial class Frm_FirstAidUpdate
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
            pnl_controlBox = new Panel();
            label1 = new Label();
            pb_dmLogo = new PictureBox();
            pb_minimize = new PictureBox();
            pb_exit = new PictureBox();
            pnl_header = new Panel();
            lbl_header = new Label();
            tbl_main = new TableLayoutPanel();
            rtxt_notes = new RichTextBox();
            rtxt_cause = new RichTextBox();
            combo_apReport = new ComboBox();
            lbl_area = new Label();
            lbl_empName = new Label();
            lbl_time = new Label();
            lbl_date = new Label();
            lbl_datelbl = new Label();
            label2 = new Label();
            lbl_title = new Label();
            lbl_areaLbl = new Label();
            lbl_employeeLbl = new Label();
            lbl_timeLbl = new Label();
            label3 = new Label();
            txt_Title = new TextBox();
            lbl_description = new Label();
            label8 = new Label();
            label9 = new Label();
            combo_investigation = new ComboBox();
            rtxt_descr = new RichTextBox();
            panel1 = new Panel();
            btn_save = new Sunny.UI.UIButton();
            btn_cancel = new Sunny.UI.UIButton();
            btn_createHazard = new Sunny.UI.UIButton();
            pnl_controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).BeginInit();
            pnl_header.SuspendLayout();
            tbl_main.SuspendLayout();
            panel1.SuspendLayout();
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
            pnl_controlBox.Size = new Size(914, 37);
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
            pb_minimize.Location = new Point(831, 3);
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
            pb_exit.Location = new Point(874, 3);
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
            pnl_header.Size = new Size(914, 40);
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
            tbl_main.Controls.Add(rtxt_notes, 1, 9);
            tbl_main.Controls.Add(rtxt_cause, 1, 8);
            tbl_main.Controls.Add(combo_apReport, 1, 6);
            tbl_main.Controls.Add(lbl_area, 1, 3);
            tbl_main.Controls.Add(lbl_empName, 1, 2);
            tbl_main.Controls.Add(lbl_time, 1, 1);
            tbl_main.Controls.Add(lbl_date, 1, 0);
            tbl_main.Controls.Add(lbl_datelbl, 0, 0);
            tbl_main.Controls.Add(label2, 0, 5);
            tbl_main.Controls.Add(lbl_title, 0, 4);
            tbl_main.Controls.Add(lbl_areaLbl, 0, 3);
            tbl_main.Controls.Add(lbl_employeeLbl, 0, 2);
            tbl_main.Controls.Add(lbl_timeLbl, 0, 1);
            tbl_main.Controls.Add(label3, 0, 6);
            tbl_main.Controls.Add(txt_Title, 1, 4);
            tbl_main.Controls.Add(lbl_description, 0, 7);
            tbl_main.Controls.Add(label8, 0, 8);
            tbl_main.Controls.Add(label9, 0, 9);
            tbl_main.Controls.Add(combo_investigation, 1, 5);
            tbl_main.Controls.Add(rtxt_descr, 1, 7);
            tbl_main.Dock = DockStyle.Fill;
            tbl_main.Location = new Point(0, 77);
            tbl_main.Name = "tbl_main";
            tbl_main.RowCount = 10;
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tbl_main.Size = new Size(914, 493);
            tbl_main.TabIndex = 2;
            // 
            // rtxt_notes
            // 
            rtxt_notes.Location = new Point(171, 368);
            rtxt_notes.Name = "rtxt_notes";
            rtxt_notes.Size = new Size(731, 65);
            rtxt_notes.TabIndex = 19;
            rtxt_notes.Text = "";
            // 
            // rtxt_cause
            // 
            rtxt_cause.Location = new Point(171, 308);
            rtxt_cause.Name = "rtxt_cause";
            rtxt_cause.Size = new Size(731, 54);
            rtxt_cause.TabIndex = 18;
            rtxt_cause.Text = "";
            // 
            // combo_apReport
            // 
            combo_apReport.FormattingEnabled = true;
            combo_apReport.Items.AddRange(new object[] { "Yes", "No" });
            combo_apReport.Location = new Point(171, 213);
            combo_apReport.Name = "combo_apReport";
            combo_apReport.Size = new Size(121, 27);
            combo_apReport.TabIndex = 16;
            // 
            // lbl_area
            // 
            lbl_area.AutoSize = true;
            lbl_area.ForeColor = Color.White;
            lbl_area.Location = new Point(171, 105);
            lbl_area.Name = "lbl_area";
            lbl_area.Size = new Size(43, 19);
            lbl_area.TabIndex = 10;
            lbl_area.Text = "Area:";
            // 
            // lbl_empName
            // 
            lbl_empName.AutoSize = true;
            lbl_empName.ForeColor = Color.White;
            lbl_empName.Location = new Point(171, 70);
            lbl_empName.Name = "lbl_empName";
            lbl_empName.Size = new Size(76, 19);
            lbl_empName.TabIndex = 9;
            lbl_empName.Text = "Employee:";
            // 
            // lbl_time
            // 
            lbl_time.AutoSize = true;
            lbl_time.ForeColor = Color.White;
            lbl_time.Location = new Point(171, 35);
            lbl_time.Name = "lbl_time";
            lbl_time.Size = new Size(45, 19);
            lbl_time.TabIndex = 8;
            lbl_time.Text = "Time:";
            // 
            // lbl_date
            // 
            lbl_date.AutoSize = true;
            lbl_date.ForeColor = Color.White;
            lbl_date.Location = new Point(171, 0);
            lbl_date.Name = "lbl_date";
            lbl_date.Padding = new Padding(0, 5, 0, 0);
            lbl_date.Size = new Size(44, 24);
            lbl_date.TabIndex = 7;
            lbl_date.Text = "Date:";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 175);
            label2.Name = "label2";
            label2.Size = new Size(159, 19);
            label2.TabIndex = 4;
            label2.Text = "Investigation Required:";
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
            // lbl_areaLbl
            // 
            lbl_areaLbl.AutoSize = true;
            lbl_areaLbl.ForeColor = Color.White;
            lbl_areaLbl.Location = new Point(3, 105);
            lbl_areaLbl.Name = "lbl_areaLbl";
            lbl_areaLbl.Size = new Size(43, 19);
            lbl_areaLbl.TabIndex = 2;
            lbl_areaLbl.Text = "Area:";
            // 
            // lbl_employeeLbl
            // 
            lbl_employeeLbl.AutoSize = true;
            lbl_employeeLbl.ForeColor = Color.White;
            lbl_employeeLbl.Location = new Point(3, 70);
            lbl_employeeLbl.Name = "lbl_employeeLbl";
            lbl_employeeLbl.Size = new Size(76, 19);
            lbl_employeeLbl.TabIndex = 1;
            lbl_employeeLbl.Text = "Employee:";
            // 
            // lbl_timeLbl
            // 
            lbl_timeLbl.AutoSize = true;
            lbl_timeLbl.ForeColor = Color.White;
            lbl_timeLbl.Location = new Point(3, 35);
            lbl_timeLbl.Name = "lbl_timeLbl";
            lbl_timeLbl.Size = new Size(45, 19);
            lbl_timeLbl.TabIndex = 5;
            lbl_timeLbl.Text = "Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 210);
            label3.Name = "label3";
            label3.Size = new Size(110, 19);
            label3.TabIndex = 6;
            label3.Text = "Reported to AP:";
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
            lbl_description.Location = new Point(3, 245);
            lbl_description.Name = "lbl_description";
            lbl_description.Size = new Size(87, 19);
            lbl_description.TabIndex = 12;
            lbl_description.Text = "Description:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 305);
            label8.Name = "label8";
            label8.Size = new Size(53, 19);
            label8.TabIndex = 13;
            label8.Text = "Cause:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(3, 365);
            label9.Name = "label9";
            label9.Size = new Size(51, 19);
            label9.TabIndex = 14;
            label9.Text = "Notes:";
            // 
            // combo_investigation
            // 
            combo_investigation.FormattingEnabled = true;
            combo_investigation.Items.AddRange(new object[] { "Yes", "No" });
            combo_investigation.Location = new Point(171, 178);
            combo_investigation.Name = "combo_investigation";
            combo_investigation.Size = new Size(121, 27);
            combo_investigation.TabIndex = 15;
            // 
            // rtxt_descr
            // 
            rtxt_descr.Location = new Point(171, 248);
            rtxt_descr.Name = "rtxt_descr";
            rtxt_descr.Size = new Size(731, 54);
            rtxt_descr.TabIndex = 17;
            rtxt_descr.Text = "";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btn_createHazard);
            panel1.Controls.Add(btn_save);
            panel1.Controls.Add(btn_cancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 516);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 54);
            panel1.TabIndex = 3;
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
            btn_save.Location = new Point(696, 7);
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
            btn_cancel.Location = new Point(802, 7);
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
            // btn_createHazard
            // 
            btn_createHazard.BackColor = Color.Transparent;
            btn_createHazard.FillColor = Color.IndianRed;
            btn_createHazard.FillColor2 = Color.IndianRed;
            btn_createHazard.FillHoverColor = Color.FromArgb(255, 192, 192);
            btn_createHazard.FillPressColor = Color.FromArgb(255, 192, 192);
            btn_createHazard.FillSelectedColor = Color.FromArgb(255, 192, 192);
            btn_createHazard.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_createHazard.Location = new Point(13, 7);
            btn_createHazard.MinimumSize = new Size(1, 1);
            btn_createHazard.Name = "btn_createHazard";
            btn_createHazard.Radius = 15;
            btn_createHazard.RectColor = Color.Black;
            btn_createHazard.RectHoverColor = Color.Black;
            btn_createHazard.RectPressColor = Color.Black;
            btn_createHazard.RectSelectedColor = Color.Black;
            btn_createHazard.Size = new Size(100, 35);
            btn_createHazard.TabIndex = 2;
            btn_createHazard.Text = "Create Hazard";
            btn_createHazard.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // Frm_FirstAidUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Black_Background_1920x1045_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 570);
            Controls.Add(panel1);
            Controls.Add(tbl_main);
            Controls.Add(pnl_header);
            Controls.Add(pnl_controlBox);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Frm_FirstAidUpdate";
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
            panel1.ResumeLayout(false);
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
        private Label label2;
        private Label lbl_area;
        private Label lbl_empName;
        private Label lbl_time;
        private Label lbl_date;
        private Label lbl_timeLbl;
        private Label label3;
        private TextBox txt_Title;
        private Label lbl_description;
        private RichTextBox rtxt_notes;
        private RichTextBox rtxt_cause;
        private ComboBox combo_apReport;
        private Label label8;
        private Label label9;
        private ComboBox combo_investigation;
        private RichTextBox rtxt_descr;
        private Panel panel1;
        private Sunny.UI.UIButton btn_cancel;
        private Sunny.UI.UIButton btn_save;
        private Sunny.UI.UIButton btn_createHazard;
        //private Guna.UI2.WinForms.Guna2Button btn_createHazard;
        //private Guna.UI2.WinForms.Guna2Button guna2Button2;
        //private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}