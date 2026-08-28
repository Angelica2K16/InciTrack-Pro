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
            richTextBox3 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            comboBox2 = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            lbl_Date = new Label();
            label2 = new Label();
            lbl_title = new Label();
            lbl_area = new Label();
            lbl_employee = new Label();
            lbl_time = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            lbl_description = new Label();
            label8 = new Label();
            label9 = new Label();
            comboBox1 = new ComboBox();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            pnl_controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).BeginInit();
            pnl_header.SuspendLayout();
            tbl_main.SuspendLayout();
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
            label1.Size = new Size(319, 49);
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
            lbl_header.Size = new Size(98, 39);
            lbl_header.TabIndex = 0;
            lbl_header.Text = "label2";
            // 
            // tbl_main
            // 
            tbl_main.BackColor = Color.Transparent;
            tbl_main.ColumnCount = 2;
            tbl_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 168F));
            tbl_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_main.Controls.Add(richTextBox3, 1, 9);
            tbl_main.Controls.Add(richTextBox2, 1, 8);
            tbl_main.Controls.Add(comboBox2, 1, 6);
            tbl_main.Controls.Add(label7, 1, 3);
            tbl_main.Controls.Add(label6, 1, 2);
            tbl_main.Controls.Add(label5, 1, 1);
            tbl_main.Controls.Add(label4, 1, 0);
            tbl_main.Controls.Add(lbl_Date, 0, 0);
            tbl_main.Controls.Add(label2, 0, 5);
            tbl_main.Controls.Add(lbl_title, 0, 4);
            tbl_main.Controls.Add(lbl_area, 0, 3);
            tbl_main.Controls.Add(lbl_employee, 0, 2);
            tbl_main.Controls.Add(lbl_time, 0, 1);
            tbl_main.Controls.Add(label3, 0, 6);
            tbl_main.Controls.Add(textBox1, 1, 4);
            tbl_main.Controls.Add(lbl_description, 0, 7);
            tbl_main.Controls.Add(label8, 0, 8);
            tbl_main.Controls.Add(label9, 0, 9);
            tbl_main.Controls.Add(comboBox1, 1, 5);
            tbl_main.Controls.Add(richTextBox1, 1, 7);
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
            // richTextBox3
            // 
            richTextBox3.Location = new Point(171, 368);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(731, 65);
            richTextBox3.TabIndex = 19;
            richTextBox3.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(171, 308);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(731, 54);
            richTextBox2.TabIndex = 18;
            richTextBox2.Text = "";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(171, 213);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 47);
            comboBox2.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(171, 105);
            label7.Name = "label7";
            label7.Size = new Size(87, 35);
            label7.TabIndex = 10;
            label7.Text = "Area:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(171, 70);
            label6.Name = "label6";
            label6.Size = new Size(155, 35);
            label6.TabIndex = 9;
            label6.Text = "Employee:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(171, 35);
            label5.Name = "label5";
            label5.Size = new Size(91, 35);
            label5.TabIndex = 8;
            label5.Text = "Time:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(171, 0);
            label4.Name = "label4";
            label4.Size = new Size(88, 35);
            label4.TabIndex = 7;
            label4.Text = "Date:";
            // 
            // lbl_Date
            // 
            lbl_Date.AutoSize = true;
            lbl_Date.ForeColor = Color.White;
            lbl_Date.Location = new Point(3, 0);
            lbl_Date.Name = "lbl_Date";
            lbl_Date.Size = new Size(88, 35);
            lbl_Date.TabIndex = 0;
            lbl_Date.Text = "Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 175);
            label2.Name = "label2";
            label2.Size = new Size(149, 35);
            label2.TabIndex = 4;
            label2.Text = "Investigation Required:";
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.ForeColor = Color.White;
            lbl_title.Location = new Point(3, 140);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(83, 35);
            lbl_title.TabIndex = 3;
            lbl_title.Text = "Title:";
            // 
            // lbl_area
            // 
            lbl_area.AutoSize = true;
            lbl_area.ForeColor = Color.White;
            lbl_area.Location = new Point(3, 105);
            lbl_area.Name = "lbl_area";
            lbl_area.Size = new Size(87, 35);
            lbl_area.TabIndex = 2;
            lbl_area.Text = "Area:";
            // 
            // lbl_employee
            // 
            lbl_employee.AutoSize = true;
            lbl_employee.ForeColor = Color.White;
            lbl_employee.Location = new Point(3, 70);
            lbl_employee.Name = "lbl_employee";
            lbl_employee.Size = new Size(155, 35);
            lbl_employee.TabIndex = 1;
            lbl_employee.Text = "Employee:";
            // 
            // lbl_time
            // 
            lbl_time.AutoSize = true;
            lbl_time.ForeColor = Color.White;
            lbl_time.Location = new Point(3, 35);
            lbl_time.Name = "lbl_time";
            lbl_time.Size = new Size(91, 35);
            lbl_time.TabIndex = 5;
            lbl_time.Text = "Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 210);
            label3.Name = "label3";
            label3.Size = new Size(145, 35);
            label3.TabIndex = 6;
            label3.Text = "Reported to AP:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(171, 143);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(387, 47);
            textBox1.TabIndex = 11;
            // 
            // lbl_description
            // 
            lbl_description.AutoSize = true;
            lbl_description.ForeColor = Color.White;
            lbl_description.Location = new Point(3, 245);
            lbl_description.Name = "lbl_description";
            lbl_description.Size = new Size(150, 60);
            lbl_description.TabIndex = 12;
            lbl_description.Text = "Description:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 305);
            label8.Name = "label8";
            label8.Size = new Size(104, 39);
            label8.TabIndex = 13;
            label8.Text = "Cause:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(3, 365);
            label9.Name = "label9";
            label9.Size = new Size(104, 39);
            label9.TabIndex = 14;
            label9.Text = "Notes:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(171, 178);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 47);
            comboBox1.TabIndex = 15;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(171, 248);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(731, 54);
            richTextBox1.TabIndex = 17;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 516);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 54);
            panel1.TabIndex = 3;
            // 
            // Frm_FirstAidUpdate
            // 
            AutoScaleDimensions = new SizeF(16F, 39F);
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
        private Label lbl_Date;
        private Label lbl_employee;
        private Label lbl_area;
        private Label lbl_title;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label lbl_time;
        private Label label3;
        private TextBox textBox1;
        private Label lbl_description;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox2;
        private ComboBox comboBox2;
        private Label label8;
        private Label label9;
        private ComboBox comboBox1;
        private RichTextBox richTextBox1;
        private Panel panel1;
        //private Guna.UI2.WinForms.Guna2Button btn_createHazard;
        //private Guna.UI2.WinForms.Guna2Button guna2Button2;
        //private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}