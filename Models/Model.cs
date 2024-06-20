using bitirmeMVC5.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bitirmeMVC5.Models
{

    public class Poliklinik
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Poliklinik Adı")]
        public string? PoliklinikAdi { get; set; }
    }

    public class Doktor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Tam ad alanı gereklidir.")]
        [StringLength(100)]
        [Display(Name = "Tam Ad")]
        public string TamAd { get; set; }

        [Required(ErrorMessage = "TC Kimlik No alanı gereklidir.")]
        [StringLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçersiz TC Kimlik No.")]
        [Display(Name = "TC Kimlik No")]
        public string TcKimlikNo { get; set; }

        [Required(ErrorMessage = "Eposta alanı gereklidir.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Geçersiz eposta adresi.")]
        [Display(Name = "E-posta")]
        public string Eposta { get; set; }

        [Required(ErrorMessage = "Telefon numarası alanı gereklidir.")]
        [StringLength(15)]
        [Display(Name = "Telefon No")]
        public string TelefonNo { get; set; }

        [Required(ErrorMessage = "Cinsiyet alanı gereklidir.")]
        [StringLength(10)]
        public string Cinsiyet { get; set; }

        [Required(ErrorMessage = "Poliklinik alanı gereklidir.")]
        [Display(Name = "Poliklinik ID")]
        public int PoliklinikID { get; set; }

        [Required(ErrorMessage = "Parola alanı gereklidir.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Parola en az 6 karakter olmalıdır.")]
        [Display(Name = "Parola")]
        public string Parola { get; set; }
    }

    public class Personel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tam ad alanı gereklidir.")]
        [StringLength(100)]
        [Display(Name = "Tam Ad")]
        public string TamAd { get; set; }

        [Required(ErrorMessage = "TC Kimlik No alanı gereklidir.")]
        [StringLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçersiz TC Kimlik No.")]
        [Display(Name = "TC Kimlik No")]
        public string TcKimlikNo { get; set; }

        [Required(ErrorMessage = "Eposta alanı gereklidir.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Geçersiz eposta adresi.")]
        public string Eposta { get; set; }

        [Required(ErrorMessage = "Telefon numarası alanı gereklidir.")]
        [StringLength(15)]
        [Display(Name = "Telefon No")]
        public string TelefonNo { get; set; }

        [Required(ErrorMessage = "Parola alanı gereklidir.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Parola en az 6 karakter olmalıdır.")]
        public string Parola { get; set; }

        [Required(ErrorMessage = "Cinsiyet alanı gereklidir.")]
        [StringLength(10)]
        public string Cinsiyet { get; set; }
    }

    public class Hasta
    {
        public int ID { get; set; }

        [Required]
        public string TamAd { get; set; }

        [Required]
        public string TcKimlikNo { get; set; }

        [Required]
        public string Eposta { get; set; }

        [Required]
        public string TelefonNo { get; set; }

        [Required]
        public string Cinsiyet { get; set; }

        [Required]
        public string Parola { get; set; }
    }

    public class Ameliyat
    {
        public int ID { get; set; } // Anahtar alanı

        [Required(ErrorMessage = "Hasta Adı gereklidir.")]
        public string HastaTamAd { get; set; }

        [Required(ErrorMessage = "T.C. Kimlik Numarası gereklidir.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "T.C. Kimlik Numarası 11 haneli olmalıdır.")]
        public string TcKimlikNo { get; set; }

        [Required(ErrorMessage = "Ameliyat Tarihi gereklidir.")]
        public DateTime AmeliyatTarihi { get; set; }

        [Required(ErrorMessage = "Ameliyat Saati gereklidir.")]
        public TimeSpan AmeliyatSaati { get; set; }

        [Required(ErrorMessage = "Doktor Adı gereklidir.")]
        public string DoktorTamAd { get; set; }
    }

    public class Randevular
    {
        public int? ID { get; set; }
        public string? TamAd { get; set; }
        public string? TcKimlikNo { get; set; }
        public string? Eposta { get; set; }
        public string? TelefonNo { get; set; }
        public DateTime? RandevuTarihi { get; set; }
        public TimeSpan? RandevuSaati { get; set; }
        public string? Poliklinik { get; set; }
        public string? DoktorTamAd { get; set; }
    }

    public class Aboneler
    {
        [Key] // ID'nin birincil anahtar olduğunu belirtir
        public int ID { get; set; }

        [Required] // Alanın zorunlu olduğunu belirtir
        [MaxLength(255)] // Alanın maksimum uzunluğu
        public string MailAdresi { get; set; }

        public DateTime KayitTarihi { get; set; } = DateTime.Now; // Kayıt tarihini otomatik olarak ayarlar
    }

}
