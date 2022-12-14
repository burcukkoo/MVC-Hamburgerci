using KD12MVCHamburger.Data;
using KD12MVCHamburger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace KD12MVCHamburger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HamburgerDbContext _hamburgerDbContext;


        public HomeController(ILogger<HomeController> logger,HamburgerDbContext hamburgerDbContext)
        {
            _logger = logger;
            _hamburgerDbContext = hamburgerDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.Menuler = _hamburgerDbContext.Menuler.ToList();
            ViewBag.Ekstralar = _hamburgerDbContext.Ekstralar.ToList();
            ViewBag.Siparisler = _hamburgerDbContext.Siparisler.Where(x => x.AktifMi).ToList();
            ViewBag.Toplam = _hamburgerDbContext.Siparisler.Where(x => x.AktifMi).Sum(x => x.ToplamTutar);

            return View();
        }

        [HttpPost]
        public IActionResult SiparisEkle(Siparis siparis , string[] ekstralar)
        {
            decimal ekstraToplam = 0;
            string ekstralarT = "";
            foreach (var item in ekstralar)
            {
                var ekstra = _hamburgerDbContext.Ekstralar.Where(x => x.EkstraAdı == item).FirstOrDefault();
                ekstraToplam += ekstra.Fiyat;

                if(ekstralarT == null)
                {
                    ekstralarT = ekstra.EkstraAdı;
                }
                else
                {
                    ekstralarT = ekstralarT + "," + ekstra.EkstraAdı;
                }

                siparis.Ekstralar = ekstralarT;
            }

            var menu = _hamburgerDbContext.Menuler.Where(x => x.Id == siparis.MenuId).FirstOrDefault();
            siparis.SecilenMenu = menu;
            if(siparis.Boyut == null)
            {
                siparis.ToplamTutar = siparis.SecilenMenu.Fiyat + ekstraToplam;
                siparis.Boyut = "Küçük";
            }
            else
            {
                siparis.ToplamTutar = siparis.ToplamTutarHesapla(siparis.Boyut) + ekstraToplam;
            }


            _hamburgerDbContext.Siparisler.Add(siparis);
            _hamburgerDbContext.SaveChanges();
            return RedirectToAction("Index");

           
        }

        public IActionResult SiparisTamamla()
        {
            var list = _hamburgerDbContext.Siparisler.Where(x => x.AktifMi).ToList();
            foreach (var item in list)
            {
                item.AktifMi = false;
                _hamburgerDbContext.Siparisler.Update(item);
                _hamburgerDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}