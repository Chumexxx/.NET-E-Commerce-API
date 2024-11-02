using ECommerce.DTOs.Item;

namespace ECommerce.DTOs.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<ItemDto> Items { get; set; }
    }
}
