using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class Advance1
    {
        public int AdvanceID { get; set; }
        public int EmployeeID { get; set; }
        public string Reason { get; set; }
        public System.DateTime AdvanceDate { get; set; }
        public double Amount { get; set; }
        public string Signer { get; set; }
        public System.DateTime SignDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}