using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class Dicongtac
    {
        public int Macongtac { get; set; }
        public string MaNV { get; set; }
        public string Veviec { get; set; }
        public string LyDo { get; set; }
        public string Noicongtac { get; set; }
        public System.DateTime Tungay { get; set; }
        public System.DateTime Denngay { get; set; }
        public int Tiendicongtac { get; set; }
        public string Nguoiky { get; set; }
        public string Chucvunguoiky { get; set; }
        public System.DateTime Ngayky { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }
    }
}
