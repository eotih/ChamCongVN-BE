using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class TuyenDung
    {
        public int Matuyendung { get; set; }
        public string HoNV { get; set; }
        public string TenNV { get; set; }
        public string Gioitinh { get; set; }
        public System.DateTime Ngaysinh { get; set; }
        public string Noisinh { get; set; }
        public string Diachi { get; set; }
        public string Dienthoaididong { get; set; }
        public string Email { get; set; }
        public string Ungtuyenvitri { get; set; }
        public string Chuyenmon { get; set; }
        public string Trangthai { get; set; }
        public string LinkCV { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
    }
}