using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        eTicaretEntities7 db = new eTicaretEntities7();

        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var values = db.User.FirstOrDefault(x => x.UserName== user.UserName && x.Password == user.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["UserName"] = values.UserName.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
           
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }


    }
}