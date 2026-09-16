using Sunny.UI;

namespace InciTrack_Pro.UserControls
{
    public partial class KpiCard : UIPanel
    {
        private UILabel lblTitle;
        private UILabel lblValue;

        public KpiCard(string title)
        {
            Width = 180;
            Height = 120;
            Radius = 10;
            FillColor = Color.White;
            Margin = new Padding(15, 25, 15, 15);

            lblTitle = new UILabel
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblValue = new UILabel
            {
                Text = "0",
                Dock = DockStyle.Fill,
                Font = new Font("Calibri", 24, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(lblValue);
            Controls.Add(lblTitle);
        }

        public void SetValue(int value)
        {
            lblValue.Text = value.ToString();
        }
    }
    
}
