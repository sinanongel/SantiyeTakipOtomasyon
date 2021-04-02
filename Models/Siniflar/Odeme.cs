using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class Odeme
    {
        [Key]
        public int OdemeId { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public decimal OdemeTutari { get; set; }
        public int TedarikciId { get; set; }
        public virtual Tedarikci Tedarikci { get; set; }
        public int OdemeSekliId { get; set; }
        public virtual OdemeSekli OdemeSekli { get; set; }
        public int OdemeTuruId { get; set; }
        public virtual OdemeTuru OdemeTuru { get; set; }
        public int ProjeId { get; set; }
        public virtual Proje Proje { get; set; }
    }
}