using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class MalHizmetGrup
    {
        [Key]
        public int MalHizmetGrupId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string MalHizmetGrupAdi { get; set; }

        public ICollection<MalHizmet> MalHizmets { get; set; }
    }
}