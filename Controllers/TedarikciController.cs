using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantiyeTakipOtomasyon.Models.Siniflar;

namespace SantiyeTakipOtomasyon.Controllers
{
    public class TedarikciController : Controller
    {
        // GET: Tedarikci
        SantiyeTakipDBContext c = new SantiyeTakipDBContext();
        public ActionResult Index()
        {
            var liste = c.Tedarikcis.OrderBy(x => x.TedarikciId).ToList();
            return View(liste);
        }
        [HttpPost]
        public ActionResult ModalAc()
        {
            List<SelectListItem> turListe = (from t in c.TedarikTurs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.TurAd,
                                                 Value = t.TedarikTurId.ToString()
                                             }).ToList();
            ViewBag.tList = turListe;

            List<SelectListItem> ilListe = (from t in c.Illers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = t.Sehir,
                                                Value = t.IllerId.ToString()
                                            }).ToList();

            ViewBag.iList = ilListe;

            return PartialView("TedarikciEkle");
        }
        [HttpGet]
        public ActionResult TedarikciEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult TedarikciEkle(Tedarikci p)
        {
            c.Tedarikcis.Add(p);
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
        public ActionResult TedarikciGetir(int? id)
        {
            List<SelectListItem> turListe = (from tl in c.TedarikTurs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = tl.TurAd,
                                                 Value = tl.TedarikTurId.ToString()
                                             }).ToList();
            ViewBag.tList = turListe;

            List<SelectListItem> ilListe = (from i in c.Illers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Sehir,
                                                Value = i.IllerId.ToString()
                                            }).ToList();

            ViewBag.iList = ilListe;

            var il = c.Tedarikcis.Where(x => x.TedarikciId == id).FirstOrDefault();
            List<Ilceler> ilceList = c.Ilcelers.Where(i => i.IllerId == il.IllerId).OrderBy(i => i.IlceAdi).ToList();

            List<SelectListItem> ilceListe = (from i in ilceList
                                              select new SelectListItem
                                              {
                                                  Text = i.IlceAdi,
                                                  Value = i.IlcelerId.ToString()
                                              }).ToList();

            ViewBag.ilcList = ilceListe;

            var tedGet = c.Tedarikcis.Find(id);
            return PartialView("TedarikciGetir", tedGet);
        }
        public ActionResult TedarikciGuncelle(Tedarikci p)
        {
            var ted = c.Tedarikcis.Find(p.TedarikciId);
            ted.TedKod = p.TedKod;
            ted.TedFirma = p.TedFirma;
            ted.TedIlgiliKisi = p.TedIlgiliKisi;
            ted.TedAdres = p.TedAdres;
            ted.IllerId = p.IllerId;
            ted.IlcelerId = p.IlcelerId;
            ted.TedTelefon = p.TedTelefon;
            ted.TedGsm = p.TedGsm;
            ted.TedEposta = p.TedEposta;
            ted.TedarikturId = p.TedarikturId;
            ted.TedKonu = p.TedKonu;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}