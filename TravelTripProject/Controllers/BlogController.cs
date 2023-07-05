using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {

        Context c = new Context(); // Context sınıfından bir nesne türettik. Blog'a ulaşabilmek için.
        BlogYorum by = new BlogYorum();
        // GET: Blog
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x=>x.ID).Take(2); // Son eklenene göre azalan sırada sıralamak
            by.Deger2 = c.Yorumlars.OrderByDescending(x => x.ID).Take(2);
            return View(by);
        }

        

        public ActionResult BlogDetay(int id)
        {
            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.BlogId == id).ToList();

            return View(by);

        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id; /*ViewBag Controller üzerinden View’a veri taşımak için kullanılır.*/
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();

        }


    }
}