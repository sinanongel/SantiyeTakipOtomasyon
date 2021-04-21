using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class TedarikTur
    {
        [Key]
        public int TedarikTurId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string TurAd { get; set; }
        public ICollection<Tedarikci> Tedarikcis { get; set; }
    }
}