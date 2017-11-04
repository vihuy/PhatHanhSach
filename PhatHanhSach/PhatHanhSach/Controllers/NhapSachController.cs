﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhatHanhSach.Models;
using System.Web.Mvc;
using PhatHanhSach.Models.ViewModels;

namespace PhatHanhSach.Controllers
{
    public class NhapSachController : Controller
    {
        PhatHanhSachEntities entities = new PhatHanhSachEntities();

        public ActionResult Index()
        {
            NHAXUATBAN nxb = new NHAXUATBAN();

            var getnxblist = entities.NHAXUATBANs.ToList();
            SelectList list = new SelectList(getnxblist, "MaNXB", "Ten");
            ViewBag.nxblistname = list;

            if(Session["listSach"] == null) 
                Session["listSach"] = new List<SachViewModel>();

            return View();
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var sachlist = (from s in entities.SACHes
                             where s.TenSach.StartsWith(prefix)
                             select new
                             {
                                 label = s.TenSach,
                                 val = s.MaSach
                             }).ToList();

            return Json(sachlist);
        }

        [HttpPost]
        public ActionResult ThemVaoBang(SachViewModel sachVM)
        {
            // Xu ly code truy xuat sach
            SACH sach = entities.SACHes.Where(s => s.TenSach == sachVM.TenSach).FirstOrDefault();
            sachVM.MaSach = sach.MaSach;
            sachVM.TenSach = sach.TenSach;
            sachVM.GiaNhap = (int)sach.DonGiaNhap;
            ((List<SachViewModel>)Session["listSach"]).Add(sachVM);
            return RedirectToAction("Index");
        }

        public ActionResult XoaKhoiBang(int MaSach)
        {
            // Xu ly code truy xuat sach
            ((List<SachViewModel>)Session["listSach"]).RemoveAll(p => p.MaSach == MaSach);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult LuuCSDL(SachViewModel sachVM)
        {
            PHIEUNHAP pn = new PHIEUNHAP();
            pn.NgayNhap = sachVM.NgayNhap;
            pn.MaNXB = sachVM.MaNXB;
            pn.TrangThai = true;
            
            var addedPN = entities.PHIEUNHAPs.Add(pn);
            entities.SaveChanges();

            int tongTien = 0;

            foreach (var ct in (List<SachViewModel>)Session["listSach"])
            {
                int thanhTien = ct.GiaNhap * ct.SLNhap;
                tongTien += thanhTien;
                // Add ct phieu nhap
                CT_PHIEUNHAP ctpn = new CT_PHIEUNHAP();
                ctpn.MaPN = pn.MaPN;
                ctpn.MaSach = ct.MaSach;
                ctpn.SLNhap = ct.SLNhap;
                ctpn.DonGia = ct.GiaNhap;
                ctpn.ThanhTien = thanhTien;

                entities.CT_PHIEUNHAP.Add(ctpn);
            }

            // Update tong tien 
            addedPN.TongTien = tongTien;

            // Update cong no NXB
            CONGNO_NXB cnNXB = new CONGNO_NXB();
            cnNXB.MaNXB = sachVM.MaNXB;
            cnNXB.ThoiGian = sachVM.NgayNhap;
            cnNXB.TienNo = tongTien;
            cnNXB.TienDaTra = 0;
            entities.CONGNO_NXB.Add(cnNXB);
            entities.SaveChanges();

            Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ThemPhieuNhap(PHIEUNHAP pn, CT_PHIEUNHAP ctpn)
        {
            //Session["dsSach"] = new List<>();
            entities.CT_PHIEUNHAP.Add(ctpn);
                entities.SaveChanges();
            return RedirectToAction("Index", "NhapSach");
        }
    }
}