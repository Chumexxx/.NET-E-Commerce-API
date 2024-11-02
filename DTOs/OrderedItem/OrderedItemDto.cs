namespace ECommerce.DTOs.OrderedItem
{
    public class OrderedItemDto
    {
        public string ItemName { get; set; } = string.Empty;
        public int QtyNeeded { get; set; }
        public decimal Bill { get; set; }
    }
}
