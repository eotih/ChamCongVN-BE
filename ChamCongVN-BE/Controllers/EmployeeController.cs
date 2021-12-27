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
    [RoutePrefix("Employee")]
    public class EmployeeController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        [Route("Employee")]
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
        [Route("Employee/{id?}")]
        [HttpGet]
        public object GetEmployeeByID(int ID)
        {
            var res = db.Employees.Where(x => x.EmployeeID == ID).ToList();
            var result = (from emp in res
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
                              Employee = emp,
                              ListDegree = db.DegreesOfEmployees.Where(x => x.EmployeeID == emp.EmployeeID).ToList(),
                              ListSpeciality = db.SpecialityOfEmployees.Where(x => x.EmployeeID == emp.EmployeeID).ToList(),
                              work.WorkName,
                              gr.GroupName,
                              position.PositionName,
                              department.DepartmentName
                          }).FirstOrDefault();
            return result;
        }
        [Route("Employee")]
        [HttpPost]
        public object AddEmployee(Employee1 emp1)
        {
            if (emp1.EmployeeID == 0)
            {
                Employee emp = new Employee
                {
                    GroupID = emp1.GroupID,
                    PositionID = emp1.PositionID,
                    DepartmentID = emp1.DepartmentID,
                    WorkID = emp1.WorkID,
                    SalaryTableID = emp1.SalaryTableID,
                    FullName = emp1.FullName,
                    NickName = emp1.NickName,
                    Gender = emp1.Gender,
                    Image = emp1.Image,
                    DateOfBirth = emp1.DateOfBirth,
                    PlaceOfBirth = emp1.PlaceOfBirth,
                    Address = emp1.Address,
                    TemporaryAddress = emp1.TemporaryAddress,
                    Phone = emp1.Phone,
                    IdentityCard = emp1.IdentityCard,
                    DateRange = emp1.DateRange,
                    IssuedBy = emp1.IssuedBy,
                    StartDate = emp1.StartDate,
                    Health = emp1.Health,
                    SocialInsurance = emp1.SocialInsurance,
                    HealthInsurance = emp1.HealthInsurance,
                    UnemploymentInsurance = emp1.UnemploymentInsurance,
                    PaidLeave = true,
                    CreatedBy = emp1.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.Employees.Add(emp);
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
        [Route("Employee/{id?}/Manager")]
        [HttpPut]
        public object EditEmployeeForManager(Employee1 emp1)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            if (obj.EmployeeID > 0)
            {
                    obj.GroupID = emp1.GroupID;
                    obj.PositionID = emp1.PositionID;
                    obj.DepartmentID = emp1.DepartmentID;
                    obj.WorkID = emp1.WorkID;
                    obj.SalaryTableID = emp1.SalaryTableID;
                    obj.UpdatedBy = emp1.UpdatedBy;
                    obj.UpdatedAt = DateTime.Now;
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
                Message = "Data not updated"
            };
        }
        [Route("Employee/{id?}")]
        [HttpPut]
        public object EditEmployeeForEmployee(Employee1 emp1)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            if (obj.EmployeeID > 0)
            {
                    obj.Image = emp1.Image;
                    obj.TemporaryAddress = emp1.TemporaryAddress;
                    obj.Phone = emp1.Phone;
                    obj.UpdatedBy = emp1.UpdatedBy;
                    obj.UpdatedAt = DateTime.Now;
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
                Message = "Data not updated"
            };
        }
        [Route("Employee/{id?}/PaidLeave")]
        [HttpPut]
        public object EditPaidLeaveForEmployee(Employee1 emp1)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            if (obj.EmployeeID > 0)
            {
                obj.PaidLeave = true;
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
                Message = "Data not updated"
            };
        }
        [Route("Employee/{id?}")]
        [HttpDelete]
        public object DeleteEmployee(int ID)
        {
            var obj = db.Employees.Where(x => x.EmployeeID == ID).FirstOrDefault();
            db.Employees.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Recruitments ------------------------------ //

        [Route("Recruitment")]
        [HttpGet]
        public object GetAllRecruitment()
        {
            var Recruitment = db.Recruitments.ToList();
            return Recruitment;
        }

        [Route("Recruitment/{id?}")]
        [HttpGet]
        public object GetRecruitmentByID(int ID)
        {
            var obj = db.Recruitments.Where(x => x.RecruitmentID == ID).FirstOrDefault();
            return obj;
        }

        [Route("Recruitment/{id?}")]
        [HttpDelete]
        public object DeleteRecruitment(int ID)
        {
            var obj = db.Recruitments.Where(x => x.RecruitmentID == ID).FirstOrDefault();
            db.Recruitments.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }
        [Route("Recruitment")]
        [HttpPost]
        public object AddRecruitment()
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
                                    Recruitment objStudent = new Recruitment();
                                    objStudent.FullName = Convert.ToString(dtStudentRecords.Rows[i][1]);
                                    objStudent.Gender = Convert.ToString(dtStudentRecords.Rows[i][2]);
                                    objStudent.DateOfBirth = Convert.ToDateTime(dtStudentRecords.Rows[i][3]);
                                    objStudent.Address = Convert.ToString(dtStudentRecords.Rows[i][4]);
                                    objStudent.TemporaryAddress = Convert.ToString(dtStudentRecords.Rows[i][5]);
                                    objStudent.Phone = Convert.ToString(dtStudentRecords.Rows[i][6]);
                                    objStudent.Email = Convert.ToString(dtStudentRecords.Rows[i][7]);
                                    objStudent.ApplyFor = Convert.ToString(dtStudentRecords.Rows[i][8]);
                                    objStudent.LinkCV = Convert.ToString(dtStudentRecords.Rows[i][9]);
                                    objStudent.CreatedAt = DateTime.Now;
                                    db.Recruitments.Add(objStudent);
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
    }
}
