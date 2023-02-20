using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        eTicaretEntities7 db = new eTicaretEntities7();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
        public PartialViewResult BlogYazilari()
        {

            var values = db.Blog.OrderByDescending(p=>p.Id).ToList();
            return PartialView(values);
        }
    }
}