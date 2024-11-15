using ECommerce.DTOs.Item;
using ECommerce.Models;

namespace ECommerce.Mappers
{
    public static class ItemMapper
    {
        public static ItemDto ToItemDto(this Item itemModel)
        {
            return new ItemDto
            {
                ItemId = itemModel.ItemId,
                ItemName = itemModel.ItemName,
                Store = itemModel.Store,
                QuantityInStock = itemModel.QuantityInStock,
                CategoryName = itemModel.CategoryName,
                CategoryId = itemModel.CategoryId,
                UnitPrice = itemModel.UnitPrice,
                Description = itemModel.Description,
                CreatedOn = itemModel.CreatedOn,
            };
        }

        public static Item ToItemFromCreateDto(this Items itemDto)
        {
            return new Item
            {
                ItemName = itemDto.ItemName,
                Store = itemDto.Store,
                QuantityInStock = itemDto.QuantityInStock,
                CategoryId = itemDto.CategoryId,
                UnitPrice = itemDto.UnitPrice,
                Description = itemDto.Description,
            };
        }

        public static Item ToItemFromUpdate(this UpdateItemRequestDto itemDto)
        {
            return new Item
            {
                Store = itemDto.Store,
                QuantityInStock = itemDto.QuantityInStock,
                UnitPrice = itemDto.UnitPrice,
                Description = itemDto.Description,

            };
        }
    }
}
