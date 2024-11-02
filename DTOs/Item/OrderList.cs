using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs.Item
{
    public class OrderList
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int QtyNeeded { get; set; }
    }
}
