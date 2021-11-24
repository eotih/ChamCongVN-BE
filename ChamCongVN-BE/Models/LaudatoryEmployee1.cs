using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class LaudatoryEmployee1
    {
        public int LaudatoryEmployeeID { get; set; }
        public int EmployeeID { get; set; }
        public string LaudatoryName { get; set; }
        public System.DateTime LaudatoryDate { get; set; }
        public string Reason { get; set; }
        public double Amount { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}