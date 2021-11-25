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
    
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public int GroupID { get; set; }
        public int PositionID { get; set; }
        public int DepartmentID { get; set; }
        public int WorkID { get; set; }
        public int SalaryTableID { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Address { get; set; }
        public string TemporaryAddress { get; set; }
        public string Phone { get; set; }
        public string IdentityCard { get; set; }
        public System.DateTime DateRange { get; set; }
        public string IssuedBy { get; set; }
        public System.DateTime StartDate { get; set; }
        public string Health { get; set; }
        public string SocialInsurance { get; set; }
        public string HealthInsurance { get; set; }
        public string UnemploymentInsurance { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}
