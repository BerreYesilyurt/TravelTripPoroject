using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TravelTripProject.Models.Siniflar
{
    public class AnaSayfa
    {
        [Key] // Sınıfın birincil anahtarı ID
        public int ID { get; set; }
        public  string Baslik { get; set; }
        public string Aciklama { get; set; }

    }
}