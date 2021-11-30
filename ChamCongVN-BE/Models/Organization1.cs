using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class Organization1
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public string Website { get; set; }
        public string PublicIP { get; set; }
    }
}