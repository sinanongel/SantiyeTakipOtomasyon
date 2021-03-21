using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class PersonelDetay
    {
        [Key]
        public int PersonelDetayId { get; set; }
        public decimal PerMaas { get; set; }
        public decimal PerYemek { get; set; }
        public decimal PerUlasim { get; set; }
        public decimal PerKonaklama { get; set; }

        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
    }
}