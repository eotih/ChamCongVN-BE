using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class LuongTangCa
    {
        public string Mabangluong { get; set; }
        public string MaNV { get; set; }
        public int Maluongtangca { get; set; }
        public int LuongGio { get; set; }
        public int Sotangcathuong { get; set; }
        public int Sotangcachunhat { get; set; }
        public int Sotangcale { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }
        public virtual PB_Danhsachbangluong PB_Danhsachbangluong { get; set; }
    }
}