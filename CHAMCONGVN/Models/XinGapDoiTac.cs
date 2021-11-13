using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class XinGapDoiTac
    {
        public int MaGapDoiTac { get; set; }
        public string MaNV { get; set; }
        public System.DateTime NgapGapDoiTac { get; set; }
        public System.TimeSpan GioBatDau { get; set; }
        public System.TimeSpan GioKetThuc { get; set; }
        public string TenDoiTac { get; set; }
        public string SDTDoiTac { get; set; }
        public string DiaChiCongTac { get; set; }
        public string NoiDung { get; set; }
        public string TrangThai { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }
    }
}