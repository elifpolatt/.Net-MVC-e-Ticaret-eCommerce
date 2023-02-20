using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class SepetController : Controller
    {
        eTicaretEntities7 db = new eTicaretEntities7();
        // GET: Sepet
        public ActionResult Index(int id)
        {
            //sepete ekleme
            if (Session["EMail"] != null)
            {
                var email = Session["EMail"];
                var model = db.Musteri1.FirstOrDefault(p => p.EMail == email);
                var urun = db.Urun.Find(id);
                var sepet = db.Sepet.FirstOrDefault(x => x.MusteriId == model.Id && x.UrunID == id);
                if (model != null)
                {
                    if (sepet != null)
                    {
                        sepet.Miktar++;
                        sepet.ToplamFiyat = urun.Fiyat * sepet.Miktar;
                        db.SaveChanges();
                        return RedirectToAction("Cart", "Cart");
                    }
                    var S = new Sepet
                    {
                        MusteriId = model.Id,
                        UrunID = urun.Id,
                        Miktar = 1,
                        AlisFiyati = urun.Fiyat,
                        ToplamFiyat = urun.Fiyat,
                        Tarih = DateTime.Now,
                        Saat = DateTime.Now
                    };
                    db.Entry(S).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return RedirectToAction("Cart", "Cart");

                }

            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }
        public ActionResult SepetToplamUrunSayisi(int? count)
        {
            if (Session["EMail"] != null)
            {
                var email = Session["EMail"];
                var model = db.Musteri1.FirstOrDefault(p => p.EMail == email);
                count = db.Sepet.Where(x=>x.MusteriId==model.Id).Count();
                ViewBag.Count = count;  
                if (count==0)
                {
                    ViewBag.Count = "";
                }
                return PartialView();
            }
            return HttpNotFound();
         


        }
        public void DinamikMiktar(int id,decimal miktari)
        {
            var model = db.Sepet.Find(id);
            model.Miktar = miktari;
            model.ToplamFiyat = model.AlisFiyati*model.Miktar;
            db.SaveChanges();
        }
        public ActionResult SepetUrunSil(int id)
        {
            var model = db.Sepet.Find(id);
            db.Sepet.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Cart", "Cart");
        }
    }
}