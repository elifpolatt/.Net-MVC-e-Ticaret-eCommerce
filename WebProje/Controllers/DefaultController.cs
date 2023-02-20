using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class DefaultController : Controller
    {
        eTicaretEntities7 db = new eTicaretEntities7();

        // GET: Default

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult BannerSlider()
        {
            var values = db.SliderTable.ToList();
            return PartialView(values);
        }
        public PartialViewResult Ozellik()
        {
            var values = db.SiteOzellik.ToList();
            return PartialView(values);
        }
        public PartialViewResult ContainerShop()
        {
            var values = db.Urun.Take(8).ToList();
            return PartialView(values);
        }
        public PartialViewResult ContainerShop1()
        {
            var values = db.Urun.OrderByDescending(p => p.Id).Take(8).ToList();
            return PartialView(values);
        }
        public PartialViewResult BannerTable()
        {
            var values = db.BannerTable.ToList();
            return PartialView(values);
        }

        public PartialViewResult BottomBanner()
        {
            var values = db.BottomBanner.ToList();
            return PartialView(values);   
        }


    }
}