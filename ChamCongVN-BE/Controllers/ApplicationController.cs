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
                       where absent.EmployeeID == emp.EmployeeID
                       select new
                       {
                           AbsentApplications = absent,
                           Employee = emp
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
        [Route("TimeApplications")]
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
                    StateID = 1,
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

        [Route("TimeApplications/{id?}")]
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
            var abs = (from OverTime in db.OverTimeApplications
                       from emp in db.Employees
                       where OverTime.EmployeeID == emp.EmployeeID
                       select new
                       {
                           OverTimeApplications = OverTime,
                           Employee = emp
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

        // ------------------------------ Deduction Employees ------------------------------ //
        [Route("DeductionEmployees")]
        [HttpPost]
        public object AddDeductionEmployees(DeductionEmployee1 deductionemployee1)
        {
            if (deductionemployee1.DeductionEmployeeID == 0)
            {
                DeductionEmployee deduc = new DeductionEmployee
                {
                    EmployeeID = deductionemployee1.EmployeeID,
                    DeductionName = deductionemployee1.DeductionName,
                    DeductionDate = deductionemployee1.DeductionDate,
                    Reason = deductionemployee1.Reason,
                    Amount = deductionemployee1.Amount,
                    CreatedBy = deductionemployee1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.DeductionEmployees.Add(deduc);
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

        [Route("DeductionEmployees/{id?}")]
        [HttpPut]
        public object EditDeductionEmployees(DeductionEmployee1 deductionemployee1)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.DeductionEmployees.Where(x => x.DeductionEmployeeID == id).FirstOrDefault();
            if (obj.DeductionEmployeeID > 0)
            {
                obj.EmployeeID = deductionemployee1.EmployeeID;
                obj.DeductionName = deductionemployee1.DeductionName;
                obj.DeductionDate = deductionemployee1.DeductionDate;
                obj.Reason = deductionemployee1.Reason;
                obj.Amount = deductionemployee1.Amount;
                obj.UpdatedBy = deductionemployee1.UpdatedBy;
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

        [Route("DeductionEmployee")]
        [HttpGet]
        public object GetAllDeductionEmployee()
        {
            var abs = (from deduction in db.DeductionEmployees
                       from emp in db.Employees
                       where deduction.EmployeeID == emp.EmployeeID
                       select new
                       {
                           DeductionEmployees = deduction,
                           Employee = emp
                       }).ToList();
            return abs;
        }

        [Route("DeductionEmployee/{id?}")]
        [HttpGet]
        public object GetDeductionEmployeeByID(int ID)
        {
            var ded = db.DeductionEmployees.Where(x => x.DeductionEmployeeID == ID).FirstOrDefault();
            return ded;
        }

        [Route("DeductionEmployee/{id?}")]
        [HttpDelete]
        public object DeleteDeductionEmployee(int ID)
        {
            var obj = db.DeductionEmployees.Where(x => x.DeductionEmployeeID == ID).FirstOrDefault();
            db.DeductionEmployees.Remove(obj);
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
                           Employee = emp
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

        [Route("DeleteRegulationEmployee/{id?}")]
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
        // ------------------------------ Laudatory Employees ------------------------------ //
        [Route("LaudatoryEmployees")]
        [HttpPost]
        public object AddLaudatoryEmployees(LaudatoryEmployee1 Laudatoryemployee1)
        {
            if (Laudatoryemployee1.LaudatoryEmployeeID == 0)
            {
                LaudatoryEmployee deduc = new LaudatoryEmployee
                {
                    EmployeeID = Laudatoryemployee1.EmployeeID,
                    LaudatoryName = Laudatoryemployee1.LaudatoryName,
                    LaudatoryDate = Laudatoryemployee1.LaudatoryDate,
                    Reason = Laudatoryemployee1.Reason,
                    Amount = Laudatoryemployee1.Amount,
                    CreatedBy = Laudatoryemployee1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.LaudatoryEmployees.Add(deduc);
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

        [Route("LaudatoryEmployees/{id?}")]
        [HttpPut]
        public object EditLaudatoryEmployees(LaudatoryEmployee1 Laudatoryemployee1)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.LaudatoryEmployees.Where(x => x.LaudatoryEmployeeID == id).FirstOrDefault();
            if (obj.LaudatoryEmployeeID > 0)
            {
                obj.EmployeeID = Laudatoryemployee1.EmployeeID;
                obj.LaudatoryName = Laudatoryemployee1.LaudatoryName;
                obj.LaudatoryDate = Laudatoryemployee1.LaudatoryDate;
                obj.Reason = Laudatoryemployee1.Reason;
                obj.Amount = Laudatoryemployee1.Amount;
                obj.UpdatedBy = Laudatoryemployee1.UpdatedBy;
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
                Message = "Data not update"
            };
        }

        [Route("LaudatoryEmployee")]
        [HttpGet]
        public object GetAllLaudatoryEmployee()
        {
            var abs = (from Laudatory in db.LaudatoryEmployees
                       from emp in db.Employees
                       where Laudatory.EmployeeID == emp.EmployeeID
                       select new
                       {
                           LaudatoryEmployees = Laudatory,
                           Employee = emp
                       }
                           ).ToList();
            return abs;
        }

        [Route("LaudatoryEmployee/{id?}")]
        [HttpGet]
        public object GetLaudatoryEmployeeByID(int ID)
        {
            var ded = db.LaudatoryEmployees.Where(x => x.LaudatoryEmployeeID == ID).FirstOrDefault();
            return ded;
        }

        [Route("LaudatoryEmployee/{id?}")]
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

        // ------------------------------ Advances ------------------------------ //
        [Route("Advances")]
        [HttpPost]
        public object AddAdvances(Advance1 adv)
        {
            if (adv.AdvanceID == 0)
            {
                Advance advance = new Advance
                {
                    EmployeeID = adv.EmployeeID,
                    AdvanceDate = adv.AdvanceDate,
                    Reason = adv.Reason,
                    Amount = adv.Amount,
                    Signer = adv.Signer,
                    SignDate = adv.SignDate,
                    CreatedAt = DateTime.Now
                };
                db.Advances.Add(advance);
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

        [Route("Advances/{id?}")]
        [HttpPut]
        public object EditAdvances(Advance1 adv)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.Advances.Where(x => x.AdvanceID == id).FirstOrDefault();
            if (obj.AdvanceID > 0)
            {
                obj.EmployeeID = adv.EmployeeID;
                obj.AdvanceDate = adv.AdvanceDate;
                obj.AdvanceDate = adv.AdvanceDate;
                obj.Amount = adv.Amount;
                obj.Signer = adv.Signer;
                obj.SignDate = adv.SignDate;
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
                Message = "Data not Updated"
            };
        }

        [Route("AllAdvances")]
        [HttpGet]
        public object GetAllAdvances()
        {
            var abs = (from adv in db.Advances
                       from emp in db.Employees
                       where adv.EmployeeID == emp.EmployeeID
                       select new
                       {
                           LaudatoryEmployees = adv,
                           Employee = emp
                       }
                           ).ToList();
            return abs;
        }

        [Route("Advance/{id?}")]
        [HttpGet]
        public object GetAdvanceByID(int ID)
        {
            var ded = db.Advances.Where(x => x.AdvanceID == ID).FirstOrDefault();
            return ded;
        }

        [Route("Advance/{id?}")]
        [HttpDelete]
        public object DeleteAdvance(int ID)
        {
            var obj = db.Advances.Where(x => x.AdvanceID == ID).FirstOrDefault();
            db.Advances.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }
    }
}