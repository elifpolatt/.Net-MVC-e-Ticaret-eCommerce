using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
       
        eTicaretEntities7 db = new eTicaretEntities7();
        public ActionResult Cart(decimal? Tutar)
        {
            if (Session["EMail"] != null)
            {
                var email = Session["EMail"];
                var uye = db.Musteri1.FirstOrDefault(x => x.EMail == email);
                var model = db.Sepet.Where(x => x.MusteriId == uye.Id).ToList();
                var kid = db.Sepet.FirstOrDefault(p => p.MusteriId == uye.Id);
                if (model!=null)
                {
                    //boş değilse sepet dolu demektir
                    if (kid==null)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün yoktur";
                    }
                    else
                    {
                        Tutar = db.Sepet.Where(x => x.MusteriId == uye.Id).Sum(x=>x.ToplamFiyat);
                        ViewBag.Tutar = "Toplam tutar = " + Tutar + " TL";
                    }
                    return View(model);
                }

            }
            return HttpNotFound();
            /* var sorgu = db.Sepet.ToList();
             return View(sorgu);*/
        }

        [HttpGet]
        public ActionResult AddtoCart()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddtoCart(Sepet s)
        {
            //if(!ModelState.IsValid)
            //{
            //    return View("AddtoCart");
            //}
            db.Sepet.Add(s);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        public ActionResult DeleteProduct(int id)
        {
            var values = db.Sepet.Find(id);
            db.Sepet.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }



    }
}