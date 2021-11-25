using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class DeductionEmployee1
    {
        public int DeductionEmployeeID { get; set; }
        public int EmployeeID { get; set; }
        public string DeductionName { get; set; }
        public System.DateTime DeductionDate { get; set; }
        public string Reason { get; set; }
        public double Amount { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}