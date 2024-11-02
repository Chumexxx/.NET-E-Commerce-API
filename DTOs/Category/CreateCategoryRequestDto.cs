using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs.Category
{
    public class CreateCategoryRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Category name cannot be less than 3 characters")]
        [MaxLength(30, ErrorMessage = "Category name cannot be over 50 chatacters")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
