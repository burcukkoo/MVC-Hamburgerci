using KD12MVCHamburger.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KD12MVCHamburger.Controllers
{
    public class SonucController : Controller
    {
        private readonly HamburgerDbContext _hamburgerDbContext;
        public SonucController(HamburgerDbContext hamburgerDbContext)
        {
            _hamburgerDbContext = hamburgerDbContext;
        }
        public IActionResult Index()
        {
            ViewBag.Ciro = _hamburgerDbContext.Siparisler.Sum(x => x.ToplamTutar).ToString("C");
            ViewBag.SiparişAdedi = _hamburgerDbContext.Siparisler.Count();
            ViewBag.MenuAdedi = _hamburgerDbContext.Siparisler.Sum(x => x.Adet);
            var list = _hamburgerDbContext.Siparisler.ToList();
            int toplam = 0;
            foreach (var item in list)
            {
                if (item.Ekstralar != null)
                {
                    toplam += item.Ekstralar.Split(',').Count();
                }
            }
            ViewBag.Ekstralar = toplam;
            return View(_hamburgerDbContext.Siparisler.Include(x => x.SecilenMenu).ToList());
        }
    }
}
