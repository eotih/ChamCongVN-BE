using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class TotalSalaryPerMonth1
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
        public Nullable<double> TotalOvertimeSalary { get; set; }
        public Nullable<double> TotalSalary { get; set; }
    }
}