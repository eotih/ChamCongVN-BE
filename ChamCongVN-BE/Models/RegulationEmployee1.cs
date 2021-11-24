using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class RegulationEmployee1
    {
        public int RegulationEmployeeID { get; set; }
        public int EmployeeID { get; set; }
        public string RegulationName { get; set; }
        public System.DateTime RegulationDate { get; set; }
        public string Reason { get; set; }
        public string RegulationFormat { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}