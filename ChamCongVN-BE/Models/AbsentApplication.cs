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
    
    public partial class AbsentApplication
    {
        public int AbsentApplicationID { get; set; }
        public int EmployeeID { get; set; }
        public string AbsentType { get; set; }
        public System.DateTime AbsentDateBegin { get; set; }
        public int NumberOfDays { get; set; }
        public string Reason { get; set; }
        public int StateID { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}
