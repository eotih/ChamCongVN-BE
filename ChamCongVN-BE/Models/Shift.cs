//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChamCongVN_BE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shift
    {
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }
        public Nullable<System.TimeSpan> StartShift { get; set; }
        public Nullable<System.TimeSpan> EndShift { get; set; }
    }
}
