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
        [Route("AddOrEditSalaryTable")]
        [HttpPost]
        public object AddOrEditSalaryTable(SalaryTable1 st1)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.SalaryTables.Where(x => x.SalaryTableID == st1.SalaryTableID).FirstOrDefault();
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
        [Route("GetAllSalaryTable")]
        [HttpGet]
        public object GetAllSalaryTable()
        {
            var salarytable = db.SalaryTables.ToList();
            return salarytable;
        }
        [Route("GetSalaryTableByID")]
        [HttpGet]
        public object GetSalaryTableByID(int ID)
        {
            var salarytable = db.SalaryTables.Where(x => x.SalaryTableID == ID).FirstOrDefault();
            return salarytable;
        }
        [Route("DeleteSalaryTable")]
        [HttpDelete]
        public object DeleteSalaryTable(int ID)
        {
            var obj = db.SalaryTables.Where(x => x.SalaryTableID == ID).FirstOrDefault();
            db.SalaryTables.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Overtime Salary ------------------------------ //
        [Route("AddOrEditOvertimeSalary")]
        [HttpPost]
        public object AddOrEditOvertimeSalary(OvertimeSalary1 ot1)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.OvertimeSalaries.Where(x => x.OvertimeSalaryID == ot1.OvertimeSalaryID).FirstOrDefault();
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
        [Route("GetAllOvertimeSalary")]
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
        [Route("GetOvertimeSalaryByID")]
        [HttpGet]
        public object GetOvertimeSalaryByID(int ID)
        {
            var ot = db.OvertimeSalaries.Where(x => x.OvertimeSalaryID == ID).FirstOrDefault();
            return ot;
        }
        [Route("DeleteOvertimeSalary")]
        [HttpDelete]
        public object DeleteOvertimeSalary(int ID)
        {
            var obj = db.OvertimeSalaries.Where(x => x.OvertimeSalaryID == ID).FirstOrDefault();
            db.OvertimeSalaries.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }
}
