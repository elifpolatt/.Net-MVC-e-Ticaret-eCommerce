using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebProje.Models;
using PagedList;
using PagedList.Mvc;


namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        eTicaretEntities7 db = new eTicaretEntities7();
        // GET: Admin

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult AddProduct()
        {
            //kategorileri dropdownliste aktarmak için
            List<SelectListItem> v = (from c in db.Kategori.ToList()
                                      select new SelectListItem
                                      {
                                          Text = c.Adi,
                                          Value = c.Id.ToString()
                                      }).ToList();
            ViewBag.kategori = v;
            //viewbag veri taşımak için kullanılıyor


            //markaları dropdownliste aktarmak için 
            List<SelectListItem> values = (from i in db.Marka.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Adi,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.markavalues = values;


            //var degerler = db.Urun.ToList();
           
            return View();

        }
        [HttpPost]
        public ActionResult AddProduct(Urun u)
        {
            db.Urun.Add(u);
            db.SaveChanges();  //değişiklikleri kaydet
            return RedirectToAction("Index");
        }

        public ActionResult ProductList(string u,int page=1)
        {

            var values = from x in db.Urun select x;
            if (!string.IsNullOrEmpty(u))
            {
                values = values.Where(y => y.Adi.Contains(u));
            }
            //var values = db.Urun.ToList();

            return View(values.ToList().ToPagedList(page,8));
        }




        //Güncellenecek verileri textboxlara çekmek için 
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {


            List<SelectListItem> v = (from c in db.Kategori.ToList()
                                      select new SelectListItem
                                      {
                                          Text = c.Adi,
                                          Value = c.Id.ToString()
                                      }).ToList();
            ViewBag.kategori = v;
            //viewbag veri taşımak için kullanılıyor


            //markaları dropdownliste aktarmak için 
            List<SelectListItem> values = (from i in db.Marka.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Adi,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.markavalues = values;

            var deger = db.Urun.Find(id);
            return View(deger);
        }
        //Güncelleme işlemi için gerekli kod blogu
        [HttpPost]
        public ActionResult UpdateProduct(Urun u)
        {
            var deger = db.Urun.Find(u.Id);
            deger.Adi = u.Adi;
            deger.Aciklama = u.Aciklama;
            deger.Fiyat = u.Fiyat;
            deger.Resim = u.Resim;
            deger.KategoriID = u.Kategori.Id;
            deger.MarkaID = u.Marka.Id;
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        //Silmek için gerekli komutlar
        public ActionResult DeleteProduct(int id)
        {
            var values = db.Urun.Find(id);
            db.Urun.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }


        //delete işlemi id ile bulunup yapılıyor.
        public ActionResult CategoryList(string k)
        {
            var values = from x in db.Kategori select x;
            if (!string.IsNullOrEmpty(k))
            {
                values = values.Where(y => y.Adi.Contains(k));
            }
            //var values = db.Kategori.ToList();
            return View(values.ToList());
        }


        [HttpGet]

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Kategori k)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCategory");
            }
            db.Kategori.Add(k);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }


        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var v = db.Kategori.Find(id);
            return View(v);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Kategori k)
        {
            var v = db.Kategori.Find(k.Id);
            v.Adi = k.Adi;
            v.Aciklama = k.Aciklama;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            var val = db.Kategori.Find(id);
            db.Kategori.Remove(val);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(Blog b)
        {
            db.Blog.Add(b);
            db.SaveChanges();
            return RedirectToAction("AddBlog");
        }

        public ActionResult BlogList(string b)
        {
            var values = from x in db.Blog select x;
            if (!string.IsNullOrEmpty(b))
            {
                values = values.Where(y => y.Baslik.Contains(b));
            }
            return View(values.ToList());
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var values = db.Blog.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            var v = db.Blog.Find(b.Id);
            v.Baslik = b.Baslik;
            v.Aciklama = v.Aciklama;
            v.Tarih = v.Tarih;
            v.Resim = v.Resim;
            db.SaveChanges();
            return RedirectToAction("BlogList");

        }
        public ActionResult DeleteBlog(int id)
        {
            var val = db.Blog.Find(id);
            db.Blog.Remove(val);
            db.SaveChanges();
            return RedirectToAction("BlogList");
        }

    }

}