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
    
    public partial class TotalSalaryPerMonth
    {
        public int TotalSalaryID { get; set; }
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalTime { get; set; }
        public Nullable<double> Salary { get; set; }
        public Nullable<double> TotalAdvance { get; set; }
        public Nullable<double> TotalDeduction { get; set; }
        public Nullable<double> TotalLaudatory { get; set; }
        public Nullable<int> TotalOvertime { get; set; }
        public Nullable<double> TotalOvertimeSalary { get; set; }
        public Nullable<double> TotalSalary { get; set; }
    }
}
