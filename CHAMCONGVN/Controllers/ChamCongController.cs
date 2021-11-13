using CHAMCONGVN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CHAMCONGVN.Controllers
{
    [System.Web.Http.RoutePrefix("Api/ChamCong")]
    public class ChamCongController : ApiController
    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        // Xem DS Bảng lương
        [System.Web.Http.Route("XemDSChamCong")]
        [System.Web.Http.HttpGet]
        public object XemDSChamCong()
        {
            var XemDSChamCong = db.DsChamCong.ToList();
            return XemDSChamCong;
        }
        [System.Web.Http.Route("getbyttcheckin")]
        [System.Web.Http.HttpGet]
        public object getbyttcheckin(string trangthaici)
        {
            var obj = db.DsChamCong.Where(x => x.TrangThaici == trangthaici).ToList();
            return obj;
        }
        [System.Web.Http.Route("getbyttcheckout")]
        [System.Web.Http.HttpGet]
        public object getbyttcheckout(string trangthaico)
        {
            var obj = db.DsChamCong.Where(x => x.TrangThaico == trangthaico).ToList();
            return obj;
        }
        [System.Web.Http.Route("getbyttchamcong")]
        [System.Web.Http.HttpGet]
        public object getbyttchamcong(string trangthai)
        {
            var obj = db.DsChamCong.Where(x => x.TrangThai == trangthai).ToList();
            return obj;
        }
    }
}