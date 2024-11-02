using ECommerce.DTOs.Item;
using ECommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.DTOs.Order
{
    public class CreateOrderRequestDto
    {
        public string ShippingAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public List<OrderList> Items { get; set; }
       
    }
}
