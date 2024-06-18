using bitirmeMVC5.Models;
using bitirmeMVC5.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace bitirmeMVC5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PoliklinikService _poliklinikService;
        private readonly PersonelService _personelService;
        private readonly DoktorService _doktorService;
        private readonly HastaService _hastaService;
        private readonly AmeliyatTarihiService _ameliyatTarihiService;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, PoliklinikService poliklinikService, PersonelService personelService, DoktorService doktorService, HastaService hastaService,AmeliyatTarihiService ameliyatTarihiService, ApplicationDbContext context)
        {
            _logger = logger;
            _poliklinikService = poliklinikService;
            _personelService = personelService;
            _doktorService = doktorService;
            _hastaService = hastaService;
            _ameliyatTarihiService=ameliyatTarihiService;
            _context = context;
            
        }
        //HASTA HESAP OLUŞTURMA KISMIDIR
        [HttpPost]
        public IActionResult HesapOluşturma(string fullname, string tckn, string email, string phone, string gender, string password, string confirm_password)
        {
            try
            {
                // Parola doğrulama kontrolü
                if (password != confirm_password)
                {
                    ViewBag.ErrorMessage = "Parolalar eşleşmiyor.";
                    return View("hesap_oluşturma");
                }

                // Cinsiyet alanının boş olup olmadığını kontrol edin
                if (string.IsNullOrEmpty(gender))
                {
                    ViewBag.Poliklinikler = _poliklinikService.GetAllPoliklinikler();
                    ViewBag.ErrorMessage = "Cinsiyet alanı boş bırakılamaz.";
                    return View("hesap_oluşturma");
                }


                var hasta = new Hasta
                {
                    TamAd = fullname,
                    TcKimlikNo = tckn,
                    Eposta = email,
                    TelefonNo = phone,
                    Cinsiyet = gender,
                    Parola = password // Parolanın hashlenmesini unutmayın
                };

                _hastaService.AddHasta(hasta);
                return RedirectToAction("HastaGirişi");
            }

            catch (Exception ex)
            {
                // Hata mesajını görüntüleme
                ViewBag.ErrorMessage = "Kayıt işlemi sırasında bir hata oluştu: " + ex.Message;
                return View("hesap_oluşturma");
            }

        }
        //HASTA HESAP OLUŞTURMA KISMININ SONU

        //AMELİYAT TARİHİ OLUŞTUR KIMIDIR
        [HttpPost]
        public IActionResult AmeliyatTarihi(string patientName, string patientID, DateTime surgeryDate, TimeSpan surgeryTime, string doctorName)
        {
            try
            {

                // Personel nesnesini oluşturma ve ekleme işlemi
                var ameliyat = new Ameliyat
                {
                    HastaTamAd = patientName,
                    TcKimlikNo = patientID,
                    AmeliyatTarihi = surgeryDate,
                    AmeliyatSaati = surgeryTime,
                    DoktorTamAd = doctorName,
          
                };

                _ameliyatTarihiService.AddAmeliyat(ameliyat);
                return RedirectToAction(); // personel ekleme sonrası yönlendirme yapılacak sayfa
            }
            catch (Exception ex)
            {
                // Hata mesajını görüntüleme
                ViewBag.ErrorMessage = "Kayıt işlemi sırasında bir hata oluştu: " + ex.Message;
                return View("ameliyat_tarihi");
            }
        }
        //AMELİYAT TARİHİ OLUŞTURMA KISMININ SONU

        //POLİKLİNİKLERİ LİSTELE KISMI
        [HttpGet]
        public JsonResult GetPoliklinikler()
        {
            var poliklinikler = _poliklinikService.GetAllPoliklinikler()
                .Select(p => new { id = p.ID, name = p.PoliklinikAdi })
                .ToList();

            return Json(poliklinikler);
        }

        //POLİKLİNİKLERİ LİSTELE KISMI SONU

        //DOKTOR GİRİŞİ KISMI
        [HttpPost]
        public IActionResult DoktorGirişi(string email, string password)
        {
            var doktor = _doktorService.ValidateDoktor(email, password);
            if (doktor != null)
            {
                // Giriş başarılı, yönlendirme yapılacak
                return View("doktor_ekranı");
            }
            else
            {
                // Giriş başarısız, hata mesajı göster
                ViewBag.ErrorMessage = "Geçersiz e-posta veya parola.";
                return View("doktor_girişi");
            }
        }
        //DOKTOR GİRİŞİ KISMI SONU

        //HASTA GİRİŞİ KISMI
        [HttpPost]
        public IActionResult HastaGirişi(string tcKimlikNo, string password)
        {
            if (_hastaService.ValidateHasta(tcKimlikNo, password))
            {
                return View("randevu");
            }
            else
            {
                ViewBag.ErrorMessage = "Geçersiz T.C. Kimlik Numarası veya Parola";
                return View("hasta_girişi");
            }
        }
        //HASTA GİRİŞİ KISMI

        //PERSONEL EKLE KISMIDIR
        [HttpPost]
        public IActionResult PersonelEkle(string fullname, string tckn, string email, string phone, string gender, string password, string confirm_password)
        {
            try
            {
                // Parola doğrulaması kontrolü
                if (password != confirm_password)
                {
                    ViewBag.ErrorMessage = "Parolalar eşleşmiyor.";
                    return View("personel_ekle");
                }

                // Personel nesnesini oluşturma ve ekleme işlemi
                var personel = new Personel
                {
                    TamAd = fullname,
                    TcKimlikNo = tckn,
                    Eposta = email,
                    TelefonNo = phone,
                    Cinsiyet = gender,
                    Parola = password // Parolanın hashlenmesini unutmayın
                };

                _personelService.AddPersonel(personel);
                return RedirectToAction("Index"); // personel ekleme sonrası yönlendirme yapılacak sayfa
            }
            catch (Exception ex)
            {
                // Hata mesajını görüntüleme
                ViewBag.ErrorMessage = "Kayıt işlemi sırasında bir hata oluştu: " + ex.Message;
                return View("personel_ekle");
            }
        }
        //PERSONEL EKLE KISMININ SONU

        // DOKTOR EKLE KISMIDIR
        [HttpPost]
        public IActionResult DoktorEkle(string fullname, string tckn, string email, string phone, string gender, int poliklinikId, string password, string confirm_password)
        {
            try
            {
                // Parola doğrulama kontrolü
                if (password != confirm_password)
                {
                    ViewBag.Poliklinikler = _poliklinikService.GetAllPoliklinikler();
                    ViewBag.ErrorMessage = "Parolalar eşleşmiyor.";
                    return View("doktor_ekle");
                }

                // Cinsiyet alanının boş olup olmadığını kontrol edin
                if (string.IsNullOrEmpty(gender))
                {
                    ViewBag.Poliklinikler = _poliklinikService.GetAllPoliklinikler();
                    ViewBag.ErrorMessage = "Cinsiyet alanı boş bırakılamaz.";
                    return View("doktor_ekle");
                }


                var doktor = new Doktor
                {
                    TamAd = fullname,
                    TcKimlikNo = tckn,
                    Eposta = email,
                    TelefonNo = phone,
                    Cinsiyet = gender,
                    PoliklinikID = poliklinikId,
                    Parola = password // Parolanın hashlenmesini unutmayın
                };

                _doktorService.AddDoktor(doktor);
                return RedirectToAction("doctors");
            }

            catch (Exception ex)
            {
                // Hata mesajını görüntüleme
                ViewBag.Poliklinikler = _poliklinikService.GetAllPoliklinikler();
                ViewBag.ErrorMessage = "Kayıt işlemi sırasında bir hata oluştu: " + ex.Message;
                return View("doktor_ekle");
            }

        }
        //DOKTOR EKLE KISMININ SONU

        //PERSONEL GİRİŞİ KISMIDIR
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
        //PERSONEL GİRİŞİ KISMI SONUDUR


        //POLİKLİNİK EKLE KISMIDIR
        [HttpPost]
        public IActionResult PoliklinikEkle(string poliklinikAdi)
        {
            _poliklinikService.AddPoliklinik(poliklinikAdi);
            return RedirectToAction("Departments"); // veya istediğiniz başka bir sayfaya yönlendirme yapabilirsiniz
        }
        //POLİKLİNİK EKLE KISMI SONUDUR


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Randevu()
        {
            return View();
        }

        public IActionResult SifremiUnuttum()
        {
            return View();
        }

        public IActionResult PersonelEkranı()
        {
            return View();
        }

        public IActionResult PoliklinikEkle()
        {
            return View("poliklinik_ekle");
        }

        /*
        public IActionResult RandevuAl()
        {
            return View("randevu_al");
        }
        */
        public IActionResult RandevuIptal()
        {
            return View("randevu_iptal");
        }

        public IActionResult RandevularımaBak()
        {
            return View("randevularıma_bak");
        }

        public IActionResult ReçeteOluştur()
        {
            return View("reçete_oluştur");
        }

        public IActionResult SevkKaydıOluştur()
        {
            return View("sevk_kaydı_oluştur");
        }        

        public IActionResult AmeliyatTarihi()
        {
            return View("ameliyat_tarihi");
        }

        public IActionResult DoktorEkranı()
        {
            return View("doktor_ekranı");
        }

        public IActionResult DoktorGirişi()
        {
            return View("doktor_girişi");
        }

        public IActionResult Contact()
        {
            return View("contact");
        }

        public IActionResult HesapOluşturma()
        {
            return View("hesap_oluşturma");
        }

        public IActionResult HastaGirişi()
        {
            return View("hasta_girişi");
        }

        public IActionResult PersonelGirişi()
        {
            return View("personel_girişi");
        }

        public IActionResult PersonelEkle()
        {
            return View("personel_ekle");
        }

        public IActionResult DoktorEkle()
        {
            var poliklinikler = _poliklinikService.GetAllPoliklinikler();
            ViewBag.Poliklinikler = poliklinikler;
            return View("doktor_ekle");
        }

        public IActionResult Departments()
        {
            var poliklinikler = _poliklinikService.GetAllPoliklinikler();
            return View(poliklinikler);
        }
        
        public IActionResult Doctors()
        {
            var doktorlar = _doktorService.GetAllDoktorlar();
            return View(doktorlar);
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> RandevuAl()
        {
            var poliklinikler = await _poliklinikService.GetAllPolikliniklerAsync();
            ViewBag.Poliklinikler = poliklinikler; // Verileri ViewBag ile görünüme taşıyoruz.

            return View("randevu_al");
        }

        [HttpPost]
        public async Task<IActionResult> RandevuAl(string fullname, string tckn, string email, string phone, DateTime date, string time, int poliklinikId, int doktorId)
        {
            try
            {
                // 1. Model Doğrulama:
                if (!ModelState.IsValid)
                {
                    // Model doğrulaması başarısız olursa, hata mesajlarını görünüme geri döndürün
                    ViewBag.Poliklinikler = await _poliklinikService.GetAllPolikliniklerAsync();
                    //return View("randevu_al");

                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage)
                                          .ToList();
                    return Json(new { success = false, message = string.Join("\n", errors) });
                }



                // 2. Randevu Çakışması Kontrolü (Opsiyonel):
                // Aynı saatte ve tarihte başka bir randevu var mı kontrol edin.

                // 3. Randevu Oluşturma:
             
                var yeniRandevu = new Randevular
                {
                    TamAd = fullname,
                    TcKimlikNo = tckn,
                    Eposta = email,
                    TelefonNo = phone,
                    RandevuTarihi = date,
                    RandevuSaati = TimeSpan.Parse(time),
                    Poliklinik = _poliklinikService.GetPoliklinikById(poliklinikId)?.PoliklinikAdi,

                    DoktorTamAd = _doktorService.GetDoktorById(doktorId)?.TamAd
                };

                var poliklinik = _poliklinikService.GetPoliklinikById(poliklinikId);

                if (poliklinik != null)
                {
                    yeniRandevu.Poliklinik = poliklinik.PoliklinikAdi;
                }
                else
                {
                    // Poliklinik bulunamadı, hata mesajı döndürün veya farklı bir işlem yapın.
                    return Json(new { success = false, message = "Geçersiz poliklinik seçimi." });
                }

                // 4. Veritabanına Kaydetme:
                _context.Randevular.Add(yeniRandevu);
                await _context.SaveChangesAsync();


                return Json(new { success = true, message = "Randevunuz başarıyla oluşturuldu!" });
            }
            catch (Exception ex)
            {
                // 6. Hata Yönetimi:
                _logger.LogError(ex, "Randevu alırken bir hata oluştu.");
                return Json(new { success = false, message = "Randevu alırken bir hata oluştu. Lütfen daha sonra tekrar deneyin." });
            }

        }

        public async Task<IActionResult> RandevulariListele()
        {
            var randevular = await _context.Randevular.ToListAsync();
            return View("randevu_iptal", randevular);
        }

        [HttpGet]
        public JsonResult GetDoktorlar(int poliklinikId)
        {
            var doktorlar = _doktorService.GetDoktorlarByPoliklinikId(poliklinikId);
            return Json(doktorlar);
        }





















    }
}
