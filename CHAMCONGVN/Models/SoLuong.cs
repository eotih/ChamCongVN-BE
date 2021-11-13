using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class SoLuong
    {
        public string Mabangluong { get; set; }
        public string MaNV { get; set; }
        public int Masoluong { get; set; }
        public double Hesoluong { get; set; }
        public int Tonggiocongthucte { get; set; }
        public int Nghiphep { get; set; }
        public bool BHXH { get; set; }
        public bool BHYT { get; set; }
        public bool BHTN { get; set; }
        public bool Phicongdoan { get; set; }
        public int Tienthue { get; set; }
        public int Songuoiphuthuoc { get; set; }
        public int Sotienconlaichiuthue { get; set; }
        public int Tiendongthue { get; set; }
        public int Phicongtac { get; set; }
        public int Tongtamung { get; set; }
        public int Tongphucap { get; set; }
        public int Tongthuong { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }
    }
}