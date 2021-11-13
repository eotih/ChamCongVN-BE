using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class DanhGiaNhanVien
    {
        public string Madanhgia { get; set; }
        public string MaNV { get; set; }
        public System.DateTime Ngay { get; set; }
        public string Tinhthankyluat { get; set; }
        public string Ketqualamviec { get; set; }
        public string Daoduc { get; set; }
        public string Tinhthanhochoi { get; set; }
        public string Tinhthanlamviec { get; set; }
        public string Danhgiachung { get; set; }
        public double Diem { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }

        public virtual PB_Nhanvien PB_Nhanvien { get; set; }
    }
}