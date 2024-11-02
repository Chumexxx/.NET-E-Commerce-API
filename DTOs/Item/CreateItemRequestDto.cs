using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs.Item
{
    public class Items
    {
        
        [Required]
        [MinLength(3, ErrorMessage = "Product Name cannot be less than 3 characters")]
        [MaxLength(50, ErrorMessage = "Product Name cannot be over 50 chatacters")]
        public string ItemName { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Store cannot be less than 3 characters")]
        [MaxLength(100, ErrorMessage = "Store cannot be over 100 chatacters")]
        public string Store { get; set; } = string.Empty;

        [Required]
        [Range(0, 100000)]
        public int QuantityInStock { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Range(0, 5000000)]
        public decimal UnitPrice { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description cannot be less than 10 characters")]
        [MaxLength(100, ErrorMessage = "Description cannot be over 100 chatacters")]
        public string Description { get; set; } = string.Empty;
    }
}
