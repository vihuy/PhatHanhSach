using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhatHanhSach.Models;
using System.Web.Mvc;

namespace PhatHanhSach.Controllers
{
    public class QuanLi_CongNo_DLController : Controller
    {
        PhatHanhSachEntities db = new PhatHanhSachEntities();
        // GET: QuanLi_CongNo_DL
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CongNoDL(DateTime date_congnodl)
        {
            List<CONGNO_DL> lst_congno_dl = new List<CONGNO_DL>();
            List<DAILY> lst_dl = new List<DAILY>();
            lst_dl = db.DAILies.ToList();
            foreach (DAILY dl in lst_dl)
            {
                CONGNO_DL congno_dl = new CONGNO_DL();
                congno_dl = db.CONGNO_DL.Where(x => x.ThoiGian <= date_congnodl.Date && x.MaDL == dl.MaDL).OrderByDescending(X => X.ThoiGian).FirstOrDefault();
                lst_congno_dl.Add(congno_dl);
            }
            ViewBag.NgayCongNo = date_congnodl.Date;
            return View(lst_congno_dl);
            
        }
    }
}