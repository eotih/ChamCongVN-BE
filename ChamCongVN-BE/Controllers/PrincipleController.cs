using ChamCongVN_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamCongVN_BE.Controllers
{
    [RoutePrefix("Principle")]
    public class PrincipleController : ApiController
    {
         ChamCongVNEntities db = new ChamCongVNEntities();
        // ------------------------------ Laudatory Employee ------------------------------ //
        [Route("LaudatoryEmployee")]
        [HttpPost]
        public object AddLaudatoryEmployee(LaudatoryEmployee1 de1)
        {
            if (de1.LaudatoryEmployeeID == 0)
            {
                LaudatoryEmployee LaudatoryEmployee = new LaudatoryEmployee
                {
                    EmployeeID = de1.EmployeeID,
                    LaudatoryName = de1.LaudatoryName,
                    LaudatoryDate = de1.LaudatoryDate,
                    Reason = de1.Reason,
                    Amount = de1.Amount,
                    CreatedBy = de1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.LaudatoryEmployees.Add(LaudatoryEmployee);
                db.SaveChanges();
                return new Response
                {
                    Status = 200,
                    Message = "Data Success"
                };
            }
            return new Response
            {
                Status = 500,
                Message = "Data not insert"
            };
        }
        [Route("LaudatoryEmployee/{id}")]
        [HttpPut]
        public object EditLaudatoryEmployee(LaudatoryEmployee1 de1)
        {
            {
                int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
                var obj = db.LaudatoryEmployees.Where(x => x.LaudatoryEmployeeID == de1.LaudatoryEmployeeID).FirstOrDefault();
                if (obj.LaudatoryEmployeeID > 0)
                {
                    obj.EmployeeID = de1.EmployeeID;
                    obj.LaudatoryName = de1.LaudatoryName;
                    obj.LaudatoryDate = de1.LaudatoryDate;
                    obj.Reason = de1.Reason;
                    obj.Amount = de1.Amount;
                    obj.UpdatedBy = de1.UpdatedBy;
                    obj.UpdatedAt = DateTime.Now;
                    db.SaveChanges();
                    return new Response
                    {
                        Status = 200,
                        Message = "Updated Successfully"
                    };
                }
            }
            return new Response
            {
                Status = 500,
                Message = "Data not updated"
            };
        }
        [Route("LaudatoryEmployee")]
        [HttpGet]
        public object GetAllLaudatoryEmployee()
        {
            var ot = (from deduc in db.LaudatoryEmployees
                      from emp in db.Employees
                      where deduc.EmployeeID == emp.EmployeeID
                      select new
                      {
                          LaudatoryEmployee = deduc,
                          Employee = emp,
                          emp.EmployeeID,
                          emp.FullName,
                          emp.Image
                      }
                           ).ToList();
            return ot;
        }
        [Route("LaudatoryEmployee/{id}")]
        [HttpGet]
        public object GetLaudatoryEmployeeByID(int ID)
        {
            var ot = db.LaudatoryEmployees.Where(x => x.LaudatoryEmployeeID == ID).FirstOrDefault();
            return ot;
        }
        [Route("LaudatoryEmployee/{id}")]
        [HttpDelete]
        public object DeleteLaudatoryEmployee(int ID)
        {
            var obj = db.LaudatoryEmployees.Where(x => x.LaudatoryEmployeeID == ID).FirstOrDefault();
            db.LaudatoryEmployees.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Regulation Employees ------------------------------ //
        [Route("RegulationEmployees")]
        [HttpPost]
        public object AddRegulationEmployees(RegulationEmployee1 Regulationemployee1)
        {
            if (Regulationemployee1.RegulationEmployeeID == 0)
            {
                RegulationEmployee deduc = new RegulationEmployee
                {
                    EmployeeID = Regulationemployee1.EmployeeID,
                    RegulationName = Regulationemployee1.RegulationName,
                    RegulationDate = Regulationemployee1.RegulationDate,
                    Reason = Regulationemployee1.Reason,
                    RegulationFormat = Regulationemployee1.RegulationFormat,
                    CreatedBy = Regulationemployee1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.RegulationEmployees.Add(deduc);
                db.SaveChanges();
                return new Response
                {
                    Status = 200,
                    Message = "Data Success"
                };
            }
            return new Response
            {
                Status = 500,
                Message = "Data not insert"
            };
        }

        [Route("RegulationEmployees/{id?}")]
        [HttpPut]
        public object EditRegulationEmployees(RegulationEmployee1 Regulationemployee1)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.RegulationEmployees.Where(x => x.RegulationEmployeeID == id).FirstOrDefault();
            if (obj.RegulationEmployeeID > 0)
            {
                obj.EmployeeID = Regulationemployee1.EmployeeID;
                obj.RegulationName = Regulationemployee1.RegulationName;
                obj.RegulationDate = Regulationemployee1.RegulationDate;
                obj.Reason = Regulationemployee1.Reason;
                obj.RegulationFormat = Regulationemployee1.RegulationFormat;
                obj.UpdatedBy = Regulationemployee1.UpdatedBy;
                obj.UpdatedAt = DateTime.Now;
                db.SaveChanges();
                return new Response
                {
                    Status = 200,
                    Message = "Updated Successfully"
                };
            }
            return new Response
            {
                Status = 500,
                Message = "Data not insert"
            };
        }

        [Route("RegulationEmployee")]
        [HttpGet]
        public object GetAllRegulationEmployee()
        {
            var abs = (from Regulation in db.RegulationEmployees
                       from emp in db.Employees
                       where Regulation.EmployeeID == emp.EmployeeID
                       select new
                       {
                           RegulationEmployees = Regulation,
                           Employee = emp,
                           emp.EmployeeID,
                           emp.FullName,
                           emp.Image
                       }
                           ).ToList();
            return abs;
        }

        [Route("RegulationEmployee/{id?}")]
        [HttpGet]
        public object GetRegulationEmployeeByID(int ID)
        {
            var ded = db.RegulationEmployees.Where(x => x.RegulationEmployeeID == ID).FirstOrDefault();
            return ded;
        }

        [Route("RegulationEmployee/{id?}")]
        [HttpDelete]
        public object DeleteRegulationEmployee(int ID)
        {
            var obj = db.RegulationEmployees.Where(x => x.RegulationEmployeeID == ID).FirstOrDefault();
            db.RegulationEmployees.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }
    }
}
