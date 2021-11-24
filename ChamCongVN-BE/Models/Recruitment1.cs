using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class Recruitment1
    {
        public int RecruitmentID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Address { get; set; }
        public string TemporaryAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ApplyFor { get; set; }
        public string LinkCV { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}