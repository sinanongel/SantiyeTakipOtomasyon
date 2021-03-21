using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class ProDurum
    {
        [Key]
        public int ProDurumId { get; set; }
        public string Durum { get; set; }
        public ICollection<Proje> Projes { get; set; }
    }
}