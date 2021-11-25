using ChamCongVN_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamCongVN_BE.Controllers
{
    [RoutePrefix("Component")]
    public class ComponentController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();

        // ------------------------------ States ------------------------------ //
        [Route("AddOrEditState")]
        [HttpPost]
        public object AddOrEditState(State1 state1)
        {
            if (state1.StateID == 0)
            {
                State state = new State
                {
                    StateName = state1.StateName
                };
                db.States.Add(state);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.States.Where(x => x.StateID == state1.StateID).FirstOrDefault();
                if (obj.StateID > 0)
                {
                    obj.StateName = state1.StateName;
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

        [Route("GetAllState")]
        [HttpGet]
        public object GetAllState()
        {
            var state = db.States.ToList();
            return state;
        }

        [Route("GetStateByID")]
        [HttpGet]
        public object GetStateByID(int ID)
        {
            var obj = db.States.Where(x => x.StateID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteState")]
        [HttpDelete]
        public object DeleteState(int ID)
        {
            var obj = db.States.Where(x => x.StateID == ID).FirstOrDefault();
            db.States.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

        // ------------------------------ Works ------------------------------ //
        [Route("AddOrEditWork")]
        [HttpPost]
        public object AddOrEditWork(Work1 work1)
        {
            if (work1.WorkID == 0)
            {
                Work work = new Work
                {
                    WorkName = work1.WorkName,
                    Note = work1.Note
                };
                db.Works.Add(work);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.Works.Where(x => x.WorkID == work1.WorkID).FirstOrDefault();
                if (obj.WorkID > 0)
                {
                    obj.WorkName = work1.WorkName;
                    obj.Note = work1.Note;
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

        [Route("GetAllWork")]
        [HttpGet]
        public object GetAllWork()
        {
            var work = db.Works.ToList();
            return work;
        }

        [Route("GetWorkByID")]
        [HttpGet]
        public object GetWorkByID(int ID)
        {
            var obj = db.Works.Where(x => x.WorkID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteWork")]
        [HttpDelete]
        public object DeleteWork(int ID)
        {
            var obj = db.Works.Where(x => x.WorkID == ID).FirstOrDefault();
            db.Works.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

        // ------------------------------ Groups ------------------------------ //
        [Route("AddOrEditGroup")]
        [HttpPost]
        public object AddOrEditGroup(Group1 group1)
        {
            if (group1.GroupID == 0)
            {
                Group group = new Group
                {
                    GroupName = group1.GroupName,
                    Note = group1.Note
                };
                db.Groups.Add(group);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.Groups.Where(x => x.GroupID == group1.GroupID).FirstOrDefault();
                if (obj.GroupID > 0)
                {
                    obj.GroupName = group1.GroupName;
                    obj.Note = group1.Note;
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

        [Route("GetAllGroup")]
        [HttpGet]
        public object GetAllGroup()
        {
            var group = db.Groups.ToList();
            return group;
        }

        [Route("GetGroupByID")]
        [HttpGet]
        public object GetGroupByID(int ID)
        {
            var obj = db.Groups.Where(x => x.GroupID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteGroup")]
        [HttpDelete]
        public object DeleteGroup(int ID)
        {
            var obj = db.Groups.Where(x => x.GroupID == ID).FirstOrDefault();
            db.Groups.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

        // ------------------------------ Departments ------------------------------ //
        [Route("AddOrEditDepartment")]
        [HttpPost]
        public object AddOrEditDepartment(Department1 department1)
        {
            if (department1.DepartmentID == 0)
            {
                Department dep = new Department
                {
                    DepartmentName = department1.DepartmentName,
                    Phone = department1.Phone,
                    Note = department1.Note
                };
                db.Departments.Add(dep);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.Departments.Where(x => x.DepartmentID == department1.DepartmentID).FirstOrDefault();
                if (obj.DepartmentID > 0)
                {
                    obj.DepartmentName = department1.DepartmentName;
                    obj.Phone = department1.Phone;
                    obj.Note = department1.Note;
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

        [Route("GetAllDepartment")]
        [HttpGet]
        public object GetAllDepartment()
        {
            var Departments = db.Departments.ToList();
            return Departments;
        }

        [Route("GetDepartmentByID")]
        [HttpGet]
        public object GetDepartmentByID(int ID)
        {
            var obj = db.Departments.Where(x => x.DepartmentID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteDepartment")]
        [HttpDelete]
        public object DeleteDepartment(int ID)
        {
            var obj = db.Departments.Where(x => x.DepartmentID == ID).FirstOrDefault();
            db.Departments.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Degrees ------------------------------ //
        [Route("AddOrEditDegrees")]
        [HttpPost]
        public object AddOrEditDegrees(Degree1 degree1)
        {
            if (degree1.DegreeID == 0)
            {
                Degree deg = new Degree
                {
                    DegreeName = degree1.DegreeName,
                    Note = degree1.Note
                };
                db.Degrees.Add(deg);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.Degrees.Where(x => x.DegreeID == degree1.DegreeID).FirstOrDefault();
                if (obj.DegreeID > 0)
                {
                    obj.DegreeName = degree1.DegreeName;
                    obj.Note = degree1.Note;
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

        [Route("GetAllDegrees")]
        [HttpGet]
        public object GetAllDegrees()
        {
            var degree = db.Degrees.ToList();
            return degree;
        }

        [Route("GetDegreeByID")]
        [HttpGet]
        public object GetDegreeByID(int ID)
        {
            var obj = db.Degrees.Where(x => x.DegreeID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteDegree")]
        [HttpDelete]
        public object DeleteDegree(int ID)
        {
            var obj = db.Degrees.Where(x => x.DegreeID == ID).FirstOrDefault();
            db.Degrees.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Degrees Detail------------------------------ //
        [Route("AddOrEditDegreeDetail")]
        [HttpPost]
        public object AddOrEditDegreeDetail(DegreeDetail1 degreedetail1)
        {
            if (degreedetail1.DegreeDetailID == 0)
            {
                DegreeDetail deg = new DegreeDetail
                {
                    EmployeeID = degreedetail1.EmployeeID,
                    DegreeID = degreedetail1.DegreeID
                };
                db.DegreeDetails.Add(deg);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.DegreeDetails.Where(x => x.DegreeDetailID == degreedetail1.DegreeDetailID).FirstOrDefault();
                if (obj.DegreeDetailID > 0)
                {
                    obj.EmployeeID = degreedetail1.EmployeeID;
                    obj.DegreeID = degreedetail1.DegreeID;
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

        [Route("GetAllDegreeDetail")]
        [HttpGet]
        public object GetAllDegreeDetail()
        {
            var degree = db.DegreeDetails.ToList();
            return degree;
        }

        [Route("GetDegreeDetailByID")]
        [HttpGet]
        public object GetDegreeDetailByID(int ID)
        {
            var obj = db.DegreeDetails.Where(x => x.DegreeDetailID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteDegreeDetail")]
        [HttpDelete]
        public object DeleteDegreeDetail(int ID)
        {
            var obj = db.DegreeDetails.Where(x => x.DegreeDetailID == ID).FirstOrDefault();
            db.DegreeDetails.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Specialities ------------------------------ //
        [Route("AddOrEditSpecialities")]
        [HttpPost]
        public object AddOrEditSpecialities(Speciality1 speciality1)
        {
            if (speciality1.SpecialtyID == 0)
            {
                Speciality deg = new Speciality
                {
                    SpecialtyName = speciality1.SpecialtyName,
                    Note = speciality1.Note
                };
                db.Specialities.Add(deg);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.Specialities.Where(x => x.SpecialtyID == speciality1.SpecialtyID).FirstOrDefault();
                if (obj.SpecialtyID > 0)
                {
                    obj.SpecialtyName = speciality1.SpecialtyName;
                    obj.Note = speciality1.Note;
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

        [Route("GetAllSpecialities")]
        [HttpGet]
        public object GetAllSpecialities()
        {
            var degree = db.Specialities.ToList();
            return degree;
        }

        [Route("GetSpecialitieByID")]
        [HttpGet]
        public object GetSpecialitieByID(int ID)
        {
            var obj = db.Specialities.Where(x => x.SpecialtyID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteSpecialitie")]
        [HttpDelete]
        public object DeleteSpecialitie(int ID)
        {
            var obj = db.Specialities.Where(x => x.SpecialtyID == ID).FirstOrDefault();
            db.Specialities.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // ------------------------------ Speciality Details------------------------------ //
        [Route("AddOrEditSpecialityDetail")]
        [HttpPost]
        public object AddOrEditSpecialityDetail(SpecialityDetail1 specialitydetail1)
        {
            if (specialitydetail1.SpecialityDetailID == 0)
            {
                SpecialityDetail deg = new SpecialityDetail
                {
                    EmployeeID = specialitydetail1.EmployeeID,
                    SpecialtyID = specialitydetail1.SpecialtyID
                };
                db.SpecialityDetails.Add(deg);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }

            else
            {
                var obj = db.SpecialityDetails.Where(x => x.SpecialityDetailID == specialitydetail1.SpecialityDetailID).FirstOrDefault();
                if (obj.SpecialityDetailID > 0)
                {
                    obj.EmployeeID = specialitydetail1.EmployeeID;
                    obj.SpecialtyID = specialitydetail1.SpecialtyID;
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

        [Route("GetAllSpecialityDetail")]
        [HttpGet]
        public object GetAllSpecialityDetail()
        {
            var degree = db.SpecialityDetails.ToList();
            return degree;
        }

        [Route("GetSpecialityDetailByID")]
        [HttpGet]
        public object GetSpecialityDetailByID(int ID)
        {
            var obj = db.SpecialityDetails.Where(x => x.SpecialityDetailID == ID).FirstOrDefault();
            return obj;
        }

        [Route("DeleteSpecialityDetail")]
        [HttpDelete]
        public object DeleteSpecialityDetail(int ID)
        {
            var obj = db.SpecialityDetails.Where(x => x.SpecialityDetailID == ID).FirstOrDefault();
            db.SpecialityDetails.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }
}
