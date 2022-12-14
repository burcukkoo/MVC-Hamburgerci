using KD12MVCHamburger.Data;
using KD12MVCHamburger.Models;
using Microsoft.AspNetCore.Mvc;

namespace KD12MVCHamburger.Controllers
{
    public class EkstraMenuController : Controller
    {
        private readonly HamburgerDbContext _hamburgerDbContext;
        public EkstraMenuController(HamburgerDbContext hamburgerDbContext)
        {
            _hamburgerDbContext = hamburgerDbContext;
        }
        public IActionResult Index()
        {
            ViewBag.Menuler = _hamburgerDbContext.Menuler.ToList();
            ViewBag.Ekstralar = _hamburgerDbContext.Ekstralar.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult MenuEkle(MEVM vm)
        {
            Menu menu = new Menu();
            menu.MenuAd = vm.MenuAd;
            menu.Fiyat = vm.Fiyat;
            _hamburgerDbContext.Menuler.Add(menu);
            _hamburgerDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EkstraEkle(MEVM vm)
        {
            Ekstra ekstra = new Ekstra();
            ekstra.EkstraAdı = vm.EkstraAd;
            ekstra.Fiyat = vm.Fiyat;
            _hamburgerDbContext.Ekstralar.Add(ekstra);
            _hamburgerDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult MenuDuzenle(int id)
        {
            Menu menu = _hamburgerDbContext.Menuler.Where(x => x.Id == id).FirstOrDefault();
            return View(menu);
        }
        [HttpPost]
        public IActionResult MenuDuzenle(Menu menu)
        {
            _hamburgerDbContext.Menuler.Update(menu);
            _hamburgerDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EkstraDuzenle(int id)
        {
            Ekstra menu = _hamburgerDbContext.Ekstralar.Where(x => x.Id == id).FirstOrDefault();
            return View(menu);
        }
        [HttpPost]
        public IActionResult EkstraDuzenle(Ekstra ekstra)
        {
            _hamburgerDbContext.Ekstralar.Update(ekstra);
            _hamburgerDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult MenuSil(int id)
        {
            var menu = _hamburgerDbContext.Menuler.Where(x => x.Id == id).FirstOrDefault();
            _hamburgerDbContext.Menuler.Remove(menu);
            _hamburgerDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult EkstraSil(int id)
        {
            var ekstra = _hamburgerDbContext.Ekstralar.Where(x => x.Id == id).FirstOrDefault();
            _hamburgerDbContext.Ekstralar.Remove(ekstra);
            _hamburgerDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
