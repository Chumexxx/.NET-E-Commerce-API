using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class OrderedItem
    {
        public int OrderedItemId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int QtyNeeded { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Bill { get; set; }
        public Item? Item { get; set; }
        public Order? Order { get; set; }
    }
}
