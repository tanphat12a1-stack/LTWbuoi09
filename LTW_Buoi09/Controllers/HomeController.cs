using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_Buoi09.Models;
using System.Data.SqlClient;
namespace LTW_Buoi09.Controllers
{
    public class HomeController : Controller
    {
        QLBSDataContext data = new QLBSDataContext();
        public ActionResult Index()
        {
            List<Sach> dsS = data.Saches.Take(10).ToList();
            return View(dsS);
        }
        public ActionResult DetailsIndex(int maS)
        {
            Sach s = data.Saches.FirstOrDefault(m => m.MaSach == maS);
            List<ThamGia> dsTG = data.ThamGias.Where(mtg=>mtg.MaSach == maS).ToList();
            ViewBag.tg = dsTG;
            return View(s);
        }
        public ActionResult IndexTheoChuDE(int maCD)
        {
            List<ChuDe> dsCD = data.ChuDes.ToList();
            return View(dsCD);
        }
        public ActionResult IndexTheoNXB(int maNXB)
        {
            List<NhaXuatBan> dsNXB = data.NhaXuatBans.ToList();
            return View(dsNXB);
        }
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Search()
        {
            ViewBag.MaChuDe = new SelectList(data.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            return View();
        }
        [HttpPost]
        public ActionResult XLSearch(string txtTuKhoa, int MaChuDe)
        {
            List<Sach> dsS = data.Saches.Where(it=>it.TenSach.Contains(txtTuKhoa) && it.MaChuDe == MaChuDe).ToList();
            return View("Index", dsS);
        }
    }
}
