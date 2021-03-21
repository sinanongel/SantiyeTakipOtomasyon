using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SantiyeTakipOtomasyon.Models.Siniflar
{
    public class SantiyeTakipDBContext : DbContext
    {
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<FaturaDetay> FaturaDetays { get; set; }
        public DbSet<Ilceler> Ilcelers { get; set; }
        public DbSet<Iller> Illers { get; set; }
        public DbSet<Kdv> Kdvs { get; set; }
        public DbSet<OdemeSekli> OdemeSeklis { get; set; }
        public DbSet<Tedarikci> Tedarikcis { get; set; }
        public DbSet<TedarikTur> TedarikTurs { get; set; }
        public DbSet<Doviz> Dovizs { get; set; }
        public DbSet<Proje> Projes { get; set; }
        public DbSet<ProDurum> ProDurums { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<PersonelDetay> PersonelDetays { get; set; }
        public DbSet<PersonelPuantaj> PersonelPuantajs { get; set; }
        public DbSet<CalismaDurum> CalismaDurums { get; set; }
        public DbSet<PersonelIzin> PersonelIzins { get; set; }
        public DbSet<IzinTuru> IzinTurus { get; set; }
        public DbSet<Aylar> Aylars { get; set; }
        public DbSet<ResmiTatil> ResmiTatils { get; set; }
    }
}