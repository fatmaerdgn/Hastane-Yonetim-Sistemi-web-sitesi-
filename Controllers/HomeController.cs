using bitirmeMVC5.Models;
using bitirmeMVC5.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bitirmeMVC5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PoliklinikService _poliklinikService;
        private readonly PersonelService _personelService;

        public HomeController(ILogger<HomeController> logger, PoliklinikService poliklinikService, PersonelService personelService)
        {
            _logger = logger;
            _poliklinikService = poliklinikService;
            _personelService = personelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AmeliyatTarihi()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Departments()
        {
            var poliklinikler = _poliklinikService.GetAllPoliklinikler();
            return View(poliklinikler);
        }

        public IActionResult Doctors()
        {
            return View();
        }

        public IActionResult DoktorEkle()
        {
            return View();
        }

        public IActionResult DoktorEkranı()
        {
            return View();
        }

        public IActionResult DoktorGirişi()
        {
            return View();
        }

        public IActionResult HastaGirişi()
        {
            return View();
        }

        public IActionResult HesapOluşturma()
        {
            return View();
        }

        public IActionResult PersonelEkle()
        {
            return View();
        }

        public IActionResult PersonelEkranı()
        {
            return View();
        }

        public IActionResult PersonelGirişi()
        {
            return View("personel_girişi");
        }

        [HttpPost]
        public IActionResult PersonelGirişi(string email, string password)
        {
            if (_personelService.ValidatePersonel(email, password))
            {
                // Giriş başarılı, yönlendirme yapılacak
                return View("personel_ekranı");
            }
            else
            {
                // Giriş başarısız, hata mesajı gösterilecek
                ViewBag.ErrorMessage = "Geçersiz e-posta veya parola.";
                return View("personel_girişi");
            }
        }

        [HttpPost]
        public IActionResult PoliklinikEkle(string poliklinikAdi)
        {
            _poliklinikService.AddPoliklinik(poliklinikAdi);
            return RedirectToAction("Departments"); // veya istediğiniz başka bir sayfaya yönlendirme yapabilirsiniz
        }

        public IActionResult Randevu()
        {
            return View();
        }

        public IActionResult RandevuAl()
        {
            return View();
        }

        public IActionResult RandevuIptal()
        {
            return View();
        }

        public IActionResult RandevularımaBak()
        {
            return View();
        }

        public IActionResult ReçeteOluştur()
        {
            return View();
        }

        public IActionResult SevkKaydıOluştur()
        {
            return View();
        }

        public IActionResult SifremiUnuttum()
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
