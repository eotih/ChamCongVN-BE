using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class LuongLamThem
    {
        public string Mabangluong { get; set; }
        public string MaNV { get; set; }
        public int Maluonglamthem { get; set; }
        public string Tenluonglamthem { get; set; }
        public int Sotien { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }
    }
}