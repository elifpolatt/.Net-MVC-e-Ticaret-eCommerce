using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class MusteriLoginController : Controller
    {
        // GET: MusteriLogin

        eTicaretEntities7 db = new eTicaretEntities7();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Musteri1 musteri)
        {
            var values = db.Musteri1.FirstOrDefault(x=>x.EMail == musteri.EMail && x.Sifre == musteri.Sifre);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.EMail, false);
                Session["EMail"] = values.EMail.ToString();
                Session["Adi"] = values.Adi.ToString();
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return View();
            }

            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "MusteriLogin");
        }
        [HttpGet]
        public PartialViewResult Create()
        {
            var values = db.Musteri1.ToList();
            return PartialView(values);
        }
        [HttpPost]

        public ActionResult Create(Musteri1 yeni)
        {
            eTicaretEntities7 db = new eTicaretEntities7();
            Musteri1 model = new Musteri1();
            model.Adi = yeni.Adi.Trim();
            model.Soyadi = yeni.Soyadi.Trim();
            model.Sifre = yeni.Sifre.Trim();
            model.EMail = yeni.EMail.Trim();
            db.Musteri1.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "MusteriLogin");
        }
    }
}