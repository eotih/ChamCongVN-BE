using ChamCongVN_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamCongVN_BE.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeeController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        [Route("ShowAllEmployees")]
        [HttpGet]
        public object ShowAllEmployees()
        {
            var result = (from emp in db.Employees
                          from gr in db.Groups
                          from position in db.Positions
                          from department in db.Departments
                          from work in db.Works
                          select new
                          {
                              emp.EmployeeID,
                              ListDegree = db.DegreesOfEmployees.ToList(),
                              ListSpeciality = db.SpecialityOfEmployees.ToList(),
                              emp.GroupID,
                              gr.GroupName,
                              emp.PositionID,
                              position.PositionName,
                              emp.DepartmentID,
                              department.DepartmentName,
                              emp.WorkID,
                              work.WorkName,
                              emp.FullName,
                              emp.NickName,
                              emp.Gender,
                              emp.Image,
                              emp.DateOfBirth,
                              emp.PlaceOfBirth,
                              emp.Address,
                              emp.TemporaryAddress,
                              emp.Phone,
                              emp.IdentityCard,
                              emp.DateRange,
                              emp.IssuedBy,
                              emp.StartDate,
                              emp.Health,
                              emp.SocialInsurance,
                              emp.HealthInsurance,
                              emp.UnemploymentInsurance,
                              emp.CreatedBy,
                              emp.UpdatedBy,
                              emp.CreatedAt,
                              emp.UpdatedAt
                          }).ToList();
            return result;
        }
    }
}
