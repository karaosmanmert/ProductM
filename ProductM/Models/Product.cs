using System.ComponentModel.DataAnnotations;

namespace ProductM.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [Display(Name = "Ürün Adı")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Ürün adı 2 ile 100 karakter arasında olmalıdır.")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; } // Açıklama zorunlu değil (nullable string)

        [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
        [Display(Name = "Fiyat")]
        [DataType(DataType.Currency)] // Para birimi formatı için
        [Range(0.01, 1000000.00, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        public decimal Price { get; set; }
    }
}