using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class PersonelIzin
    {
        [Key]
        public int PersonelIzinId { get; set; }
        public DateTime IzinBaslangicTarihi { get; set; }
        public DateTime IzinBitisTarihi { get; set; }
        public int IzinSuresi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string IzinAciklama { get; set; }

        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
        public int IzinTuruId { get; set; }
        public virtual IzinTuru IzinTuru { get; set; }

    }
}