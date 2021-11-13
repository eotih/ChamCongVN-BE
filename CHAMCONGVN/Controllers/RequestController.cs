using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CHAMCONGVN.Models;

namespace CHAMCONGVN.Controllers
{

    [System.Web.Http.RoutePrefix("Api/Request")]
    public class RequestController : ApiController
    {
        
        ChamCongVNEntities db = new ChamCongVNEntities();

        string choduyet = "Chờ Duyệt";
        //---------Nghỉ phép-----------------
        [System.Web.Http.Route("Xinnghiphep")]
        [System.Web.Http.HttpPost]
        public object Xinnghiphep(XinNghiPhep xnp)
        {
            
            DIC_Xinnghiphep dxnp = new DIC_Xinnghiphep();
            try
            {
                if (xnp.MaNghiPhep == 0)
                {
                    dxnp.MaNghiPhep = xnp.MaNghiPhep;
                    dxnp.MaNV = xnp.MaNV;
                    dxnp.LoaiNghi = xnp.LoaiNghi;
                    dxnp.NgayNghi = xnp.NgayNghi;
                    dxnp.TieuDeNghi = xnp.TieuDeNghi;
                    dxnp.LyDoNghi = xnp.LyDoNghi;
                    dxnp.TrangThai = choduyet;
                    dxnp.CreatedByUser = xnp.CreatedByUser;
                    dxnp.CreatedByDate = DateTime.Now;
                    db.DIC_Xinnghiphep.Add(dxnp);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
                    var obj = db.DIC_Xinnghiphep.Where(x => x.MaNghiPhep == xnp.MaNghiPhep).ToList().FirstOrDefault();
                    if (obj.MaNghiPhep != 0)
                    {
                        obj.TrangThai = xnp.TrangThai;
                        obj.UpdatedByUser = xnp.UpdatedByUser;
                        obj.UpdatedByDate = DateTime.Now;
                        db.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
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
        [System.Web.Http.Route("getbyIdxinnghiphep")]
        [System.Web.Http.HttpGet]
        public object getbyIdxinnghiphep(int manghiphep)
        {
            var obj = db.DIC_Xinnghiphep.Where(x => x.MaNghiPhep == manghiphep).ToList().FirstOrDefault();
            return obj;
        }
        [System.Web.Http.Route("getbyttxinnghiphep")]
        [System.Web.Http.HttpGet]
        public object getbyttxinnghiphep(string trangthai)
        {
            var obj = db.DIC_Xinnghiphep.Where(x => x.TrangThai == trangthai).ToList();
            return obj;
        }
        //------------Quên chấm công-----------------
        [System.Web.Http.Route("Xinquenchamcong")]
        [System.Web.Http.HttpPost]
        public object Xinquenchamcong(XinQuenChamCong xqcc)
        {
            DIC_Xinquenchamcong dxqcc = new DIC_Xinquenchamcong();
            try
            {
                if (xqcc.MaQCC == 0)
                {
                    dxqcc.MaQCC = xqcc.MaQCC;
                    dxqcc.MaNV = xqcc.MaNV;
                    dxqcc.LoaiQCC = xqcc.LoaiQCC;
                    dxqcc.NgayQCC = xqcc.NgayQCC;
                    dxqcc.GioCICO = xqcc.GioCICO;
                    dxqcc.TieuDeLyDo = xqcc.TieuDeLyDo;
                    dxqcc.LyDo = xqcc.LyDo;
                    dxqcc.TrangThai = choduyet;
                    dxqcc.CreatedByUser = xqcc.CreatedByUser;
                    dxqcc.CreatedByDate = DateTime.Now;
                    db.DIC_Xinquenchamcong.Add(dxqcc);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
                    var obj = db.DIC_Xinquenchamcong.Where(x => x.MaQCC == xqcc.MaQCC).ToList().FirstOrDefault();
                    if (obj.MaQCC > 0)
                    {
                        obj.TrangThai = xqcc.TrangThai;
                        obj.UpdatedByUser = xqcc.UpdatedByUser;
                        obj.UpdatedByDate = DateTime.Now;
                        db.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
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
        [System.Web.Http.Route("getbyIdquenchamcong")]
        [System.Web.Http.HttpGet]
        public object getbyIdquenchamcong(int maqcc)
        {
            var obj = db.DIC_Xinquenchamcong.Where(x => x.MaQCC == maqcc).ToList().FirstOrDefault();
            return obj;
        }
        [System.Web.Http.Route("getbyttquenchamcong")]
        [System.Web.Http.HttpGet]
        public object getbyttquenchamcong(string trangthai)
        {
            var obj = db.DIC_Xinquenchamcong.Where(x => x.TrangThai == trangthai).ToList();
            return obj;
        }
        //------------Đi muộn về sớm-----------------
        [System.Web.Http.Route("Xindimuonvesom")]
        [System.Web.Http.HttpPost]
        public object Xindimuonvesom(XinDiMuonVeSom xdmvs)
        {
            DIC_Xindimuonvesom dxdmvs = new DIC_Xindimuonvesom();
            try
            {
                if (xdmvs.MaDMVS == 0)
                {
                    dxdmvs.MaDMVS = xdmvs.MaDMVS;
                    dxdmvs.MaNV = xdmvs.MaNV;
                    dxdmvs.LoaiDMVS = xdmvs.LoaiDMVS;
                    dxdmvs.NgayDMVS = xdmvs.NgayDMVS;
                    dxdmvs.GioXin = xdmvs.GioXin;
                    dxdmvs.TieuDeDMVS = xdmvs.TieuDeDMVS;
                    dxdmvs.LyDoDMVS = xdmvs.LyDoDMVS;
                    dxdmvs.TrangThai = choduyet;
                    dxdmvs.CreatedByUser = xdmvs.CreatedByUser;
                    dxdmvs.CreatedByDate = DateTime.Now;
                    db.DIC_Xindimuonvesom.Add(dxdmvs);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
                    var obj = db.DIC_Xindimuonvesom.Where(x => x.MaDMVS == xdmvs.MaDMVS).ToList().FirstOrDefault();
                    if (obj.MaDMVS >0)
                    {
                        obj.TrangThai = xdmvs.TrangThai;
                        obj.UpdatedByUser = xdmvs.UpdatedByUser;
                        obj.UpdatedByDate = DateTime.Now;
                        db.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
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
        [System.Web.Http.Route("getbyIddimuonvesom")]
        [System.Web.Http.HttpGet]
        public object getbyIddimuonvesom(int madmvs)
        {
            var obj = db.DIC_Xindimuonvesom.Where(x => x.MaDMVS == madmvs).ToList().FirstOrDefault();
            return obj;
        }
        [System.Web.Http.Route("getbyttdimuonvesom")]
        [System.Web.Http.HttpGet]
        public object getbyttdimuonvesom(string trangthai)
        {
            var obj = db.DIC_Xindimuonvesom.Where(x => x.TrangThai == trangthai).ToList();
            return obj;
        }
        //------------Gặp đối tác-----------------
        [System.Web.Http.Route("Xingapdoitac")]
        [System.Web.Http.HttpPost]
        public object Xingapdoitac(XinGapDoiTac xgdt)
        {
            if (xgdt.MaGapDoiTac == 0)
            {
                DIC_Xingapdoitac dxgdt = new DIC_Xingapdoitac
                {
                    MaGapDoiTac = xgdt.MaGapDoiTac,
                    MaNV = xgdt.MaNV,
                    NgapGapDoiTac = xgdt.NgapGapDoiTac,
                    GioBatDau = xgdt.GioBatDau,
                    GioKetThuc = xgdt.GioKetThuc,
                    TenDoiTac = xgdt.TenDoiTac,
                    SDTDoiTac = xgdt.SDTDoiTac,
                    DiaChiCongTac = xgdt.DiaChiCongTac,
                    NoiDung = xgdt.NoiDung,
                    TrangThai = choduyet,
                    CreatedByUser = xgdt.CreatedByUser,
                    CreatedByDate = DateTime.Now
                };
                db.DIC_Xingapdoitac.Add(dxgdt);
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "Data Successfully"
                };
            }
            else
            {
                var obj = db.DIC_Xingapdoitac.Where(x => x.MaGapDoiTac == xgdt.MaGapDoiTac).ToList().FirstOrDefault();
                if (obj.MaGapDoiTac > 0)
                {
                    obj.TrangThai = xgdt.TrangThai;
                    obj.UpdatedByUser = xgdt.UpdatedByUser;
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
        [System.Web.Http.Route("getbyIdgapdoitac")]
        [System.Web.Http.HttpGet]
        public object getbyIdgapdoitac(int magapdoitac)
        {
            var obj = db.DIC_Xingapdoitac.Where(x => x.MaGapDoiTac == magapdoitac).ToList().FirstOrDefault();
            return obj;
        }
        [System.Web.Http.Route("getbyttgapdoitac")]
        [System.Web.Http.HttpGet]
        public object getbyttgapdoitac(string trangthai)
        {
            var obj = db.DIC_Xingapdoitac.Where(x => x.TrangThai == trangthai).ToList();
            return obj;
        }
    }
}