namespace InciTrack_Pro
{
    partial class Frm_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
            pnl_controlBox = new Panel();
            label1 = new Label();
            pb_dmLogo = new PictureBox();
            pb_minimize = new PictureBox();
            pb_exit = new PictureBox();
            flp_menu = new FlowLayoutPanel();
            flp_Kpi = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            //cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            pnl_controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).BeginInit();
            tableLayoutPanel1.SuspendLayout();
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
            pnl_controlBox.TabIndex = 0;
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
            // flp_menu
            // 
            flp_menu.BackColor = Color.RosyBrown;
            flp_menu.Dock = DockStyle.Left;
            flp_menu.FlowDirection = FlowDirection.TopDown;
            flp_menu.Location = new Point(0, 39);
            flp_menu.Name = "flp_menu";
            flp_menu.Size = new Size(200, 711);
            flp_menu.TabIndex = 1;
            // 
            // flp_Kpi
            // 
            flp_Kpi.BackColor = Color.Transparent;
            flp_Kpi.Dock = DockStyle.Top;
            flp_Kpi.Location = new Point(200, 39);
            flp_Kpi.Name = "flp_Kpi";
            flp_Kpi.Size = new Size(1080, 120);
            flp_Kpi.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            //tableLayoutPanel1.Controls.Add(cartesianChart1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(200, 159);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1080, 591);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // cartesianChart1
            // 
            //cartesianChart1.AutoUpdateEnabled = true;
            //cartesianChart1.ChartTheme = null;
            //skDefaultLegend1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            //skDefaultLegend1.Content = null;
            //skDefaultLegend1.IsValid = true;
            //skDefaultLegend1.Opacity = 1F;
            //padding1.Bottom = 0F;
            //padding1.Left = 0F;
            //padding1.Right = 0F;
            //padding1.Top = 0F;
            //skDefaultLegend1.Padding = padding1;
            //skDefaultLegend1.RemoveOnCompleted = false;
            //skDefaultLegend1.RotateTransform = 0F;
            //skDefaultLegend1.X = 0F;
            //skDefaultLegend1.Y = 0F;
            //cartesianChart1.Legend = skDefaultLegend1;
            //cartesianChart1.Location = new Point(3, 4);
            //cartesianChart1.Margin = new Padding(3, 4, 3, 4);
            //cartesianChart1.MatchAxesScreenDataRatio = false;
            //cartesianChart1.Name = "cartesianChart1";
            //cartesianChart1.Size = new Size(171, 190);
            //cartesianChart1.TabIndex = 0;
            //skDefaultTooltip1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            //skDefaultTooltip1.Content = null;
            //skDefaultTooltip1.IsValid = true;
            //skDefaultTooltip1.Opacity = 1F;
            //padding2.Bottom = 0F;
            //padding2.Left = 0F;
            //padding2.Right = 0F;
            //padding2.Top = 0F;
            //skDefaultTooltip1.Padding = padding2;
            //skDefaultTooltip1.RemoveOnCompleted = false;
            //skDefaultTooltip1.RotateTransform = 0F;
            //skDefaultTooltip1.Wedge = 10;
            //skDefaultTooltip1.X = 0F;
            //skDefaultTooltip1.Y = 0F;
            //cartesianChart1.Tooltip = skDefaultTooltip1;
            //cartesianChart1.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
            //cartesianChart1.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // Frm_Main
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Black_Background_1920x1045_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1280, 750);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flp_Kpi);
            Controls.Add(flp_menu);
            Controls.Add(pnl_controlBox);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1280, 750);
            MinimumSize = new Size(1280, 750);
            Name = "Frm_Main";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            pnl_controlBox.ResumeLayout(false);
            pnl_controlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dmLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_minimize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_exit).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_controlBox;
        private PictureBox pb_dmLogo;
        private PictureBox pb_minimize;
        private PictureBox pb_exit;
        private Label label1;
        private FlowLayoutPanel flp_menu;
        private FlowLayoutPanel flp_Kpi;
        private TableLayoutPanel tableLayoutPanel1;
        //private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        //private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
    }
}
