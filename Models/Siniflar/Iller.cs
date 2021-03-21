using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Iller
    {
        [Key]
        public int IllerId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Sehir { get; set; }

        public ICollection<Ilceler> Ilcelers { get; set; }
        public ICollection<Tedarikci> Tedarikcis { get; set; }
        public ICollection<Proje> Projes { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}