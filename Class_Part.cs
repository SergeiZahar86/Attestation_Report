using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attestation_Report
{
    class Class_Part
    {
        public Guid Part_id { get; set; }
        public string Oper { get; set; }
        public int? Num_izm { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public int? Num_metering { get; set; }

    }
}
