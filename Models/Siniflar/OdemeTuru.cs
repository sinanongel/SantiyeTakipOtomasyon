using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class OdemeTuru
    {
        [Key]
        public int OdemeTuruId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TurAdi { get; set; }
        public ICollection<Odeme> Odemes { get; set; }
    }
}