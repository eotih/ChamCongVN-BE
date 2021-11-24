using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamCongVN_BE.Models
{
    public class Employee1
    {
        public int EmployeeID { get; set; }
        public int DegreeID { get; set; }
        public int SpecialtyID { get; set; }
        public int GroupID { get; set; }
        public int PositionID { get; set; }
        public int DepartmentID { get; set; }
        public int WorkID { get; set; }
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
        public Nullable<System.DateTime> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}