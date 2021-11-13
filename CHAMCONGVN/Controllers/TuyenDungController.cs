using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CHAMCONGVN.Models;
using ExcelDataReader;

namespace CHAMCONGVN.Controllers
{
    [System.Web.Http.RoutePrefix("Api/Excel")]
    public class TuyenDungController : ApiController

    {
        ChamCongVNEntities db = new ChamCongVNEntities();
        [System.Web.Http.Route("ReadFile")]
        [System.Web.Http.HttpPost]
        public string ReadFile()
        {
            try
            {
                #region Variable Declaration  
                string message = "";
                HttpResponseMessage ResponseMessage = null;
                var httpRequest = HttpContext.Current.Request;
                DataSet dsexcelRecords = new DataSet();
                IExcelDataReader reader = null;
                HttpPostedFile Inputfile = null;
                Stream FileStream = null;
                #endregion

                #region Save Student Detail From Excel  
                using (ChamCongVNEntities objEntity = new ChamCongVNEntities())
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        Inputfile = httpRequest.Files[0];
                        FileStream = Inputfile.InputStream;

                        if (Inputfile != null && FileStream != null)
                        {
                            if (Inputfile.FileName.EndsWith(".xls"))
                                reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                            else if (Inputfile.FileName.EndsWith(".xlsx"))
                                reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
                            else
                                message = "The file format is not supported.";

                            dsexcelRecords = reader.AsDataSet();
                            reader.Close();

                            if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                            {
                                DataTable dtTuyenDung = dsexcelRecords.Tables[0];
                                for (int i = 0; i < dtTuyenDung.Rows.Count; i++)
                                {
                                    PB_TuyenDung pbtd = new PB_TuyenDung();
                                    pbtd.Matuyendung = Convert.ToInt32(dtTuyenDung.Rows[i][0]);
                                    pbtd.HoNV = Convert.ToString(dtTuyenDung.Rows[i][1]);
                                    pbtd.TenNV = Convert.ToString(dtTuyenDung.Rows[i][2]);
                                    pbtd.Gioitinh = Convert.ToString(dtTuyenDung.Rows[i][3]);
                                    pbtd.Ngaysinh = Convert.ToDateTime(dtTuyenDung.Rows[i][4]);
                                    pbtd.Noisinh = Convert.ToString(dtTuyenDung.Rows[i][5]);
                                    pbtd.Diachi = Convert.ToString(dtTuyenDung.Rows[i][6]);
                                    pbtd.Dienthoaididong = Convert.ToString(dtTuyenDung.Rows[i][7]);
                                    pbtd.Email = Convert.ToString(dtTuyenDung.Rows[i][8]);
                                    pbtd.Ungtuyenvitri = Convert.ToString(dtTuyenDung.Rows[i][9]);
                                    pbtd.Chuyenmon = Convert.ToString(dtTuyenDung.Rows[i][10]);
                                    pbtd.Trangthai = Convert.ToString(dtTuyenDung.Rows[i][11]);
                                    pbtd.LinkCV = Convert.ToString(dtTuyenDung.Rows[i][12]);
                                    pbtd.CreatedByUser = Convert.ToString(dtTuyenDung.Rows[i][13]);
                                    pbtd.CreatedByDate = Convert.ToDateTime(dtTuyenDung.Rows[i][14]);
                                    objEntity.PB_TuyenDung.Add(pbtd);
                                }

                                int output = objEntity.SaveChanges();
                                if (output > 0)
                                    message = "The Excel file has been successfully uploaded.";
                                else
                                    message = "Something Went Wrong!, The Excel file uploaded has fiald.";
                            }
                            else
                                message = "Selected file is empty.";
                        }
                        else
                            message = "Invalid File.";
                    }
                    else
                        ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                return message;
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.Route("DeleteTuyenDung")]
        [System.Web.Http.HttpDelete]
        public object DeleteTuyenDung(int matuyendung)
        {
            var obj = db.PB_TuyenDung.Where(x => x.Matuyendung == matuyendung).ToList().FirstOrDefault();
            db.PB_TuyenDung.Remove(obj);
            db.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Success"
            };
        }
        [System.Web.Http.Route("XemDSTuyenDung")]
        [System.Web.Http.HttpGet]
        public object XemDSTuyenDung()
        {
            var xemtuyendung = db.PB_TuyenDung.ToList();
            return xemtuyendung;
        }
        [System.Web.Http.Route("getbytuyendung")]
        [System.Web.Http.HttpGet]
        public object getbytuyendung(int matuyendung)
        {
            var getbytuyendung = db.PB_TuyenDung.Where(x => x.Matuyendung == matuyendung).ToList().FirstOrDefault();
            return getbytuyendung;
        }
    }
}