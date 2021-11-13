using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CHAMCONGVN.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CHAMCONGVN.Controllers
{
    [System.Web.Http.RoutePrefix("Api/User")]
    public class NguoiDungController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        [System.Web.Http.Route("Themnguoidung")]
        [System.Web.Http.HttpPost]
        public object Themnguoidung(NguoiDung nd)
        {
            SYS_Nguoidung snd = new SYS_Nguoidung();
            try
            {
                if (nd.ID != snd.ID)
                {
                    snd.ID = nd.ID;
                    snd.MaNV = nd.MaNV;
                    snd.Username = nd.Username;
                    snd.Password = GetMD5(nd.Password);
                    snd.Email = nd.Email;
                    snd.Fullname = nd.Fullname;
                    snd.IDQuyen = nd.IDQuyen;
                    snd.NumberOfLogin = nd.NumberOfLogin;
                    snd.LaterLogin = nd.LaterLogin;
                    snd.CreatedByUser = nd.CreatedByUser;
                    snd.CreatedByDate = DateTime.Now;
                    snd.GhiChu = nd.GhiChu;
                    snd.IsActive = nd.IsActive;
                    db.SYS_Nguoidung.Add(snd);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };

        }

        [System.Web.Http.Route("SuaNguoiDung")]
        [System.Web.Http.HttpPost]
        public object EditND(NguoiDung nd)
        {
            SYS_Nguoidung snd = new SYS_Nguoidung();
            try
            {
                var obj = db.SYS_Nguoidung.Where(x => x.ID == nd.ID).ToList().FirstOrDefault();
                if (obj.ID != null)
                {
                    obj.Username = nd.Username;
                    obj.Password = GetMD5(nd.Password);
                    obj.Email = nd.Email;
                    obj.Fullname = nd.Fullname;
                    obj.LaterLogin = nd.LaterLogin;
                    obj.UpdatedByUser = nd.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
                    obj.IDQuyen = nd.IDQuyen;
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Updated",
                        Message = "Updated Successfully"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };

        }
        // Xem danh sách tài khoản
        [System.Web.Http.Route("XemDStaikhoan")]
        [System.Web.Http.HttpGet]
        public object XemDStaikhoan()
        {
            var a = (from nd in db.SYS_Nguoidung
                    from nv in db.PB_Nhanvien
                    from quyen in db.SYS_Quyen
                    where nv.MaNV == nd.MaNV
                    where quyen.IDQuyen == nd.IDQuyen
                    
                    select new
                    {
                        nd.ID,
                        nv.MaNV,
                        nd.Fullname,
                        quyen.Rollname,
                        nd.Username,
                        nd.Password,
                        nd.Email,
                        nd.CreatedByUser,
                        nd.CreatedByDate,
                        nd.IsActive

                    }).ToList();
            return a;
        }
        [System.Web.Http.Route("UpdateThongTinCaNhan")]
        [System.Web.Http.HttpPost]
        public object EditTTCN(NhanVien nv)
        {
            var obj = db.PB_Nhanvien.Where(x => x.MaNV == nv.MaNV).ToList().FirstOrDefault();
            if (obj.MaNV != null)
            {
                obj.HoNV = nv.HoNV;
                obj.TenNV = nv.TenNV;
                obj.Nickname = nv.Nickname;
                obj.GioiTinh = nv.GioiTinh;
                obj.Hinhanh = nv.Hinhanh;
                obj.Ngaysinh = nv.Ngaysinh;
                obj.Noisinh = nv.Noisinh;
                obj.Honnhan = nv.Honnhan;
                obj.Diachi = nv.Diachi;
                obj.Tamtru = nv.Tamtru;
                obj.Dienthoaididong = nv.Dienthoaididong;
                obj.Email = nv.Email;
                obj.SoCMND = nv.SoCMND;
                obj.Ngaycap = nv.Ngaycap;
                obj.Ngayvaolam = nv.Ngayvaolam;
                obj.Suckhoe = nv.Suckhoe;
                obj.Chieucao = nv.Chieucao;
                obj.Cannang = nv.Cannang;
                obj.Tinhtrang = nv.Tinhtrang;
                obj.Quoctich = nv.Quoctich;
                obj.Dantoc = nv.Dantoc;
                obj.TonGiao = nv.TonGiao;
                obj.MaBangcap = obj.MaBangcap;
                obj.Machuyenmon = obj.Machuyenmon;
                obj.MaToNhom = obj.MaToNhom;
                obj.Machucvu = obj.Machucvu;
                obj.Maphongban = obj.Maphongban;
                obj.Macongviec = obj.Macongviec;
                obj.BHXH = obj.BHXH;
                obj.BHYT = obj.BHYT;
                obj.BHTN = obj.BHTN;
                obj.Phicongdoan = obj.Phicongdoan;
                obj.GhiChu = nv.GhiChu;
                obj.CreatedByUser = nv.CreatedByUser;
                obj.CreatedByDate = DateTime.Now;
                obj.UpdatedByUser = nv.UpdatedByUser;
                obj.UpdatedByDate = DateTime.Now;
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
        // Xóa tài khoản
        [System.Web.Http.Route("Xoataikhoan")]
        [System.Web.Http.HttpDelete]
        public object Xoataikhoan(string id)
        {
            var obj = db.SYS_Nguoidung.Where(x => x.ID == id).ToList().FirstOrDefault();
            db.SYS_Nguoidung.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // getbyID tài khoản
        [System.Web.Http.Route("getbyIdtaikhoan")]
        [System.Web.Http.HttpGet]
        public object getbyIdtaikhoan(string id)
        {
            var obj = db.SYS_Nguoidung.Where(x => x.ID == id).ToList().FirstOrDefault();
            return obj;
        }
        //------------------ Login -------------------------//
        [System.Web.Http.Route("Login")]
        [System.Web.Http.HttpPost]
        public Response employeeLogin(Login lg)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(lg.Password);
                var user = db.LoginRole.Where(s => s.Username.Equals(lg.Username) && s.Password.Equals(f_password)).FirstOrDefault();
                if (user != null)
                {
                    return new UserResponse() { Status = "Success", Message = TokenManager.GenerateToken(user.ID, user.MaNV, user.Fullname, user.Rollname, user.Username, user.Password, user.Email, user.CreatedByUser) };
                }
            }
            else
            {
                return new Response { Status = "Fail", Message = "Login Fail" };
            }
            return new Response { Status = "Sai", Message = "Sai" };
        }
        [System.Web.Http.Route("Validate")]
        [System.Web.Http.HttpGet]
        public ResponseVM Validate(string token, string username)
        {
            int UserId = Convert.ToInt32(new UserRepository().GetUser(username));
            if (UserId == null) return new ResponseVM { Status = "Invalid", Message = "Invalid User." };
            string tokenUsername = TokenManager.ValidateToken(token);
            if (username.Equals(tokenUsername))
            {
                return new ResponseVM
                {
                    Status = "Success",
                    Message = "OK",
                };
            }
            return new ResponseVM { Status = "Invalid", Message = "Invalid Token." };
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        //--Quyền-----
        //---Thêm quyền-----------
        [System.Web.Http.Route("ThemQuyen")]
        [System.Web.Http.HttpPost]
        public object ThemQuyen(Quyen q)
        {
            SYS_Quyen sq = new SYS_Quyen();
            try
            {
                if (q.IDQuyen != sq.IDQuyen)
                {
                    sq.IDQuyen = q.IDQuyen;
                    sq.Rollname = q.Rollname;
                    sq.Description = q.Description;
                    db.SYS_Quyen.Add(sq);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };

        }
        // Xem danh sách quyền
        [System.Web.Http.Route("XemDSQuyen")]
        [System.Web.Http.HttpGet]
        public object XemDSQuyen()
        {
            var xemdsquyen = db.SYS_Quyen.ToList();
            return xemdsquyen;
        }
        // Xóa quyền
        [System.Web.Http.Route("XoaQuyen")]
        [System.Web.Http.HttpDelete]
        public object XoaQuyen(string idquyen)
        {
            var obj = db.SYS_Quyen.Where(x => x.IDQuyen == idquyen).ToList().FirstOrDefault();
            db.SYS_Quyen.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // getbyID quyền
        [System.Web.Http.Route("getbyIdquyen")]
        [System.Web.Http.HttpGet]
        public object getbyIdquyen(string idquyen)
        {
            var obj = db.SYS_Quyen.Where(x => x.IDQuyen == idquyen).ToList().FirstOrDefault();
            return obj;
        }
        
    }
}