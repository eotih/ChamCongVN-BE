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
                          where gr.GroupID == emp.GroupID
                          where position.PositionID == emp.PositionID
                          where department.DepartmentID == emp.DepartmentID
                          where work.WorkID == emp.WorkID
                          select new
                          {
                              emp,
                              ListDegree = db.DegreesOfEmployees.Where(x=>x.EmployeeID==emp.EmployeeID).ToList(),
                              ListSpeciality = db.SpecialityOfEmployees.Where(x => x.EmployeeID == emp.EmployeeID).ToList(),
                              work.WorkName,
                              gr.GroupName,
                              position.PositionName,
                              department.DepartmentName
                          }).ToList();
            return result;
        }
        [Route("GetDegreeOfEmployeeByEmployeeID")]
        [HttpGet]
        public object GetDegreeDetailsByEmployeeID(int employeeid)
        {
            var obj = db.DegreesOfEmployees.Where(x => x.EmployeeID == employeeid).FirstOrDefault();
            return obj;
        }
        [Route("GetEmployeeByEmployeeID")]
        [HttpGet]
        public object GetEmployeeByEmployeeID(int employeeid)
        {
            var obj = db.Employees.Where(x => x.EmployeeID == employeeid).FirstOrDefault();
            return obj;
        }
    }
}
