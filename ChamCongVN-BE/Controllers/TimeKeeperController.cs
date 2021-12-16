using ChamCongVN_BE.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ChamCongVN_BE.Controllers
{
    [RoutePrefix("TimeKeeper")]
    public class TimeKeeperController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        public DateTime dateTime = DateTime.Now;

        [Route("CheckIn")]
        [HttpGet]
        public object GetAllCheckIn()
        {
            var obj = db.CheckIns.ToList();
            return obj;
        }
        [Route("CheckIn")]
        [HttpPost]
        public object AddCheckIn(TimeKeeper checkin1)
        {
            if (checkin1.ID == 0)
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
                    Status = 200,
                    Message = "Data Success"
                };
            }
            return new Response
            {
                Status = 500,
                Message = "Data Not Insert"
            };

        }
        [Route("CheckOut")]
        [HttpGet]
        public object GetAllCheckOut()
        {
            var obj = db.CheckOuts.ToList();
            return obj;
        }
        [Route("CheckOut")]
        [HttpPost]
        public object AddCheckOut(TimeKeeper check)
        {
            if (check.ID == 0)
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
                    Status = 200,
                    Message = "Data Success"
                };
            }
            return new Response
            {
                Status = 500,
                Message = "Data Not Insert"
            };

        }

        [Route("TimeKeeping/{id?}")]
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
        [Route("TimeKeeping")]
        [HttpGet]
        public object GetAllTimeKeeping()
        {
            var obj = (from res in db.GetAllTimeKeepings
                       select new
                       {
                           res.EmployeeName,
                           res.EmployeeID,
                           res.Department,
                           res.CheckInImage,
                           res.CheckOutImage,
                           res.CheckInCreatedAt,
                           res.CheckOutCreatedAt,
                           res.CheckOutStatus,
                           res.CheckInStatus
                       }).ToList();
            return obj;
        }

        [Route("CheckIn/{id?}")]
        [HttpGet]
        public object GetCheckInByEmployeeID(int EmployeeID)
        {
            var ci = db.CheckIns.Where(x => x.EmployeeID == EmployeeID).ToList();
            return ci;
        }
        [Route("CheckOut/{id?}")]
        [HttpGet]
        public object GetCheckOutByEmployeeID(int EmployeeID)
        {
            var ci = db.CheckOuts.Where(x => x.EmployeeID == EmployeeID).ToList();
            return ci;
        }
        // ------------------------------ Handle ci To Python ------------------------------ //

        [Route("HandleSendToPython")]
        [HttpPost]
        public async System.Threading.Tasks.Task<object> HandleciToPythonAsync(TimeKeeper ci)
        {
            var objOrganizations = db.Organizations.FirstOrDefault();
            var hour = dateTime.Hour;
            var minute = dateTime.Minute;
            var objOvertime = db.OverTimes.ToList();
            var checkTime = objOvertime.Where(x => x.StartTime <= dateTime.TimeOfDay && x.EndTime >= dateTime.TimeOfDay).FirstOrDefault();
            string apiPython = objOrganizations.PythonIP + "nhandienkhuonmat";
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
                            {
                                new StringContent(ci.Image), "base64"
                            }
                        };
                        var response = await client.PostAsync(apiPython, form);
                        var success = response.IsSuccessStatusCode;
                        if (success)
                        {
                            var responsebody = await response.Content.ReadAsStringAsync();
                            var obj = JObject.Parse(responsebody);
                            var objResult = obj["name"].ToString();
                            var objResult1 = obj["name"].ToString();
                            if (responsebody != null)
                            {
                                var empID = Convert.ToInt32(objResult.Substring(0, 1));
                                ci.EmployeeID = empID;
                                var haveItCheckIn = db.CheckIns.Where(x => x.EmployeeID == empID).ToList();
                                var haveItCheckOut = db.CheckOuts.Where(x => x.EmployeeID == empID).ToList();
                                var checkIn = haveItCheckIn.Where(x => ((DateTime)x.CreatedAt).ToString("yyyy-MM-dd") == dateTime.Date.ToString("yyyy-MM-dd")).FirstOrDefault(); // Kiểm tra đã check in hay chưa
                                var checkOut = haveItCheckOut.Where(x => ((DateTime)x.CreatedAt).ToString("yyyy-MM-dd") == dateTime.Date.ToString("yyyy-MM-dd")).FirstOrDefault(); // Kiểm tra đã check in hay chưa

                                if (hour >= 8 && hour < 12)
                                {
                                    if (checkIn == null)
                                    {
                                        if (hour >= 8 && minute >= 15)
                                        {
                                            ci.Status = "Đi muộn";
                                            AddCheckIn(ci);
                                        }
                                        else
                                        {
                                            ci.Status = "Đúng giờ";
                                            AddCheckIn(ci);
                                        }
                                    }
                                    else
                                    {
                                        return new Response
                                        {
                                            Status = 403,
                                            Message = "Bạn đã check in hôm nay rồi"
                                        };
                                    }
                                }
                                else if (hour >= 13 && hour <= 19)
                                {
                                    if (checkOut == null)
                                    {
                                        if (hour < 17)
                                        {
                                            ci.Status = "Về sớm";
                                            AddCheckOut(ci);
                                        }
                                        else
                                        {
                                            ci.Status = "Đúng giờ";
                                            AddCheckOut(ci);
                                        }
                                    }
                                    else
                                    {
                                        return new Response
                                        {
                                            Status = 403,
                                            Message = "Bạn đã check out hôm nay rồi"
                                        };
                                    }
                                }
                                /*
                                else if(dateTime.TimeOfDay >= checkTime.StartTime && minute <= 30)
                                {
                                    if(minute <= 15)
                                    {
                                        ci.Status = "Đúng giờ";
                                        AddCheckIn(ci);
                                    }
                                    else
                                    {
                                        ci.Status = "Đi muộn";
                                        AddCheckIn(ci);
                                    }
                                }
                                else if(dateTime.TimeOfDay >= checkTime.EndTime && minute > 30)
                                {
                                    if(minute <= 15)
                                    {
                                        ci.Status = "Đúng giờ";
                                        AddCheckIn(ci);
                                    }
                                    else
                                    {
                                        ci.Status = "Đi muộn";
                                        AddCheckIn(ci);
                                    }
                                }*/
                            }
                            else
                            {
                                return responsebody;
                            }

                        }
                        return response;
                    }
                }
                catch (Exception err)
                {
                    return err;
                }
            }
            else if (radius > 50)
            {
                return new Response
                {
                    Status = 403,
                    Message = "Vui lòng vào đúng phạm vi công ty"
                };
            }
            else if (IPOrganiztion != publicIPRequest)
            {
                return new Response
                {
                    Status = 403,
                    Message = "Vui lòng vào mạng công ty"
                };
            }
            else
            {
                return new Response
                {
                    Status = 403,
                    Message = "Access Deined"
                };
            }
        }

        [Route("CheckIn/checked")]
        [HttpGet]
        public object GetCountCheckedIn()
        {
            var ci = db.GetCountCheckedIns.ToList();
            return ci;
        }
        [Route("CheckIn/unchecked")]
        [HttpGet]
        public object GetCountHaventCheckedIn()
        {
            var ci = db.GetCountHaventCheckedIns.ToList();
            return ci;
        }
        [Route("CheckIn/late")]
        [HttpGet]
        public object GetCountLate()
        {
            var ci = db.GetCountLates.ToList();
            return ci;
        }

    }
}