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
        [Route("GetAllEmployee")]
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
        [Route("GetEmployeeByID")]
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
        // ------------------------------ Recruitments ------------------------------ //

        [Route("GetAllRecruitment")]
        [HttpGet]
        public object GetAllRecruitment()
        {
            var Recruitment = db.Recruitments.ToList();
            return Recruitment;
        }

        [Route("GetRecruitmentByID")]
        [HttpGet]
        public object GetRecruitmentByID(int ID)
        {
            var obj = db.Recruitments.Where(x => x.RecruitmentID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteRecruitment")]
        [HttpDelete]
        public object DeleteRecruitment(int ID)
        {
            var obj = db.Recruitments.Where(x => x.RecruitmentID == ID).FirstOrDefault();
            db.Recruitments.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        [Route("UploadListRecruitment")]
        [HttpPost]
        public string ReadFile()
        {
            try
            {
                #region Variable Declaration  
                string message = "";
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
                                message = "The file format is not supported.";

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
                                    message = "The Excel file has been successfully uploaded.";
                                else
                                    message = "Something Went Wrong!, The Excel file uploaded has fiald.";
                            }
                            else
                                message = "Selected file is empty.";
                        }
                        else
                            message = "Invalid File.";
                    }
                    else
                        ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                return message;
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }
        }
}
