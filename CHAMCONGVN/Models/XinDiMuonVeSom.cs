using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class XinDiMuonVeSom
    {
        public int MaDMVS { get; set; }
        public string MaNV { get; set; }
        public string LoaiDMVS { get; set; }
        public System.DateTime NgayDMVS { get; set; }
        public System.TimeSpan GioXin { get; set; }
        public string TieuDeDMVS { get; set; }
        public string LyDoDMVS { get; set; }
        public string TrangThai { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }
    }
}