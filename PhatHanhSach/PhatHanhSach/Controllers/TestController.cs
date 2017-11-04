using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhatHanhSach.Models;

namespace PhatHanhSach.Controllers
{
    public class TestController : Controller
    {
        PhatHanhSachEntities db = new PhatHanhSachEntities();
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Search(string prefix)
        {
            var sach = (from s in db.SACHes
                        where s.TenSach.Contains(prefix)
                        select new
                        {
                            label = s.TenSach,
                            val = s.MaSach
                        }).ToList();

            return Json(sach);
        }

    }
}