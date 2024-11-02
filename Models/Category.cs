using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<Item> Item { get; set; } = new List<Item>();

    }
}
