using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class PersonelPuantaj
    {
        [Key]
        public int PersonelPuantajId { get; set; }
        public int PuaYil { get; set; }
        public int PuaAy { get; set; }
        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
        public bool? PuaGun1 { get; set; }
        public bool? PuaGun2 { get; set; }
        public bool? PuaGun3 { get; set; }
        public bool? PuaGun4 { get; set; }
        public bool? PuaGun5 { get; set; }
        public bool? PuaGun6 { get; set; }
        public bool? PuaGun7 { get; set; }
        public bool? PuaGun8 { get; set; }
        public bool? PuaGun9 { get; set; }
        public bool? PuaGun10 { get; set; }
        public bool? PuaGun11 { get; set; }
        public bool? PuaGun12 { get; set; }
        public bool? PuaGun13 { get; set; }
        public bool? PuaGun14 { get; set; }
        public bool? PuaGun15 { get; set; }
        public bool? PuaGun16 { get; set; }
        public bool? PuaGun17 { get; set; }
        public bool? PuaGun18 { get; set; }
        public bool? PuaGun19 { get; set; }
        public bool? PuaGun20 { get; set; }
        public bool? PuaGun21 { get; set; }
        public bool? PuaGun22 { get; set; }
        public bool? PuaGun23 { get; set; }
        public bool? PuaGun24 { get; set; }
        public bool? PuaGun25 { get; set; }
        public bool? PuaGun26 { get; set; }
        public bool? PuaGun27 { get; set; }
        public bool? PuaGun28 { get; set; }
        public bool? PuaGun29 { get; set; }
        public bool? PuaGun30 { get; set; }
        public bool? PuaGun31 { get; set; }
        public int? PuaTopCalisma { get; set; }
    }
}