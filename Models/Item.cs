﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [Table("Items")]
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Store { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Category? Category { get; set; }
    }
}
