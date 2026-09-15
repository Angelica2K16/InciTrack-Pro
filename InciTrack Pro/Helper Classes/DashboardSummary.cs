using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InciTrack_Pro.Helper_Classes
{
    public class DashboardSummary
    {
        public int AP_HPNM { get; set; }
        public int AP_FirstAid { get; set; }
        public int AP_UnsafeAct { get; set; }
        public int AP_UnsafeCondition { get; set; }

        public int SHES_HPNM { get; set; }
        public int SHES_FirstAid { get; set; }
        public int SHES_UnsafeAct { get; set; }
        public int SHES_UnsafeCondition { get; set; }

        public int ClosedActions { get; set; }
        public int Audits { get; set; }
        public int MinimalHazards { get; set; }
    }
}
