using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class PersonelPuantaj
    {
        [Key]
        public int PersonelPuantajId { get; set; }
        public int PuaYil { get; set; }
        public int PuaAy { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(9)]
        public string PuaGunAd { get; set; }
        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
        public int CalismaDurumId { get; set; }
        public virtual CalismaDurum CalismaDurum { get; set; }
    }
}