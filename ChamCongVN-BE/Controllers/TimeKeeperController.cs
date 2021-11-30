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
        // ------------------------------ Handle ci To Python ------------------------------ //
        [Route("CheckLocation")]
        [HttpGet]
        public object AddCheckIn(double latitude, double longtitude)
        {
            double a = 10.797407401664431;
            double b = 106.70355907451703;
            double radius = Utilities.Radius(a, b, latitude, longtitude);
            if (radius < 50)
            {
                return new Response
                {
                    Status = "OK",
                    Message = "Valid location"
                };
            }
            else
            {
                return new Response
                {
                    Status = "Fail",
                    Message = "Invalid location"
                };
            }
        }
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
