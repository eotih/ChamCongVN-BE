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
        [Route("AddOrEditAbsentApplications")]
        [HttpPost]
        public object AddOrEditAbsentApplications(AbsentApplication1 absentapplication1)
        {
            if (absentapplication1.AbsentApplicationID == 0)
            {
                AbsentApplication absent = new AbsentApplication
                {
                    EmployeeID = absentapplication1.EmployeeID,
                    AbsentType = absentapplication1.AbsentType,
                    AbsentDate = absentapplication1.AbsentDate,
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.AbsentApplications.Where(x => x.AbsentApplicationID == absentapplication1.AbsentApplicationID).FirstOrDefault();
                if (obj.AbsentApplicationID > 0)
                {
                    obj.AbsentType = absentapplication1.AbsentType;
                    obj.AbsentDate = absentapplication1.AbsentDate;
                    obj.Reason = absentapplication1.Reason;
                    obj.NumberOfDays = absentapplication1.NumberOfDays;
                    obj.UpdatedBy = absentapplication1.UpdatedBy;
                    obj.UpdatedAt = DateTime.Now;
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Updated",
                        Message = "Updated Successfully"
                    };
                }
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }
        [Route("EditStateAbsentApplication")]
        [HttpPost]
        public object EditStateAbsentApplication(AbsentApplication1 absent)
        {
            var obj = db.AbsentApplications.Where(x => x.AbsentApplicationID == absent.AbsentApplicationID).FirstOrDefault();
            if (obj.AbsentApplicationID > 0)
            {
                obj.StateID = absent.StateID;
                obj.UpdatedAt = DateTime.Now;
                obj.UpdatedBy = absent.UpdatedBy;
                db.SaveChanges();
                return new Response
                {
                    Status = "Updated",
                    Message = "Updated Successfully"
                };
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }
        [Route("GetAllAbsentApplication")]
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
        [Route("GetAbsentApplicationByID")]
        [HttpGet]
        public object GetAbsentApplicationByID(int ID)
        {
            var abs = db.AbsentApplications.Where(x => x.AbsentApplicationID == ID).FirstOrDefault();
            return abs;
        }
        [Route("GetAbsentApplicationByEmployeeID")]
        [HttpGet]
        public object GetEmployeeByID(int EmployeeID)
        {
            var obj = db.AbsentApplications.Where(x => x.EmployeeID == EmployeeID).ToList();
            return obj;
        }
        [Route("DeleteAbsentApplication")]
        [HttpDelete]
        public object DeleteAbsentApplication(int ID)
        {
            var obj = db.AbsentApplications.Where(x => x.AbsentApplicationID == ID).FirstOrDefault();
            db.AbsentApplications.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Deduction Employees ------------------------------ //
        [Route("AddOrEditDeductionEmployees")]
        [HttpPost]
        public object AddOrEditDeductionEmployees(DeductionEmployee1 deductionemployee1)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.DeductionEmployees.Where(x => x.DeductionEmployeeID == deductionemployee1.DeductionEmployeeID).FirstOrDefault();
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
                        Status = "Updated",
                        Message = "Updated Successfully"
                    };
                }
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }
        
        [Route("GetAllDeductionEmployee")]
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
                       }
                           ).ToList();
            return abs;
        }
        [Route("GetDeductionEmployeeByID")]
        [HttpGet]
        public object GetDeductionEmployeeByID(int ID)
        {
            var ded = db.DeductionEmployees.Where(x => x.DeductionEmployeeID == ID).FirstOrDefault();
            return ded;
        }
        [Route("DeleteDeductionEmployee")]
        [HttpDelete]
        public object DeleteDeductionEmployee(int ID)
        {
            var obj = db.DeductionEmployees.Where(x => x.DeductionEmployeeID == ID).FirstOrDefault();
            db.DeductionEmployees.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Regulation Employees ------------------------------ //
        [Route("AddOrEditRegulationEmployees")]
        [HttpPost]
        public object AddOrEditRegulationEmployees(RegulationEmployee1 Regulationemployee1)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.RegulationEmployees.Where(x => x.RegulationEmployeeID == Regulationemployee1.RegulationEmployeeID).FirstOrDefault();
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
                        Status = "Updated",
                        Message = "Updated Successfully"
                    };
                }
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }

        [Route("GetAllRegulationEmployee")]
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
        [Route("GetRegulationEmployeeByID")]
        [HttpGet]
        public object GetRegulationEmployeeByID(int ID)
        {
            var ded = db.RegulationEmployees.Where(x => x.RegulationEmployeeID == ID).FirstOrDefault();
            return ded;
        }
        [Route("DeleteRegulationEmployee")]
        [HttpDelete]
        public object DeleteRegulationEmployee(int ID)
        {
            var obj = db.RegulationEmployees.Where(x => x.RegulationEmployeeID == ID).FirstOrDefault();
            db.RegulationEmployees.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Laudatory Employees ------------------------------ //
        [Route("AddOrEditLaudatoryEmployees")]
        [HttpPost]
        public object AddOrEditLaudatoryEmployees(LaudatoryEmployee1 Laudatoryemployee1)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.LaudatoryEmployees.Where(x => x.LaudatoryEmployeeID == Laudatoryemployee1.LaudatoryEmployeeID).FirstOrDefault();
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
                        Status = "Updated",
                        Message = "Updated Successfully"
                    };
                }
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }

        [Route("GetAllLaudatoryEmployee")]
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
        [Route("GetLaudatoryEmployeeByID")]
        [HttpGet]
        public object GetLaudatoryEmployeeByID(int ID)
        {
            var ded = db.LaudatoryEmployees.Where(x => x.LaudatoryEmployeeID == ID).FirstOrDefault();
            return ded;
        }
        [Route("DeleteLaudatoryEmployee")]
        [HttpDelete]
        public object DeleteLaudatoryEmployee(int ID)
        {
            var obj = db.LaudatoryEmployees.Where(x => x.LaudatoryEmployeeID == ID).FirstOrDefault();
            db.LaudatoryEmployees.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Advances ------------------------------ //
        [Route("AddOrEditAdvances")]
        [HttpPost]
        public object AddOrEditAdvances(Advance1 adv)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.Advances.Where(x => x.AdvanceID == adv.AdvanceID).FirstOrDefault();
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
                        Status = "Updated",
                        Message = "Updated Successfully"
                    };
                }
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }

        [Route("GetAllAdvances")]
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
        [Route("GetAdvanceByID")]
        [HttpGet]
        public object GetAdvanceByID(int ID)
        {
            var ded = db.Advances.Where(x => x.AdvanceID == ID).FirstOrDefault();
            return ded;
        }
        [Route("DeleteAdvance")]
        [HttpDelete]
        public object DeleteAdvance(int ID)
        {
            var obj = db.Advances.Where(x => x.AdvanceID == ID).FirstOrDefault();
            db.Advances.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }
}
