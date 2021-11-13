using CHAMCONGVN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CHAMCONGVN.Controllers
{
    [System.Web.Http.RoutePrefix("Api/Luong")]
    public class LuongController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        //------------------ Danh Sách Bàng Lương -------------------------//
        [System.Web.Http.Route("ThemSuaDanhSachBangLuong")]
        [System.Web.Http.HttpPost]
        public object ThemSuaDanhSachBangLuong(DanhSachBangLuong dsbl)
        {
            PB_Danhsachbangluong danhsachbl = new PB_Danhsachbangluong();
            try
            {
                if (dsbl.Mabangluong != danhsachbl.Mabangluong)
                {
                    danhsachbl.Mabangluong = dsbl.Mabangluong;
                    danhsachbl.Thang = dsbl.Thang;
                    danhsachbl.Nam = dsbl.Nam;
                    danhsachbl.Nguoiky = dsbl.Nguoiky;
                    danhsachbl.Chucvunguoiky = dsbl.Chucvunguoiky;
                    danhsachbl.Ngayky = DateTime.Now;
                    danhsachbl.Luongtoithieu = dsbl.Luongtoithieu;
                    danhsachbl.Tongsogioquydinh = dsbl.Tongsogioquydinh;
                    danhsachbl.Tienbatdautinhthue = dsbl.Tienbatdautinhthue;
                    danhsachbl.Tienmoinguoiphuthuoc = dsbl.Tienmoinguoiphuthuoc;
                    danhsachbl.Hesothuong = dsbl.Hesothuong;
                    danhsachbl.Hesochunhat = dsbl.Hesochunhat;
                    danhsachbl.Hesonghile = dsbl.Hesonghile;
                    danhsachbl.BHXH = dsbl.BHXH;
                    danhsachbl.BHYT = dsbl.BHYT;
                    danhsachbl.BHTN = dsbl.BHTN;
                    danhsachbl.BHXHMAX = dsbl.BHXHMAX;
                    danhsachbl.Phicongdoan = dsbl.Phicongdoan;
                    danhsachbl.PhicongdoanMax = dsbl.PhicongdoanMax;
                    danhsachbl.IsLock = dsbl.IsLock;
                    danhsachbl.IsFinish = dsbl.IsFinish;
                    danhsachbl.CreatedByUser = dsbl.CreatedByUser;
                    danhsachbl.CreatedByDate = DateTime.Now;
                    db.PB_Danhsachbangluong.Add(danhsachbl);
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
        [System.Web.Http.Route("EditDSBangLuong")]
        [System.Web.Http.HttpPost]
        public object EditDSBangLuong(DanhSachBangLuong dsbl)
        {
            try
            {
                var obj = db.PB_Danhsachbangluong.Where(x => x.Mabangluong == dsbl.Mabangluong).ToList().FirstOrDefault();
                if (obj.Mabangluong != null)
                {
                    obj.Thang = dsbl.Thang;
                    obj.Nam = dsbl.Nam;
                    obj.Nguoiky = dsbl.Nguoiky;
                    obj.Chucvunguoiky = dsbl.Chucvunguoiky;
                    obj.Ngayky = DateTime.Now;
                    obj.Luongtoithieu = dsbl.Luongtoithieu;
                    obj.Tongsogioquydinh = dsbl.Tongsogioquydinh;
                    obj.Tienbatdautinhthue = dsbl.Tienbatdautinhthue;
                    obj.Tienmoinguoiphuthuoc = dsbl.Tienmoinguoiphuthuoc;
                    obj.Hesothuong = dsbl.Hesothuong;
                    obj.Hesochunhat = dsbl.Hesochunhat;
                    obj.Hesonghile = dsbl.Hesonghile;
                    obj.BHXH = dsbl.BHXH;
                    obj.BHYT = dsbl.BHYT;
                    obj.BHTN = dsbl.BHTN;
                    obj.BHXHMAX = dsbl.BHXHMAX;
                    obj.Phicongdoan = dsbl.Phicongdoan;
                    obj.PhicongdoanMax = dsbl.PhicongdoanMax;
                    obj.IsLock = dsbl.IsLock;
                    obj.IsFinish = dsbl.IsFinish;
                    obj.UpdatedByUser = dsbl.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
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
        // Xem DS Bảng lương
        [System.Web.Http.Route("XemBangLuong")]
        [System.Web.Http.HttpGet]
        public object XemBangLuong()
        {
            var xembangluong = db.PB_Danhsachbangluong.ToList();
            return xembangluong;
        }
        // Xóa Bảng lương
        [System.Web.Http.Route("XoaBangLuong")]
        [System.Web.Http.HttpDelete]
        public object XoaBangLuong(string mabangluong)
        {
            var obj = db.PB_Danhsachbangluong.Where(x => x.Mabangluong == mabangluong).ToList().FirstOrDefault();
            db.PB_Danhsachbangluong.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // getbyID Bảng Lương
        [System.Web.Http.Route("getbyIdDSBangLuong")]
        [System.Web.Http.HttpGet]
        public object getbyIdDSBangLuong(string mabangluong)
        {
            var obj = db.PB_Danhsachbangluong.Where(x => x.Mabangluong == mabangluong).ToList().FirstOrDefault();
            return obj;
        }
        //------------------ Lương tăng ca -------------------------//
        [System.Web.Http.Route("ThemSuaLuongTangCa")]
        [System.Web.Http.HttpPost]
        public object ThemSuaLuongTangCa(LuongTangCa ltc)
        {
            PB_Luongtangca luongtangca = new PB_Luongtangca();
            try
            {
                if (ltc.Maluongtangca != luongtangca.Maluongtangca)
                {
                    luongtangca.Mabangluong = ltc.Mabangluong;
                    luongtangca.MaNV = ltc.MaNV;
                    luongtangca.Maluongtangca = ltc.Maluongtangca;
                    luongtangca.LuongGio = ltc.LuongGio;
                    luongtangca.Sotangcathuong = ltc.Sotangcathuong;
                    luongtangca.Sotangcachunhat = ltc.Sotangcachunhat;
                    luongtangca.Sotangcale = ltc.Sotangcale;
                    luongtangca.CreatedByUser = ltc.CreatedByUser;
                    luongtangca.CreatedByDate = DateTime.Now;
                    db.PB_Luongtangca.Add(luongtangca);
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
        [System.Web.Http.Route("EditLuongtangca")]
        [System.Web.Http.HttpPost]
        public object EditLuongtangca(LuongTangCa ltc)
        {
            try
            {
                var obj = db.PB_Luongtangca.Where(x => x.Maluongtangca == ltc.Maluongtangca).ToList().FirstOrDefault();
                if (obj.Maluongtangca > 0)
                {
                    obj.LuongGio = ltc.LuongGio;
                    obj.Sotangcathuong = ltc.Sotangcathuong;
                    obj.Sotangcachunhat = ltc.Sotangcachunhat;
                    obj.Sotangcale = ltc.Sotangcale;
                    obj.UpdatedByUser = ltc.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
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
        // Xem DS Bảng lương
        [System.Web.Http.Route("XemLuongtangca")]
        [System.Web.Http.HttpGet]
        public object XemLuongtangca()
        {
            var xemltc = (from nv in db.PB_Nhanvien
                          join ltc in db.PB_Luongtangca on nv.MaNV equals ltc.MaNV
                          select new
                          {
                              ltc.Mabangluong,
                              ltc.Maluongtangca,
                              nv.HoNV,
                              nv.TenNV,
                              ltc.LuongGio,
                              ltc.Sotangcathuong,
                              ltc.Sotangcachunhat,
                              ltc.Sotangcale,
                              ltc.CreatedByUser,
                              ltc.CreatedByDate,
                              ltc.UpdatedByUser,
                              ltc.UpdatedByDate
                          }).ToList();
            return xemltc;
        }
        // Xóa Bảng lương
        [System.Web.Http.Route("Xoaluongtangca")]
        [System.Web.Http.HttpDelete]
        public object Xoaluongtangca(int maluongtangca)
        {
            var obj = db.PB_Luongtangca.Where(x => x.Maluongtangca == maluongtangca).ToList().FirstOrDefault();
            db.PB_Luongtangca.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // getbyID Bảng Lương
        [System.Web.Http.Route("getbyIdLuongtangca")]
        [System.Web.Http.HttpGet]
        public object getbyIdLuongtangca(int maluongtangca)
        {
            var obj = db.PB_Luongtangca.Where(x => x.Maluongtangca == maluongtangca).ToList().FirstOrDefault();
            return obj;
        }
        //--List lương ngày
        [System.Web.Http.Route("ListLuongNgay")]
        [System.Web.Http.HttpGet]
        public object ListLuong()
        {
            var a = db.tinh_luong.ToList();
                    
            return a;
        }

        //------------------ Lương làm thêm -------------------------//
        [System.Web.Http.Route("ThemLuongLamThem")]
        [System.Web.Http.HttpPost]
        public object ThemLuongLamThem(LuongLamThem llt)
        {
            PB_Luonglamthem pllt = new PB_Luonglamthem();
            try
            {
                if (llt.Maluonglamthem != pllt.Maluonglamthem)
                {
                    pllt.Mabangluong = llt.Mabangluong;
                    pllt.MaNV = llt.MaNV;
                    pllt.Maluonglamthem = llt.Maluonglamthem;
                    pllt.Tenluonglamthem = llt.Tenluonglamthem;
                    pllt.Sotien = llt.Sotien;
                    pllt.CreatedByUser = llt.CreatedByUser;
                    pllt.CreatedByDate = DateTime.Now;
                    db.PB_Luonglamthem.Add(pllt);
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
        [System.Web.Http.Route("EditLuongLamThem")]
        [System.Web.Http.HttpPost]
        public object EditLuongLamThem(LuongLamThem llt)
        {
            try
            {
                var obj = db.PB_Luonglamthem.Where(x => x.Maluonglamthem == llt.Maluonglamthem).ToList().FirstOrDefault();
                if (obj.Maluonglamthem > 0)
                {
                    obj.MaNV = llt.MaNV;
                    obj.Mabangluong = llt.Mabangluong;
                    obj.Tenluonglamthem = llt.Tenluonglamthem;
                    obj.Sotien = llt.Sotien;
                    obj.UpdatedByUser = llt.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
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
        
        [System.Web.Http.Route("XemLuonglamthem")]
        [System.Web.Http.HttpGet]
        public object XemLuonglamthem()
        {
            var xemllt = (from nv in db.PB_Nhanvien
                          join llt in db.PB_Luonglamthem on nv.MaNV equals llt.MaNV
                          select new
                          {
                              llt.Mabangluong,
                              nv.HoNV,
                              nv.TenNV,
                              llt.Maluonglamthem,
                              llt.Tenluonglamthem,
                              llt.Sotien,
                              llt.CreatedByUser,
                              llt.CreatedByDate,
                              llt.UpdatedByUser,
                              llt.UpdatedByDate
                          }).ToList();
            return xemllt;
        }
        
        [System.Web.Http.Route("XoaLuonglamthem")]
        [System.Web.Http.HttpDelete]
        public object XoaLuonglamthem(int maluonglamthem)
        {
            var obj = db.PB_Luonglamthem.Where(x => x.Maluonglamthem == maluonglamthem).ToList().FirstOrDefault();
            db.PB_Luonglamthem.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        
        [System.Web.Http.Route("getbyLuonglamthem")]
        [System.Web.Http.HttpGet]
        public object getbyLuonglamthem(int maluonglamthem)
        {
            var obj = db.PB_Luonglamthem.Where(x => x.Maluonglamthem == maluonglamthem).ToList().FirstOrDefault();
            return obj;
        }
        //------------------ Khấu trừ nhân viên -------------------------//
        [System.Web.Http.Route("ThemKhauTruNhanVien")]
        [System.Web.Http.HttpPost]
        public object ThemKhauTruNhanVien(KhauTruNhanVien ktnv)
        {
            PB_KhautruNhanvien pktnv = new PB_KhautruNhanvien();
            try
            {
                if (ktnv.Makhautru != pktnv.Makhautru)
                {
                    pktnv.Mabangluong = ktnv.Mabangluong;
                    pktnv.MaNV = ktnv.MaNV;
                    pktnv.Makhautru = ktnv.Makhautru;
                    pktnv.Tenkhautru = ktnv.Tenkhautru;
                    pktnv.Sotien = ktnv.Sotien;
                    pktnv.CreatedByUser = ktnv.CreatedByUser;
                    pktnv.CreatedByDate = DateTime.Now;
                    
                    db.PB_KhautruNhanvien.Add(pktnv);
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
        [System.Web.Http.Route("EditKhauTruNhanVien")]
        [System.Web.Http.HttpPost]
        public object EditKhauTruNhanVien(KhauTruNhanVien ktnv)
        {
            try
            {
                var obj = db.PB_KhautruNhanvien.Where(x => x.Makhautru == ktnv.Makhautru).ToList().FirstOrDefault();
                if (obj.Makhautru > 0)
                {
                    obj.MaNV = ktnv.MaNV;
                    obj.Mabangluong = ktnv.Mabangluong;
                    obj.Tenkhautru = ktnv.Tenkhautru;
                    obj.Sotien = ktnv.Sotien;
                    obj.UpdatedByUser = ktnv.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
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
        
        [System.Web.Http.Route("XemKhauTruNV")]
        [System.Web.Http.HttpGet]
        public object XemKhauTruNV()
        {
            var xemktnv = (from nv in db.PB_Nhanvien
                           join ktnv in db.PB_KhautruNhanvien on nv.MaNV equals ktnv.MaNV
                           select new
                           {
                               ktnv.Mabangluong,
                               nv.HoNV,
                               nv.TenNV,
                               ktnv.Makhautru,
                               ktnv.Tenkhautru,
                               ktnv.Sotien,
                               ktnv.CreatedByUser,
                               ktnv.CreatedByDate,
                               ktnv.UpdatedByUser,
                               ktnv.UpdatedByDate
                           }).ToList();
            return xemktnv;
        }
        
        [System.Web.Http.Route("Xoakhautrunv")]
        [System.Web.Http.HttpDelete]
        public object Xoakhautrunv(int makhautru)
        {
            var obj = db.PB_KhautruNhanvien.Where(x => x.Makhautru == makhautru).ToList().FirstOrDefault();
            db.PB_KhautruNhanvien.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        
        [System.Web.Http.Route("getbykhautrunv")]
        [System.Web.Http.HttpGet]
        public object getbykhautrunv(int makhautru)
        {
            var obj = db.PB_KhautruNhanvien.Where(x => x.Makhautru == makhautru).ToList().FirstOrDefault();
            return obj;
        }

        //------------------ Số Lương -------------------------//
        [System.Web.Http.Route("ThemSoLuong")]
        [System.Web.Http.HttpPost]
        public object ThemSoLuong(SoLuong sl)
        {
            PB_SoLuong psl = new PB_SoLuong();
            try
            {
                if (sl.Masoluong != psl.Masoluong)
                {
                    psl.Mabangluong = sl.Mabangluong;
                    psl.MaNV = sl.MaNV;
                    psl.Masoluong = sl.Masoluong;
                    psl.Hesoluong = sl.Hesoluong;
                    psl.Tonggiocongthucte = sl.Tonggiocongthucte;
                    psl.Nghiphep = sl.Nghiphep;
                    psl.BHXH = sl.BHXH;
                    psl.BHYT = sl.BHYT;
                    psl.BHTN = sl.BHTN;
                    psl.Phicongdoan = sl.Phicongdoan;
                    psl.Tienthue = sl.Tienthue;
                    psl.Songuoiphuthuoc = sl.Songuoiphuthuoc;
                    psl.Sotienconlaichiuthue = sl.Sotienconlaichiuthue;
                    psl.Tiendongthue = sl.Tiendongthue;
                    psl.Phicongtac = sl.Phicongtac;
                    psl.Tongtamung = sl.Tongtamung;
                    psl.Tongphucap = sl.Tongphucap;
                    psl.Tongthuong = sl.Tongthuong;
                    psl.CreatedByUser = sl.CreatedByUser;
                    psl.CreatedByDate = DateTime.Now;

                    db.PB_SoLuong.Add(psl);
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
        [System.Web.Http.Route("EditSoLuong")]
        [System.Web.Http.HttpPost]
        public object EditSoLuong(SoLuong sl)
        {
            try
            {
                var obj = db.PB_SoLuong.Where(x => x.Masoluong == sl.Masoluong).ToList().FirstOrDefault();
                if (obj.Masoluong >0)
                {
                    obj.Mabangluong = sl.Mabangluong;
                    obj.MaNV = sl.MaNV;
                    obj.Hesoluong = sl.Hesoluong;
                    obj.Tonggiocongthucte = sl.Tonggiocongthucte;
                    obj.Nghiphep = sl.Nghiphep;
                    obj.BHXH = sl.BHXH;
                    obj.BHYT = sl.BHYT;
                    obj.BHTN = sl.BHTN;
                    obj.Phicongdoan = sl.Phicongdoan;
                    obj.Tienthue = sl.Tienthue;
                    obj.Songuoiphuthuoc = sl.Songuoiphuthuoc;
                    obj.Sotienconlaichiuthue = sl.Sotienconlaichiuthue;
                    obj.Tiendongthue = sl.Tiendongthue;
                    obj.Phicongtac = sl.Phicongtac;
                    obj.Tongtamung = sl.Tongtamung;
                    obj.Tongphucap = sl.Tongphucap;
                    obj.Tongthuong = sl.Tongthuong;
                    obj.UpdatedByUser = sl.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
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
        
        [System.Web.Http.Route("XemSoLuong")]
        [System.Web.Http.HttpGet]
        public object XemSoLuong()
        {
            var xemsl = (from nv in db.PB_Nhanvien
                         join sl in db.PB_SoLuong on nv.MaNV equals sl.MaNV
                         select new
                         {
                             sl.Mabangluong,
                             sl.Masoluong,
                             nv.HoNV,
                             nv.TenNV,
                             sl.Hesoluong,
                             sl.Tonggiocongthucte,
                             sl.Nghiphep,
                             sl.BHXH,
                             sl.BHYT,
                             sl.BHTN,
                             sl.Phicongdoan,
                             sl.Tienthue,
                             sl.Songuoiphuthuoc,
                             sl.Sotienconlaichiuthue,
                             sl.Tiendongthue,
                             sl.Phicongtac,
                             sl.Tongtamung,
                             sl.Tongphucap,
                             sl.Tongthuong,
                             sl.CreatedByUser,
                             sl.CreatedByDate,
                             sl.UpdatedByUser,
                             sl.UpdatedByDate
                         }).ToList();
            return xemsl;
        }
        
        [System.Web.Http.Route("XoaSoLuong")]
        [System.Web.Http.HttpDelete]
        public object XoaSoLuong(int masoluong)
        {
            var obj = db.PB_SoLuong.Where(x => x.Masoluong == masoluong).ToList().FirstOrDefault();
            db.PB_SoLuong.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        
        [System.Web.Http.Route("getbySoLuong")]
        [System.Web.Http.HttpGet]
        public object getbySoLuong(int masoluong)
        {
            var obj = db.PB_SoLuong.Where(x => x.Masoluong == masoluong).ToList().FirstOrDefault();
            return obj;
        }
    }
}