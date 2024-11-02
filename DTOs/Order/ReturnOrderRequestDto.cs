using ECommerce.DTOs.Item;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs.Order
{
    public class ReturnOrderRequestDto
    {
        [Required]
        public string? ItemName { get; set; } = string.Empty;
    }
}
