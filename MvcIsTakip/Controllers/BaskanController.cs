using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIsTakip.Models;

namespace MvcIsTakip.Controllers
{
    public class BaskanController : Controller
    {
        DBIsTakipEntities db = new DBIsTakipEntities();
       
        // GET: Baskan
        public ActionResult Index()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);

            if (yetkiid==1)
            {
                int personelid = Convert.ToInt32(Session["PersonelId"]);
                var seciliper = (from x in db.TBL_Personel where x.PersonelID == personelid select x).FirstOrDefault();
                var tumıs = (from x in db.Isler select x).ToList();
                ViewBag.seciliper = seciliper;
                ViewBag.tumis = tumıs;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Ata()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 1)
            {
                var yetkipersonel = (from x in db.Yetkiler where x.YetkiTurID == 1 select x).ToList();
                int personelid = Convert.ToInt32(yetkipersonel[0].PersonelID);
                var personeller = (from y in db.TBL_Personel where y.PersonelID != personelid select y).ToList();
                ViewBag.personeller = personeller;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Ata(string txtis, string txtaciklama, int selectper)
        {
            Isler isata = new Isler();
            isata.IsAd = txtis;
            isata.IsAciklama = txtaciklama;
            isata.IsTarih = DateTime.Now;
            isata.IsPersonelID = selectper;
            isata.IsDurum = "İletiliyor.";
            db.Isler.Add(isata);
            db.SaveChanges();
            return RedirectToAction("Index", "Baskan");
        }
        public ActionResult Takipilet()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);
            if (yetkiid == 1)
            {
                int personelid = Convert.ToInt32(Session["PersonelId"]);
                var personeller = (from x in db.TBL_Personel where x.PersonelID != personelid select x).ToList();
                ViewBag.personeller=personeller;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Takipilet(int selectper)
        {
            var secilipersonel = (from x in db.TBL_Personel where x.PersonelID == selectper select x).FirstOrDefault();
            //Tempdata secilen veriyi farklı bir view a gönderir.
            TempData["secilipersonel"] = secilipersonel;
            return RedirectToAction("Takip", "Baskan");
        }
        public ActionResult Takip()
        {
            int yetkiid = Convert.ToInt32(Session["Yetkiid"]);

            if (yetkiid == 1)
            {
                TBL_Personel personel = (TBL_Personel)TempData["secilipersonel"];
                var isler = (from x in db.Isler where x.IsPersonelID == personel.PersonelID select x).ToList();
                ViewBag.isler = isler;
                ViewBag.secilipersonel = personel;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}