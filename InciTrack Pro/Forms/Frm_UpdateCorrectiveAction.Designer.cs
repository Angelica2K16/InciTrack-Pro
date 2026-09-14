namespace InciTrack_Pro.Forms
{
    partial class Frm_UpdateCorrectiveAction
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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            dtp_compDate = new Sunny.UI.UIDatePicker();
            lbl_compDateLbl = new Label();
            rtxt_action = new Sunny.UI.UIRichTextBox();
            rtxt_notes = new Sunny.UI.UIRichTextBox();
            dtp_dueDate = new Sunny.UI.UIDatePicker();
            combo_actionOwner = new Sunny.UI.UIComboBox();
            label10 = new Label();
            panel1 = new Panel();
            btn_save = new Sunny.UI.UIButton();
            btn_cancel = new Sunny.UI.UIButton();
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
            pnl_controlBox.TabIndex = 1;
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
            pnl_header.TabIndex = 2;
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
            tbl_main.Controls.Add(label6, 0, 3);
            tbl_main.Controls.Add(label5, 0, 2);
            tbl_main.Controls.Add(label4, 0, 0);
            tbl_main.Controls.Add(dtp_compDate, 1, 1);
            tbl_main.Controls.Add(lbl_compDateLbl, 0, 1);
            tbl_main.Controls.Add(rtxt_action, 1, 3);
            tbl_main.Controls.Add(dtp_dueDate, 1, 0);
            tbl_main.Controls.Add(combo_actionOwner, 1, 2);
            tbl_main.Controls.Add(label10, 0, 4);
            tbl_main.Controls.Add(rtxt_notes, 1, 4);
            tbl_main.Dock = DockStyle.Fill;
            tbl_main.Location = new Point(0, 77);
            tbl_main.Name = "tbl_main";
            tbl_main.RowCount = 5;
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 156F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tbl_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tbl_main.Size = new Size(914, 493);
            tbl_main.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 105);
            label6.Name = "label6";
            label6.Size = new Size(104, 19);
            label6.TabIndex = 23;
            label6.Text = "Action Details:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 70);
            label5.Name = "label5";
            label5.Size = new Size(101, 19);
            label5.TabIndex = 22;
            label5.Text = "Action Owner:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(74, 19);
            label4.TabIndex = 21;
            label4.Text = "Due Date:";
            // 
            // dtp_compDate
            // 
            dtp_compDate.CanEmpty = true;
            dtp_compDate.DateCultureInfo = new System.Globalization.CultureInfo("");
            dtp_compDate.FillColor = Color.White;
            dtp_compDate.Font = new Font("Microsoft Sans Serif", 12F);
            dtp_compDate.Location = new Point(172, 40);
            dtp_compDate.Margin = new Padding(4, 5, 4, 5);
            dtp_compDate.MaxLength = 10;
            dtp_compDate.MinimumSize = new Size(63, 0);
            dtp_compDate.Name = "dtp_compDate";
            dtp_compDate.Padding = new Padding(0, 0, 30, 2);
            dtp_compDate.ShowToday = true;
            dtp_compDate.Size = new Size(204, 25);
            dtp_compDate.SymbolDropDown = 61555;
            dtp_compDate.SymbolNormal = 61555;
            dtp_compDate.SymbolSize = 24;
            dtp_compDate.TabIndex = 19;
            dtp_compDate.Text = "2026-09-14";
            dtp_compDate.TextAlignment = ContentAlignment.MiddleLeft;
            dtp_compDate.Value = new DateTime(2026, 9, 14, 11, 27, 47, 454);
            dtp_compDate.Watermark = "";
            // 
            // lbl_compDateLbl
            // 
            lbl_compDateLbl.AutoSize = true;
            lbl_compDateLbl.ForeColor = Color.White;
            lbl_compDateLbl.Location = new Point(3, 35);
            lbl_compDateLbl.Name = "lbl_compDateLbl";
            lbl_compDateLbl.Size = new Size(122, 19);
            lbl_compDateLbl.TabIndex = 5;
            lbl_compDateLbl.Text = "Completion Date:";
            // 
            // rtxt_action
            // 
            rtxt_action.FillColor = Color.White;
            rtxt_action.Font = new Font("Microsoft Sans Serif", 12F);
            rtxt_action.Location = new Point(172, 110);
            rtxt_action.Margin = new Padding(4, 5, 4, 5);
            rtxt_action.MinimumSize = new Size(1, 1);
            rtxt_action.Name = "rtxt_action";
            rtxt_action.Padding = new Padding(2);
            rtxt_action.ShowText = false;
            rtxt_action.Size = new Size(738, 146);
            rtxt_action.TabIndex = 16;
            rtxt_action.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // rtxt_notes
            // 
            rtxt_notes.FillColor = Color.White;
            rtxt_notes.Font = new Font("Microsoft Sans Serif", 12F);
            rtxt_notes.Location = new Point(172, 266);
            rtxt_notes.Margin = new Padding(4, 5, 4, 5);
            rtxt_notes.MinimumSize = new Size(1, 1);
            rtxt_notes.Name = "rtxt_notes";
            rtxt_notes.Padding = new Padding(2);
            rtxt_notes.ShowText = false;
            rtxt_notes.Size = new Size(738, 165);
            rtxt_notes.TabIndex = 17;
            rtxt_notes.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // dtp_dueDate
            // 
            dtp_dueDate.DateCultureInfo = new System.Globalization.CultureInfo("");
            dtp_dueDate.FillColor = Color.White;
            dtp_dueDate.Font = new Font("Microsoft Sans Serif", 12F);
            dtp_dueDate.Location = new Point(172, 5);
            dtp_dueDate.Margin = new Padding(4, 5, 4, 5);
            dtp_dueDate.MaxLength = 10;
            dtp_dueDate.MinimumSize = new Size(63, 0);
            dtp_dueDate.Name = "dtp_dueDate";
            dtp_dueDate.Padding = new Padding(0, 0, 30, 2);
            dtp_dueDate.ShowToday = true;
            dtp_dueDate.Size = new Size(204, 25);
            dtp_dueDate.SymbolDropDown = 61555;
            dtp_dueDate.SymbolNormal = 61555;
            dtp_dueDate.SymbolSize = 24;
            dtp_dueDate.TabIndex = 18;
            dtp_dueDate.Text = "2026-09-14";
            dtp_dueDate.TextAlignment = ContentAlignment.MiddleLeft;
            dtp_dueDate.Value = new DateTime(2026, 9, 14, 11, 27, 47, 454);
            dtp_dueDate.Watermark = "";
            // 
            // combo_actionOwner
            // 
            combo_actionOwner.DataSource = null;
            combo_actionOwner.FillColor = Color.White;
            combo_actionOwner.Font = new Font("Microsoft Sans Serif", 12F);
            combo_actionOwner.ItemHoverColor = Color.FromArgb(155, 200, 255);
            combo_actionOwner.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            combo_actionOwner.Location = new Point(172, 75);
            combo_actionOwner.Margin = new Padding(4, 5, 4, 5);
            combo_actionOwner.MinimumSize = new Size(63, 0);
            combo_actionOwner.Name = "combo_actionOwner";
            combo_actionOwner.Padding = new Padding(0, 0, 30, 2);
            combo_actionOwner.Size = new Size(204, 25);
            combo_actionOwner.SymbolSize = 24;
            combo_actionOwner.TabIndex = 20;
            combo_actionOwner.TextAlignment = ContentAlignment.MiddleLeft;
            combo_actionOwner.Watermark = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.White;
            label10.Location = new Point(3, 261);
            label10.Name = "label10";
            label10.Size = new Size(51, 19);
            label10.TabIndex = 25;
            label10.Text = "Notes:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btn_save);
            panel1.Controls.Add(btn_cancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 516);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 54);
            panel1.TabIndex = 4;
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
            // Frm_UpdateCorrectiveAction
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
            MaximumSize = new Size(914, 570);
            MinimumSize = new Size(914, 570);
            Name = "Frm_UpdateCorrectiveAction";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Frm_UpdateCorrectiveAction";
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
        private Label label1;
        private PictureBox pb_dmLogo;
        private PictureBox pb_minimize;
        private PictureBox pb_exit;
        private Panel pnl_header;
        private Label lbl_header;
        private TableLayoutPanel tbl_main;
        //private RichTextBox rtxt_cause;
        //private ComboBox combo_apReport;
       // private Label lbl_area;
        //private Label lbl_empName;
       // private Label lbl_time;
        //private Label lbl_date;
        //private Label lbl_datelbl;
        private Label label2;
       // private Label lbl_title;
        //private Label lbl_areaLbl;
       // private Label lbl_employeeLbl;
        private Label lbl_compDateLbl;
        private Label label3;
       // private TextBox txt_Title;
       // private Label lbl_description;
        private Label label8;
        private Label label9;
        //private ComboBox combo_investigation;
       // private RichTextBox rtxt_descr;
        private Panel panel1;
       // private Sunny.UI.UIButton btn_createHazard;
        private Sunny.UI.UIButton btn_save;
        private Sunny.UI.UIButton btn_cancel;
        private Sunny.UI.UIRichTextBox rtxt_action;
        private Sunny.UI.UIDatePicker dtp_compDate;
        private Sunny.UI.UIRichTextBox rtxt_notes;
        private Sunny.UI.UIDatePicker dtp_dueDate;
        private Sunny.UI.UIComboBox combo_actionOwner;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label10;
    }
}