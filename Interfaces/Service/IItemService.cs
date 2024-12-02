using ECommerce.DTOs.Item;
using ECommerce.Helpers;

namespace ECommerce.Interfaces.Service
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItemsAsync(QueryObject query);
        Task<ItemDto> GetItemByIdAsync(int id);
        //Task<ItemDto> CreateItemAsync(CreateItemRequestDto itemDto);
        Task<ItemDto> UpdateItemAsync(int id, UpdateItemRequestDto updateDto);
        Task<ItemDto> DeleteItemAsync(int id);
    }
}
