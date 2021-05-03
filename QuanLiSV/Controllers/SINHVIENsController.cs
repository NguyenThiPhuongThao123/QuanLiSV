using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiSV.Models;

namespace QuanLiSV.Controllers
{
    public class SINHVIENsController : Controller
    {
        private QuanLiSVContext db = new QuanLiSVContext();

        ReadExcel excel = new ReadExcel();

        // GET: SINHVIENs
        public ActionResult Index()
        {
            return View(db.SINHVIENs.ToList());
        }

        // GET: SINHVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // GET: SINHVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SINHVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masv,Hoten,Diachi,Malop")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.SINHVIENs.Add(sINHVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sINHVIEN);
        }

        // GET: SINHVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // POST: SINHVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masv,Hoten,Diachi,Malop")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sINHVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sINHVIEN);
        }

        // GET: SINHVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // POST: SINHVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            db.SINHVIENs.Remove(sINHVIEN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DownloadFile()
        {
            //duong dan chua file muon download
            string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/ExcelFile/"; // tu muc chua fiel excel
            //chuyen file sang dang byte
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "fielexcel.xlsx"); //doan nay de file excel
            //ten file khi download ve
            string fileName = "Sinhviencapnhat.xlsx";
            //tra ve file
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                //upload file thanh cong va file co du lieu
                if (file.ContentLength > 0)
                {

                    string _FileName = DateTime.Now.Year.ToString() + DateTime.Now.Date.ToString();
                    //save file to server
                    string _path = Path.Combine(Server.MapPath("~/Uploads/ExcelFile/Sinhviencapnhat.xlsx"), _FileName);
                    //luu file len server
                    file.SaveAs(_path);
                    //Import data form excel to sqlserver
                    CopyDataByBulk(p: excel.ReadDataFromExcelFile(_path));
                    ViewBag.ThongBao = "Import du lieu thanh cong";
                }
            }
            catch (Exception ex)
            {
                //neu upload file that bai
                ViewBag.ThongBao = "Import du lieu that bai";
            }
            return View("Index");
        }

        private void CopyDataByBulk(object p)
        {
            throw new NotImplementedException();
        }
        private void UploadExcelFile(HttpPostedFileBase file)
        {
            //dat ten cho file
            string _FileName = "ruoucapnhat.xlsx";
            //duong dan luu file
            string _path = Path.Combine(Server.MapPath("~/Uploads/ExcelFile/Sinhviencapnhat.xlsx"), _FileName);
            //luu file len server
            file.SaveAs(_path);
        }
        //copy large data from datatable to sqlserver
        private void CopyDataByBulk(DataTable dt)
        {
            //lay ket noi voi database luu trong file webconfig
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SINHVIENDbContext"].ConnectionString);
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "SINHVIENs";
            bulkcopy.ColumnMappings.Add(0, "Masv");
            bulkcopy.ColumnMappings.Add(1, "Hoten");
            bulkcopy.ColumnMappings.Add(3, "Diachi");
            bulkcopy.ColumnMappings.Add(4, "Malop");
            con.Open();
            bulkcopy.WriteToServer(dt);
            con.Close();
        }


        public DataTable ReadDataFromExcelFile(string filepath)
        {
            string connectionString = " ";
            string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtention.IndexOf("xlsx") == 0)
            {
                connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
            }
            else if (fileExtention.IndexOf("xls") == 0)
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";
            }
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {
                // Mở kết nối
                oledbConn.Open();

                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet ds = new DataSet();

                // Đổ đữ liệu từ tập excel vào DataSet
                oleda.Fill(ds);

                data = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                // Đóng chuỗi kết nối
                oledbConn.Close();
            }
            return data;
        }
    }
   // protected override void Dispose(bool disposing)
   //     {
   //         if (disposing)
    //        {
    //            db.Dispose();
   //       }
     //       base.Dispose(disposing);
    //    }
  //  }
}
