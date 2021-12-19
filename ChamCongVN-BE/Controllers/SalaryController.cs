using ChamCongVN_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamCongVN_BE.Controllers
{
    [RoutePrefix("Salary")]
    public class SalaryController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        // ------------------------------ Salary Table ------------------------------ //
        [Route("SalaryTable")]
        [HttpPost]
        public object AddSalaryTable(SalaryTable1 st1)
        {
            if (st1.SalaryTableID == 0)
            {
                SalaryTable salarytable = new SalaryTable
                {
                    SalaryTableName = st1.SalaryTableName,
                    Month = st1.Month,
                    Year = st1.Year,
                    MinSalary = st1.MinSalary,
                    TotalTimeRegulation = st1.TotalTimeRegulation,
                    CreatedBy = st1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.SalaryTables.Add(salarytable);
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
        [Route("SalaryTable/{id?}")]
        [HttpPut]
        public object EditSalaryTable(SalaryTable1 st1)
        {
            {
                int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
                var obj = db.SalaryTables.Where(x => x.SalaryTableID == id).FirstOrDefault();
                if (obj.SalaryTableID > 0)
                {
                    obj.SalaryTableName = st1.SalaryTableName;
                    obj.Month = st1.Month;
                    obj.Year = st1.Year;
                    obj.MinSalary = st1.MinSalary;
                    obj.TotalTimeRegulation = st1.TotalTimeRegulation;
                    obj.UpdatedBy = st1.UpdatedBy;
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
        [Route("SalaryTable")]
        [HttpGet]
        public object GetAllSalaryTable()
        {
            var salarytable = db.SalaryTables.ToList();
            return salarytable;
        }
        [Route("SalaryTable/{id?}")]
        [HttpGet]
        public object GetSalaryTableByID(int ID)
        {
            var salarytable = db.SalaryTables.Where(x => x.SalaryTableID == ID).FirstOrDefault();
            return salarytable;
        }
        [Route("SalaryTable/{id?}")]
        [HttpDelete]
        public object DeleteSalaryTable(int ID)
        {
            var obj = db.SalaryTables.Where(x => x.SalaryTableID == ID).FirstOrDefault();
            db.SalaryTables.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Overtime Salary ------------------------------ //
        [Route("OvertimeSalary")]
        [HttpPost]
        public object AddOvertimeSalary(OvertimeSalary1 ot1)
        {
            if (ot1.OvertimeSalaryID == 0)
            {
                OvertimeSalary overtimesalary = new OvertimeSalary
                {
                    EmployeeID = ot1.EmployeeID,
                    OvertimeSalaryName = ot1.OvertimeSalaryName,
                    Time = ot1.Time,
                    OvertimeType = ot1.OvertimeType,
                    CreatedBy = ot1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.OvertimeSalaries.Add(overtimesalary);
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
        [Route("OvertimeSalary/{id?}")]
        [HttpPut]
        public object EditOvertimeSalary(OvertimeSalary1 ot1)
        {
            {
                int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
                var obj = db.OvertimeSalaries.Where(x => x.OvertimeSalaryID == id).FirstOrDefault();
                if (obj.OvertimeSalaryID > 0)
                {
                    obj.EmployeeID = ot1.EmployeeID;
                    obj.OvertimeSalaryName = ot1.OvertimeSalaryName;
                    obj.Time = ot1.Time;
                    obj.OvertimeType = ot1.OvertimeType;
                    obj.UpdatedBy = ot1.UpdatedBy;
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
        [Route("OvertimeSalary")]
        [HttpGet]
        public object GetAllOvertimeSalary()
        {
            var ot = (from overtime in db.OvertimeSalaries
                       from emp in db.Employees
                       where overtime.EmployeeID == emp.EmployeeID
                       select new
                       {
                           OvertimeSalary = overtime,
                           Employee = emp
                       }
                           ).ToList();
            return ot;
        }
        [Route("OvertimeSalary/{id?}")]
        [HttpGet]
        public object GetOvertimeSalaryByID(int ID)
        {
            var ot = db.OvertimeSalaries.Where(x => x.OvertimeSalaryID == ID).FirstOrDefault();
            return ot;
        }
        [Route("OvertimeSalary/{id?}")]
        [HttpDelete]
        public object DeleteOvertimeSalary(int ID)
        {
            var obj = db.OvertimeSalaries.Where(x => x.OvertimeSalaryID == ID).FirstOrDefault();
            db.OvertimeSalaries.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Deduction Employee ------------------------------ //
        [Route("DeductionEmployee")]
        [HttpPost]
        public object AddDeductionEmployee(DeductionEmployee1 de1)
        {
            if (de1.DeductionEmployeeID == 0)
            {
                DeductionEmployee DeductionEmployee = new DeductionEmployee
                {
                    EmployeeID = de1.EmployeeID,
                    DeductionName = de1.DeductionName,
                    DeductionDate = de1.DeductionDate,
                    Reason = de1.Reason,
                    Amount = de1.Amount,
                    CreatedBy = de1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.DeductionEmployees.Add(DeductionEmployee);
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
        [Route("DeductionEmployee/{id?}")]
        [HttpPut]
        public object EditDeductionEmployee(DeductionEmployee1 de1)
        {
            {
                int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
                var obj = db.DeductionEmployees.Where(x => x.DeductionEmployeeID == id).FirstOrDefault();
                if (obj.DeductionEmployeeID > 0)
                {
                    obj.EmployeeID = de1.EmployeeID;
                    obj.DeductionName = de1.DeductionName;
                    obj.DeductionDate = de1.DeductionDate;
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
        [Route("DeductionEmployee")]
        [HttpGet]
        public object GetAllDeductionEmployee()
        {
            var ot = (from deduc in db.DeductionEmployees
                      from emp in db.Employees
                      where deduc.EmployeeID == emp.EmployeeID
                      select new
                      {
                          DeductionEmployee = deduc,
                          Employee = emp,
                          emp.FullName,
                          emp.EmployeeID,
                          emp.Image
                      }
                           ).ToList();
            return ot;
        }
        [Route("DeductionEmployee/{id?}")]
        [HttpGet]
        public object GetDeductionEmployeeByID(int ID)
        {
            var ot = db.DeductionEmployees.Where(x => x.DeductionEmployeeID == ID).FirstOrDefault();
            return ot;
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
                    SignDate = DateTime.Now
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
                obj.Reason = adv.Reason;
                obj.Amount = adv.Amount;
                obj.UpdatedAt = DateTime.Now;
                obj.UpdatedBy = adv.UpdatedBy;
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

        [Route("Advances")]
        [HttpGet]
        public object GetAllAdvances()
        {
            var abs = (from adv in db.Advances
                       from emp in db.Employees
                       where adv.EmployeeID == emp.EmployeeID
                       select new
                       {
                           Advance = adv,
                           Employee = emp,
                           emp.EmployeeID,
                           emp.FullName,
                           emp.Image
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
