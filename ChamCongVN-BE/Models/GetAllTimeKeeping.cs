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
    
    public partial class GetAllTimeKeeping
    {
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public string Department { get; set; }
        public string CheckInImage { get; set; }
        public string CheckOutImage { get; set; }
        public Nullable<System.DateTime> CheckInCreatedAt { get; set; }
        public Nullable<System.DateTime> CheckOutCreatedAt { get; set; }
        public string CheckOutStatus { get; set; }
        public string CheckInStatus { get; set; }
    }
}
