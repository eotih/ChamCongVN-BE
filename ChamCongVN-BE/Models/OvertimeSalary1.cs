using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class OvertimeSalary1
    {
        public int OvertimeSalaryID { get; set; }
        public int EmployeeID { get; set; }
        public string OvertimeSalaryName { get; set; }
        public System.DateTime Time { get; set; }
        public double OvertimeType { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}