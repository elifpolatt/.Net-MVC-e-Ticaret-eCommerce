using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        eTicaretEntities7 db = new eTicaretEntities7();    
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shop()
        {
            return View();
        }
        public PartialViewResult Products() {

            var values = db.Urun.ToList();
            return PartialView(values);

        }
        public PartialViewResult PageHeader()
        {
            //var values = db.PageHeader.Find();
           var values = db.PageHeader.Take(1).ToList();
            return PartialView(values);
        }
    }
}