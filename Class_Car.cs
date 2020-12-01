using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attestation_Report
{
    class Class_Car
    {
        public Guid Part_id { get; set; }
        public int Car_id { get; set; }
        public string Num { get; set; }
        public int? Att_code { get; set; }
        public float? Tara { get; set; }
        public float? Tara_e { get; set; }
        public int? zone_e { get; set; }
        public int? Cause_id { get; set; }
        public float? Carring_e { get; set; }
        public DateTime Att_time { get; set; }
        public int? Shipper { get; set; }
        public int? Consigner { get; set; }
        public int? Mat { get; set; }
        public float? Left_truck { get; set; }
        public float? Right_truck { get; set; }
        public float? Brutto { get; set; }
        public float? Netto { get; set; }
        public DateTime Weighing_time { get; set; }
    }
}
