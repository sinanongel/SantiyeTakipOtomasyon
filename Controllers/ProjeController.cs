using SantiyeTakipOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantiyeTakipOtomasyon.Controllers
{
    public class ProjeController : Controller
    {
        // GET: Proje
        SantiyeTakipDBContext c = new SantiyeTakipDBContext();
        public ActionResult Index()
        {
            var liste = c.Projes.OrderBy(p => p.ProjeId).ToList();
            return View(liste);
        }
        [HttpPost]
        public ActionResult ModalAc()
        {
            List<SelectListItem> ilListe = (from t in c.Illers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = t.Sehir,
                                                Value = t.IllerId.ToString()
                                            }).ToList();
            ViewBag.iList = ilListe;

            List<SelectListItem> durListe = (from d in c.ProDurums.ToList()
                                            select new SelectListItem
                                            {
                                                Text = d.Durum,
                                                Value = d.ProDurumId.ToString()
                                            }).ToList();
            ViewBag.dList = durListe;

            return PartialView("ProjeEkle");
        }
        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ProjeEkle(Proje p)
        {
            if(p.ProSozlesmeTarihi == null)
            {

            }
            c.Projes.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult IlceListe(int IlId)
        {
            List<Ilceler> ilceList = c.Ilcelers.Where(i => i.IllerId == IlId).OrderBy(i => i.IlceAdi).ToList();

            List<SelectListItem> ilceListe = (from i in ilceList
                                              select new SelectListItem
                                              {
                                                  Text = i.IlceAdi,
                                                  Value = i.IlcelerId.ToString()
                                              }).ToList();

            return Json(ilceListe, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProjeGetir(int? id)
        {
            var pGet = c.Projes.Find(id);

            List<SelectListItem> ilListe = (from t in c.Illers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = t.Sehir,
                                                Value = t.IllerId.ToString()
                                            }).ToList();
            ViewBag.iList = ilListe;

            List<SelectListItem> durListe = (from d in c.ProDurums.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = d.Durum,
                                                 Value = d.ProDurumId.ToString()
                                             }).ToList();
            ViewBag.dList = durListe;

            var il = c.Projes.Where(x => x.ProjeId == id).FirstOrDefault();
            List<Ilceler> ilceList = c.Ilcelers.Where(i => i.IllerId == il.IllerId).OrderBy(i => i.IlceAdi).ToList();

            List<SelectListItem> ilceListe = (from i in ilceList
                                              select new SelectListItem
                                              {
                                                  Text = i.IlceAdi,
                                                  Value = i.IlcelerId.ToString()
                                              }).ToList();

            ViewBag.ilcList = ilceListe;

            return PartialView("ProjeGetir", pGet);
        }
        public ActionResult ProjeGuncelle(Proje p)
        {
            var pro = c.Projes.Find(p.ProjeId);
            pro.ProAdi = p.ProAdi;
            pro.ProAdres = p.ProAdres;
            pro.IllerId = p.IllerId;
            pro.IlcelerId = p.IlcelerId;
            pro.ProMusavir = p.ProMusavir;
            pro.ProYapiDenetim = p.ProYapiDenetim;
            pro.ProSozlesmeTarihi = p.ProSozlesmeTarihi;
            pro.ProYerTeslimTarihi = p.ProYerTeslimTarihi;
            pro.ProIseBaslamaTarihi = p.ProIseBaslamaTarihi;
            pro.ProIsinBitisTarihi = p.ProIsinBitisTarihi;
            pro.ProSozlesmeSuresi = p.ProSozlesmeSuresi;
            pro.ProSozlesmeBedeli = p.ProSozlesmeBedeli;
            pro.ProDurumId = p.ProDurumId;
            pro.ProSureUzatimi1 = p.ProSureUzatimi1;
            pro.ProSureUzatimi2 = p.ProSureUzatimi2;
            pro.ProSureUzatimi3 = p.ProSureUzatimi3;
            pro.ProKesifArtisi1 = p.ProKesifArtisi1;
            pro.ProKesifArtisi2 = p.ProKesifArtisi2;
            pro.ProKesifArtisi3 = p.ProKesifArtisi3;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult ProjeBilgi(int? id)
        {
            ViewBag.ProAdi = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProAdi).FirstOrDefault();
            ViewBag.ProAdres = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProAdres).FirstOrDefault();
            ViewBag.Sehir = c.Projes.Where(p => p.ProjeId == id).Select(x => x.Iller.Sehir).FirstOrDefault();
            ViewBag.Ilce = c.Projes.Where(p => p.ProjeId == id).Select(x => x.Ilceler.IlceAdi).FirstOrDefault();
            ViewBag.ProMusavir = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProMusavir).FirstOrDefault();
            ViewBag.ProYapiDenetim = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProYapiDenetim).FirstOrDefault();
            ViewBag.ProSozlesmeTarihi = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProSozlesmeTarihi).FirstOrDefault();
            ViewBag.ProYerTeslimTarihi = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProYerTeslimTarihi).FirstOrDefault();
            ViewBag.ProIseBaslamaTarihi = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProIseBaslamaTarihi).FirstOrDefault();
            ViewBag.ProIsinBitisTarihi = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProIsinBitisTarihi).FirstOrDefault();
            ViewBag.ProSozlesmeSuresi = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProSozlesmeSuresi).FirstOrDefault();
            ViewBag.ProSozlesmeBedeli = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProSozlesmeBedeli).FirstOrDefault();
            ViewBag.ProDurum = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProDurum.Durum).FirstOrDefault();

            ViewBag.ProSureUzatimi1 = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProSureUzatimi1).FirstOrDefault();
            ViewBag.ProSureUzatimi2 = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProSureUzatimi2).FirstOrDefault();
            ViewBag.ProSureUzatimi3 = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProSureUzatimi3).FirstOrDefault();

            ViewBag.ProKesifArtisi1 = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProKesifArtisi1).FirstOrDefault();
            ViewBag.ProKesifArtisi2 = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProKesifArtisi2).FirstOrDefault();
            ViewBag.ProKesifArtisi3 = c.Projes.Where(p => p.ProjeId == id).Select(x => x.ProKesifArtisi3).FirstOrDefault();

            return PartialView("ProjeBilgi");
        }
    }
}