using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantiyeTakipOtomasyon.Models.Siniflar;

namespace SantiyeTakipOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        SantiyeTakipDBContext c = new SantiyeTakipDBContext();
        public ActionResult Index()
        {
            List<SelectListItem> proListe = (from p in c.Projes.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = p.ProAdi,
                                                 Value = p.ProjeId.ToString()
                                             }).ToList();

            ViewBag.pList = proListe;

            return PartialView("Index");
        }
        [HttpPost]
        public ActionResult ProjeModalAc()
        {

            return PartialView("Index");
        }
        [HttpPost]
        public ActionResult ModalAc()
        {
            List<SelectListItem> tedListe = (from t in c.Tedarikcis.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.TedFirma,
                                                 Value = t.TedarikciId.ToString()
                                             }).ToList();
            ViewBag.tList = tedListe;

            List<SelectListItem> odListe = (from o in c.OdemeSeklis.ToList()
                                            select new SelectListItem
                                            {
                                                Text = o.OdSekliAdi,
                                                Value = o.OdemeSekliId.ToString()
                                            }).ToList();

            ViewBag.oList = odListe;

            return PartialView("FaturaEkle");
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int? id)
        {
            List<SelectListItem> tedListe = (from t in c.Tedarikcis.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.TedFirma,
                                                 Value = t.TedarikciId.ToString()
                                             }).ToList();
            ViewBag.tList = tedListe;

            List<SelectListItem> odListe = (from o in c.OdemeSeklis.ToList()
                                            select new SelectListItem
                                            {
                                                Text = o.OdSekliAdi,
                                                Value = o.OdemeSekliId.ToString()
                                            }).ToList();

            ViewBag.oList = odListe;

            var fatGet = c.Faturas.Find(id);
            return PartialView("FaturaGetir", fatGet);
        }
        public ActionResult FaturaGuncelle(Fatura p)
        {
            var fat = c.Faturas.Find(p.FaturaId);
            fat.FatSeri = p.FatSeri;
            fat.FatSiraNo = p.FatSiraNo;
            fat.FatTarihi = p.FatTarihi;
            fat.TedarikciId = p.TedarikciId;
            fat.OdemeSekliId = p.OdemeSekliId;
            c.SaveChanges();
            return RedirectToAction("FaturaDinamik");
        }
        public ActionResult FaturaDetay(int? id)
        {
            var fd = c.FaturaDetays.Where(x => x.FaturaId == id).OrderBy(x => x.FaturaDetayId).ToList();
            var fatSeri = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.FatSeri).FirstOrDefault();
            var fatSira = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.FatSiraNo).FirstOrDefault();
            var firAd = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.Tedarikci.TedFirma).FirstOrDefault();
            var fatTarihi = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.FatTarihi).FirstOrDefault();

            ViewBag.FSeri = fatSeri;
            ViewBag.FSira = fatSira;
            ViewBag.FirmaAd = firAd;
            ViewBag.FaturaTarihi = fatTarihi.ToString("d");

            return PartialView("FaturaDetay", fd);
        }
        [HttpPost]
        public ActionResult ModalFaturaDetayAc(int id)
        {
            var FatId = c.Faturas.Where(i => i.FaturaId == id).Select(f => f.FaturaId).FirstOrDefault();
            var FatSeri = c.Faturas.Where(f => f.FaturaId == id).Select(s => s.FatSeri).FirstOrDefault();
            var FatSiraNo = c.Faturas.Where(f => f.FaturaId == id).Select(s => s.FatSiraNo).FirstOrDefault();
            var FatTarihi = c.Faturas.Where(f => f.FaturaId == id).Select(t => t.FatTarihi).FirstOrDefault();
            var FatFirma = c.Faturas.Where(f => f.FaturaId == id).Select(i => i.Tedarikci.TedFirma).FirstOrDefault();
            var FatTutari = c.Faturas.Where(f => f.FaturaId == id).Select(t => t.FatToplami).FirstOrDefault();
            var FatKdvTutari = c.Faturas.Where(f => f.FaturaId == id).Select(k => k.FatKdvToplami).FirstOrDefault();
            var FatOdenecekTutar = c.Faturas.Where(f => f.FaturaId == id).Select(o => o.FatOdenecekTutar).FirstOrDefault();

            List<SelectListItem> biListe = (from b in c.Birims.OrderBy(b => b.BirimId).ToList()
                                            select new SelectListItem
                                            {
                                                Text = b.BirimAdi,
                                                Value = b.BirimId.ToString()
                                            }).ToList();

            List<SelectListItem> kdvListe = (from k in c.Kdvs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = k.KdvAdi,
                                                 Value = k.KdvId.ToString()
                                             }).ToList();

            List<SelectListItem> dovizListe = (from d in c.Dovizs.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = d.DovizCinsi,
                                                   Value = d.DovizId.ToString()
                                               }).ToList();

            ViewBag.fId = FatId;
            ViewBag.fSeri = FatSeri;
            ViewBag.fSiraNo = FatSiraNo;
            ViewBag.fTarihi = FatTarihi.ToString("d");
            ViewBag.fTutari = FatTutari;
            ViewBag.fKdvTutari = FatKdvTutari;
            ViewBag.fOdenecekTutar = FatOdenecekTutar;
            ViewBag.fFirma = FatFirma;
            ViewBag.bList = biListe;
            ViewBag.kList = kdvListe;
            ViewBag.dList = dovizListe;

            return PartialView("FaturaDetayEkle");
        }
        [HttpGet]
        public ActionResult FaturaDetayEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult FaturaDetayEkle(FaturaDetay p)
        {
            var fId = p.FaturaId;
            c.FaturaDetays.Add(p);
            c.SaveChanges();

            var FdTutarToplam = c.FaturaDetays.Where(x => x.FaturaId == fId).Sum(x => x.FdTutar);
            var FdKdvTutarToplam = c.FaturaDetays.Where(x => x.FaturaId == fId).Sum(x => x.KdvTutar);
            var FatToplam = FdTutarToplam + FdKdvTutarToplam;

            var f = c.Faturas.Find(fId);
            f.FatToplami = FdTutarToplam;
            f.FatKdvToplami = FdKdvTutarToplam;
            f.FatOdenecekTutar = FatToplam;
            c.SaveChanges();
            return RedirectToAction("FaturaDinamik");
        }
        [HttpPost]
        public ActionResult ProjeSecim(int ProId)
        {
            return View("FaturaDinamik");
        }
        public ActionResult FaturaDinamik(int? id)
        {
            var proId = id;
            FaturaFaturaDetay fd = new FaturaFaturaDetay();
            fd.FaturaBaslik = c.Faturas.OrderBy(x => x.FaturaId).Where(p => p.ProjeId == id).ToList();
            fd.FaturaDetaylar = c.FaturaDetays.ToList();

            var ProjeAdi = c.Projes.Where(p => p.ProjeId == proId).Select(a => a.ProAdi).FirstOrDefault();

            ViewBag.proAd = ProjeAdi;

            List<SelectListItem> tedListe = (from t in c.Tedarikcis.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.TedFirma,
                                                 Value = t.TedarikciId.ToString()
                                             }).ToList();
            ViewBag.tList = tedListe;

            List<SelectListItem> odListe = (from o in c.OdemeSeklis.ToList()
                                            select new SelectListItem
                                            {
                                                Text = o.OdSekliAdi,
                                                Value = o.OdemeSekliId.ToString()
                                            }).ToList();

            ViewBag.oList = odListe;

            List<SelectListItem> biListe = (from b in c.Birims.OrderBy(b => b.BirimId).ToList()
                                            select new SelectListItem
                                            {
                                                Text = b.BirimAdi,
                                                Value = b.BirimId.ToString()
                                            }).ToList();

            ViewBag.bList = biListe;

            List<SelectListItem> kdvListe = (from k in c.Kdvs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = k.KdvAdi,
                                                 Value = k.KdvId.ToString()
                                             }).ToList();

            ViewBag.kList = kdvListe;

            List<SelectListItem> dovizListe = (from d in c.Dovizs.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = d.DovizCinsi,
                                                   Value = d.DovizId.ToString()
                                               }).ToList();

            ViewBag.dList = dovizListe;

            return View(fd);
        }
        public ActionResult FaturaKaydet(string FatSeri, string FatSiraNo, DateTime FatTarihi, int TedarikciId, int OdemeSekliId, decimal FatToplami, decimal FatKdvToplami, decimal FatOdenecekTutar, FaturaDetay[] Detaylar)
        {
            Fatura f = new Fatura();
            f.FatSeri = FatSeri;
            f.FatSiraNo = FatSiraNo;
            f.FatTarihi = FatTarihi;
            f.TedarikciId = TedarikciId;
            f.OdemeSekliId = OdemeSekliId;
            f.FatToplami = FatToplami;
            f.FatKdvToplami = FatKdvToplami;
            f.FatOdenecekTutar = FatOdenecekTutar;
            c.Faturas.Add(f);
            foreach (var d in Detaylar)
            {
                FaturaDetay fd = new FaturaDetay();
                fd.FdCinsi = d.FdCinsi;
                fd.FdMiktar = d.FdMiktar;
                fd.BirimId = d.BirimId;
                fd.FdBirimFiyat = d.FdBirimFiyat;
                fd.DovizId = d.DovizId;
                fd.FdKur = d.FdKur;
                fd.FdBirimFiyatTl = d.FdBirimFiyatTl;
                fd.KdvId = d.KdvId;
                fd.KdvTutar = d.KdvTutar;
                fd.FdTutar = d.FdTutar;
                fd.FaturaId = d.FaturaDetayId;
                c.FaturaDetays.Add(fd);
            }
            c.SaveChanges();

            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
        public ActionResult FaturaDetayGetir(int? id)
        {
            List<SelectListItem> biListe = (from b in c.Birims.OrderBy(b => b.BirimId).ToList()
                                            select new SelectListItem
                                            {
                                                Text = b.BirimAdi,
                                                Value = b.BirimId.ToString()
                                            }).ToList();

            ViewBag.bList = biListe;

            List<SelectListItem> kdvListe = (from k in c.Kdvs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = k.KdvAdi,
                                                 Value = k.KdvId.ToString()
                                             }).ToList();

            ViewBag.kList = kdvListe;

            List<SelectListItem> dovizListe = (from d in c.Dovizs.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = d.DovizCinsi,
                                                   Value = d.DovizId.ToString()
                                               }).ToList();

            ViewBag.dList = dovizListe;
            var fId = c.FaturaDetays.Where(f => f.FaturaDetayId == id).Select(x => x.FaturaId).FirstOrDefault();
            ViewBag.faturaId = fId;

            var fdGet = c.FaturaDetays.Find(id);

            return PartialView("FaturaDetayGetir", fdGet);
        }
        public ActionResult FaturaDetayGuncelle(FaturaDetay p)
        {
            var fd = c.FaturaDetays.Find(p.FaturaDetayId);
            fd.FdCinsi = p.FdCinsi;
            fd.FdMiktar = p.FdMiktar;
            fd.BirimId = p.BirimId;
            fd.FdBirimFiyat = p.FdBirimFiyat;
            fd.DovizId = p.DovizId;
            fd.FdKur = p.FdKur;
            fd.FdBirimFiyatTl = p.FdBirimFiyatTl;
            fd.KdvId = p.KdvId;
            fd.KdvTutar = p.KdvTutar;
            fd.FdTutar = p.FdTutar;
            c.SaveChanges();

            var FdTutarToplam = c.FaturaDetays.Where(x => x.FaturaId == fd.FaturaId).Sum(x => x.FdTutar);
            var FdKdvTutarToplam = c.FaturaDetays.Where(x => x.FaturaId == fd.FaturaId).Sum(x => x.KdvTutar);
            var FatToplam = FdTutarToplam + FdKdvTutarToplam;

            var f = c.Faturas.Find(fd.FaturaId);
            f.FatToplami = FdTutarToplam;
            f.FatKdvToplami = FdKdvTutarToplam;
            f.FatOdenecekTutar = FatToplam;
            c.SaveChanges();

            var faturaId = p.FaturaId;

            return RedirectToAction("FaturaDetay", new { id = faturaId });
        }
        public ActionResult FaturaDinamikGetir(int? id)
        {
            var fGet = c.Faturas.Find(id);

            return PartialView("FaturaDinamikGetir", fGet);
        }
    }
}