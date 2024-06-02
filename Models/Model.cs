using System.ComponentModel.DataAnnotations;

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
}
