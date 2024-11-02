using ECommerce.DTOs.Order;

namespace ECommerce.DTOs.Item
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Store { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
