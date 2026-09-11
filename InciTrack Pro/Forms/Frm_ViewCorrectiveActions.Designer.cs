namespace InciTrack_Pro.Forms
{
    partial class Frm_ViewCorrectiveActions
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            pnl_controlBox = new Panel();
            label1 = new Label();
            pb_dmLogo = new PictureBox();
            pb_minimize = new PictureBox();
            pb_exit = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btn_ViewAllActions = new Sunny.UI.UIButton();
            btn_viewHazards = new Sunny.UI.UIButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgv_caList = new Sunny.UI.UIDataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            dgv_hazardList = new Sunny.UI.UIDataGridView();
            cb_includeAll = new Sunny.UI.UICheckBox();
            btn_addCa = new Sunny.UI.UIButton();
            pnl_controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_caList).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_hazardList).BeginInit();
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.RosyBrown;
            flowLayoutPanel1.Controls.Add(btn_ViewAllActions);
            flowLayoutPanel1.Controls.Add(btn_viewHazards);
            flowLayoutPanel1.Controls.Add(btn_addCa);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 39);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 711);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // btn_ViewAllActions
            // 
            btn_ViewAllActions.FillColor = Color.Firebrick;
            btn_ViewAllActions.FillColor2 = Color.Firebrick;
            btn_ViewAllActions.FillHoverColor = Color.IndianRed;
            btn_ViewAllActions.FillPressColor = Color.DarkRed;
            btn_ViewAllActions.FillSelectedColor = Color.DarkRed;
            btn_ViewAllActions.Font = new Font("Microsoft Sans Serif", 12F);
            btn_ViewAllActions.Location = new Point(40, 20);
            btn_ViewAllActions.Margin = new Padding(40, 20, 3, 0);
            btn_ViewAllActions.MinimumSize = new Size(1, 1);
            btn_ViewAllActions.Name = "btn_ViewAllActions";
            btn_ViewAllActions.Radius = 15;
            btn_ViewAllActions.RectColor = Color.Black;
            btn_ViewAllActions.RectHoverColor = Color.Black;
            btn_ViewAllActions.RectPressColor = Color.Black;
            btn_ViewAllActions.RectSelectedColor = Color.Black;
            btn_ViewAllActions.Size = new Size(127, 41);
            btn_ViewAllActions.TabIndex = 1;
            btn_ViewAllActions.Text = "View All Actions";
            btn_ViewAllActions.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btn_viewHazards
            // 
            btn_viewHazards.FillColor = Color.Firebrick;
            btn_viewHazards.FillColor2 = Color.Firebrick;
            btn_viewHazards.FillHoverColor = Color.IndianRed;
            btn_viewHazards.FillPressColor = Color.DarkRed;
            btn_viewHazards.FillSelectedColor = Color.DarkRed;
            btn_viewHazards.Font = new Font("Microsoft Sans Serif", 12F);
            btn_viewHazards.Location = new Point(40, 81);
            btn_viewHazards.Margin = new Padding(40, 20, 3, 0);
            btn_viewHazards.MinimumSize = new Size(1, 1);
            btn_viewHazards.Name = "btn_viewHazards";
            btn_viewHazards.Radius = 15;
            btn_viewHazards.RectColor = Color.Black;
            btn_viewHazards.RectHoverColor = Color.Black;
            btn_viewHazards.RectPressColor = Color.Black;
            btn_viewHazards.RectSelectedColor = Color.Black;
            btn_viewHazards.Size = new Size(127, 41);
            btn_viewHazards.TabIndex = 2;
            btn_viewHazards.Text = "View Hazards";
            btn_viewHazards.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dgv_caList, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(200, 39);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.4922638F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.5077362F));
            tableLayoutPanel1.Size = new Size(1080, 711);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // dgv_caList
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgv_caList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_caList.BackgroundColor = Color.White;
            dgv_caList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_caList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_caList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_caList.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_caList.Dock = DockStyle.Fill;
            dgv_caList.EnableHeadersVisualStyles = false;
            dgv_caList.Font = new Font("Microsoft Sans Serif", 12F);
            dgv_caList.GridColor = Color.FromArgb(80, 160, 255);
            dgv_caList.Location = new Point(3, 362);
            dgv_caList.Name = "dgv_caList";
            dgv_caList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_caList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            dgv_caList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv_caList.SelectedIndex = -1;
            dgv_caList.Size = new Size(1074, 346);
            dgv_caList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgv_caList.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(dgv_hazardList, 0, 1);
            tableLayoutPanel2.Controls.Add(cb_includeAll, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.4645891F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 87.53541F));
            tableLayoutPanel2.Size = new Size(1074, 353);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // dgv_hazardList
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dgv_hazardList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgv_hazardList.BackgroundColor = Color.White;
            dgv_hazardList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgv_hazardList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgv_hazardList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgv_hazardList.DefaultCellStyle = dataGridViewCellStyle8;
            dgv_hazardList.Dock = DockStyle.Fill;
            dgv_hazardList.EnableHeadersVisualStyles = false;
            dgv_hazardList.Font = new Font("Microsoft Sans Serif", 12F);
            dgv_hazardList.GridColor = Color.FromArgb(80, 160, 255);
            dgv_hazardList.Location = new Point(3, 47);
            dgv_hazardList.Name = "dgv_hazardList";
            dgv_hazardList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgv_hazardList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 12F);
            dgv_hazardList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgv_hazardList.SelectedIndex = -1;
            dgv_hazardList.Size = new Size(1068, 303);
            dgv_hazardList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgv_hazardList.TabIndex = 1;
            // 
            // cb_includeAll
            // 
            cb_includeAll.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cb_includeAll.ForeColor = Color.White;
            cb_includeAll.Location = new Point(3, 3);
            cb_includeAll.MinimumSize = new Size(1, 1);
            cb_includeAll.Name = "cb_includeAll";
            cb_includeAll.Size = new Size(220, 38);
            cb_includeAll.TabIndex = 0;
            cb_includeAll.Text = "Include All Hazards";
            // 
            // btn_addCa
            // 
            btn_addCa.FillColor = Color.Firebrick;
            btn_addCa.FillColor2 = Color.Firebrick;
            btn_addCa.FillHoverColor = Color.IndianRed;
            btn_addCa.FillPressColor = Color.DarkRed;
            btn_addCa.FillSelectedColor = Color.DarkRed;
            btn_addCa.Font = new Font("Microsoft Sans Serif", 12F);
            btn_addCa.Location = new Point(40, 142);
            btn_addCa.Margin = new Padding(40, 20, 3, 20);
            btn_addCa.MinimumSize = new Size(1, 1);
            btn_addCa.Name = "btn_addCa";
            btn_addCa.Radius = 15;
            btn_addCa.RectColor = Color.Black;
            btn_addCa.RectHoverColor = Color.Black;
            btn_addCa.RectPressColor = Color.Black;
            btn_addCa.RectSelectedColor = Color.Black;
            btn_addCa.Size = new Size(127, 41);
            btn_addCa.TabIndex = 3;
            btn_addCa.Text = "Add Action";
            btn_addCa.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // Frm_ViewCorrectiveActions
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Black_Background_1920x1045_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1280, 750);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pnl_controlBox);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1280, 750);
            MinimumSize = new Size(1280, 750);
            Name = "Frm_ViewCorrectiveActions";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Frm_ViewCorrectiveActions";
            pnl_controlBox.ResumeLayout(false);
            pnl_controlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_caList).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_hazardList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_controlBox;
        private Label label1;
        private PictureBox pb_dmLogo;
        private PictureBox pb_minimize;
        private PictureBox pb_exit;
        private FlowLayoutPanel flowLayoutPanel1;
        private Sunny.UI.UIButton btn_ViewAllActions;
        private TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UIDataGridView dgv_caList;
        private Sunny.UI.UIButton btn_viewHazards;
        private TableLayoutPanel tableLayoutPanel2;
        private Sunny.UI.UIDataGridView dgv_hazardList;
        private Sunny.UI.UICheckBox cb_includeAll;
        private Sunny.UI.UIButton btn_addCa;
    }
}