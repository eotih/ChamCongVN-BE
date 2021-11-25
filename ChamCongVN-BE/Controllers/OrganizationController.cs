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
                    Password = account.Password,
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

        [Route("EditStateAccount")]
        [HttpPost]
        public object EditStateAccount(Account1 account)
        {
            var obj = db.Accounts.Where(x => x.AccountID == account.AccountID).FirstOrDefault();
            if (obj.AccountID > 0)
            {
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
                           where acc.EmployeeID == emp.EmployeeID
                           select new
                           {
                               Account = acc,
                               Employee = emp
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
        public Response Login(string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                var f_password = Utilities.GetMD5(Password);
                var user = db.Accounts.Where(s => s.Email.Equals(Email) && s.Password.Equals(f_password)).FirstOrDefault();
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
    }
}