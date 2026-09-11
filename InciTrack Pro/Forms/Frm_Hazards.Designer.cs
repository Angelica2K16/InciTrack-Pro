namespace InciTrack_Pro.Forms
{
    partial class Frm_Hazards
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            pnl_controlBox = new Panel();
            label1 = new Label();
            pb_dmLogo = new PictureBox();
            pb_minimize = new PictureBox();
            pb_exit = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            flp_Kpi = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            txt_search = new TextBox();
            cb_apReports = new CheckBox();
            dgv_hazardsList = new Sunny.UI.UIDataGridView();
            cb_includeAll = new CheckBox();
            pnl_controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_hazardsList).BeginInit();
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
            pnl_controlBox.Size = new Size(1280, 39);
            pnl_controlBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 9);
            label1.Name = "label1";
            label1.Size = new Size(158, 24);
            label1.TabIndex = 4;
            label1.Text = "InciTrack Pro";
            // 
            // pb_dmLogo
            // 
            pb_dmLogo.BackColor = Color.Transparent;
            pb_dmLogo.BackgroundImage = Properties.Resources.Dan_Mar_Logo_large;
            pb_dmLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pb_dmLogo.Location = new Point(3, 2);
            pb_dmLogo.Name = "pb_dmLogo";
            pb_dmLogo.Size = new Size(37, 34);
            pb_dmLogo.TabIndex = 3;
            pb_dmLogo.TabStop = false;
            // 
            // pb_minimize
            // 
            pb_minimize.BackColor = Color.Transparent;
            pb_minimize.BackgroundImage = Properties.Resources.minimize_14775;
            pb_minimize.BackgroundImageLayout = ImageLayout.Zoom;
            pb_minimize.Location = new Point(1197, 3);
            pb_minimize.Name = "pb_minimize";
            pb_minimize.Size = new Size(37, 34);
            pb_minimize.TabIndex = 2;
            pb_minimize.TabStop = false;
            // 
            // pb_exit
            // 
            pb_exit.BackColor = Color.Transparent;
            pb_exit.BackgroundImage = Properties.Resources.exit_close_error_15565;
            pb_exit.BackgroundImageLayout = ImageLayout.Zoom;
            pb_exit.Location = new Point(1240, 3);
            pb_exit.Name = "pb_exit";
            pb_exit.Size = new Size(37, 34);
            pb_exit.TabIndex = 1;
            pb_exit.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(dgv_hazardsList, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 39);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 36.9901543F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 63.0098457F));
            tableLayoutPanel1.Size = new Size(1280, 711);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1274, 257);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(flp_Kpi, 0, 0);
            tableLayoutPanel3.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(631, 251);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // flp_Kpi
            // 
            flp_Kpi.Dock = DockStyle.Fill;
            flp_Kpi.Location = new Point(3, 3);
            flp_Kpi.Name = "flp_Kpi";
            flp_Kpi.Size = new Size(625, 119);
            flp_Kpi.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(txt_search);
            flowLayoutPanel2.Controls.Add(cb_apReports);
            flowLayoutPanel2.Controls.Add(cb_includeAll);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 128);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(625, 120);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 23);
            label2.TabIndex = 3;
            label2.Text = "Search:";
            // 
            // txt_search
            // 
            txt_search.Location = new Point(3, 26);
            txt_search.Name = "txt_search";
            txt_search.Size = new Size(573, 27);
            txt_search.TabIndex = 4;
            // 
            // cb_apReports
            // 
            cb_apReports.AutoSize = true;
            cb_apReports.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cb_apReports.ForeColor = Color.White;
            cb_apReports.Location = new Point(3, 59);
            cb_apReports.Name = "cb_apReports";
            cb_apReports.Size = new Size(141, 23);
            cb_apReports.TabIndex = 5;
            cb_apReports.Text = "View AP Reports";
            cb_apReports.UseVisualStyleBackColor = true;
            // 
            // dgv_hazardsList
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgv_hazardsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_hazardsList.BackgroundColor = Color.White;
            dgv_hazardsList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_hazardsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_hazardsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_hazardsList.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_hazardsList.Dock = DockStyle.Fill;
            dgv_hazardsList.EnableHeadersVisualStyles = false;
            dgv_hazardsList.Font = new Font("Microsoft Sans Serif", 12F);
            dgv_hazardsList.GridColor = Color.FromArgb(80, 160, 255);
            dgv_hazardsList.Location = new Point(3, 266);
            dgv_hazardsList.Name = "dgv_hazardsList";
            dgv_hazardsList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_hazardsList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            dgv_hazardsList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv_hazardsList.SelectedIndex = -1;
            dgv_hazardsList.Size = new Size(1274, 442);
            dgv_hazardsList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgv_hazardsList.TabIndex = 1;
            // 
            // cb_includeAll
            // 
            cb_includeAll.AutoSize = true;
            cb_includeAll.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cb_includeAll.ForeColor = Color.White;
            cb_includeAll.Location = new Point(150, 59);
            cb_includeAll.Name = "cb_includeAll";
            cb_includeAll.Size = new Size(100, 23);
            cb_includeAll.TabIndex = 6;
            cb_includeAll.Text = "Include All";
            cb_includeAll.UseVisualStyleBackColor = true;
            // 
            // Frm_Hazards
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Black_Background_1920x1045_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1280, 750);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnl_controlBox);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1280, 750);
            MinimumSize = new Size(1280, 750);
            Name = "Frm_Hazards";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Frm_Hazards";
            pnl_controlBox.ResumeLayout(false);
            pnl_controlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_hazardsList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_controlBox;
        private Label label1;
        private PictureBox pb_dmLogo;
        private PictureBox pb_minimize;
        private PictureBox pb_exit;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Sunny.UI.UIDataGridView dgv_hazardsList;
        private FlowLayoutPanel flp_Kpi;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private TextBox txt_search;
        private CheckBox cb_apReports;
        private CheckBox cb_includeAll;
        //private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
    }
}