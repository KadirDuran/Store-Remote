using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int productId { get; set; }
        [Required(ErrorMessage ="Ürün ismi zorunlu alandır.")]
        public string? productName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ürün fiyatı zorunlu alandır.")] 
        public decimal? productPrice { get; set; }
        public int? categoryId { get; set; }
        public string? summary { get; set; } = string.Empty;    
        public string? imageUrl { get; set; } = string.Empty;
        public Category? category { get; set; } 
    }
}
