using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class Account1
    {
        public int AccountID { get; set; }
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
        public int StateID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}