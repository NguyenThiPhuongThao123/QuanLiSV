using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiSV.Models;

namespace QuanLiSV.Controllers
{
    public class NganhHocsController : Controller
    {
        private QuanLiSVContext db = new QuanLiSVContext();
        // GET: NganhHocs
        public ActionResult Index()
        {
            return View(db.NganhHocs.ToList());
        }

        // GET: NganhHocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhHoc nganhHoc = db.NganhHocs.Find(id);
            if (nganhHoc == null)
            {
                return HttpNotFound();
            }
            return View(nganhHoc);
        }

        // GET: NganhHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NganhHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Malop,Tenlop,Manghanh,Tennghanh,Makhoa")] NganhHoc nganhHoc)
        {
            if (ModelState.IsValid)
            {
                db.LOPs.Add(nganhHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nganhHoc);
        }

        // GET: NganhHocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhHoc nganhHoc = db.NganhHocs.Find(id);
            if (nganhHoc == null)
            {
                return HttpNotFound();
            }
            return View(nganhHoc);
        }

        // POST: NganhHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Malop,Tenlop,Manghanh,Tennghanh,Makhoa")] NganhHoc nganhHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nganhHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nganhHoc);
        }

        // GET: NganhHocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhHoc nganhHoc = db.NganhHocs.Find(id);
            if (nganhHoc == null)
            {
                return HttpNotFound();
            }
            return View(nganhHoc);
        }

        // POST: NganhHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NganhHoc nganhHoc = db.NganhHocs.Find(id);
            db.LOPs.Remove(nganhHoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
