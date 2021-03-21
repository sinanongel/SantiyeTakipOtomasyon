using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class FaturaFaturaDetay
    {
        public IEnumerable<Fatura> FaturaBaslik { get; set; }
        public IEnumerable<FaturaDetay> FaturaDetaylar { get; set; }
    }
}