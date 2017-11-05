using PhatHanhSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhatHanhSach.Controllers
{
    public class SachController : Controller
    {
        PhatHanhSachEntities db = new PhatHanhSachEntities();
        // GET: Sach
        public ActionResult Index()
        {
            var list = db.SACHes;

            return View(list);
        }
        [HttpGet]
        public ActionResult ThemSach()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemSach(SACH s, FormCollection f)
        {
            db.SACHes.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}