using ECommerce.DTOs.Item;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs.Order
{
    public class UpdateOrderRequestDto
    {
        public int OrderedItemId { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public List<OrderList> Items { get; set; }
    }
}
