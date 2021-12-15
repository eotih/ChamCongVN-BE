using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class OverTimeApplication1
    {
        public int OverTimeApplicationID { get; set; }
        public int EmployeeID { get; set; }
        public int StateID { get; set; }
        public int OverTimeID { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}