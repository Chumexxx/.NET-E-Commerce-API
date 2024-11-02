using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs.Category
{
    public class UpdateCategoryRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Category Name cannot be less than than 3 characters")]
        [MaxLength(30, ErrorMessage = "Category Name cannot be over 30 chatacters")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
