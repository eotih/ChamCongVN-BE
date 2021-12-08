using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class TimeKeeper
    {
        public int ID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Device { get; set; }
        public string PublicIP { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}