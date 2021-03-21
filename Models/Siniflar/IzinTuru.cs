using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class IzinTuru
    {
        [Key]
        public int IzinTuruId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string IzinTurAd { get; set; }

        public ICollection<PersonelIzin> PersonelIzins { get; set; }
    }
}