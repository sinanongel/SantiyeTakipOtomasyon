using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantiyeTakipOtomasyon.Models.Siniflar;

namespace SantiyeTakipOtomasyon.Controllers
{
    public class MalHizmetController : Controller
    {
        SantiyeTakipDBContext c = new SantiyeTakipDBContext();
        // GET: MalHizmet
        public ActionResult Index()
        {
            var liste = c.MalHizmets.ToList();
            return View(liste);
        }
        [HttpPost]
        public ActionResult ModalAc()
        {
            List<SelectListItem> malHizmetListe = (from m in c.MalHizmetGrups.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = m.MalHizmetGrupAdi,
                                                       Value = m.MalHizmetGrupId.ToString()
                                                   }).ToList();

            List<SelectListItem> birimListe = (from b in c.Birims.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = b.BirimAdi,
                                                   Value = b.BirimId.ToString()
                                               }).ToList();

            ViewBag.mhListe = malHizmetListe;
            ViewBag.brmListe = birimListe;

            return PartialView("MalHizmetEkle");
        }
        [HttpGet]
        public ActionResult MalHizmetEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult MalHizmetEkle(MalHizmet p)
        {
            c.MalHizmets.Add(p);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult MalHizmetGetir(int id)
        {
            List<SelectListItem> malHizmetListe = (from m in c.MalHizmetGrups.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = m.MalHizmetGrupAdi,
                                                       Value = m.MalHizmetGrupId.ToString()
                                                   }).ToList();

            List<SelectListItem> birimListe = (from b in c.Birims.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = b.BirimAdi,
                                                       Value = b.BirimId.ToString()
                                                   }).ToList();

            ViewBag.mhListe = malHizmetListe;
            ViewBag.brmListe = birimListe;
            var mlHiz = c.MalHizmets.Find(id);

            return PartialView("MalHizmetGetir", mlHiz);
        }
        public ActionResult MalHizmetGuncelle(MalHizmet p)
        {
            var mlhmt = c.MalHizmets.Find(p.MalHizmetId);
            mlhmt.MalHizmetAdi = p.MalHizmetAdi;
            mlhmt.MalHizmetGrupId = p.MalHizmetGrupId;
            mlhmt.BirimId = p.BirimId;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}