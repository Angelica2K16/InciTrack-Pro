using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InciTrack_Pro.Forms
{
    public partial class Frm_UpdateCorrectiveAction : Form
    {
        public Frm_UpdateCorrectiveAction()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += Frm_UpdateCorrectiveAction_Load;
        }

        private void Frm_UpdateCorrectiveAction_Load(object? sender, EventArgs e)
        {
            
        }
    }
}
