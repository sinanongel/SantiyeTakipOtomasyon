using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Kdv
    {
        [Key]
        public int KdvId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KdvAdi { get; set; }
        public decimal KdvOran { get; set; }

        public ICollection<FaturaDetay> FaturaDetays { get; set; }

    }
}