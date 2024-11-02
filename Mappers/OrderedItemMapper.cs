using ECommerce.DTOs.OrderedItem;
using ECommerce.Models;

namespace ECommerce.Mappers
{
    public static class OrderedItemMapper
    {
        public static OrderedItemDto ToOrderedItemDto(this OrderedItem orderedItemModel)
        {
            return new OrderedItemDto
            {
                Bill = orderedItemModel.Bill,
                ItemName = orderedItemModel.ItemName,
                QtyNeeded = orderedItemModel.QtyNeeded,
            };
        }
    }
}
