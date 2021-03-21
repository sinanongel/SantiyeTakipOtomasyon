using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantiyeTakipOtomasyon.Models.Siniflar;

namespace SantiyeTakipOtomasyon.Controllers
{
    public class TedarikTurController : Controller
    {
        // GET: TedarikTur
        SantiyeTakipDBContext c = new SantiyeTakipDBContext();
        public ActionResult Index()
        {
            var turListesi = c.TedarikTurs.ToList();
            return View(turListesi);
        }
        [HttpPost]
        public ActionResult ModalAc()
        {
            return PartialView("TedarikTurEkle");
        }
        [HttpGet]
        public ActionResult TedarikTurEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult TedarikTurEkle(TedarikTur t)
        {
            c.TedarikTurs.Add(t);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TedarikTurSil(int id)
        {
            var tedSil = c.TedarikTurs.Find(id);
            c.TedarikTurs.Remove(tedSil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TedarikTurGetir(int? id)
        {
            var tedGet = c.TedarikTurs.Find(id);
            return PartialView("TedarikTurGetir", tedGet);
        }
        public ActionResult TedarikTurGuncelle(TedarikTur t)
        {
            var tur = c.TedarikTurs.Find(t.TedarikTurId);
            tur.TurAd = t.TurAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}