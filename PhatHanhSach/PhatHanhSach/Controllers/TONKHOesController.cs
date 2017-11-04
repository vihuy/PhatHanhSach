using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhatHanhSach.Models;

namespace PhatHanhSach.Controllers
{
    public class TONKHOesController : Controller
    {
        private PhatHanhSachEntities db = new PhatHanhSachEntities();

        // GET: TONKHOes
        public ActionResult Index()
        {
            var tONKHOes = db.TONKHOes.Include(t => t.SACH);
            return View(tONKHOes.ToList());
        }

        // GET: TONKHOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TONKHO tONKHO = db.TONKHOes.Find(id);
            if (tONKHO == null)
            {
                return HttpNotFound();
            }
            return View(tONKHO);
        }

        // GET: TONKHOes/Create
        public ActionResult Create()
        {
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach");
            return View();
        }

        // POST: TONKHOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,ThoiGian,SLTon")] TONKHO tONKHO)
        {
            if (ModelState.IsValid)
            {
                db.TONKHOes.Add(tONKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", tONKHO.MaSach);
            return View(tONKHO);
        }

        // GET: TONKHOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TONKHO tONKHO = db.TONKHOes.Find(id);
            if (tONKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", tONKHO.MaSach);
            return View(tONKHO);
        }

        // POST: TONKHOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,ThoiGian,SLTon")] TONKHO tONKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tONKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", tONKHO.MaSach);
            return View(tONKHO);
        }

        // GET: TONKHOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TONKHO tONKHO = db.TONKHOes.Find(id);
            if (tONKHO == null)
            {
                return HttpNotFound();
            }
            return View(tONKHO);
        }

        // POST: TONKHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TONKHO tONKHO = db.TONKHOes.Find(id);
            db.TONKHOes.Remove(tONKHO);
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
