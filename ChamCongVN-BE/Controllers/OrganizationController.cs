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
        [Route("AddAccount")]
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

        [Route("EditAccount")]
        [HttpPost]
        public object EditAccount(Account1 account)
        {
            var obj = db.Accounts.Where(x => x.AccountID == account.AccountID).FirstOrDefault();
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
                    Status = "Updated",
                    Message = "Updated Successfully"
                };
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }

        [Route("EditPasswordAccount")]
        [HttpPost]
        public object EditPasswordAccount(Account1 account)
        {
            var obj = db.Accounts.Where(x => x.AccountID == account.AccountID).FirstOrDefault();
            if (obj.AccountID > 0)
            {
                obj.Password = account.Password;
                obj.UpdatedAt = DateTime.Now;
                obj.UpdatedBy = account.UpdatedBy;
                db.SaveChanges();
                return new Response
                {
                    Status = "Updated",
                    Message = "Updated Successfully"
                };
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }

        [Route("GetAccountByID")]
        [HttpGet]
        public object GetAccountByID(int ID)
        {
            var account = db.Accounts.Where(x => x.AccountID == ID).FirstOrDefault();
            return account;
        }

        [Route("GetAllAccount")]
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

        [Route("DeleteAccount")]
        [HttpDelete]
        public object DeleteAccount(int ID)
        {
            var obj = db.Accounts.Where(x => x.AccountID == ID).FirstOrDefault();
            db.Accounts.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

        // ------------------------------ Roles ------------------------------ //
        [Route("AddOrEditRole")]
        [HttpPost]
        public object AddOrEditRole(Role1 role1)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Roles.Where(x => x.RoleID == role1.RoleID).FirstOrDefault();
                if (obj.RoleID > 0)
                {
                    obj.RoleName = role1.RoleName;
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

        [Route("GetAllRole")]
        [HttpGet]
        public object GetAllRole()
        {
            var role = db.Roles.ToList();
            return role;
        }

        [Route("GetRoleByID")]
        [HttpGet]
        public object GetRoleByID(int ID)
        {
            var obj = db.Roles.Where(x => x.RoleID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteRole")]
        [HttpDelete]
        public object DeleteRole(int ID)
        {
            var obj = db.Roles.Where(x => x.RoleID == ID).FirstOrDefault();
            db.Roles.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
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
                        Status = "Success",
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
                return new Response { Status = "Fail", Message = "Login Fail" };
            }
            return new Response { Status = "Sai", Message = "Sai" };
        }
        // ------------------------------ Shift ------------------------------ //
        [Route("AddOrEditShift")]
        [HttpPost]
        public object AddOrEditShift(Shift1 shift1)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Shifts.Where(x => x.ShiftID == shift1.ShiftID).FirstOrDefault();
                if (obj.ShiftID > 0)
                {
                    obj.ShiftName = shift1.ShiftName;
                    obj.StartShift = shift1.StartShift;
                    obj.EndShift = shift1.EndShift;
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

        [Route("GetAllShift")]
        [HttpGet]
        public object GetAllShift()
        {
            var shift = db.Shifts.ToList();
            return shift;
        }

        [Route("GetShiftByID")]
        [HttpGet]
        public object GetShiftByID(int ID)
        {
            var obj = db.Shifts.Where(x => x.ShiftID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteShift")]
        [HttpDelete]
        public object DeleteShift(int ID)
        {
            var obj = db.Shifts.Where(x => x.ShiftID == ID).FirstOrDefault();
            db.Shifts.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ OverTime ------------------------------ //
        [Route("AddOrEditOverTime")]
        [HttpPost]
        public object AddOrEditOverTime(OverTime1 OverTime1)
        {
            if (OverTime1.OverTimeID == 0)
            {
                OverTime OverTime = new OverTime
                {
                    OverTimeName = OverTime1.OverTimeName,
                    DepartmentID = OverTime1.DepartmentID,
                    OverTimeDate = OverTime1.OverTimeDate,
                    IsActive = OverTime1.IsActive,
                    Quantity = OverTime1.Quantity,
                    CreatedBy = OverTime1.CreatedBy
                };
                db.OverTimes.Add(OverTime);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.OverTimes.Where(x => x.OverTimeID == OverTime1.OverTimeID).FirstOrDefault();
                if (obj.OverTimeID > 0)
                {
                    obj.OverTimeName = OverTime1.OverTimeName;
                    obj.DepartmentID = OverTime1.DepartmentID;
                    obj.OverTimeDate = OverTime1.OverTimeDate;
                    obj.Quantity = OverTime1.Quantity;
                    obj.UpdatedBy = OverTime1.UpdatedBy;
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

        [Route("GetAllOverTime")]
        [HttpGet]
        public object GetAllOverTime()
        {
            var OverTime = db.OverTimes.ToList();
            return OverTime;
        }

        [Route("GetOverTimeByID")]
        [HttpGet]
        public object GetOverTimeByID(int ID)
        {
            var obj = db.OverTimes.Where(x => x.OverTimeID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteOverTime")]
        [HttpDelete]
        public object DeleteOverTime(int ID)
        {
            var obj = db.OverTimes.Where(x => x.OverTimeID == ID).FirstOrDefault();
            db.OverTimes.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Position ------------------------------ //
        [Route("AddOrEditPosition")]
        [HttpPost]
        public object AddOrEditPosition(Position1 Position1)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Positions.Where(x => x.PositionID == Position1.PositionID).FirstOrDefault();
                if (obj.PositionID > 0)
                {
                    obj.PositionName = Position1.PositionName;
                    obj.Note = Position1.Note;
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

        [Route("GetAllPosition")]
        [HttpGet]
        public object GetAllPosition()
        {
            var Position = db.Positions.ToList();
            return Position;
        }

        [Route("GetPositionByID")]
        [HttpGet]
        public object GetPositionByID(int ID)
        {
            var obj = db.Positions.Where(x => x.PositionID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeletePosition")]
        [HttpDelete]
        public object DeletePosition(int ID)
        {
            var obj = db.Positions.Where(x => x.PositionID == ID).FirstOrDefault();
            db.Positions.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Level ------------------------------ //
        [Route("AddOrEditLevel")]
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Levels.Where(x => x.LevelID == lv1.LevelID).FirstOrDefault();
                if (obj.OverTimeID > 0)
                {
                    obj.LevelName = lv1.LevelName;
                    obj.PositionID = lv1.PositionID;
                    obj.Coefficient = lv1.Coefficient;
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

        [Route("GetAllLevels")]
        [HttpGet]
        public object GetAllLevels()
        {
            var lv = db.Levels.ToList();
            return lv;
        }

        [Route("GetLevelByID")]
        [HttpGet]
        public object GetLevelByID(int ID)
        {
            var obj = db.Levels.Where(x => x.LevelID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteLevel")]
        [HttpDelete]
        public object DeleteLevel(int ID)
        {
            var obj = db.Levels.Where(x => x.LevelID == ID).FirstOrDefault();
            db.Levels.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Organization ------------------------------ //
        [Route("AddOrEditOrganization")]
        [HttpPost]
        public object AddOrEditOrganization(Organization1 or1)
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
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.Organizations.Where(x => x.OrganizationID == or1.OrganizationID).FirstOrDefault();
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

        [Route("GetAllOrganization")]
        [HttpGet]
        public object GetAllOrganization()
        {
            var or = db.Organizations.ToList();
            return or;
        }

        [Route("GetOrganizationByID")]
        [HttpGet]
        public object GetOrganizationByID(int ID)
        {
            var obj = db.Organizations.Where(x => x.OrganizationID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteOrganization")]
        [HttpDelete]
        public object DeleteOrganization(int ID)
        {
            var obj = db.Organizations.Where(x => x.OrganizationID == ID).FirstOrDefault();
            db.Organizations.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

    }
}