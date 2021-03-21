using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Birim
    {
        [Key]
        public int BirimId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string BirimAdi { get; set; }

        public ICollection<FaturaDetay> FaturaDetays { get; set; }
    }
}