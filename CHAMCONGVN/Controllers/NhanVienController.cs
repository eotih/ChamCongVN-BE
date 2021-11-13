using CHAMCONGVN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CHAMCONGVN.Controllers
{
    [System.Web.Http.RoutePrefix("Api/NhanVien")]
    public class NhanVienController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        //------------------ Tạm Ứng Nhân Viên -------------------------//
        // Thêm tạm ứng nhân viên -  Một khi đã lưu thì không được phép sửa
        [System.Web.Http.Route("ThemTamUng")]
        [System.Web.Http.HttpPost]
        public object ThemTamUng(TamUngNhanVien tunv)
        {
           PB_TamungNhanvien ptu = new PB_TamungNhanvien();
            try
            {
                if (tunv.Matamung != ptu.Matamung)
                {
                    ptu.Matamung = tunv.Matamung;
                    ptu.MaNV = tunv.MaNV;
                    ptu.LyDo = tunv.LyDo;
                    ptu.Ngaytamung = DateTime.Now;
                    ptu.Sotien = tunv.Sotien;
                    ptu.Nguoiky = tunv.Nguoiky;
                    ptu.Chucvunguoiky = tunv.Chucvunguoiky;
                    ptu.Ngayky = DateTime.Now;
                    ptu.CreatedByUser = tunv.CreatedByUser;
                    ptu.CreatedByDate = DateTime.Now;
                    db.PB_TamungNhanvien.Add(ptu);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
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

        [System.Web.Http.Route("EditTamUng")]
        [System.Web.Http.HttpPost]
        public object EditTamUng(TamUngNhanVien tunv)
        {
            PB_TamungNhanvien ptu = new PB_TamungNhanvien();
            try
            {

                var obj = db.PB_TamungNhanvien.Where(x => x.Matamung == tunv.Matamung).ToList().FirstOrDefault();
                if (obj.Matamung != null)
                {
                    obj.Matamung = tunv.Matamung;
                    obj.MaNV = tunv.MaNV;
                    obj.LyDo = tunv.LyDo;
                    obj.Ngaytamung = DateTime.Now;
                    obj.Sotien = tunv.Sotien;
                    obj.Nguoiky = tunv.Nguoiky;
                    obj.Chucvunguoiky = tunv.Chucvunguoiky;
                    obj.Ngayky = DateTime.Now;
                    obj.UpdatedByUser = tunv.UpdatedByUser;
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
        // Xem tạm ứng nhân viên
        [System.Web.Http.Route("XemTamUng")]
        [System.Web.Http.HttpGet]
        public object XemTamUng()
        {
            var a = (from nv in db.PB_Nhanvien
                     join tunv in db.PB_TamungNhanvien on nv.MaNV equals tunv.MaNV
                     select new
                     {
                         tunv.Matamung,
                         nv.MaNV,
                         nv.HoNV,
                         nv.TenNV,
                         tunv.LyDo,
                         tunv.Ngaytamung,
                         tunv.Sotien,
                         tunv.Nguoiky,
                         tunv.Chucvunguoiky,
                         tunv.Ngayky,
                         tunv.CreatedByUser,
                         tunv.CreatedByDate,
                     }).ToList();
            return a;
        }
        // Xóa tạm ứng nhân viên
        [System.Web.Http.Route("XoaTamUng")]
        [System.Web.Http.HttpDelete]
        public object XoaTamUng(string matamung)
        {
            var obj = db.PB_TamungNhanvien.Where(x => x.Matamung == matamung).ToList().FirstOrDefault();
            db.PB_TamungNhanvien.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // getbyID tạm ứng nhân viên
        [System.Web.Http.Route("getbyIdTamUng")]
        [System.Web.Http.HttpGet]
        public object getbyIdTamUng(string matamung)
        {
            var obj = db.PB_TamungNhanvien.Where(x => x.Matamung == matamung).ToList().FirstOrDefault();
            return obj;
        }

        //------------------ Kỷ Luật Nhân Viên -------------------------//
        // Thêm/Sửa kỷ luật nhân viên
        [System.Web.Http.Route("ThemSuaKyLuatNhanVien")]
        [System.Web.Http.HttpPost]
        public object ThemSuaKyLuatNhanVien(KyluatNhanvien klnv)
        {
            PB_KyluatNhanvien pkl = new PB_KyluatNhanvien();
            try
            {
                if (klnv.Makyluat != pkl.Makyluat)
                {
                    pkl.Makyluat = klnv.Makyluat;
                    pkl.MaNV = klnv.MaNV;
                    pkl.Tenkyluat = klnv.Tenkyluat;
                    pkl.Ngayxayra = DateTime.Now;
                    pkl.Ngaykyluat = DateTime.Now;
                    pkl.Diadiem = klnv.Diadiem;
                    pkl.Nguoichungkien = klnv.Nguoichungkien;
                    pkl.Motasuviec = klnv.Motasuviec;
                    pkl.Hinhthuckyluat = klnv.Hinhthuckyluat;
                    pkl.Nguoibikyluatgiaithich = klnv.Nguoibikyluatgiaithich;
                    pkl.LyDo = klnv.LyDo;
                    pkl.Nguoiky = klnv.Nguoiky;
                    pkl.Chucvunguoiky = klnv.Chucvunguoiky;
                    pkl.Ngayky = DateTime.Now;
                    pkl.CreatedByUser = klnv.CreatedByUser;
                    pkl.CreatedByDate = DateTime.Now;
                    db.PB_KyluatNhanvien.Add(pkl);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
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

        [System.Web.Http.Route("EditKyluat")]
        [System.Web.Http.HttpPost]
        public object EditKyluat(KyluatNhanvien klnv)
        {
            PB_KyluatNhanvien pkl = new PB_KyluatNhanvien();
            try
            {

                var obj = db.PB_KyluatNhanvien.Where(x => x.Makyluat == klnv.Makyluat).ToList().FirstOrDefault();
                if (obj.Makyluat != null)
                {
                    obj.Makyluat = klnv.Makyluat;
                    obj.MaNV = klnv.MaNV;
                    obj.Tenkyluat = klnv.Tenkyluat;
                    obj.Ngayxayra = DateTime.Now;
                    obj.Ngaykyluat = DateTime.Now;
                    obj.Diadiem = klnv.Diadiem;
                    obj.Nguoichungkien = klnv.Nguoichungkien;
                    obj.Motasuviec = klnv.Motasuviec;
                    obj.Hinhthuckyluat = klnv.Hinhthuckyluat;
                    obj.Nguoibikyluatgiaithich = klnv.Nguoibikyluatgiaithich;
                    obj.LyDo = klnv.LyDo;
                    obj.Nguoiky = klnv.Nguoiky;
                    obj.Chucvunguoiky = klnv.Chucvunguoiky;
                    obj.Ngayky = DateTime.Now;
                    obj.UpdatedByUser = klnv.UpdatedByUser;
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
        // Xem kỷ luật nhân viên
        [System.Web.Http.Route("XemKyLuat")]
        [System.Web.Http.HttpGet]
        public object XemKyLuat()
        {
            var a = (from nv in db.PB_Nhanvien
                     join klnv in db.PB_KyluatNhanvien on nv.MaNV equals klnv.MaNV
                     select new
                     {
                         klnv.Makyluat,
                         nv.HoNV,
                         nv.TenNV,
                         klnv.Tenkyluat,
                         klnv.Ngayxayra,
                         klnv.Ngaykyluat,
                         klnv.Diadiem,
                         klnv.Nguoichungkien,
                         klnv.Motasuviec,
                         klnv.Hinhthuckyluat,
                         klnv.Nguoibikyluatgiaithich,
                         klnv.LyDo,
                         klnv.Nguoiky,
                         klnv.Chucvunguoiky,
                         klnv.Ngayky,
                         klnv.CreatedByUser,
                         klnv.CreatedByDate,
                     }).ToList();
            return a;
        }

        // Xóa kỷ luật nhân viên
        [System.Web.Http.Route("XoaKyLuat")]
        [System.Web.Http.HttpDelete]
        public object XoaKyLuat(string makyluat)
        {
            var obj = db.PB_KyluatNhanvien.Where(x => x.Makyluat == makyluat).ToList().FirstOrDefault();
            db.PB_KyluatNhanvien.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

        // getbyID kỷ luật nhân viên
        [System.Web.Http.Route("getbyIdkyluat")]
        [System.Web.Http.HttpGet]
        public object getbyIdkyluat(string makyluat)
        {
            var obj = db.PB_KyluatNhanvien.Where(x => x.Makyluat == makyluat).ToList().FirstOrDefault();
            return obj;
        }

        //-------------------------------------------------------//

        //------------------ DIC_Bằng Cấp -------------------------//
        //  Thêm/Sửa Bằng Cấp
        [System.Web.Http.Route("ThemBangCap")]
        [System.Web.Http.HttpPost]
        public object ThemBangCap(BangCap bc)
        {
            if (bc.Mabang == 0)
            {
                DIC_Bangcap bangcap = new DIC_Bangcap();
                bangcap.Tenbang = bc.Tenbang;
                bangcap.GhiChu = bc.GhiChu;
                bangcap.CreatedByUser = bc.CreatedByUser;
                bangcap.CreatedByDate = DateTime.Now;
                bangcap.IsActive = bc.IsActive;
                db.DIC_Bangcap.Add(bangcap);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Successfully"
                };
            }
            else
            {
                var obj = db.DIC_Bangcap.Where(x => x.Mabang == bc.Mabang).ToList().FirstOrDefault();
                if (obj.Mabang > 0)
                {

                    obj.Tenbang = bc.Tenbang;
                    obj.GhiChu = bc.GhiChu;
                    obj.UpdatedByUser = bc.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
                    obj.IsActive = bc.IsActive;
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
        // Xem bằng cấp
        [System.Web.Http.Route("XemBangCap")]
        [System.Web.Http.HttpGet]
        public object XemBangCap()
        {
            var xembangcap = db.DIC_Bangcap.ToList();
            return xembangcap;
        }

        // Xóa bằng cấp
        [System.Web.Http.Route("XoaBangCap")]
        [System.Web.Http.HttpDelete]
        public object XoaBangCap(int mabang)
        {
            var obj = db.DIC_Bangcap.Where(x => x.Mabang == mabang).ToList().FirstOrDefault();
            db.DIC_Bangcap.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

        // getbyID bằng cấp
        [System.Web.Http.Route("getbyIdbangcap")]
        [System.Web.Http.HttpGet]
        public object getbyIdbangcap(int mabang)
        {
            var obj = db.DIC_Bangcap.Where(x => x.Mabang == mabang).ToList().FirstOrDefault();
            return obj;
        }

        //------------------ NDT -------------------------//
        //------------------ Chuyên môn -------------------------//
        [System.Web.Http.Route("ThemChuyenMon")]
        [System.Web.Http.HttpPost]
        public object ThemSuaChuyenMon(ChuyenMon cm)
        {
            if(cm.Machuyenmon==0)
            {
                DIC_Chuyenmon chuyenmon = new DIC_Chuyenmon();
                chuyenmon.Tenchuyenmon = cm.Tenchuyenmon;
                chuyenmon.GhiChu = cm.GhiChu;
                chuyenmon.CreatedByUser = cm.CreatedByUser;
                chuyenmon.CreatedByDate = DateTime.Now;
                chuyenmon.IsActive = cm.IsActive;
                db.DIC_Chuyenmon.Add(chuyenmon);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Successfully"
                };
            }
            else
            {
                var obj = db.DIC_Chuyenmon.Where(x => x.Machuyenmon == cm.Machuyenmon).ToList().FirstOrDefault();
                if (obj.Machuyenmon > 0)
                {

                    obj.Tenchuyenmon = cm.Tenchuyenmon;
                    obj.GhiChu = cm.GhiChu;
                    obj.UpdatedByUser = cm.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
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
    
        // Xem Ds chuyên môn
        [System.Web.Http.Route("XemChuyenMon")]
        [System.Web.Http.HttpGet]
        public object XemChuyenMon()
        {
            var xemchuyenmon = db.DIC_Chuyenmon.ToList();
            return xemchuyenmon;
        }
        // Xóa Chuyên môn
        [System.Web.Http.Route("XoaChuyenMon")]
        [System.Web.Http.HttpDelete]
        public object XoaChuyenMon(int machuyenmon)
        {
            var obj = db.DIC_Chuyenmon.Where(x => x.Machuyenmon == machuyenmon).ToList().FirstOrDefault();
            db.DIC_Chuyenmon.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
        // getbyID chuyên môn
        [System.Web.Http.Route("getbyIdChuyenMon")]
        [System.Web.Http.HttpGet]
        public object getbyIdChuyenMon(int machuyenmon)
        {
            var obj = db.DIC_Chuyenmon.Where(x => x.Machuyenmon == machuyenmon).ToList().FirstOrDefault();
            return obj;
        }
        //-------------------------------------------------------//

        //------------------ Đánh giá nhân viên -------------------------//
        // Thêm/Sửa đánh giá nhân viên
        //------------------ Đánh giá nhân viên -------------------------//
        // Thêm/Sửa đánh giá nhân viên
        [System.Web.Http.Route("ThemSuaDanhGiaNhanVien")]
        [System.Web.Http.HttpPost]
        public object ThemSuaDanhGiaNhanVien(DanhGiaNhanVien dgnv)
        {
            PB_Danhgianhanvien danhgianv = new PB_Danhgianhanvien();
            if (dgnv.Madanhgia != danhgianv.Madanhgia)
            {
                danhgianv.Madanhgia = dgnv.Madanhgia;
                danhgianv.Madanhgia = dgnv.Madanhgia;
                danhgianv.MaNV = dgnv.MaNV;
                danhgianv.Ngay = DateTime.Now;
                danhgianv.Tinhthankyluat = dgnv.Tinhthankyluat;
                danhgianv.Ketqualamviec = dgnv.Ketqualamviec;
                danhgianv.Daoduc = dgnv.Daoduc;
                danhgianv.Tinhthanhochoi = dgnv.Tinhthanhochoi;
                danhgianv.Tinhthanlamviec = dgnv.Tinhthanlamviec;
                danhgianv.Danhgiachung = dgnv.Danhgiachung;
                danhgianv.Diem = dgnv.Diem;
                danhgianv.CreatedByUser = dgnv.CreatedByUser;
                danhgianv.CreatedByDate = DateTime.Now;

                db.PB_Danhgianhanvien.Add(danhgianv);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Successfully"
                };
            }

            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }

        [System.Web.Http.Route("SuaDanhGia")]
        [System.Web.Http.HttpPost]
        public object EditDanhGia(DanhGiaNhanVien dgnv)
        {
            try
            {
                var obj = db.PB_Danhgianhanvien.Where(x => x.Madanhgia == dgnv.Madanhgia).ToList().FirstOrDefault();
                if (obj.Madanhgia != null)
                {
                    obj.Madanhgia = dgnv.Madanhgia;
                    obj.MaNV = dgnv.MaNV;
                    obj.Ngay = DateTime.Now;
                    obj.Tinhthankyluat = dgnv.Tinhthankyluat;
                    obj.Ketqualamviec = dgnv.Ketqualamviec;
                    obj.Daoduc = dgnv.Daoduc;
                    obj.Tinhthanhochoi = dgnv.Tinhthanhochoi;
                    obj.Tinhthanlamviec = dgnv.Tinhthanlamviec;
                    obj.Danhgiachung = dgnv.Danhgiachung;
                    obj.Diem = dgnv.Diem;
                    obj.UpdatedByUser = dgnv.UpdatedByUser;
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

        // Xem đánh giá nhân viên
        [System.Web.Http.Route("XemDanhGia")]
        [System.Web.Http.HttpGet]
        public object XemDanhGia()
        {
            var a = (from nv in db.PB_Nhanvien
                     join dgnv in db.PB_Danhgianhanvien on nv.MaNV equals dgnv.MaNV
                     select new
                     {
                         dgnv.Madanhgia,
                         nv.HoNV,
                         nv.TenNV,
                         dgnv.Ngay,
                         dgnv.Tinhthankyluat,
                         dgnv.Ketqualamviec,
                         dgnv.Daoduc,
                         dgnv.Tinhthanhochoi,
                         dgnv.Tinhthanlamviec,
                         dgnv.Danhgiachung,
                         dgnv.Diem,
                         dgnv.CreatedByUser,
                         dgnv.CreatedByDate,
                     }).ToList();
            return a;
        }

        // Xóa đánh giá nhân viên
        [System.Web.Http.Route("XoaDanhGia")]
        [System.Web.Http.HttpDelete]
        public object XoaDanhGia(string madanhgia)
        {
            var obj = db.PB_Danhgianhanvien.Where(x => x.Madanhgia == madanhgia).ToList().FirstOrDefault();
            db.PB_Danhgianhanvien.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

        // getbyID đánh giá nhân viên
        [System.Web.Http.Route("getbyIddanhgia")]
        [System.Web.Http.HttpGet]
        public object getbyIddanhgia(string madanhgia)
        {
            var obj = db.PB_Danhgianhanvien.Where(x => x.Madanhgia == madanhgia).ToList().FirstOrDefault();
            return obj;
        }

        //------------------ Phòng ban -------------------------//
        // Thêm/Sửa phòng ban
        [System.Web.Http.Route("ThemSuaPhongBan")]
        [System.Web.Http.HttpPost]
        public object ThemSuaPhongBan(PhongBan pb)
        {
            if (pb.Maphong == 0)
            {
                PB_Phongban phongban = new PB_Phongban();
                phongban.Maphong = pb.Maphong;
                phongban.Tenphong = pb.Tenphong;
                phongban.Dienthoai = pb.Dienthoai;
                phongban.Tongsonhanvien = pb.Tongsonhanvien;
                phongban.GhiChu = pb.GhiChu;
                phongban.CreatedByUser = pb.CreatedByUser;
                phongban.CreatedByDate = DateTime.Now;
                db.PB_Phongban.Add(phongban);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Successfully"
                };
            }
            else
            {
                var obj = db.PB_Phongban.Where(x => x.Maphong == pb.Maphong).ToList().FirstOrDefault();
                if (obj.Maphong > 0)
                {
                   
                    obj.Tenphong = pb.Tenphong;
                    obj.Dienthoai = pb.Dienthoai;
                    obj.Tongsonhanvien = pb.Tongsonhanvien;
                    obj.GhiChu = pb.GhiChu;
                    obj.UpdatedByUser = pb.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
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
        // Xem phòng ban
        [System.Web.Http.Route("XemPhongBan")]
        [System.Web.Http.HttpGet]
        public object XemPhongBan()
        {
            var xemphongban = db.PB_Phongban.ToList();
            return xemphongban;
        }

        // Xóa đánh giá nhân viên
        [System.Web.Http.Route("XoaPhongBan")]
        [System.Web.Http.HttpDelete]
        public object XoaPhongBan(int maphongban)
        {
            var obj = db.PB_Phongban.Where(x => x.Maphong == maphongban).ToList().FirstOrDefault();
            db.PB_Phongban.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }

        // getbyID đánh giá nhân viên
        [System.Web.Http.Route("getbyIdphongban")]
        [System.Web.Http.HttpGet]
        public object getbyIdphongban(int maphongban)
        {
            var obj = db.PB_Phongban.Where(x => x.Maphong == maphongban).ToList().FirstOrDefault();
            return obj;
        }



        //----------------To Nhom-----------------//
        [System.Web.Http.Route("ThemToNhom")]
        [System.Web.Http.HttpPost]
        public object ThemToNhom(ToNhom tn)
        {

            if (tn.MaToNhom == 0)
            {
                PB_ToNhom ptn = new PB_ToNhom();
                ptn.Maphong = tn.Maphong;
                ptn.TenToNhom = tn.TenToNhom;
                ptn.Tongsonhanvien = tn.Tongsonhanvien;
                ptn.GhiChu = tn.GhiChu;
                ptn.CreatedByUser = tn.CreatedByUser;
                ptn.CreatedByDate = DateTime.Now;
                db.PB_ToNhom.Add(ptn);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.PB_ToNhom.Where(x => x.MaToNhom == tn.MaToNhom).ToList().FirstOrDefault();
                if (obj.MaToNhom > 0)
                {

                    obj.Maphong = tn.Maphong;
                    obj.TenToNhom = tn.TenToNhom;
                    obj.Tongsonhanvien = tn.Tongsonhanvien;
                    obj.GhiChu = tn.GhiChu;
                    obj.UpdatedByUser = tn.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
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
        // xem tất cả tổ nhóm
        [System.Web.Http.Route("ListTonhom")]
        [System.Web.Http.HttpGet]
        public object getListTN()
        {
            var a = (from tn in db.PB_ToNhom
                     from pb in db.PB_Phongban
                     where  tn.Maphong == pb.Maphong
                     select new
                     {
                         tn.MaToNhom,
                         tn.Maphong,
                         pb.Tenphong,
                         tn.TenToNhom,
                         tn.Tongsonhanvien,
                         tn.GhiChu,
                         tn.CreatedByUser,
                         tn.CreatedByDate
                     }).ToList();
            return a;
        }

        [System.Web.Http.Route("DeleteToNhom")]
        [System.Web.Http.HttpDelete]
        public object DeleteStd(int id)
        {
            var obj = db.PB_ToNhom.Where(x => x.MaToNhom == id).ToList().FirstOrDefault();
            db.PB_ToNhom.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Success"
            };
        }

        [System.Web.Http.Route("MoTaToNhom")]
        [System.Web.Http.HttpGet]
        public object Getbyid(int id)
        {
            var moi = db.PB_ToNhom.Where(x => x.MaToNhom == id).ToList().FirstOrDefault();
            return moi;
        }


        //----------------DICONGTAC-----------------//
        [System.Web.Http.Route("ThemNVcongtac")]
        [System.Web.Http.HttpPost]

        public object ThemNVCongtac(Dicongtac dct)
        {
            if (dct.Macongtac == 0)
            {
                PB_Dicongtac pdct = new PB_Dicongtac();
                pdct.MaNV = dct.MaNV;
                pdct.Veviec = dct.Veviec;
                pdct.LyDo = dct.LyDo;
                pdct.Noicongtac = dct.Noicongtac;
                pdct.Tungay = dct.Tungay;
                pdct.Denngay = dct.Denngay;
                pdct.Tiendicongtac = dct.Tiendicongtac;
                pdct.Nguoiky = dct.Nguoiky;
                pdct.Chucvunguoiky = dct.Chucvunguoiky;
                pdct.Ngayky = DateTime.Now;
                pdct.CreatedByUser = dct.CreatedByUser;
                pdct.CreatedByDate = DateTime.Now;
                db.PB_Dicongtac.Add(pdct);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.PB_Dicongtac.Where(x => x.Macongtac == dct.Macongtac).ToList().FirstOrDefault();
                if (obj.Macongtac > 0)
                {

                    obj.MaNV = dct.MaNV;
                    obj.Veviec = dct.Veviec;
                    obj.LyDo = dct.LyDo;
                    obj.Noicongtac = dct.Noicongtac;
                    obj.Tungay = dct.Tungay;
                    obj.Denngay = dct.Denngay;
                    obj.Tiendicongtac = dct.Tiendicongtac;
                    obj.Nguoiky = dct.Nguoiky;
                    obj.Chucvunguoiky = dct.Chucvunguoiky;
                    obj.Ngayky = DateTime.Now;
                    obj.UpdatedByUser = dct.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
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

        [System.Web.Http.Route("LISTNVCT")]
        [System.Web.Http.HttpGet]
        public object ListNVCT()
        {
            var a = (from nv in db.PB_Nhanvien
                     join nvct in db.PB_Dicongtac on nv.MaNV equals nvct.MaNV
                     select new
                     {
                         nvct.Macongtac,
                         nv.HoNV,
                         nv.TenNV,
                         nvct.Veviec,
                         nvct.LyDo,
                         nvct.Noicongtac,
                         nvct.Tungay,
                         nvct.Denngay,
                         nvct.Tiendicongtac,
                         nvct.Nguoiky,
                         nvct.Chucvunguoiky,
                         nvct.Ngayky,
                         nvct.CreatedByUser,
                         nvct.CreatedByDate,
                     }).ToList();
            return a;
        }

        [System.Web.Http.Route("CongtacDetail")]
        [System.Web.Http.HttpGet]
        public object GetbyidCT(int id)
        {
            var moi = db.PB_Dicongtac.Where(x => x.Macongtac == id).ToList().FirstOrDefault();
            return moi;
        }



        //----------------KhenThuongNhanVien-----------------//
        [System.Web.Http.Route("ThemNVKhenThuong")]
        [System.Web.Http.HttpPost]
        public object ThemNVKhenThuong(KhenthuongNhanvien ktnv)
        {
            PB_KhenthuongNhanvien pktnv = new PB_KhenthuongNhanvien();
            try
            {
                if (ktnv.Makhenthuong != pktnv.Makhenthuong)
                {
                    pktnv.Makhenthuong = ktnv.Makhenthuong;
                    pktnv.MaNV = ktnv.MaNV;
                    pktnv.Ngaykhenthuong = DateTime.Now;
                    pktnv.Tenkhenthuong = ktnv.Tenkhenthuong;
                    pktnv.LyDo = ktnv.LyDo;
                    pktnv.Hinhthuckhenthuong = ktnv.Hinhthuckhenthuong;
                    pktnv.Sotien = ktnv.Sotien;
                    pktnv.Nguoiky = ktnv.Nguoiky;
                    pktnv.Chucvunguoiky = ktnv.Chucvunguoiky;
                    pktnv.Ngayky = DateTime.Now;
                    pktnv.CreatedByUser = ktnv.CreatedByUser;
                    pktnv.CreatedByDate = DateTime.Now;
                    db.PB_KhenthuongNhanvien.Add(pktnv);
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

        [System.Web.Http.Route("SuaNVKhenThuong")]
        [System.Web.Http.HttpPost]
        public object SuaNVKhenThuong(KhenthuongNhanvien ktnv)
        {
            var obj = db.PB_KhenthuongNhanvien.Where(x => x.Makhenthuong == ktnv.Makhenthuong).ToList().FirstOrDefault();
            if (obj.Makhenthuong != null)
            {
                obj.MaNV = ktnv.MaNV;
                obj.Ngaykhenthuong = obj.Ngayky = DateTime.Now;
                obj.Tenkhenthuong = ktnv.Tenkhenthuong;
                obj.LyDo = ktnv.LyDo;
                obj.Hinhthuckhenthuong = ktnv.Hinhthuckhenthuong;
                obj.Sotien = ktnv.Sotien;
                obj.Nguoiky = ktnv.Nguoiky;
                obj.Chucvunguoiky = ktnv.Chucvunguoiky;
                obj.Ngayky = DateTime.Now;
                obj.UpdatedByUser = ktnv.UpdatedByUser;
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

        [System.Web.Http.Route("ListNVKhenThuong")]
        [System.Web.Http.HttpGet]
        public object ListNVKhenthuong()
        {
            var a = (from kt in db.PB_KhenthuongNhanvien
                     join nv in db.PB_Nhanvien on kt.MaNV equals nv.MaNV
                     select new
                     {
                         kt.Makhenthuong,
                         nv.HoNV,
                         nv.TenNV,
                         kt.Ngaykhenthuong,
                         kt.Tenkhenthuong,
                         kt.LyDo,
                         kt.Hinhthuckhenthuong,
                         kt.Sotien,
                         kt.Nguoiky,
                         kt.Chucvunguoiky,
                         kt.Ngayky,
                         kt.CreatedByUser,
                         kt.CreatedByDate
                     }).ToList();
            return a;
        }

        [System.Web.Http.Route("KhenThuongDetail")]
        [System.Web.Http.HttpGet]
        public object GetNVKT(string id)
        {
            var moi = db.PB_KhenthuongNhanvien.Where(x => x.Makhenthuong == id).ToList().FirstOrDefault();
            return moi;
        }

        //--------------CongViec---------------//
        [System.Web.Http.Route("AddCongViec")]
        [System.Web.Http.HttpPost]
        public object ThemCongViec(Congviec cv)
        {
            if (cv.Macongviec == 0)
            {
                DIC_Congviec dcv = new DIC_Congviec();
                dcv.Tencongviec = cv.Tencongviec;
                dcv.GhiChu = cv.GhiChu;
                dcv.CreatedByUser = cv.CreatedByUser;
                dcv.CreatedByDate = DateTime.Now;
                dcv.IsActive = cv.IsActive;
                db.DIC_Congviec.Add(dcv);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.DIC_Congviec.Where(x => x.Macongviec == cv.Macongviec).ToList().FirstOrDefault();
                if (obj.Macongviec > 0)
                {
                    obj.Tencongviec = cv.Tencongviec;
                    obj.GhiChu = cv.GhiChu;
                    obj.UpdatedByUser = cv.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
                    obj.IsActive = cv.IsActive;
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

        [System.Web.Http.Route("ListCongViec")]
        [System.Web.Http.HttpGet]
        public object ListCV()
        {
            var a = db.DIC_Congviec.ToList();
            return a;
        }

        [System.Web.Http.Route("CongViecDetail")]
        [System.Web.Http.HttpGet]
        public object GetCVbyid(int id)
        {
            var moi = db.DIC_Congviec.Where(x => x.Macongviec == id).ToList().FirstOrDefault();
            return moi;
        }




        //-----------------------ChucVu-------------------------//
        [System.Web.Http.Route("ThemChucVu")]
        [System.Web.Http.HttpPost]
        public object ThemChucVu(Chucvu cv)
        {
            if (cv.Machucvu == 0)
            {
                DIC_Chucvu dcv = new DIC_Chucvu();
                dcv.Tenchucvu = cv.Tenchucvu;
                dcv.Captren = cv.Captren;
                dcv.CreatedByUser = cv.CreatedByUser;
                dcv.CreatedByDate = DateTime.Now;
                dcv.IsActive = cv.IsActive;
                db.DIC_Chucvu.Add(dcv);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Success"
                };
            }
            else
            {
                var obj = db.DIC_Chucvu.Where(x => x.Machucvu == cv.Machucvu).ToList().FirstOrDefault();
                if (obj.Machucvu > 0)
                {

                    obj.Tenchucvu = cv.Tenchucvu;
                    obj.GhiChu = cv.GhiChu;
                    obj.UpdatedByUser = cv.UpdatedByUser;
                    obj.UpdatedByDate = DateTime.Now;
                    obj.IsActive = cv.IsActive;
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
                Status = "Updated",
                Message = "Updated Successfully"
            };

        }

        [System.Web.Http.Route("ListChucvu")]
        [System.Web.Http.HttpGet]
        public object ListChucVu()
        {
            var a = db.DIC_Chucvu.ToList();
            return a;
        }
        [System.Web.Http.Route("ChucvuDetail")]
        [System.Web.Http.HttpGet]
        public object getChucvubyId(int id)
        {
            var moi = db.DIC_Chucvu.Where(x => x.Machucvu == id).ToList().FirstOrDefault();
            return moi;
        }



        //----------------Nhân Viên-----------------//
        [System.Web.Http.Route("AddNhanVien")]
        [System.Web.Http.HttpPost]
        public object AddNhanVien(NhanVien nv)
        {
            PB_Nhanvien tnv = new PB_Nhanvien();
            try
            {
                if (nv.MaNV != tnv.MaNV)
                {
                    tnv.MaNV = nv.MaNV;
                    tnv.HoNV = nv.HoNV;
                    tnv.TenNV = nv.TenNV;
                    tnv.Nickname = nv.Nickname;
                    tnv.GioiTinh = nv.GioiTinh;
                    tnv.Hinhanh = nv.Hinhanh;
                    tnv.Ngaysinh = nv.Ngaysinh;
                    tnv.Noisinh = nv.Noisinh;
                    tnv.Honnhan = nv.Honnhan;
                    tnv.Diachi = nv.Diachi;
                    tnv.Tamtru = nv.Tamtru;
                    tnv.Dienthoaididong = nv.Dienthoaididong;
                    tnv.Email = nv.Email;
                    tnv.SoCMND = nv.SoCMND;
                    tnv.Noicap = nv.Noicap;
                    tnv.Ngaycap = nv.Ngaycap;
                    tnv.Ngayvaolam = nv.Ngayvaolam;
                    tnv.Suckhoe = nv.Suckhoe;
                    tnv.Chieucao = nv.Chieucao;
                    tnv.Cannang = nv.Cannang;
                    tnv.Tinhtrang = nv.Tinhtrang;
                    tnv.Quoctich = nv.Quoctich;
                    tnv.Dantoc = nv.Dantoc;
                    tnv.TonGiao = nv.TonGiao;
                    tnv.MaBangcap = nv.MaBangcap;
                    tnv.Machuyenmon = nv.Machuyenmon;
                    tnv.MaToNhom = nv.MaToNhom;
                    tnv.Machucvu = nv.Machucvu;
                    tnv.Maphongban = nv.Maphongban;
                    tnv.Macongviec = nv.Macongviec;
                    tnv.BHXH = nv.BHXH;
                    tnv.BHYT = nv.BHYT;
                    tnv.BHTN = nv.BHTN;
                    tnv.Phicongdoan = nv.Phicongdoan;
                    tnv.GhiChu = nv.GhiChu;
                    tnv.CreatedByUser = nv.CreatedByUser;
                    tnv.CreatedByDate = DateTime.Now;
                    tnv.UpdatedByUser = nv.UpdatedByUser;
                    tnv.UpdatedByDate = DateTime.Now;
                    db.PB_Nhanvien.Add(tnv);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Success"
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

        [System.Web.Http.Route("UpdateNhanVien")]
        [System.Web.Http.HttpPost]
        public object EditNhanVien(NhanVien nv)
        {
            var obj = db.PB_Nhanvien.Where(x => x.MaNV == nv.MaNV).ToList().FirstOrDefault();
            if (obj.MaNV != null)
            {
                obj.HoNV = nv.HoNV;
                obj.TenNV = nv.TenNV;
                obj.GioiTinh = nv.GioiTinh;
                obj.Ngaysinh = nv.Ngaysinh;
                obj.MaBangcap = nv.MaBangcap;
                obj.Machuyenmon = nv.Machuyenmon;
                obj.MaToNhom = nv.MaToNhom;
                obj.Machucvu = nv.Machucvu;
                obj.Maphongban = nv.Maphongban;
                obj.Macongviec = nv.Macongviec;
                obj.BHXH = nv.BHXH;
                obj.BHYT = nv.BHYT;
                obj.BHTN = nv.BHTN;
                obj.Phicongdoan = nv.Phicongdoan;
                obj.GhiChu = nv.GhiChu;
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

        [System.Web.Http.Route("ListNhanVien")]
        [System.Web.Http.HttpGet]
        public object ListNhanVien()
        {
            var a = (from nv in db.PB_Nhanvien
                     from bc in db.DIC_Bangcap
                     from cm in db.DIC_Chuyenmon
                     from tn in db.PB_ToNhom
                     from cvu in db.DIC_Chucvu
                     from pban in db.PB_Phongban
                     from cviec in db.DIC_Congviec
                     where nv.MaBangcap == bc.Mabang
                     where nv.Machuyenmon == cm.Machuyenmon
                     where nv.MaToNhom == tn.MaToNhom
                     where nv.Machucvu == cvu.Machucvu
                     where nv.Maphongban == pban.Maphong
                     where nv.Macongviec == cviec.Macongviec
                     select new
                     {
                         nv.MaNV,
                         nv.HoNV,
                         nv.TenNV,
                         nv.GioiTinh,
                         nv.Ngaysinh,
                         cvu.Tenchucvu,
                         tn.TenToNhom,
                         cviec.Tencongviec,
                         bc.Tenbang,
                         cm.Tenchuyenmon,
                         pban.Tenphong,
                     }).ToList();
            return a;

        }

        [System.Web.Http.Route("ListTTCNNhanVien")]
        [System.Web.Http.HttpGet]
        
        [System.Web.Http.Route("DeleteNV")]
        [System.Web.Http.HttpDelete]
        public object DeleteNV(string manv)
        {
            var obj = db.PB_Nhanvien.Where(x => x.MaNV == manv).ToList().FirstOrDefault();
            db.PB_Nhanvien.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Success"
            };
        }

        //------------Thông Tin Cá Nhân---------------//
        [System.Web.Http.Route("getThongTinNhanVienbyId")]
        [System.Web.Http.HttpGet]
        public object getTTNVbyId(string manv)
        {
            var a = (from nv in db.PB_Nhanvien
                     from bc in db.DIC_Bangcap
                     from cm in db.DIC_Chuyenmon
                     from tn in db.PB_ToNhom
                     from cvu in db.DIC_Chucvu
                     from pban in db.PB_Phongban
                     from cviec in db.DIC_Congviec
                     where nv.MaBangcap == bc.Mabang
                     where nv.Machuyenmon == cm.Machuyenmon
                     where nv.MaToNhom == tn.MaToNhom
                     where nv.Machucvu == cvu.Machucvu
                     where nv.Maphongban == pban.Maphong
                     where nv.Macongviec == cviec.Macongviec
                     where nv.MaNV == manv
                     select new
                     {
                         nv.HoNV,
                         nv.TenNV,
                         nv.Nickname,
                         nv.GioiTinh,
                         nv.Hinhanh,
                         nv.Ngaysinh,
                         nv.Noisinh,
                         nv.Honnhan,
                         nv.Diachi,
                         nv.Tamtru,
                         nv.Dienthoaididong,
                         nv.Email,
                         nv.SoCMND,
                         nv.Ngaycap,
                         nv.Noicap,
                         nv.Quoctich,
                         nv.Dantoc,
                         nv.TonGiao,
                         nv.CreatedByUser,
                         nv.CreatedByDate,
                         nv.UpdatedByUser,
                         nv.UpdatedByDate,
                         cvu.Tenchucvu,
                         tn.TenToNhom,
                         cviec.Tencongviec,
                         bc.Tenbang,
                         cm.Tenchuyenmon,
                         pban.Tenphong
                     }).ToList();
            return a;
        }

        [System.Web.Http.Route("getNhanVienbyId")]
        [System.Web.Http.HttpGet]
        public object getNhanVienbyId(string manv)
        {
            var moi = db.PB_Nhanvien.Where(x => x.MaNV == manv).ToList().FirstOrDefault();
            return moi;
        }
        //Ca LÃ m 
        [System.Web.Http.Route("EditCalam")]
        [System.Web.Http.HttpPost]
        public object EditCaLam(CaLam cl)
        {
            var obj = db.DIC_Calam.Where(x => x.Maca == cl.Maca).ToList().FirstOrDefault();
            if (obj.Maca > 0)
            {
                obj.TenCa = cl.TenCa;
                obj.Batdauca = cl.Batdauca;
                obj.Ketthucca = cl.Ketthucca;
                obj.Batdaunghi = cl.Batdaunghi;
                obj.Dimuon = cl.Dimuon;
                obj.Vesom = cl.Vesom;
                obj.Checkin = cl.Checkin;
                obj.Checkout = cl.Checkout;
                obj.CheckIP = cl.CheckIP;
                obj.CheckKhuonMat = cl.CheckKhuonMat;
                obj.CheckViTri = cl.CheckViTri;
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

        [System.Web.Http.Route("DanhSachCaLam")]
        [System.Web.Http.HttpGet]
        public object DSCalam()
        {
            var a = db.DIC_Calam.ToList();
            return a;
        }
        [System.Web.Http.Route("getbyIDcalam")]
        [System.Web.Http.HttpGet]
        public object getbyIDcalam(int maca)
        {
            var moi = db.DIC_Calam.Where(x => x.Maca == maca).ToList().FirstOrDefault();
            return moi;
        }
    }
}