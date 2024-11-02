using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [Table("Order")]
    public class Order
    {
        public string AppUserId { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public string OrderedBy { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalBill { get; set; }
        public AppUser? AppUser { get; set; }
        public bool IsReturned { get; set; } = false;
        public bool IsCancelled { get; set; } = false;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public DateTime CancelDate { get; set; } = DateTime.Now;
        public ICollection<OrderedItem> OrderedItems { get; set; }

    }
}
