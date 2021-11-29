using ChamCongVN_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                    Longtitude = checkin1.Longtitude,
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
        // ------------------------------ Handle Send To Python ------------------------------ //
        [Route("HandleSendToPython")]
        [HttpGet]
        public object HandleSendToPython(SendToPython send)
        {
            var PublicIP = Utilities.GetIPAddress();
            if (PublicIP == send.PublicIP)
            {
                // Call API Python Overhere
                return new Response
                {
                    Status = "Succees",
                    Message = "Call Successfuly"
                };
            }
            else
            {
                return new Response
                {
                    Status = "403",
                    Message = "Access Denied"
                };
            }
        }
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
    }
}
