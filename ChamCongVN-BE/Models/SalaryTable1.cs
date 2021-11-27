using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class SalaryTable1
    {
        public int SalaryTableID { get; set; }
        public string SalaryTableName { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public double MinSalary { get; set; }
        public double TotalTimeRegulation { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}