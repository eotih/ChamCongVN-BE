using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class CheckIn1
    {
        public int CheckInCode { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Device { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}