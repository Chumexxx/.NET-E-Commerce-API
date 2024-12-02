using ECommerce.Data;
using ECommerce.DTOs.Item;
using ECommerce.Helpers;
using ECommerce.Interfaces.Repository;
using ECommerce.Interfaces.Service;
using ECommerce.Mappers;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepo;
        public ItemService(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }
        //public async Task<ItemDto> CreateItemAsync(CreateItemRequestDto itemDto)
        //{
        //    var existingItem = await _itemRepo.GetByItemNameAsync(itemDto.ItemName);
        //    if (existingItem != null)
        //        throw new Exception("This item already exists");

        //    var itemModel = itemDto.ToItemFromCreateDto();
        //    itemModel.CreatedOn = DateTime.Now;

        //    await _itemRepo.CreateItemAsync(itemModel);
        //    return itemModel.ToItemDto();
        //}

        public async Task<ItemDto> DeleteItemAsync(int id)
        {
            var deletedItem = await _itemRepo.DeleteItemAsync(id);
            if (deletedItem == null)
                throw new Exception("Item does not exist");
            return deletedItem.ToItemDto();
        }

        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync(QueryObject query)
        {
            var items = await _itemRepo.GetAllItemsAsync(query);
            return items.Select(i => i.ToItemDto());
        }

        public async Task<ItemDto> GetItemByIdAsync(int id)
        {
            var item = await _itemRepo.GetItemByIdAsync(id);
            if (item == null)
                throw new Exception("Item not found");
            return item.ToItemDto();
        }

        public async Task<ItemDto> UpdateItemAsync(int id, UpdateItemRequestDto updateDto)
        {
            var updatedItem = await _itemRepo.UpdateItemAsync(id, updateDto);
            if (updatedItem == null)
                throw new Exception("Item does not exist");
            return updatedItem.ToItemDto();
        }
    }
}
