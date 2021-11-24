﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class AbsentApplication1
    {
        public int AbsentApplicationID { get; set; }
        public int EmployeeID { get; set; }
        public string AbsentType { get; set; }
        public System.DateTime AbsentDate { get; set; }
        public string Reason { get; set; }
        public int StateID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}