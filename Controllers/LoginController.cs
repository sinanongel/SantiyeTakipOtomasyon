using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SantiyeTakipOtomasyon.Models.Siniflar;

namespace SantiyeTakipOtomasyon.Controllers
{
    [AllowAnonymous] //Tüm kullanıcıların login sayfasına ulaşabilmesi için
    public class LoginController : Controller
    {
        SantiyeTakipDBContext c = new SantiyeTakipDBContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Kullanici p)
        {
            var kullanici = c.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, false);
                return RedirectToAction("Index", "Tedarikci");
            }
            else
            {
                return View();
            }
        }
    }
}