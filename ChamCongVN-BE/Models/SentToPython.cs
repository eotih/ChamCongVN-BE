using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class SendToPython
    {
        public string Image { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PublicIP { get; set; }
        public string Device { get; set; }
    }
}