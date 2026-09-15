namespace InciTrack_Pro.Forms
{
    partial class Frm_Summary
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
            flowLayoutPanel3 = new FlowLayoutPanel();
            label5 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            combo_Year = new Sunny.UI.UIComboBox();
            combo_Quarter = new Sunny.UI.UIComboBox();
            combo_month = new Sunny.UI.UIComboBox();
            flow_AP = new FlowLayoutPanel();
            flow_SHES = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label4 = new Label();
            pnl_controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
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
            pnl_controlBox.Size = new Size(1400, 37);
            pnl_controlBox.TabIndex = 2;
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
            pb_minimize.Location = new Point(1320, 2);
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
            pb_exit.Location = new Point(1363, 2);
            pb_exit.Name = "pb_exit";
            pb_exit.Size = new Size(37, 34);
            pb_exit.TabIndex = 2;
            pb_exit.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flow_AP, 0, 2);
            tableLayoutPanel1.Controls.Add(flow_SHES, 0, 4);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ForeColor = SystemColors.ControlText;
            tableLayoutPanel1.Location = new Point(0, 37);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.Size = new Size(1400, 713);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.RosyBrown;
            flowLayoutPanel3.Controls.Add(label5);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 353);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(1394, 44);
            flowLayoutPanel3.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(307, 39);
            label5.TabIndex = 3;
            label5.Text = "SHES Reported Events";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(combo_Year);
            flowLayoutPanel1.Controls.Add(combo_Quarter);
            flowLayoutPanel1.Controls.Add(combo_month);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1394, 94);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 15);
            label3.Margin = new Padding(3, 15, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(58, 23);
            label3.TabIndex = 0;
            label3.Text = "Filter:";
            // 
            // combo_Year
            // 
            combo_Year.DataSource = null;
            combo_Year.FillColor = Color.White;
            combo_Year.Font = new Font("Microsoft Sans Serif", 12F);
            combo_Year.ItemHoverColor = Color.FromArgb(155, 200, 255);
            combo_Year.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            combo_Year.Location = new Point(68, 15);
            combo_Year.Margin = new Padding(4, 15, 4, 5);
            combo_Year.MinimumSize = new Size(63, 0);
            combo_Year.Name = "combo_Year";
            combo_Year.Padding = new Padding(0, 0, 30, 2);
            combo_Year.Size = new Size(150, 39);
            combo_Year.SymbolSize = 24;
            combo_Year.TabIndex = 1;
            combo_Year.TextAlignment = ContentAlignment.MiddleLeft;
            combo_Year.Watermark = "";
            // 
            // combo_Quarter
            // 
            combo_Quarter.DataSource = null;
            combo_Quarter.FillColor = Color.White;
            combo_Quarter.Font = new Font("Microsoft Sans Serif", 12F);
            combo_Quarter.ItemHoverColor = Color.FromArgb(155, 200, 255);
            combo_Quarter.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            combo_Quarter.Location = new Point(226, 15);
            combo_Quarter.Margin = new Padding(4, 15, 4, 5);
            combo_Quarter.MinimumSize = new Size(63, 0);
            combo_Quarter.Name = "combo_Quarter";
            combo_Quarter.Padding = new Padding(0, 0, 30, 2);
            combo_Quarter.Size = new Size(150, 39);
            combo_Quarter.SymbolSize = 24;
            combo_Quarter.TabIndex = 2;
            combo_Quarter.TextAlignment = ContentAlignment.MiddleLeft;
            combo_Quarter.Watermark = "";
            // 
            // combo_month
            // 
            combo_month.DataSource = null;
            combo_month.FillColor = Color.White;
            combo_month.Font = new Font("Microsoft Sans Serif", 12F);
            combo_month.ItemHoverColor = Color.FromArgb(155, 200, 255);
            combo_month.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            combo_month.Location = new Point(384, 15);
            combo_month.Margin = new Padding(4, 15, 4, 5);
            combo_month.MinimumSize = new Size(63, 0);
            combo_month.Name = "combo_month";
            combo_month.Padding = new Padding(0, 0, 30, 2);
            combo_month.Size = new Size(150, 39);
            combo_month.SymbolSize = 24;
            combo_month.TabIndex = 2;
            combo_month.TextAlignment = ContentAlignment.MiddleLeft;
            combo_month.Watermark = "";
            // 
            // flow_AP
            // 
            flow_AP.Dock = DockStyle.Fill;
            flow_AP.Location = new Point(3, 153);
            flow_AP.Name = "flow_AP";
            flow_AP.Size = new Size(1394, 194);
            flow_AP.TabIndex = 3;
            // 
            // flow_SHES
            // 
            flow_SHES.Dock = DockStyle.Fill;
            flow_SHES.Location = new Point(3, 403);
            flow_SHES.Name = "flow_SHES";
            flow_SHES.Size = new Size(1394, 307);
            flow_SHES.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.RosyBrown;
            flowLayoutPanel2.Controls.Add(label4);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 103);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1394, 44);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(277, 39);
            label4.TabIndex = 3;
            label4.Text = "AP Reported Events";
            // 
            // Frm_Summary
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Black_Background_1920x1045_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1400, 750);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnl_controlBox);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1400, 750);
            MinimumSize = new Size(1400, 750);
            Name = "Frm_Summary";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Frm_Summary";
            pnl_controlBox.ResumeLayout(false);
            pnl_controlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
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
        private Label label3;
        private Sunny.UI.UIComboBox combo_Year;
        private Sunny.UI.UIComboBox combo_Quarter;
        private Sunny.UI.UIComboBox combo_month;
        private FlowLayoutPanel flow_AP;
        private FlowLayoutPanel flow_SHES;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label4;
    }
}