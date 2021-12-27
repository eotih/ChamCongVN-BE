using ChamCongVN_BE.Models;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ChamCongVN_BE.Controllers
{
    [RoutePrefix("Salary")]
    public class SalaryController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        // ------------------------------ Salary Table ------------------------------ //
        public DateTime dateTime = DateTime.Now;
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
                    SalaryPerHour = st1.SalaryPerHour,
                    OTCoefficient = st1.OTCoefficient,
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
                    obj.SalaryPerHour = st1.SalaryPerHour;
                    obj.OTCoefficient = st1.OTCoefficient;
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
        //----------Quyền admin mới chạy -------------------//
        [Route("TotalSalary/{year?}/{month?}")]
        [HttpGet]
        public object TotalSalaryPerMonthYear(int month, int year)
        {
            var total = db.TotalSalaryOfEmployees.Where(x => x.Month == month && x.Year == year).ToList();
            return total;
        }
        [Route("TotalSalary/{year?}")]
        [HttpGet]
        public object TotalSalaryPerYear(int year)
        {
            var total = db.TotalSalaryOfEmployees.Where(x =>x.Year == year).ToList();
            return total;
        }
        [Route("TotalSalary")]
        [HttpGet]
        public object TotalSalary()
        {
            var total = db.TotalSalaryOfEmployees.Where(x=>x.Month == (dateTime.Month -1) && x.Year== (dateTime.Year)).ToList();
            return total;
        }
        //
        [Route("TotalSalaryPerMonths")]
        [HttpPost]
        public object TotalSalaryPerMonths()
        {
            try
            {
                #region Variable Declaration  
                HttpResponseMessage ResponseMessage = null;
                var httpRequest = HttpContext.Current.Request;
                DataSet dsexcelRecords = new DataSet();
                IExcelDataReader reader = null;
                HttpPostedFile Inputfile = null;
                Stream FileStream = null;
                #endregion

                #region Save Student Detail From Excel  
                using (ChamCongVNEntities db = new ChamCongVNEntities())
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        Inputfile = httpRequest.Files[0];
                        FileStream = Inputfile.InputStream;

                        if (Inputfile != null && FileStream != null)
                        {
                            if (Inputfile.FileName.EndsWith(".xls"))
                                reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                            else if (Inputfile.FileName.EndsWith(".xlsx"))
                                reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
                            else
                                return new Response
                                {
                                    Status = 500,
                                    Message = "No file"
                                };
                            dsexcelRecords = reader.AsDataSet();
                            reader.Close();

                            if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                            {
                                DataTable dtStudentRecords = dsexcelRecords.Tables[0];
                                for (int i = 1; i < dtStudentRecords.Rows.Count; i++)
                                {
                                    TotalSalaryPerMonth total = new TotalSalaryPerMonth();
                                    total.EmployeeID = Convert.ToInt16(dtStudentRecords.Rows[i][1]);
                                    total.FullName = Convert.ToString(dtStudentRecords.Rows[i][2]);
                                    total.Month = Convert.ToInt16(dtStudentRecords.Rows[i][3]);
                                    total.Year = Convert.ToInt16(dtStudentRecords.Rows[i][4]);
                                    total.TotalTime = Convert.ToInt16(dtStudentRecords.Rows[i][5]);
                                    total.Salary = Convert.ToDouble(dtStudentRecords.Rows[i][6]);
                                    total.TotalAdvance = Convert.ToDouble(dtStudentRecords.Rows[i][7]);
                                    total.TotalDeduction = Convert.ToDouble(dtStudentRecords.Rows[i][8]);
                                    total.TotalLaudatory = Convert.ToDouble(dtStudentRecords.Rows[i][9]);
                                    total.TotalOvertime = Convert.ToInt16(dtStudentRecords.Rows[i][10]);
                                    total.TotalOvertimeSalary = Convert.ToDouble(dtStudentRecords.Rows[i][11]);
                                    total.TotalSalary = Convert.ToDouble(dtStudentRecords.Rows[i][12]);
                                    db.TotalSalaryPerMonths.Add(total);
                                }

                                int output = db.SaveChanges();
                                if (output > 0)
                                    return new Response
                                    {
                                        Status = 200,
                                        Message = "Data Success"
                                    };
                                else
                                    return new Response
                                    {
                                        Status = 500,
                                        Message = "Data not insert"
                                    };
                            }
                            else
                                return new Response
                                {
                                    Status = 404,
                                    Message = "File is emty"
                                };
                        }
                        else
                            return new Response
                            {
                                Status = 404,
                                Message = "Invalid File"
                            };
                    }
                    else
                        ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                return null;
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Route("TotalSalaryPerMonth/{id?}")]
        [HttpGet]
        public object TotalSalaryPerMonthYear(int id)
        {
            var total = db.TotalSalaryPerMonths.Where(x => x.EmployeeID == id).ToList();
            return total;
        }
        [Route("TotalSalaryPerMonth")]
        [HttpGet]
        public object TotalSalaryPerMonth()
        {
            var total = (from obj in db.TotalSalaryPerMonths
                         from emp in db.Employees
                         where obj.EmployeeID == emp.EmployeeID
                         select new {
                             TotalSalary = obj,
                             emp.Image,
                         }).ToList();
            return total;
        }
    }
}
