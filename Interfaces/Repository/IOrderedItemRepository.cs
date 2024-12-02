using ECommerce.DTOs.Order;
using ECommerce.Models;

namespace ECommerce.Interfaces.Repository
{
    public interface IOrderedItemRepository
    {
        Task<OrderedItem> CreateAsync(OrderedItem orderedItemModel);
        Task<OrderedItem?> GetOrderedItemAsync(int itemId);
        Task<OrderedItem> UpdateOrderedItemAsync(int itemId, UpdateOrderRequestDto updateDto);
    }
}
