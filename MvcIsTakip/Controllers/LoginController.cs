using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIsTakip.Models;

namespace MvcIsTakip.Controllers
{
    public class LoginController : Controller
    {
        DBIsTakipEntities db = new DBIsTakipEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string KullaniciAd, string PersonelParola)
        {
            var personel = (from x in db.TBL_Personel 
                            where x.KullaniciAd == KullaniciAd && x.PersonelParola == PersonelParola 
                            select x).FirstOrDefault();
            if (personel!=null)
            {
                Session["PersonelAd"] = personel.PersonelAd;
                Session["PersonelId"] = personel.PersonelID;

                var yetki = (from y in db.Yetkiler where y.PersonelID == personel.PersonelID select y).FirstOrDefault();
                Session["Yetkiid"] = yetki.YetkiTurID;
                if (yetki.YetkiID==1)
                {
                    return RedirectToAction("Index", "Baskan");
                }
                if (yetki.YetkiID == 2)
                {
                    return RedirectToAction("Index", "Mudur");
                }
                if (yetki.YetkiID == 3)
                {
                    return RedirectToAction("Index", "Memur");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}