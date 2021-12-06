using ChamCongVN_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ChamCongVN_BE.Controllers
{
    public class TimeKeeperController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        [Route("GetAllCheckIn")]
        [HttpGet]
        public object GetAllCheckIn()
        {
            var obj = db.CheckIns.ToList();
            return obj;
        }
        [Route("AddCheckIn")]
        [HttpPost]
        public object AddCheckIn(CheckIn1 checkin1)
        {
            if (checkin1.CheckInCode == 0)
            {
                CheckIn checkin = new CheckIn
                {
                    EmployeeID = checkin1.EmployeeID,
                    Image = checkin1.Image,
                    Status = checkin1.Status,
                    Device = checkin1.Device,
                    Latitude = checkin1.Latitude,
                    Longitude = checkin1.Longitude,
                    CreatedAt = DateTime.Now
                };
                db.CheckIns.Add(checkin);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }
        [Route("GetAllCheckOut")]
        [HttpGet]
        public object GetAllCheckOut()
        {
            var obj = db.CheckOuts.ToList();
            return obj;
        }
        [Route("AddCheckOut")]
        [HttpPost]
        public object AddCheckOut(CheckOut1 check)
        {
            if (check.CheckOutCode == 0)
            {
                CheckOut checkout = new CheckOut
                {
                    EmployeeID = check.EmployeeID,
                    Image = check.Image,
                    Status = check.Status,
                    Device = check.Device,
                    Latitude = check.Latitude,
                    Longitude = check.Longitude,
                    CreatedAt = DateTime.Now
                };
                db.CheckOuts.Add(checkout);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }
        [Route("GetAllTimeKeepingByEmployeeID")]
        [HttpGet]
        public object GetAllTimeKeepingByEmployeeID(int EmployeeID)
        {
            var empIn = db.CheckIns.Where(x => x.EmployeeID == EmployeeID).ToList();
            var empOut = db.CheckOuts.Where(x => x.EmployeeID == EmployeeID).ToList();
            var obj = (from ci in empIn
                       from co in empOut
                       where ci.EmployeeID == co.EmployeeID
                       select new
                       {
                           checkin = ci,
                           checkout = co
                       }).ToList();
            return obj;
        }
        [Route("GetAllTimeKeeping")]
        [HttpGet]
        public object GetAllTimeKeeping()
        {
            var obj = (from ci in db.CheckIns
                       from co in db.CheckOuts
                       from emp in db.Employees
                       from dep in db.Departments
                       where emp.DepartmentID == dep.DepartmentID
                       where ci.EmployeeID == co.EmployeeID
                       where emp.EmployeeID == co.EmployeeID
                       where emp.EmployeeID == ci.EmployeeID
                       select new
                       {
                           EmployeeName = emp.FullName,
                           Department = dep.DepartmentName,
                           checkin = ci,
                           checkout = co
                       }).ToList();
            return obj;
        }
        [Route("GetCheckInByEmployeeID")]
        [HttpGet]
        public object GetCheckInByEmployeeID(int EmployeeID)
        {
            var ci = db.CheckIns.Where(x => x.EmployeeID == EmployeeID).ToList();
            return ci;
        }
        [Route("GetCheckOutByEmployeeID")]
        [HttpGet]
        public object GetCheckOutByEmployeeID(int EmployeeID)
        {
            var ci = db.CheckOuts.Where(x => x.EmployeeID == EmployeeID).ToList();
            return ci;
        }
        // ------------------------------ Handle ci To Python ------------------------------ //

        [Route("HandleciToPython")]
        [HttpPost]
        public async System.Threading.Tasks.Task<object> HandleciToPythonAsync(CheckIn1 ci)
        {
            string apiPython = "http://192.168.1.8:6868/nhandienkhuonmat";
            var objOrganizations = db.Organizations.FirstOrDefault();

            string IPOrganiztion = objOrganizations.PublicIP;
            string publicIPRequest = ci.PublicIP;

            double latOrganiztion = Convert.ToDouble(objOrganizations.Latitude);
            double longOrganiztion = Convert.ToDouble(objOrganizations.Longitude);
            double latRequest = Convert.ToDouble(ci.Latitude);
            double longRequest = Convert.ToDouble(ci.Longitude);

            double radius = Utilities.Radius(latOrganiztion, longOrganiztion, latRequest, longRequest);

            if (IPOrganiztion == publicIPRequest && radius < 50)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiPython);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                        MultipartFormDataContent form = new MultipartFormDataContent
                    {
                        { new StringContent(ci.Image), "facebase64" }
                    };
                        var response = await client.PostAsync(apiPython, form);
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            // Get data from response and check if Name != "Unknown" add to database
                            if (result != "Unknown")
                            {
                                CheckIn checkin = new CheckIn
                                {
                                    EmployeeID = ci.EmployeeID,
                                    Image = ci.Image,
                                    Status = ci.Status,
                                    Device = ci.Device,
                                    Latitude = ci.Latitude,
                                    Longitude = ci.Longitude,
                                    CreatedAt = DateTime.Now
                                };
                                db.CheckIns.Add(checkin);
                                db.SaveChanges();
                                return new Response
                                {
                                    Status = "Success",
                                    Message = "Data Success"
                                };
                            }
                            else
                            {
                                return new Response
                                {
                                    Status = "Error",
                                    Message = "Data not insert"
                                };
                            }
                        }
                        return response;
                    }
                }
                catch
                {
                    return null;
                }
            }
            else if (radius > 50)
            {
                return new Response
                {
                    Status = "403",
                    Message = "Vui lòng vào đúng phạm vi công ty"
                };
            }
            else if (IPOrganiztion != publicIPRequest)
            {
                return new Response
                {
                    Status = "403",
                    Message = "Vui lòng vào mạng công ty"
                };
            }
            else
            {
                return new Response
                {
                    Status = "403",
                    Message = "Access Deined"
                };
            }
        }
    }
}