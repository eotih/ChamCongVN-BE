using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class DanhSachBangLuong
    {


        public string Mabangluong { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string Nguoiky { get; set; }
        public string Chucvunguoiky { get; set; }
        public Nullable<System.DateTime> Ngayky { get; set; }
        public int Luongtoithieu { get; set; }
        public int Tongsogioquydinh { get; set; }
        public int Tienbatdautinhthue { get; set; }
        public int Tienmoinguoiphuthuoc { get; set; }
        public double Hesothuong { get; set; }
        public double Hesochunhat { get; set; }
        public double Hesonghile { get; set; }
        public double BHXH { get; set; }
        public double BHYT { get; set; }
        public double BHTN { get; set; }
        public int BHXHMAX { get; set; }
        public double Phicongdoan { get; set; }
        public int PhicongdoanMax { get; set; }
        public bool IsLock { get; set; }
        public bool IsFinish { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> CreatedByDate { get; set; }
        public string UpdatedByUser { get; set; }
        public Nullable<System.DateTime> UpdatedByDate { get; set; }

        
       
    }
}