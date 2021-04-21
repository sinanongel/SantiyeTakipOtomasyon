using SantiyeTakipOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantiyeTakipOtomasyon.Controllers
{
    public class RaporFaturaController : Controller
    {
        SantiyeTakipDBContext c = new SantiyeTakipDBContext();
        // GET: RaporFatura
        public ActionResult Index()
        {
            var liste = c.FaturaDetays.ToList();
            //List<FaturaDetay> faturaDetay = c.FaturaDetays.ToList();
            //List<Fatura> fatura = c.Faturas.ToList();
            //List<MalHizmet> malHizmet = c.MalHizmets.ToList();
            //List<MalHizmetGrup> malHizmetGrup = c.MalHizmetGrups.ToList();
            //List<Doviz> doviz = c.Dovizs.ToList();
            //List<Birim> birim = c.Birims.ToList();

            //var liste = (from fd in faturaDetay
            //             join f in fatura on fd.FaturaId equals f.FaturaId
            //             join mh in malHizmet on fd.MalHizmetId equals mh.MalHizmetId
            //             join d in doviz on fd.DovizId equals d.DovizId
            //             join b in birim on fd.BirimId equals b.BirimId
            //             join mg in malHizmetGrup on mh.MalHizmetGrupId equals mg.MalHizmetGrupId
            //             group i by new { p.personel_adi, p.personel_soyadi, p.ise_giris_tarihi, f.firma_adi } into g
            //             orderby g.Key.MalHizmetGrupAdi
            //             select new MalzemeListe
            //             {
            //                 MalHizmetGrupAdi = g.Key.MalHizmetGrupAdi,
            //                 MalHizmetAdi = g.Key.MalHizmetAdi,
            //                 FatTarihi = g.Key.FatTarihi,
            //                 FdMiktar = g.Key.FdMiktar,
            //                 BirimAdi = g.Key.BirimAdi,
            //                 DovizCinsi = g.Key.DovizCinsi,
            //                 FdBirimFiyatTl = g.Key.FdBirimFiyatTl
            //             }).ToList();


            return View(liste);
        }
    }
}