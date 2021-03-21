using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class OdemeSekli
    {
        [Key]
        public int OdemeSekliId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string OdSekliAdi { get; set; }
        public ICollection<Fatura> Faturas { get; set; }
    }
}