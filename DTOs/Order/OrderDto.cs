using ECommerce.DTOs.Item;
using ECommerce.DTOs.OrderedItem;
using ECommerce.Models;

namespace ECommerce.DTOs.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string OrderedBy { get; set; } = string.Empty;
        public bool IsReturned { get; set; } 
        public bool IsCancelled { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalBill { get; set; }
        public ICollection<OrderedItemDto> OrderedItems { get; set; }

    }
}
