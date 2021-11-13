using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class XinQuenChamCong
    {
        public int MaQCC { get; set; }
        public string MaNV { get; set; }
        public string LoaiQCC { get; set; }
        public System.DateTime NgayQCC { get; set; }
        public System.TimeSpan GioCICO { get; set; }
        public string TieuDeLyDo { get; set; }
        public string LyDo { get; set; }
        public string TrangThai { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }
    }
}