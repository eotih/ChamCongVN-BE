using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class Salary1
    {
        public int SalaryID { get; set; }
        public int EmployeeID { get; set; }
        public int SalaryTableID { get; set; }
        public double CoefficientSalary { get; set; }
        public double TotalWorkTime { get; set; }
        public int TotalAbsentApplications { get; set; }
        public double TotalAdvances { get; set; }
        public double TotalOvertimeSalary { get; set; }
        public double TotalBonusSalary { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}