using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class FaturaDetay
    {
        [Key]
        public int FaturaDetayId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string FdCinsi { get; set; }
        public int FdMiktar { get; set; }
        public decimal FdBirimFiyat { get; set; }
        public decimal FdKur { get; set; }
        public decimal FdBirimFiyatTl { get; set; }
        public decimal KdvTutar { get; set; }
        public decimal FdTutar { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string FdAciklama { get; set; }

        public int FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }
        public int BirimId { get; set; }
        public virtual Birim Birim { get; set; }
        public int KdvId { get; set; }
        public virtual Kdv Kdv { get; set; }
        public int DovizId { get; set; }
        public virtual Doviz Doviz { get; set; }
    }
}