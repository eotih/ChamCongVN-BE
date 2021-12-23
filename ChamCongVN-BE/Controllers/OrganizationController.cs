using ChamCongVN_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamCongVN_BE.Controllers
{
    [RoutePrefix("Organization")]
    public class OrganizationController : ApiController
    {
        // Khai báo database
        ChamCongVNEntities db = new ChamCongVNEntities();

        // ------------------------------ Accounts ------------------------------ //
        [Route("Account")]
        [HttpPost]
        public object AddAccount(Account1 account)
        {
            if (account.AccountID == 0)
            {
                Account acc = new Account
                {
                    EmployeeID = account.EmployeeID,
                    RoleID = account.RoleID,
                    StateID = 1,
                    Email = account.Email,
                    Password = Utilities.GetMD5(account.Password),
                    CreatedBy = account.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                db.Accounts.Add(acc);
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

        [Route("Account/{id?}")]
        [HttpPut]
        public object EditAccount(Account1 account)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.Accounts.Where(x => x.AccountID == id).FirstOrDefault();
            if (obj.AccountID > 0)
            {
                obj.EmployeeID = account.EmployeeID;
                obj.Email = account.Email;
                obj.RoleID = account.RoleID;
                obj.StateID = account.StateID;
                obj.UpdatedAt = DateTime.Now;
                obj.UpdatedBy = account.UpdatedBy;
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
                Message = "Data not updated"
            };
        }

        [Route("Account/Password/{id?}")]
        [HttpPut]
        public object EditPasswordAccount(Account1 account)
        {
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.Accounts.Where(x => x.AccountID == id).FirstOrDefault();
            if (obj.AccountID > 0)
            {
                obj.Password = Utilities.GetMD5(account.Password);
                obj.UpdatedAt = DateTime.Now;
                obj.UpdatedBy = account.UpdatedBy;
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
                Message = "Data not updated"
            };
        }
        [Route("EmployeeForAccount")]
        [HttpGet]
        public object GetEmployeeForAccount()
        {
            var account = db.EmployeeForAccounts.ToList();
            return account;
        }
        [Route("Account/{id?}")]
        [HttpGet]
        public object GetAccountByID(int ID)
        {
            var objaccount = db.Accounts.Where(x => x.AccountID == ID).ToList();
            var account = (from acc in objaccount
                           from emp in db.Employees
                           from role in db.Roles
                           from state in db.States
                           where acc.EmployeeID == emp.EmployeeID
                           where role.RoleID == acc.RoleID
                           where state.StateID == acc.StateID
                           select new
                           {
                               Account = acc,
                               acc.AccountID,
                               acc.EmployeeID,
                               acc.RoleID,
                               acc.StateID,
                               Employee = emp,
                               emp.Image,
                               role.RoleName,
                               state.StateName
                           }
                           ).FirstOrDefault();
            return account;
        }
        [Route("Account/Employee/{id?}")]
        [HttpGet]
        public object GetAccountForEmployeeByID(int ID)
        {
            var account = (from acc in db.Accounts
                           from role in db.Roles
                           where acc.RoleID == role.RoleID
                           select new
                           {
                               Account = acc,
                               role.RoleName
                           }).FirstOrDefault();
            return account;
        }
        [Route("Account")]
        [HttpGet]
        public object GetAllAccount()
        {
            var account = (from acc in db.Accounts
                           from emp in db.Employees
                           from role in db.Roles
                           from state in db.States
                           where acc.EmployeeID == emp.EmployeeID
                           where role.RoleID == acc.RoleID
                           where state.StateID == acc.StateID
                           select new
                           {
                               Account = acc,
                               acc.AccountID,
                               acc.EmployeeID,
                               acc.RoleID,
                               acc.StateID,
                               Employee = emp,
                               role.RoleName,
                               state.StateName
                           }
                           ).ToList();
            return account;
        }

        [Route("Account/{id?}")]
        [HttpDelete]
        public object DeleteAccount(int ID)
        {
            var obj = db.Accounts.Where(x => x.AccountID == ID).FirstOrDefault();
            db.Accounts.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status =200,
                Message = "Delete Successfuly"
            };
        }

        // ------------------------------ Roles ------------------------------ //
        [Route("Role")]
        [HttpPost]
        public object AddRole(Role1 role1)
        {
            if (role1.RoleID == 0)
            {
                Role role = new Role
                {
                    RoleName = role1.RoleName
                };
                db.Roles.Add(role);
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

        [Route("Role/{id?}")]
        [HttpPut]
        public object EditRole(Role1 role1)
        {
            // Get id from routeParam
            int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
            var obj = db.Roles.Where(x => x.RoleID == id).FirstOrDefault();
            if (obj.RoleID > 0)
            {
                obj.RoleName = role1.RoleName;
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
                Message = "Data not updated"
            };
        }

        [Route("Role")]
        [HttpGet]
        public object GetAllRole()
        {
            var role = db.Roles.ToList();
            return role;
        }

        [Route("Role/{id?}")]
        [HttpGet]
        public object GetRoleByID(int ID)
        {
            var obj = db.Roles.Where(x => x.RoleID == ID).FirstOrDefault();
            return obj;
        }

        [Route("Role/{id?}")]
        [HttpDelete]
        public object DeleteRole(int ID)
        {
            var obj = db.Roles.Where(x => x.RoleID == ID).FirstOrDefault();
            db.Roles.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = 200,
                Message = "Delete Successfuly"
            };
        }

        // ------------------------------ Login ------------------------------ //
        [Route("Login")]
        [HttpPost]
        public Response Login(Login lg)
        {
            if (ModelState.IsValid)
            {
                var f_password = Utilities.GetMD5(lg.Password);
                var user = db.Accounts.Where(s => s.Email.Equals(lg.Email) && s.Password.Equals(f_password)).FirstOrDefault();
                if (user != null)
                {
                    return new Response()
                    {
                        Status = 200,
                        Message = TokenManager.GenerateToken
                        (
                            user.AccountID,
                            Convert.ToInt32(user.RoleID),
                            Convert.ToInt32(user.EmployeeID)
                        )
                    };
                }
            }
            else
            {
                return new Response { Status = 500, Message = "Login Fail" };
            }
            return new Response { Status = 500, Message = "Sai" };
        }
        // ------------------------------ Shift ------------------------------ //
        [Route("Shift")]
        [HttpPost]
        public object AddShift(Shift1 shift1)
        {
            if (shift1.ShiftID == 0)
            {
                Shift shift = new Shift
                {
                    ShiftName = shift1.ShiftName,
                    StartShift = shift1.StartShift,
                    EndShift = shift1.EndShift
                };
                db.Shifts.Add(shift);
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
        [Route("Shift/{id?}")]
        [HttpPut]
        public object EditShift(Shift1 shift1)
        {
            {
                int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
                var obj = db.Shifts.Where(x => x.ShiftID == id).FirstOrDefault();
                if (obj.ShiftID > 0)
                {
                    obj.ShiftName = shift1.ShiftName;
                    obj.StartShift = shift1.StartShift;
                    obj.EndShift = shift1.EndShift;
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

        [Route("Shift")]
        [HttpGet]
        public object GetAllShift()
        {
            var shift = db.Shifts.ToList();
            return shift;
        }

        [Route("Shift/{id?}")]
        [HttpGet]
        public object GetShiftByID(int ID)
        {
            var obj = db.Shifts.Where(x => x.ShiftID == ID).FirstOrDefault();
            return obj;
        }

        [Route("Shift/{id?}")]
        [HttpDelete]
        public object DeleteShift(int ID)
        {
            var obj = db.Shifts.Where(x => x.ShiftID == ID).FirstOrDefault();
            db.Shifts.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status =200,
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ OverTime ------------------------------ //
        [Route("OverTime")]
        [HttpPost]
        public object AddOverTime(OverTime1 OverTime1)
        {
            if (OverTime1.OverTimeID == 0)
            {
                OverTime OverTime = new OverTime
                {
                    OverTimeName = OverTime1.OverTimeName,
                    DepartmentID = OverTime1.DepartmentID,
                    OverTimeDate = OverTime1.OverTimeDate,
                    StartTime = OverTime1.StartTime,
                    EndTime = OverTime1.EndTime,
                    IsActive = OverTime1.IsActive,
                    Quantity = OverTime1.Quantity,
                    CreatedBy = OverTime1.CreatedBy
                };
                db.OverTimes.Add(OverTime);
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
        [Route("OverTime/{id?}")]
        [HttpPut]
        public object EditOverTime(OverTime1 OverTime1)
        {
            {
                int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
                var obj = db.OverTimes.Where(x => x.OverTimeID == id).FirstOrDefault();
                if (obj.OverTimeID > 0)
                {
                    obj.OverTimeName = OverTime1.OverTimeName;
                    obj.DepartmentID = OverTime1.DepartmentID;
                    obj.StartTime = OverTime1.StartTime;
                    obj.EndTime = OverTime1.EndTime;
                    obj.OverTimeDate = OverTime1.OverTimeDate;
                    obj.IsActive = OverTime1.IsActive;
                    obj.Quantity = OverTime1.Quantity;
                    obj.UpdatedBy = OverTime1.UpdatedBy;
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

        [Route("OverTime")]
        [HttpGet]
        public object GetAllOverTime()
        {
            var OverTime = (from overtime in db.OverTimes
                            from dep in db.Departments
                            where overtime.DepartmentID == dep.DepartmentID
                            select new
                            {
                                Overtime = overtime,
                                Department = dep.DepartmentName
                            })
                .ToList();
            return OverTime;
        }

        [Route("OverTime/{id?}")]
        [HttpGet]
        public object GetOverTimeByID(int ID)
        {
            var obj = db.OverTimes.Where(x => x.OverTimeID == ID).FirstOrDefault();
            return obj;
        }

        [Route("OverTime/{id?}")]
        [HttpDelete]
        public object DeleteOverTime(int ID)
        {
            var obj = db.OverTimes.Where(x => x.OverTimeID == ID).FirstOrDefault();
            db.OverTimes.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status =200,
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Position ------------------------------ //
        [Route("Position")]
        [HttpPost]
        public object AddPosition(Position1 Position1)
        {
            if (Position1.PositionID == 0)
            {
                Position Position = new Position
                {
                    PositionName = Position1.PositionName,
                    Note = Position1.Note,
                };
                db.Positions.Add(Position);
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
        [Route("Position/{id?}")]
        [HttpPut]
        public object EditPosition(Position1 Position1)
        {
            {
                int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
                var obj = db.Positions.Where(x => x.PositionID == id).FirstOrDefault();
                if (obj.PositionID > 0)
                {
                    obj.PositionName = Position1.PositionName;
                    obj.Note = Position1.Note;
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

        [Route("Position")]
        [HttpGet]
        public object GetAllPosition()
        {
            var Position = db.Positions.ToList();
            return Position;
        }

        [Route("Position/{id?}")]
        [HttpGet]
        public object GetPositionByID(int ID)
        {
            var obj = db.Positions.Where(x => x.PositionID == ID).FirstOrDefault();
            return obj;
        }

        [Route("Position/{id?}")]
        [HttpDelete]
        public object DeletePosition(int ID)
        {
            var obj = db.Positions.Where(x => x.PositionID == ID).FirstOrDefault();
            db.Positions.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status =200,
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Level ------------------------------ //
        [Route("Level")]
        [HttpPost]
        public object AddOrEditLevel(Level1 lv1)
        {
            if (lv1.LevelID == 0)
            {
                Level lv = new Level
                {
                    LevelName = lv1.LevelName,
                    PositionID = lv1.PositionID,
                    Coefficient = lv1.Coefficient
                    
                };
                db.Levels.Add(lv);
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
        [Route("Level/{id?}")]
        [HttpPut]
        public object EditLevel(Level1 lv1)
        {
            {
                int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
                var obj = db.Levels.Where(x => x.LevelID == id).FirstOrDefault();
                if (obj.LevelID > 0)
                {
                    obj.LevelName = lv1.LevelName;
                    obj.PositionID = lv1.PositionID;
                    obj.Coefficient = lv1.Coefficient;
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

        [Route("Level")]
        [HttpGet]
        public object GetAllLevels()
        {
            var result = (from lv in db.Levels
                          from position in db.Positions
                          where position.PositionID == lv.PositionID
                          select new
                          {
                              Level = lv,
                              position.PositionName
                          }).ToList();
            return result;
        }

        [Route("Level/{id?}")]
        [HttpGet]
        public object GetLevelByID(int ID)
        {
            var obj = db.Levels.Where(x => x.LevelID == ID).FirstOrDefault();
            return obj;
        }

        [Route("Level/{id?}")]
        [HttpDelete]
        public object DeleteLevel(int ID)
        {
            var obj = db.Levels.Where(x => x.LevelID == ID).FirstOrDefault();
            db.Levels.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status =200,
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Organization ------------------------------ //
        [Route("Organization")]
        [HttpPost]
        public object AddOrganization(Organization1 or1)
        {
            if (or1.OrganizationID == 0)
            {
                Organization or = new Organization
                {
                    Name = or1.Name,
                    Logo = or1.Logo,
                    Email = or1.Email,
                    Latitude = or1.Latitude,
                    Longitude = or1.Longitude,
                    Website = or1.Website,
                    PublicIP = or1.PublicIP,
                    PythonIP = or1.PythonIP,
                };
                db.Organizations.Add(or);
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
        [Route("Organization/{id?}")]
        [HttpPut]
        public object EditOrganization(Organization1 or1)
        {
            {
                int id = Convert.ToInt32(Request.GetRouteData().Values["id"]);
                var obj = db.Organizations.Where(x => x.OrganizationID == id).FirstOrDefault();
                if (obj.OrganizationID > 0)
                {
                    obj.Name = or1.Name;
                    obj.Logo = or1.Logo;
                    obj.Email = or1.Email;
                    obj.Latitude = or1.Latitude;
                    obj.Longitude = or1.Longitude;
                    obj.Website = or1.Website;
                    obj.PublicIP = or1.PublicIP;
                    obj.PythonIP = or1.PythonIP;
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

        [Route("Organization")]
        [HttpGet]
        public object GetAllOrganization()
        {
            var or = db.Organizations.ToList();
            return or;
        }

        [Route("Organization/{id?}")]
        [HttpGet]
        public object GetOrganizationByID(int ID)
        {
            var obj = db.Organizations.Where(x => x.OrganizationID == ID).FirstOrDefault();
            return obj;
        }

        [Route("Organization/{id?}")]
        [HttpDelete]
        public object DeleteOrganization(int ID)
        {
            var obj = db.Organizations.Where(x => x.OrganizationID == ID).FirstOrDefault();
            db.Organizations.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status =200,
                Message = "Delete Successfuly"
            };
        }

    }
}