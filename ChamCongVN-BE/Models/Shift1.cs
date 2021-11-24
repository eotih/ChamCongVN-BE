using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class Shift1
    {
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }
        public Nullable<System.TimeSpan> StartShift { get; set; }
        public Nullable<System.TimeSpan> EndShift { get; set; }
    }
}