using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Aylar
    {
        [Key]
        public int AylarId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(7)]
        public string Ay { get; set; }
    }
}