using ChamCongVN_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamCongVN_BE.Controllers
{
    [RoutePrefix("Application")]
    public class ApplicationController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        // ------------------------------ Absent Application ------------------------------ //
        [Route("AbsentApplications")]
        [HttpPost]
        public object AddAbsentApplications(AbsentApplication1 absentapplication1)
        {
            if (absentapplication1.AbsentApplicationID == 0)
            {
                AbsentApplication absent = new AbsentApplication
                {
                    EmployeeID = absentapplication1.EmployeeID,
                    AbsentType = absentapplication1.AbsentType,
                    AbsentDateBegin = absentapplication1.AbsentDateBegin,
                    Reason = absentapplication1.Reason,
                    NumberOfDays = absentapplication1.NumberOfDays,
                    StateID = 1,
                    CreatedBy = absentapplication1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.AbsentApplications.Add(absent);
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
                Message = "Data Success"
            };
        }

        [Route("AbsentApplications/{id?}")]
        [HttpPut]
        public object EditAbsentApplications(AbsentApplication1 absentapplication1)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.AbsentApplications.Where(x => x.AbsentApplicationID == id).FirstOrDefault();
            if (obj.AbsentApplicationID > 0)
            {
                obj.AbsentType = absentapplication1.AbsentType;
                obj.AbsentDateBegin = absentapplication1.AbsentDateBegin;
                obj.Reason = absentapplication1.Reason;
                obj.NumberOfDays = absentapplication1.NumberOfDays;
                obj.UpdatedBy = absentapplication1.UpdatedBy;
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
                Message = "Data not Update"
            };
        }

        [Route("AbsentApplication/EditState/{id?}")]
        [HttpPut]
        public object EditStateAbsentApplication(AbsentApplication1 absent)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.AbsentApplications.Where(x => x.AbsentApplicationID == id).FirstOrDefault();
            if (obj.AbsentApplicationID > 0)
            {
                obj.StateID = absent.StateID;
                obj.UpdatedAt = DateTime.Now;
                obj.UpdatedBy = absent.UpdatedBy;
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
                Message = "Data not update"
            };
        }

        [Route("AbsentApplication")]
        [HttpGet]
        public object GetAllAbsentApplication()
        {
            var abs = (from absent in db.AbsentApplications
                       from emp in db.Employees
                       from state in db.States
                       where absent.EmployeeID == emp.EmployeeID
                       where state.StateID == absent.StateID
                       select new
                       {
                           AbsentApplications = absent,
                           Employee = emp,
                           emp.EmployeeID,
                           emp.FullName,
                           emp.Image,
                           state.StateName
                       }
                           ).ToList();
            return abs;
        }

        [Route("AbsentApplication/{id?}")]
        [HttpGet]
        public object GetAbsentApplicationByID(int ID)
        {
            var abs = db.AbsentApplications.Where(x => x.AbsentApplicationID == ID).FirstOrDefault();
            return abs;
        }

        [Route("AbsentApplication/Employee/{id?}")]
        [HttpGet]
        public object GetAbsentApplicationByEmployeeID(int ID)
        {
            var obj = db.AbsentApplications.Where(x => x.EmployeeID == ID).ToList();
            return obj;
        }

        [Route("AbsentApplication/{id?}")]
        [HttpDelete]
        public object DeleteAbsentApplication(int ID)
        {
            var obj = db.AbsentApplications.Where(x => x.AbsentApplicationID == ID).FirstOrDefault();
            db.AbsentApplications.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }
        //--------------------------- OverTime Application------------------------//
        [Route("OverTimeApplications")]
        [HttpPost]
        public object AddOverTimeApplications(OverTimeApplication1 OverTimeapplication1)
        {
            if (OverTimeapplication1.OverTimeApplicationID == 0)
            {
                OverTimeApplication OverTime = new OverTimeApplication
                {
                    EmployeeID = OverTimeapplication1.EmployeeID,
                    OverTimeID = OverTimeapplication1.OverTimeID,
                    Note = OverTimeapplication1.Note,
                    StateID = OverTimeapplication1.StateID,
                    CreatedBy = OverTimeapplication1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.OverTimeApplications.Add(OverTime);
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
                Message = "Data Success"
            };
        }

        [Route("OverTimeApplications/{id?}")]
        [HttpPut]
        public object EditOverTimeApplications(OverTimeApplication1 OverTimeapplication1)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.OverTimeApplications.Where(x => x.OverTimeApplicationID == id).FirstOrDefault();
            if (obj.OverTimeApplicationID > 0)
            {
                obj.OverTimeID = OverTimeapplication1.OverTimeID;
                obj.Note = OverTimeapplication1.Note;
                obj.UpdatedBy = OverTimeapplication1.UpdatedBy;
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

        [Route("OverTimeApplication/EditState/{id?}")]
        [HttpPut]
        public object EditStateOverTimeApplication(OverTimeApplication1 OverTime)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.OverTimeApplications.Where(x => x.OverTimeApplicationID == id).FirstOrDefault();
            if (obj.OverTimeApplicationID > 0)
            {
                obj.StateID = OverTime.StateID;
                obj.UpdatedAt = DateTime.Now;
                obj.UpdatedBy = OverTime.UpdatedBy;
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

        [Route("OverTimeApplication")]
        [HttpGet]
        public object GetAllOverTimeApplication()
        {
            var abs = (from Otapp in db.OverTimeApplications
                       from emp in db.Employees
                       from state in db.States
                       from ot in db.OverTimes
                       where state.StateID == Otapp.StateID
                       where Otapp.EmployeeID == emp.EmployeeID
                       where ot.OverTimeID == Otapp.OverTimeID
                       select new
                       {
                           OverTimeApplications = Otapp,
                           Employee = emp,
                           OverTime = ot,
                           ot.OverTimeName,
                           state.StateName,
                           emp.EmployeeID,
                           emp.FullName,
                           emp.Image
                       }).ToList();
            return abs;
        }

        [Route("OverTimeApplication/{id?}")]
        [HttpGet]
        public object GetOverTimeApplicationByID(int ID)
        {
            var abs = db.OverTimeApplications.Where(x => x.OverTimeApplicationID == ID).FirstOrDefault();
            return abs;
        }

        [Route("OverTimeApplication/Employee/{id?}")]
        [HttpGet]
        public object GetOverTimeApplicationByEmployeeID(int ID)
        {
            var obj = db.OverTimeApplications.Where(x => x.EmployeeID == ID).ToList();
            return obj;
        }

        [Route("OverTimeApplication/{id?}")]
        [HttpDelete]
        public object DeleteOverTimeApplication(int ID)
        {
            var obj = db.OverTimeApplications.Where(x => x.OverTimeApplicationID == ID).FirstOrDefault();
            db.OverTimeApplications.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }
        
    }
}