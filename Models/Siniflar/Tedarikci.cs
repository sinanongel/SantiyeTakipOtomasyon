using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Tedarikci
    {
        [Key]
        public int TedarikciId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(3)]
        public string TedKod { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(75)]
        public string TedFirma { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TedIlgiliKisi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string TedAdres { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string TedTelefon { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string TedGsm { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TedEposta { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string TedKonu { get; set; }

        public int TedarikturId { get; set; }
        public virtual TedarikTur TedarikTur { get; set; }
        public int IllerId { get; set; }
        public virtual Iller Iller { get; set; }
        public int IlcelerId { get; set; }
        public virtual Ilceler Ilceler { get; set; }

        public ICollection<Fatura> Faturas { get; set; }
    }
}