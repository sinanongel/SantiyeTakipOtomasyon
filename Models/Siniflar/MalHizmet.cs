using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class MalHizmet
    {
        [Key]
        public int MalHizmetId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string MalHizmetAdi { get; set; }

        public int BirimId { get; set; }
        public virtual Birim Birim { get; set; }
        public int MalHizmetGrupId { get; set; }
        public virtual MalHizmetGrup MalHizmetGrup { get; set; }
        public ICollection<FaturaDetay> FaturaDetays { get; set; }
    }
}