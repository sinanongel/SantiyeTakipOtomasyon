using System;
using System.Collections.Generic;
using System.IO;
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
            return View("Index");
        }
        public ActionResult ProjeSecim()
        {
            List<SelectListItem> proListe = (from p in c.Projes.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = p.ProAdi,
                                                 Value = p.ProjeId.ToString()
                                             }).ToList();

            ViewBag.pList = proListe;

            return PartialView("ProjeSecim");
        }
        public ActionResult ListeGetir(int? id)
        {
            var liste = c.Faturas.OrderBy(f => f.FaturaId).Where(x => x.ProjeId == id).ToList();
            var ProjeAdi = c.Projes.Where(p => p.ProjeId == id).Select(a => a.ProAdi).FirstOrDefault();

            List<SelectListItem> tedListe = (from t in c.Tedarikcis.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.TedFirma,
                                                 Value = t.TedarikciId.ToString()
                                             }).ToList();

            ViewBag.proAd = ProjeAdi;
            ViewBag.projeId = id;

            return View("Index", liste);
        }
        [HttpPost]
        public ActionResult ModalAc(int id)
        {
            List<SelectListItem> tedListe = (from t in c.Tedarikcis.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.TedFirma,
                                                 Value = t.TedarikciId.ToString()
                                             }).ToList();

            List<SelectListItem> odListe = (from o in c.OdemeSeklis.ToList()
                                            select new SelectListItem
                                            {
                                                Text = o.OdSekliAdi,
                                                Value = o.OdemeSekliId.ToString()
                                            }).ToList();

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

            List<SelectListItem> malHizmetGrup = (from m in c.MalHizmetGrups.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = m.MalHizmetGrupAdi,
                                                   Value = m.MalHizmetGrupId.ToString()
                                               }).ToList();

            ViewBag.tList = tedListe;
            ViewBag.oList = odListe;
            ViewBag.bList = biListe;
            ViewBag.kList = kdvListe;
            ViewBag.dList = dovizListe;
            ViewBag.mhgList = malHizmetGrup;
            ViewBag.projeId = id;

            return PartialView("FaturaEkle");
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult FaturaEkle(string FatSiraNo, DateTime FatTarihi, string FatIrsaliyeNo, DateTime? FatIrsaliyeTarihi, DateTime? FatOnayTarihi, int TedarikciId, int OdemeSekliId, decimal FatToplami, decimal FatKdvToplami, decimal FatOdenecekTutar, int ProjeId, FaturaDetay[] Detaylar)
        {
            Fatura f = new Fatura();
            f.FatSiraNo = FatSiraNo;
            f.FatTarihi = FatTarihi;
            f.FatIrsaliyeNo = FatIrsaliyeNo;
            f.FatIrsaliyeTarihi = FatIrsaliyeTarihi;
            f.FatOnayTarihi = FatOnayTarihi;
            f.TedarikciId = TedarikciId;
            f.OdemeSekliId = OdemeSekliId;
            f.FatToplami = FatToplami;
            f.FatKdvToplami = FatKdvToplami;
            f.FatOdenecekTutar = FatOdenecekTutar;
            f.ProjeId = ProjeId;
            c.Faturas.Add(f);
            foreach (var d in Detaylar)
            {
                FaturaDetay fd = new FaturaDetay();
                fd.MalHizmetId = d.MalHizmetId;
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
        public ActionResult FaturaGetir(int? id)
        {
            var fatGet = c.Faturas.Find(id);
            var proId = c.Faturas.Where(x => x.FaturaId == id).Select(p => p.ProjeId).FirstOrDefault();

            List<SelectListItem> tedListe = (from t in c.Tedarikcis.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.TedFirma,
                                                 Value = t.TedarikciId.ToString()
                                             }).ToList();

            List<SelectListItem> odListe = (from o in c.OdemeSeklis.ToList()
                                            select new SelectListItem
                                            {
                                                Text = o.OdSekliAdi,
                                                Value = o.OdemeSekliId.ToString()
                                            }).ToList();

            ViewBag.tList = tedListe;
            ViewBag.oList = odListe;
            ViewBag.projeId = proId;

            return PartialView("FaturaGetir", fatGet);
        }
        public ActionResult FaturaGuncelle(Fatura p)
        {
            var fat = c.Faturas.Find(p.FaturaId);
            fat.FatSiraNo = p.FatSiraNo;
            fat.FatTarihi = p.FatTarihi;
            fat.TedarikciId = p.TedarikciId;
            fat.OdemeSekliId = p.OdemeSekliId;
            c.SaveChanges();

            var projeId = p.ProjeId;
            return RedirectToAction("ListeGetir", new { id = projeId });
        }
        public ActionResult FaturaDetay(int? id)
        {
            var fd = c.FaturaDetays.OrderBy(f=>f.FaturaDetayId).Where(x => x.FaturaId == id).OrderBy(x => x.FaturaDetayId).ToList();
            var fatSira = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.FatSiraNo).FirstOrDefault();
            var firAd = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.Tedarikci.TedFirma).FirstOrDefault();
            var fatTarihi = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.FatTarihi).FirstOrDefault();
            var projeId = c.Faturas.Where(x => x.FaturaId == id).Select(y => y.ProjeId).FirstOrDefault();
            var projeAdi = c.Projes.Where(x => x.ProjeId == projeId).Select(y => y.ProAdi).FirstOrDefault();

            ViewBag.FSira = fatSira;
            ViewBag.FirmaAd = firAd;
            ViewBag.FaturaTarihi = fatTarihi.ToString("d");
            ViewBag.ProjeId = projeId;
            ViewBag.ProjeAd = projeAdi;
            ViewBag.FaturaId = id;

            return View("FaturaDetay", fd);
        }
        [HttpPost]
        public ActionResult ModalFaturaDetayAc(int id)
        {
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

            List<SelectListItem> malHizmetGrup = (from m in c.MalHizmetGrups.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = m.MalHizmetGrupAdi,
                                                      Value = m.MalHizmetGrupId.ToString()
                                                  }).ToList();

            ViewBag.bList = biListe;
            ViewBag.kList = kdvListe;
            ViewBag.dList = dovizListe;
            ViewBag.mhgList = malHizmetGrup;
            ViewBag.faturaId = id;

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
            return RedirectToAction("FaturaDetay");
        }
        public ActionResult FaturaDinamik(int? id)
        {
            var proId = id;
            FaturaFaturaDetay fd = new FaturaFaturaDetay();
            fd.FaturaBaslik = c.Faturas.OrderBy(x => x.FaturaId).Where(p => p.ProjeId == id).ToList();
            fd.FaturaDetaylar = c.FaturaDetays.ToList();

            var ProjeAdi = c.Projes.Where(p => p.ProjeId == proId).Select(a => a.ProAdi).FirstOrDefault();

            List<SelectListItem> tedListe = (from t in c.Tedarikcis.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.TedFirma,
                                                 Value = t.TedarikciId.ToString()
                                             }).ToList();

            List<SelectListItem> odListe = (from o in c.OdemeSeklis.ToList()
                                            select new SelectListItem
                                            {
                                                Text = o.OdSekliAdi,
                                                Value = o.OdemeSekliId.ToString()
                                            }).ToList();

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

            ViewBag.proAd = ProjeAdi;
            ViewBag.tList = tedListe;
            ViewBag.oList = odListe;
            ViewBag.bList = biListe;
            ViewBag.kList = kdvListe;
            ViewBag.dList = dovizListe;

            return View(fd);
        }
        public ActionResult FaturaKaydet(string FatSiraNo, DateTime FatTarihi, int TedarikciId, int OdemeSekliId, decimal FatToplami, decimal FatKdvToplami, decimal FatOdenecekTutar, FaturaDetay[] Detaylar)
        {
            Fatura f = new Fatura();
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
            List<SelectListItem> mhizListe = (from mh in c.MalHizmets.OrderBy(m => m.MalHizmetAdi).ToList()
                                            select new SelectListItem
                                            {
                                                Text = mh.MalHizmetAdi,
                                                Value = mh.MalHizmetId.ToString()
                                            }).ToList();

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

            List<SelectListItem> malHizmetGrup = (from m in c.MalHizmetGrups.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = m.MalHizmetGrupAdi,
                                                      Value = m.MalHizmetGrupId.ToString()
                                                  }).ToList();

            ViewBag.mhList = mhizListe;
            ViewBag.bList = biListe;
            ViewBag.kList = kdvListe;
            ViewBag.dList = dovizListe;
            ViewBag.mhgList = malHizmetGrup;
            var fId = c.FaturaDetays.Where(f => f.FaturaDetayId == id).Select(x => x.FaturaId).FirstOrDefault();
            ViewBag.faturaId = fId;

            var fdGet = c.FaturaDetays.Find(id);

            return PartialView("FaturaDetayGetir", fdGet);
        }
        public ActionResult FaturaDetayGuncelle(FaturaDetay p)
        {
            var fd = c.FaturaDetays.Find(p.FaturaDetayId);
            fd.MalHizmetId = p.MalHizmetId;
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
        [HttpPost]
        public ActionResult ModalDosya(int id)
        {
            var FatId = c.Faturas.Where(i => i.FaturaId == id).Select(f => f.FaturaId).FirstOrDefault();

            List<SelectListItem> dtListe = (from d in c.DosyaTurus.OrderBy(d => d.DosyaTuruId).ToList()
                                            select new SelectListItem
                                            {
                                                Text = d.DosyaTurAd,
                                                Value = d.DosyaTuruId.ToString()
                                            }).ToList();

            ViewBag.dListe = dtListe;
            ViewBag.fId = FatId;

            return PartialView("DosyaYukle");
        }
        [HttpGet]
        public ActionResult DosyaYukle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult DosyaYukle(Dosya p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Dosya/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.DosyaYolu = "/Dosya/" + dosyaAdi;
            }
            c.Dosyas.Add(p);
            c.SaveChanges();

            var projeId = c.Faturas.Where(x => x.FaturaId == p.FaturaId).Select(y => y.ProjeId).FirstOrDefault();
            return RedirectToAction("ListeGetir", new { id = projeId });
        }
        [HttpPost]
        public JsonResult DosyaListe(int id)
        {
            List<Dosya> dosyaList = c.Dosyas.Where(i => i.FaturaId == id).OrderBy(i => i.DosyaYolu).ToList();

            List<SelectListItem> dListe = (from i in dosyaList
                                              select new SelectListItem
                                              {
                                                  Text = i.DosyaYolu,
                                                  Value = i.DosyaId.ToString()
                                              }).ToList();

            return Json(dListe, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ModalDosyaListe(int id)
        {
            var liste = c.Dosyas.OrderBy(f => f.DosyaId).Where(x => x.FaturaId == id).ToList();

            return PartialView("DosyaListele", liste);
        }
        public ActionResult DosyaListele()
        {
            return PartialView("DosyaListele");
        }
        public FileResult DosyaAc(string dosya)
        {
            Response.AppendHeader("Content-Disposition", "inline; filename" + dosya + ";");

            string yol = AppDomain.CurrentDomain.BaseDirectory + "Dosya/";
            return File(yol + dosya, System.Net.Mime.MediaTypeNames.Application.Pdf, dosya);
        }
        [HttpPost]
        public JsonResult MalHizmetListe(int MhgId)
        {
            List<MalHizmet> malHizmetList = c.MalHizmets.Where(i => i.MalHizmetGrupId == MhgId).OrderBy(i => i.MalHizmetAdi).ToList();

            List<SelectListItem> mhListe = (from m in malHizmetList
                                              select new SelectListItem
                                              {
                                                  Text = m.MalHizmetAdi,
                                                  Value = m.MalHizmetId.ToString()
                                              }).ToList();

            return Json(mhListe, JsonRequestBehavior.AllowGet);
        }
    }
}