using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class OverTime1
    {
        public int OverTimeID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string OverTimeName { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<System.DateTime> OverTimeDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}