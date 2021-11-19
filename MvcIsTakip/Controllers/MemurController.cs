using MvcIsTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcIsTakip.Controllers
{
    public class MemurController : Controller
    {
        DBIsTakipEntities db = new DBIsTakipEntities();
        // GET: Memur
        public ActionResult Index()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 3)
            {
                int personelid = Convert.ToInt32(Session["PersonelId"]);
                var isler = (from x in db.Isler where x.IsPersonelID == personelid select x).ToList();
                ViewBag.isler = isler;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Yap()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 3)
            {
                int personelid = Convert.ToInt32(Session["PersonelId"]);
                var isler = (from x in db.Isler where x.IsPersonelID == personelid && x.IsDurum == "Yapılıyor" select x).ToList();
                ViewBag.isler = isler;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Yap(int IsID)
        {
            var tekis = (from x in db.Isler where x.IsID == IsID select x).FirstOrDefault();
            tekis.IsDurum = "Yapıldı";
            tekis.YapilanTarih = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index", "Memur");
        }
        public ActionResult Takip()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 3)
            {
                int personelid = Convert.ToInt32(Session["PersonelId"]);
                var isler = (from x in db.Isler where x.IsPersonelID == personelid select x).ToList();
                ViewBag.isler = isler;
                return View();
            }
            return RedirectToAction("Index", "Login");

        }
    }
}