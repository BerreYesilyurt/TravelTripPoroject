using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet] /*HttpGet metodunu kullanıyoruz. Sayfa yüklenirken karşımıza çıkacak olan sayfanın getirilmesi işlemi.*/
        public ActionResult YeniBlogEkle()
        {

            return View(); /*Sadece sayfanın geri döndürülmemesi, haricinde hiçbir işlemin yapılmaması.*/
        }

        [HttpPost] /*Üstteki metodun aynısı ama çeşitli ekleme vs. işlemlerinde kullanılan metot. Ayrıca isim aynı olduğu için parametre çağırmak gerekiyor.*/
        public ActionResult YeniBlogEkle(Blog p)
        {
            c.Blogs.Add(p); // p parametresinden gelen yani sayfadaki textboxlardan gelen değerlerin Blog tablosuna eklenmesi
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl); // Sayfayı döndürürken bl'den gelen değerleri de getir.
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var guncel = c.Blogs.Find(b.ID);
            guncel.Aciklama = b.Aciklama;
            guncel.Baslik = b.Baslik;
            guncel.BlogImage = b.BlogImage;
            guncel.Tarih = b.Tarih;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        //public ActionResult YorumGetir(int id)
        //{
        //    var y = c.Yorumlars.Find(id);
        //    return View("YorumGetir", y);


        //}

        //public ActionResult YorumGuncelle(Yorumlar y)
        //{
        //    var yg = c.Yorumlars.Find(y.ID);
        //    yg.KullaniciAdi = y.KullaniciAdi;
        //    yg.Mail = y.Mail;
        //    yg.Yorum = y.Yorum;
        //    c.SaveChanges();
        //    return RedirectToAction("Index");



        //}
    }
}