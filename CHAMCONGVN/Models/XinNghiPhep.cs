using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class XinNghiPhep
    {
        public int MaNghiPhep { get; set; }
        public string MaNV { get; set; }
        public string LoaiNghi { get; set; }
        public System.DateTime NgayNghi { get; set; }
        public string TieuDeNghi { get; set; }
        public string LyDoNghi { get; set; }
        public string TrangThai { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }
    }
}