using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class CheckOut1
    {
        public int CheckOutCode { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Device { get; set; }
        public string Latitude { get; set; }
        public string PublicIP { get; set; }
        public string Longitude { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}