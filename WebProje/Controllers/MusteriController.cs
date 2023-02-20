using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        eTicaretEntities7 db = new eTicaretEntities7();


        public ActionResult Index()
        {
            var values = db.Musteri1.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(Musteri1 m)
        {
            db.Musteri1.Add(m); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}