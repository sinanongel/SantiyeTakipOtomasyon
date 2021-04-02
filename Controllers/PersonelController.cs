using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantiyeTakipOtomasyon.Models.Siniflar;

namespace SantiyeTakipOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        SantiyeTakipDBContext c = new SantiyeTakipDBContext();
        // GET: Personel
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
            var liste = c.Personels.OrderBy(p => p.PersonelId).Where(x => x.ProjeId == id).ToList();
            var ProjeAdi = c.Projes.Where(p => p.ProjeId == id).Select(a => a.ProAdi).FirstOrDefault();

            ViewBag.proAd = ProjeAdi;
            ViewBag.projeId = id;

            return View("Index", liste);
        }
        [HttpPost]
        public ActionResult ModalAc(int id)
        {
            var ProjeAdi = c.Projes.Where(p => p.ProjeId == id).Select(a => a.ProAdi).FirstOrDefault();
            List<SelectListItem> ilListe = (from t in c.Illers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = t.Sehir,
                                                Value = t.IllerId.ToString()
                                            }).ToList();

            ViewBag.iList = ilListe;
            ViewBag.projeId = id;
            ViewBag.proAd = ProjeAdi;

            return PartialView("PersonelEkle");
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            var projeId = p.ProjeId;
            return RedirectToAction("ListeGetir", new { id = projeId });
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
        public ActionResult PersonelGetir(int? id)
        {
            var perGet = c.Personels.Find(id);
            var projeId = c.Personels.Where(p => p.PersonelId == id).Select(x => x.ProjeId).FirstOrDefault();

            List<SelectListItem> ilListe = (from t in c.Illers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = t.Sehir,
                                                Value = t.IllerId.ToString()
                                            }).ToList();
            ViewBag.iList = ilListe;

            var il = c.Personels.Where(x => x.PersonelId == id).FirstOrDefault();
            List<Ilceler> ilceList = c.Ilcelers.Where(i => i.IllerId == il.IllerId).OrderBy(i => i.IlceAdi).ToList();

            List<SelectListItem> ilceListe = (from i in ilceList
                                              select new SelectListItem
                                              {
                                                  Text = i.IlceAdi,
                                                  Value = i.IlcelerId.ToString()
                                              }).ToList();

            ViewBag.ilcList = ilceListe;
            ViewBag.proId = projeId;

            return PartialView("PersonelGetir", perGet);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var per = c.Personels.Find(p.PersonelId);
            per.PerAd = p.PerAd;
            per.PerSoyad = p.PerSoyad;
            per.PerAdres = p.PerAdres;
            per.IllerId = p.IllerId;
            per.IlcelerId = p.IlcelerId;
            per.PerTelefon = p.PerTelefon;
            per.PerIseGirisTarihi = p.PerIseGirisTarihi;
            per.PerIstenCikisTarihi = p.PerIstenCikisTarihi;
            per.PerGorev = p.PerGorev;
            c.SaveChanges();

            var projeId = p.ProjeId;
            return RedirectToAction("ListeGetir", new { id = projeId });
        }
        public ActionResult PersonelIzin(int? id)
        {
            var liste = c.PersonelIzins.OrderBy(p => p.PersonelId).Where(x => x.PersonelId == id).ToList();
            var ProjeId = c.Personels.Where(x => x.PersonelId == id).Select(p => p.ProjeId).FirstOrDefault();
            var ProjeAdi = c.Projes.Where(x => x.ProjeId == ProjeId).Select(p => p.ProAdi).FirstOrDefault();
            var PerAdi = c.Personels.Where(x => x.PersonelId == id).Select(x => x.PerAd).FirstOrDefault();
            var PerSoyad = c.Personels.Where(x => x.PersonelId == id).Select(x => x.PerSoyad).FirstOrDefault();

            ViewBag.proAd = ProjeAdi;
            ViewBag.proId = ProjeId;
            ViewBag.personelId = id;
            ViewBag.personelAd = PerAdi + " " + PerSoyad;

            return View(liste);
        }
        [HttpPost]
        public ActionResult IzinModalAc(int id)
        {
            List<SelectListItem> turListe = (from t in c.IzinTurus.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.IzinTurAd,
                                                 Value = t.IzinTuruId.ToString()
                                             }).ToList();

            ViewBag.tList = turListe;
            ViewBag.personelId = id;

            return PartialView("PersonelIzinEkle");
        }
        [HttpGet]
        public ActionResult PersonelIzinEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult PersonelIzinEkle(PersonelIzin p)
        {
            c.PersonelIzins.Add(p);
            c.SaveChanges();
            var personelId = p.PersonelId;

            return RedirectToAction("PersonelIzin", new { id = personelId });
        }
        [HttpPost]
        public JsonResult Hesaplama(PersonelIzin izin)
        {
            DateTime izBasTar = izin.IzinBaslangicTarihi;
            DateTime izBitTar = izin.IzinBitisTarihi;

            TimeSpan izinSure = izBitTar - izBasTar;
            var izSure = Math.Floor(izinSure.TotalDays + 1);

            var sonuc = izSure;

            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PersonelIzinGetir(int? id)
        {
            var izinGet = c.PersonelIzins.Find(id);
            var perId = c.PersonelIzins.Where(p => p.PersonelIzinId == id).Select(x => x.PersonelId).FirstOrDefault();

            List<SelectListItem> turListe = (from t in c.IzinTurus.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = t.IzinTurAd,
                                                 Value = t.IzinTuruId.ToString()
                                             }).ToList();

            ViewBag.tList = turListe;
            ViewBag.personelId = perId;

            return PartialView("PersonelIzinGetir", izinGet);
        }
        public ActionResult PersonelIzinGuncelle(PersonelIzin p)
        {
            var izin = c.PersonelIzins.Find(p.PersonelIzinId);
            izin.IzinTuruId = p.IzinTuruId;
            izin.IzinBaslangicTarihi = p.IzinBaslangicTarihi;
            izin.IzinBitisTarihi = p.IzinBitisTarihi;
            izin.IzinSuresi = p.IzinSuresi;
            izin.IzinAciklama = p.IzinAciklama;
            c.SaveChanges();

            var personelId = p.PersonelId;
            return RedirectToAction("PersonelIzin", new { id = personelId });
        }
        public ActionResult PuantajProjeSecim()
        {
            List<SelectListItem> proListe = (from p in c.Projes.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = p.ProAdi,
                                                 Value = p.ProjeId.ToString()
                                             }).ToList();

            ViewBag.pList = proListe;

            return PartialView("PuantajProjeSecim");
        }
        public ActionResult PersonelPuantaj(int? id)
        {
            var liste = c.PersonelPuantajs.OrderBy(p => p.PersonelId).ToList();
            //var liste = c.Personels.OrderBy(p => p.PersonelId).Where(x => x.ProjeId == id).ToList();
            var ProjeAdi = c.Projes.Where(p => p.ProjeId == id).Select(a => a.ProAdi).FirstOrDefault();

            List<SelectListItem> ayListe = (from a in c.Aylars.ToList()
                                            select new SelectListItem
                                            {
                                                Text = a.Ay,
                                                Value = a.AylarId.ToString()
                                            }).ToList();

            ViewBag.aList = ayListe;
            ViewBag.proAd = ProjeAdi;
            ViewBag.projeId = id;

            return View(liste);
        }
        public ActionResult PersonelPuantajOlustur(int? id)
        {
            var ay = (DateTime.Now.Month - 2);
            var yil = DateTime.Now.Year;
            var idList = c.Personels.Where(p => p.ProjeId == id).Select(x => x.PersonelId).ToList();
            var gunSayisi = DateTime.DaysInMonth(yil, ay);

            foreach (int perId in idList)
            {
                PersonelPuantaj p = new PersonelPuantaj();

                p.PuaYil = yil;
                p.PuaAy = ay;
                p.PersonelId = perId;
                if (gunSayisi == 31)
                {
                    p.PuaGun1 = false;
                    p.PuaGun2 = false;
                    p.PuaGun3 = false;
                    p.PuaGun4 = false;
                    p.PuaGun5 = false;
                    p.PuaGun6 = false;
                    p.PuaGun7 = false;
                    p.PuaGun8 = false;
                    p.PuaGun9 = false;
                    p.PuaGun10 = false;
                    p.PuaGun11 = false;
                    p.PuaGun12 = false;
                    p.PuaGun13 = false;
                    p.PuaGun14 = false;
                    p.PuaGun15 = false;
                    p.PuaGun16 = false;
                    p.PuaGun17 = false;
                    p.PuaGun18 = false;
                    p.PuaGun19 = false;
                    p.PuaGun20 = false;
                    p.PuaGun21 = false;
                    p.PuaGun22 = false;
                    p.PuaGun23 = false;
                    p.PuaGun24 = false;
                    p.PuaGun25 = false;
                    p.PuaGun26 = false;
                    p.PuaGun27 = false;
                    p.PuaGun28 = false;
                    p.PuaGun29 = false;
                    p.PuaGun30 = false;
                    p.PuaGun31 = false;
                } else if (gunSayisi == 30)
                {
                    p.PuaGun1 = false;
                    p.PuaGun2 = false;
                    p.PuaGun3 = false;
                    p.PuaGun4 = false;
                    p.PuaGun5 = false;
                    p.PuaGun6 = false;
                    p.PuaGun7 = false;
                    p.PuaGun8 = false;
                    p.PuaGun9 = false;
                    p.PuaGun10 = false;
                    p.PuaGun11 = false;
                    p.PuaGun12 = false;
                    p.PuaGun13 = false;
                    p.PuaGun14 = false;
                    p.PuaGun15 = false;
                    p.PuaGun16 = false;
                    p.PuaGun17 = false;
                    p.PuaGun18 = false;
                    p.PuaGun19 = false;
                    p.PuaGun20 = false;
                    p.PuaGun21 = false;
                    p.PuaGun22 = false;
                    p.PuaGun23 = false;
                    p.PuaGun24 = false;
                    p.PuaGun25 = false;
                    p.PuaGun26 = false;
                    p.PuaGun27 = false;
                    p.PuaGun28 = false;
                    p.PuaGun29 = false;
                    p.PuaGun30 = false;
                }
                else if (gunSayisi == 28)
                {
                    p.PuaGun1 = false;
                    p.PuaGun2 = false;
                    p.PuaGun3 = false;
                    p.PuaGun4 = false;
                    p.PuaGun5 = false;
                    p.PuaGun6 = false;
                    p.PuaGun7 = false;
                    p.PuaGun8 = false;
                    p.PuaGun9 = false;
                    p.PuaGun10 = false;
                    p.PuaGun11 = false;
                    p.PuaGun12 = false;
                    p.PuaGun13 = false;
                    p.PuaGun14 = false;
                    p.PuaGun15 = false;
                    p.PuaGun16 = false;
                    p.PuaGun17 = false;
                    p.PuaGun18 = false;
                    p.PuaGun19 = false;
                    p.PuaGun20 = false;
                    p.PuaGun21 = false;
                    p.PuaGun22 = false;
                    p.PuaGun23 = false;
                    p.PuaGun24 = false;
                    p.PuaGun25 = false;
                    p.PuaGun26 = false;
                    p.PuaGun27 = false;
                    p.PuaGun28 = false;
                }
                else if (gunSayisi == 29)
                {
                    p.PuaGun1 = false;
                    p.PuaGun2 = false;
                    p.PuaGun3 = false;
                    p.PuaGun4 = false;
                    p.PuaGun5 = false;
                    p.PuaGun6 = false;
                    p.PuaGun7 = false;
                    p.PuaGun8 = false;
                    p.PuaGun9 = false;
                    p.PuaGun10 = false;
                    p.PuaGun11 = false;
                    p.PuaGun12 = false;
                    p.PuaGun13 = false;
                    p.PuaGun14 = false;
                    p.PuaGun15 = false;
                    p.PuaGun16 = false;
                    p.PuaGun17 = false;
                    p.PuaGun18 = false;
                    p.PuaGun19 = false;
                    p.PuaGun20 = false;
                    p.PuaGun21 = false;
                    p.PuaGun22 = false;
                    p.PuaGun23 = false;
                    p.PuaGun24 = false;
                    p.PuaGun25 = false;
                    p.PuaGun26 = false;
                    p.PuaGun27 = false;
                    p.PuaGun28 = false;
                    p.PuaGun29 = false;
                }
                c.PersonelPuantajs.Add(p);
                c.SaveChanges();
            }
            return View();
        }
    }
}