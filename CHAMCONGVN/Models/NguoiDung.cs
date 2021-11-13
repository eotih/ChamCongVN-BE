using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class NguoiDung
    {
        public string ID { get; set; }
        public string IDQuyen { get; set; }
        public string MaNV { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public Nullable<long> NumberOfLogin { get; set; }
        public Nullable<System.DateTime> LaterLogin { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }


    }
}