using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class CalismaDurum
    {
        [Key]
        public int CalismaDurumId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CalismaDurumAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2)]
        public string CalismaDurumKod { get; set; }

    }
}