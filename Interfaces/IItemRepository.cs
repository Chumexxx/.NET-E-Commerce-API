using ECommerce.DTOs.Item;
using ECommerce.Helpers;
using ECommerce.Models;

namespace ECommerce.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync(QueryObject query);
        Task<Item?> GetByIdAsync(int id);
        Task<Item?> GetByNameAsync(string itemName);
        Task<Item> CreateAsync(Item itemModel);
        Task<Item?> UpdateAsync(int id, UpdateItemRequestDto itemDto);
        Task<Item?> DeleteAsync(int id);
        Task<bool> ItemExists(int id);
    }
}
