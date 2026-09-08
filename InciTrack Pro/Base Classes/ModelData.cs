using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InciTrack_Pro.Base_Classes
{
    public class ModelData
    {
        #region Class Setup Code
        private static readonly Lazy<ModelData> _instance = new(() => new ModelData());
        public static ModelData Instance => _instance.Value;
        private ModelData() { }
        #endregion 

        #region First Aid Update Variables
        public int firstAidIdx { get; set; }
        public string? title { get; set; }
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public string? empName { get; set; }
        public string? area { get; set; }
        public string? descr { get; set; }
        public string? cause { get; set; }
        public string? investigation { get; set; }
        public string? apReport { get; set; }
        public string? notes { get; set; }
        #endregion

        #region Hazard Update Variables
        public int hazardIdx { get; set; }
        public string? hazTitle { get; set; }
        public DateTime hazDate { get; set; }
        //public DateTime time { get; set; }
        //public string? empName { get; set; }
        public string? hazArea { get; set; }
        public string? hazReportedBy { get; set; }
        public string? hazDescr { get; set; }
        public string? hazIncidentType { get; set; }
        public string? hazRiskMatrix { get; set; }
        public string? hazApReport { get; set; }
        public string? hazNotes { get; set; }
        public string? hazStatus { get; set; }
        public string? hazInjury { get; set; }
        public string? hazEnv { get; set; }
        public string? hazDamage { get; set; }

        #endregion

    }
}
