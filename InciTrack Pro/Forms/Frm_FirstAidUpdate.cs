using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace InciTrack_Pro.Forms
{
    public partial class Frm_FirstAidUpdate : Form
    {
        public Frm_FirstAidUpdate()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_FirstAidUpdate_Load;
        }

        private void Frm_FirstAidUpdate_Load(object? sender, EventArgs e)
        {
            lbl_header.Text = "First Aid Incident Update";
            lbl_header.Image = IconCharToImage(IconChar.Bandage);
            lbl_header.ImageAlign = ContentAlignment.MiddleLeft;
            lbl_header.TextAlign = ContentAlignment.MiddleCenter;
        }

        private Image IconCharToImage(IconChar iconChar)
        {
            using IconPictureBox icon = new IconPictureBox();

            icon.IconChar = iconChar;
            icon.IconColor = Color.White;
            icon.IconSize = 24;

            return icon.Image!;
        }
    }
}
