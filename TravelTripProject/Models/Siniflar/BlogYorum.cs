using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Siniflar
{
    public class BlogYorum
    {
        public IEnumerable<Blog> Deger1 { get; set; } //IEnumerable yapısı sayesinde bir view'de birden fazla tablodan veri çekebiliyoruz. Blogun detaylarını görüntüleyebilmek için, hangi blog olduğuna göre o blogun gelmesi ve gelen bloga göre o bloga yapılan yorumların görüntülenmesi gerekiyor.
        public IEnumerable<Yorumlar> Deger2 { get; set; }
        public IEnumerable<Blog> Deger3 { get; set; } // Son blogları alabilmek için
    }
}