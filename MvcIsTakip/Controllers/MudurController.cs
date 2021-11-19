using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIsTakip.Models;

namespace MvcIsTakip.Controllers
{
    public class MudurController : Controller
    {
        DBIsTakipEntities db = new DBIsTakipEntities();
        // GET: Mudur

        public ActionResult Index()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid==2)
            {
                int personelid = Convert.ToInt32(Session["PersonelId"]);
                var seciliper = (from x in db.TBL_Personel where x.PersonelID == personelid select x).FirstOrDefault();
                ViewBag.seciliper = seciliper;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult ilet()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 2)
            {
                int personelid = Convert.ToInt32(Session["PersonelId"]);
                var personel = (from x in db.TBL_Personel where x.PersonelID == personelid select x).FirstOrDefault();
                var personeller = (from y in db.TBL_Personel where y.PersonelBirimID == personel.PersonelBirimID select y).ToList();
                ViewBag.personeller = personeller;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult ilet(int selectper)
        {
            var secilen = (from x in db.TBL_Personel where x.PersonelID == selectper select x).FirstOrDefault();
            TempData["secilen"] = secilen;
            return RedirectToAction("Ata", "Mudur");
        }
        [HttpGet]
        public ActionResult Ata()
        {
            TBL_Personel personel = (TBL_Personel)TempData["secilen"];
            var isler = (from x in db.Isler where x.IsPersonelID == personel.PersonelID && x.IsDurum== "İletiliyor" select x).ToList();
            ViewBag.isler = isler;
            ViewBag.personel = personel;
            return View();
        }
        [HttpPost]
        public ActionResult Ata(int IsID)
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 2)
            {
                var tekis = (from x in db.Isler where x.IsID == IsID select x).FirstOrDefault();
                tekis.IsDurum = "yapılıyor.";
                tekis.IletilenTarih = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index", "Mudur");
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult TakipIlet()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 2)
            {
                int personelid = Convert.ToInt32(Session["PersonelId"]);
                var personel = (from x in db.TBL_Personel where x.PersonelID == personelid select x).FirstOrDefault();
                var personeller = (from y in db.TBL_Personel where y.PersonelBirimID == personel.PersonelBirimID select y).ToList();
                ViewBag.personeller = personeller;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult TakipIlet(int selectper)
        {
            var secilen = (from x in db.TBL_Personel where x.PersonelID == selectper select x).FirstOrDefault();
            TempData["secilen"] = secilen;
            return RedirectToAction("Takip", "Mudur");
        }
        public ActionResult Takip()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 2)
            {
                TBL_Personel personel = (TBL_Personel)TempData["secilen"];
                var isler = (from x in db.Isler where x.IsPersonelID == personel.PersonelID select x).ToList();
                ViewBag.isler = isler;
                ViewBag.personel = personel;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Yap()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 2)
            {
                int personelid = Convert.ToInt32(Session["PersonelId"]);
                var isler = (from x in db.Isler where x.IsPersonelID == personelid &&x.IsDurum=="Yapılıyor" select x).ToList();
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
            return RedirectToAction("Index", "Mudur");
        }
    }
}