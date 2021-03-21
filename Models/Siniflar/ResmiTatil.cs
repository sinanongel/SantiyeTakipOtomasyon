using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class ResmiTatil
    {
        [Key]
        public int ResmiTatilId { get; set; }
        public DateTime Tarih { get; set; }
    }
}