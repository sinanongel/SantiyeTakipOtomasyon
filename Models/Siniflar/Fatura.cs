using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string FatSeri { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FatSiraNo { get; set; }
        public DateTime FatTarihi { get; set; }
        public decimal FatToplami { get; set; }
        public decimal FatKdvToplami { get; set; }
        public decimal FatOdenecekTutar { get; set; }
        public bool OdemeDurumu { get; set; }

        public ICollection<FaturaDetay> FaturaDetays { get; set; }

        public int TedarikciId { get; set; }
        public virtual Tedarikci Tedarikci { get; set; }
        public int OdemeSekliId { get; set; }
        public virtual OdemeSekli OdemeSekli { get; set; }
        public int ProjeId { get; set; }
        public virtual Proje Proje { get; set; }
    }
}