using System;
using System.Collections.Generic;
using System.Linq;
using PhatHanhSach.Models;
using System.Web;
using System.Web.Mvc;

namespace PhatHanhSach.Controllers
{
    public class QuanLi_CongNo_NXBController : Controller
    {
        PhatHanhSachEntities db = new PhatHanhSachEntities();
        // GET: QuanLi_CongNo_DL
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CongNoNXB(DateTime date_congnonxb)
        {
            List<CONGNO_NXB> lst_congno_nxb = new List<CONGNO_NXB>();
            List<NHAXUATBAN> lst_nxb = new List<NHAXUATBAN>();
            lst_nxb = db.NHAXUATBANs.ToList();
            foreach (NHAXUATBAN nxb in lst_nxb)
            {
                CONGNO_NXB congno_nxb = new CONGNO_NXB();
                congno_nxb = db.CONGNO_NXB.Where(x => x.ThoiGian <= date_congnonxb.Date && x.MaNXB == nxb.MaNXB).OrderByDescending(X => X.ThoiGian).FirstOrDefault();
                lst_congno_nxb.Add(congno_nxb);
            }
            ViewBag.NgayCongNo = date_congnonxb.Date;
            return View(lst_congno_nxb);

        }
	}
}