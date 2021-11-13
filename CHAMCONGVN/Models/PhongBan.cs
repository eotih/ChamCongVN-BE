using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class PhongBan
    {


        public int Maphong { get; set; }
        public string Tenphong { get; set; }
        public string Dienthoai { get; set; }
        public Nullable<int> Tongsonhanvien { get; set; }
        public string GhiChu { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }


    }
}