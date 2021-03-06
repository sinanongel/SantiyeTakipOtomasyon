using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Dosya
    {
        [Key]
        public int DosyaId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string DosyaYolu { get; set; }

        public int DosyaTuruId { get; set; }
        public virtual DosyaTuru DosyaTuru { get; set; }
        public int? FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }

    }
}