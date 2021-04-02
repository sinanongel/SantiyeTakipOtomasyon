using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantiyeTakipOtomasyon.Models.Siniflar;

namespace SantiyeTakipOtomasyon.Controllers
{
    public class OdemeController : Controller
    {
        SantiyeTakipDBContext c = new SantiyeTakipDBContext();
        // GET: Odeme
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
            var liste = c.Odemes.OrderBy(o => o.OdemeId).Where(x => x.ProjeId == id).ToList();
            var ProjeAdi = c.Projes.Where(p => p.ProjeId == id).Select(a => a.ProAdi).FirstOrDefault();

            ViewBag.proAd = ProjeAdi;
            ViewBag.projeId = id;

            return View("Index", liste);
        }
        [HttpPost]
        public ActionResult ModalAc(int id)
        {
            List<SelectListItem> firmaListe = (from f in c.Tedarikcis.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = f.TedFirma,
                                                   Value = f.TedarikciId.ToString()
                                               }).ToList();

            List<SelectListItem> odemeTurListe = (from o in c.OdemeTurus.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = o.TurAdi,
                                                      Value = o.OdemeTuruId.ToString()
                                                  }).ToList();

            List<SelectListItem> odemeSekliListe = (from o in c.OdemeSeklis.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = o.OdSekliAdi,
                                                        Value = o.OdemeSekliId.ToString()
                                                    }).ToList();

            ViewBag.fListe = firmaListe;
            ViewBag.oTListe = odemeTurListe;
            ViewBag.oSListe = odemeSekliListe;
            ViewBag.projeId = id;

            return PartialView("OdemeEkle");
        }
        [HttpGet]
        public ActionResult OdemeEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult OdemeEkle(Odeme p)
        {
            c.Odemes.Add(p);
            c.SaveChanges();
            var projeId = p.ProjeId;
            return RedirectToAction("ListeGetir", new { id = projeId });
        }
        public ActionResult OdemeGetir(int? id)
        {
            var odemeGetir = c.Odemes.Find(id);
            var proId = c.Odemes.Where(x => x.OdemeId == id).Select(p => p.ProjeId).FirstOrDefault();

            List<SelectListItem> firmaListe = (from f in c.Tedarikcis.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = f.TedFirma,
                                                   Value = f.TedarikciId.ToString()
                                               }).ToList();

            List<SelectListItem> odemeTurListe = (from o in c.OdemeTurus.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = o.TurAdi,
                                                      Value = o.OdemeTuruId.ToString()
                                                  }).ToList();

            List<SelectListItem> odemeSekliListe = (from o in c.OdemeSeklis.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = o.OdSekliAdi,
                                                        Value = o.OdemeSekliId.ToString()
                                                    }).ToList();

            ViewBag.fListe = firmaListe;
            ViewBag.oTListe = odemeTurListe;
            ViewBag.oSListe = odemeSekliListe;
            ViewBag.projeId = proId;

            return PartialView("OdemeGetir", odemeGetir);
        }
        public ActionResult OdemeGuncelle(Odeme p)
        {
            var odeme = c.Odemes.Find(p.OdemeId);
            odeme.TedarikciId = p.TedarikciId;
            odeme.OdemeTuruId = p.OdemeTuruId;
            odeme.OdemeSekliId = p.OdemeSekliId;
            odeme.OdemeTarihi = p.OdemeTarihi;
            odeme.OdemeTutari = p.OdemeTutari;
            c.SaveChanges();

            var projeId = p.ProjeId;
            return RedirectToAction("ListeGetir", new { id = projeId });
        }
        public ActionResult OdemeSil(int id)
        {
            var projeId = c.Odemes.Where(x => x.OdemeId == id).Select(p => p.ProjeId).FirstOrDefault();
            var odemeSil = c.Odemes.Find(id);
            c.Odemes.Remove(odemeSil);
            c.SaveChanges();

            return RedirectToAction("ListeGetir", new { id = projeId });
        }
    }
}