using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PerAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PerSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string PerAdres { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string PerTelefon { get; set; }
        public DateTime PerIseGirisTarihi { get; set; }
        public DateTime? PerIstenCikisTarihi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PerGorev { get; set; }
        public string PerCalismaDonemi { get; set; }

        public int IllerId { get; set; }
        public virtual Iller Iller { get; set; }
        public int IlcelerId { get; set; }
        public virtual Ilceler Ilceler { get; set; }
        public int ProjeId { get; set; }
        public virtual Proje Proje { get; set; }

        public ICollection<PersonelDetay> PersonelDetays { get; set; }
        public ICollection<PersonelPuantaj> PersonelPuantajs { get; set; }
        public ICollection<PersonelIzin> personelIzins { get; set; }
    }
}