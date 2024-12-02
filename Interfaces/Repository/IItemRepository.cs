using ECommerce.DTOs.Item;
using ECommerce.Helpers;
using ECommerce.Models;

namespace ECommerce.Interfaces.Repository
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItemsAsync(QueryObject query);
        Task<Item?> GetItemByIdAsync(int id);
        Task<Item?> GetItemByNameAsync(string itemName);
        Task<Item> CreateItemAsync(Item itemModel);
        Task<Item?> UpdateItemAsync(int id, UpdateItemRequestDto itemDto);
        Task<Item?> DeleteItemAsync(int id);
        Task<bool> ItemExists(int id);
    }
}
