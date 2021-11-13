using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class CaLam
    {
        public int Maca { get; set; }
        public string TenCa { get; set; }
        public System.TimeSpan Batdauca { get; set; }
        public System.TimeSpan Ketthucca { get; set; }
        public Nullable<System.TimeSpan> Batdaunghi { get; set; }
        public Nullable<System.TimeSpan> Ketthucnghi { get; set; }
        public System.TimeSpan Dimuon { get; set; }
        public System.TimeSpan Vesom { get; set; }
        public System.TimeSpan Checkin { get; set; }
        public System.TimeSpan Checkout { get; set; }
        public bool CheckIP { get; set; }
        public bool CheckKhuonMat { get; set; }
        public bool CheckViTri { get; set; }
    }
}