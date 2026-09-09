namespace InciTrack_Pro.Forms
{
    partial class Frm_AddCorrectiveAction
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
            tableLayoutPanel1 = new TableLayoutPanel();
            rtxt_notes = new Sunny.UI.UIRichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btn_saveCa = new Sunny.UI.UIButton();
            combo_empName = new Sunny.UI.UIComboBox();
            rtxt_Ca = new Sunny.UI.UIRichTextBox();
            dtp_dueDate = new Sunny.UI.UIDatePicker();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lbl_title = new Label();
            lbl_date = new Label();
            lbl_type = new Label();
            pnl_controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            pnl_controlBox.Size = new Size(916, 37);
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(rtxt_notes, 1, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 3);
            tableLayoutPanel1.Controls.Add(btn_saveCa, 1, 4);
            tableLayoutPanel1.Controls.Add(combo_empName, 1, 0);
            tableLayoutPanel1.Controls.Add(rtxt_Ca, 1, 2);
            tableLayoutPanel1.Controls.Add(dtp_dueDate, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 101);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 138F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.Size = new Size(916, 422);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // rtxt_notes
            // 
            rtxt_notes.FillColor = Color.White;
            rtxt_notes.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtxt_notes.Location = new Point(184, 225);
            rtxt_notes.Margin = new Padding(4, 5, 4, 5);
            rtxt_notes.MinimumSize = new Size(1, 1);
            rtxt_notes.Name = "rtxt_notes";
            rtxt_notes.Padding = new Padding(2);
            rtxt_notes.RectColor = Color.IndianRed;
            rtxt_notes.ShowText = false;
            rtxt_notes.Size = new Size(719, 120);
            rtxt_notes.TabIndex = 8;
            rtxt_notes.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 19);
            label2.TabIndex = 0;
            label2.Text = "Action Owner:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 39);
            label3.Name = "label3";
            label3.Size = new Size(76, 19);
            label3.TabIndex = 1;
            label3.Text = "Due Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 82);
            label4.Name = "label4";
            label4.Size = new Size(130, 19);
            label4.TabIndex = 2;
            label4.Text = "Corrective Action:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 220);
            label5.Name = "label5";
            label5.Size = new Size(53, 19);
            label5.TabIndex = 3;
            label5.Text = "Notes:";
            // 
            // btn_saveCa
            // 
            btn_saveCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_saveCa.FillColor = Color.IndianRed;
            btn_saveCa.FillColor2 = Color.IndianRed;
            btn_saveCa.FillHoverColor = Color.FromArgb(255, 192, 192);
            btn_saveCa.FillPressColor = Color.FromArgb(255, 192, 192);
            btn_saveCa.FillSelectedColor = Color.FromArgb(255, 192, 192);
            btn_saveCa.Font = new Font("Microsoft Sans Serif", 12F);
            btn_saveCa.Location = new Point(813, 384);
            btn_saveCa.MinimumSize = new Size(1, 1);
            btn_saveCa.Name = "btn_saveCa";
            btn_saveCa.Radius = 13;
            btn_saveCa.RectColor = Color.IndianRed;
            btn_saveCa.RectHoverColor = Color.IndianRed;
            btn_saveCa.RectPressColor = Color.IndianRed;
            btn_saveCa.RectSelectedColor = Color.IndianRed;
            btn_saveCa.Size = new Size(100, 35);
            btn_saveCa.TabIndex = 4;
            btn_saveCa.Text = "Save";
            btn_saveCa.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // combo_empName
            // 
            combo_empName.DataSource = null;
            combo_empName.FillColor = Color.White;
            combo_empName.FilterIgnoreCase = true;
            combo_empName.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            combo_empName.ItemHoverColor = Color.FromArgb(155, 200, 255);
            combo_empName.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            combo_empName.Location = new Point(184, 5);
            combo_empName.Margin = new Padding(4, 5, 4, 5);
            combo_empName.MinimumSize = new Size(63, 0);
            combo_empName.Name = "combo_empName";
            combo_empName.Padding = new Padding(0, 0, 30, 2);
            combo_empName.Radius = 2;
            combo_empName.RectColor = Color.IndianRed;
            combo_empName.ShowFilter = true;
            combo_empName.Size = new Size(243, 29);
            combo_empName.Sorted = true;
            combo_empName.SymbolSize = 24;
            combo_empName.TabIndex = 5;
            combo_empName.TextAlignment = ContentAlignment.MiddleLeft;
            combo_empName.TrimFilter = true;
            combo_empName.Watermark = "";
            // 
            // rtxt_Ca
            // 
            rtxt_Ca.FillColor = Color.White;
            rtxt_Ca.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtxt_Ca.Location = new Point(184, 87);
            rtxt_Ca.Margin = new Padding(4, 5, 4, 5);
            rtxt_Ca.MinimumSize = new Size(1, 1);
            rtxt_Ca.Name = "rtxt_Ca";
            rtxt_Ca.Padding = new Padding(2);
            rtxt_Ca.RectColor = Color.IndianRed;
            rtxt_Ca.ShowText = false;
            rtxt_Ca.Size = new Size(719, 128);
            rtxt_Ca.TabIndex = 7;
            rtxt_Ca.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // dtp_dueDate
            // 
            dtp_dueDate.DateCultureInfo = new System.Globalization.CultureInfo("en-US");
            dtp_dueDate.FillColor = Color.White;
            dtp_dueDate.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_dueDate.Location = new Point(184, 44);
            dtp_dueDate.Margin = new Padding(4, 5, 4, 5);
            dtp_dueDate.MaxLength = 10;
            dtp_dueDate.MinimumSize = new Size(63, 0);
            dtp_dueDate.MultiLanguageSupport = false;
            dtp_dueDate.Name = "dtp_dueDate";
            dtp_dueDate.Padding = new Padding(0, 0, 30, 2);
            dtp_dueDate.ShowToday = true;
            dtp_dueDate.Size = new Size(243, 33);
            dtp_dueDate.SymbolDropDown = 61555;
            dtp_dueDate.SymbolNormal = 61555;
            dtp_dueDate.SymbolSize = 24;
            dtp_dueDate.TabIndex = 9;
            dtp_dueDate.Text = "2026-09-09";
            dtp_dueDate.TextAlignment = ContentAlignment.MiddleLeft;
            dtp_dueDate.Value = new DateTime(2026, 9, 9, 0, 0, 0, 0);
            dtp_dueDate.Watermark = "";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.IndianRed;
            flowLayoutPanel1.Controls.Add(lbl_title);
            flowLayoutPanel1.Controls.Add(lbl_date);
            flowLayoutPanel1.Controls.Add(lbl_type);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 37);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(916, 64);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_title.ForeColor = Color.White;
            lbl_title.Location = new Point(3, 0);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(107, 19);
            lbl_title.TabIndex = 1;
            lbl_title.Text = "Action Owner:";
            // 
            // lbl_date
            // 
            lbl_date.AutoSize = true;
            lbl_date.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_date.ForeColor = Color.White;
            lbl_date.Location = new Point(3, 19);
            lbl_date.Name = "lbl_date";
            lbl_date.Size = new Size(107, 19);
            lbl_date.TabIndex = 2;
            lbl_date.Text = "Action Owner:";
            // 
            // lbl_type
            // 
            lbl_type.AutoSize = true;
            lbl_type.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_type.ForeColor = Color.White;
            lbl_type.Location = new Point(3, 38);
            lbl_type.Name = "lbl_type";
            lbl_type.Size = new Size(107, 19);
            lbl_type.TabIndex = 3;
            lbl_type.Text = "Action Owner:";
            // 
            // Frm_AddCorrectiveAction
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Black_Background_1920x1045_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(916, 523);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pnl_controlBox);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(916, 523);
            MinimumSize = new Size(916, 523);
            Name = "Frm_AddCorrectiveAction";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Frm_AddCorrectiveAction";
            pnl_controlBox.ResumeLayout(false);
            pnl_controlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_controlBox;
        private Label label1;
        private PictureBox pb_dmLogo;
        private PictureBox pb_minimize;
        private PictureBox pb_exit;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Sunny.UI.UIButton btn_saveCa;
        private Sunny.UI.UIComboBox combo_empName;
        private Sunny.UI.UIRichTextBox rtxt_notes;
        private Sunny.UI.UIRichTextBox rtxt_Ca;
        private Label lbl_title;
        private Label lbl_date;
        private Label lbl_type;
        private Sunny.UI.UIDatePicker dtp_dueDate;
    }
}