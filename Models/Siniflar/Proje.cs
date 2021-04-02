using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Proje
    {
        [Key]
        public int ProjeId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ProAdi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ProAdres { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ProMusavir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ProYapiDenetim { get; set; }
        public DateTime ProSozlesmeTarihi { get; set; }
        public DateTime ProYerTeslimTarihi { get; set; }
        public DateTime ProIseBaslamaTarihi { get; set; }
        public DateTime ProIsinBitisTarihi { get; set; }
        public int ProSozlesmeSuresi { get; set; }
        public int ProSureUzatimi1 { get; set; }
        public int ProSureUzatimi2 { get; set; }
        public int ProSureUzatimi3 { get; set; }
        public DateTime ProGeciciKabulTarihi { get; set; }
        public DateTime ProKesinKabulTarihi { get; set; }
        public decimal ProSozlesmeBedeli { get; set; }
        public decimal ProKesifArtisi1 { get; set; }
        public decimal ProKesifArtisi2 { get; set; }
        public decimal ProKesifArtisi3 { get; set; }
        public decimal ProToplamSozlesmeBedeli { get; set; }

        public int? ProDurumId { get; set; }
        public virtual ProDurum ProDurum { get; set; }
        public int IllerId { get; set; }
        public virtual Iller Iller { get; set; }
        public int IlcelerId { get; set; }
        public virtual Ilceler Ilceler { get; set; }

        public ICollection<Fatura> Faturas { get; set; }
        public ICollection<Personel> Personels { get; set; }
        public ICollection<Odeme> Odemes { get; set; }
    }
}