using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class KyluatNhanvien
    {
        public string Makyluat { get; set; }
        public string MaNV { get; set; }
        public string Tenkyluat { get; set; }
        public System.DateTime Ngayxayra { get; set; }
        public System.DateTime Ngaykyluat { get; set; }
        public string Diadiem { get; set; }
        public string Nguoichungkien { get; set; }
        public string Motasuviec { get; set; }
        public string Hinhthuckyluat { get; set; }
        public string Nguoibikyluatgiaithich { get; set; }
        public string LyDo { get; set; }
        public string Nguoiky { get; set; }
        public string Chucvunguoiky { get; set; }
        public System.DateTime Ngayky { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }
    }
}