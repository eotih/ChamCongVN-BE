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
    
    public partial class OTCheckOut
    {
        public int OTCheckOutsID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Device { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}
