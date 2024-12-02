using ECommerce.Data;
using ECommerce.DTOs.Item;
using ECommerce.Helpers;
using ECommerce.Interfaces.Repository;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDBContext _context;
        public ItemRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Item> CreateItemAsync(Item itemModel)
        {
            var existingitem = await _context.Items.FirstOrDefaultAsync(x => x.ItemName == itemModel.ItemName);

            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == itemModel.CategoryName);

            if (existingitem != null)
            {
                return null;
            }

            if (existingCategory != null)
            {
                return null;
            }
            await _context.Items.AddAsync(itemModel);
            await _context.SaveChangesAsync();
            return itemModel;

        }

        public async Task<Item?> DeleteItemAsync(int id)
        {
            var itemModel = await _context.Items.FirstOrDefaultAsync(x => x.ItemId == id);

            if (itemModel == null)
            {
                return null;
            }

            _context.Items.Remove(itemModel);
            await _context.SaveChangesAsync();

            return itemModel;

        }

        public async Task<List<Item>> GetAllItemsAsync(QueryObject query)
        {
            var items = _context.Items.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.ItemName))
            {
                items = items.Where(p => p.ItemName.Contains(query.ItemName));
            }

            if (!string.IsNullOrWhiteSpace(query.CategoryName))
            {
                items = items.Where(p => p.CategoryName.Contains(query.CategoryName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    items = query.IsDescending ? items.OrderByDescending(p => p.UnitPrice) : items.OrderBy(p => p.UnitPrice);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await items.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.ItemId == id);
        }

        public async Task<Item?> GetItemByNameAsync(string itemName)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.ItemName == itemName);
        }

        public Task<bool> ItemExists(int id)
        {
            return _context.Items.AnyAsync(o => o.ItemId == id);
        }


        public async Task<Item?> UpdateItemAsync(int id, UpdateItemRequestDto itemDto)
        {
            var existingItem = await _context.Items.FirstOrDefaultAsync(x => x.ItemId == id);

            if (existingItem == null)
            {
                return null;
            }
 
            existingItem.Store = itemDto.Store;
            existingItem.QuantityInStock = itemDto.QuantityInStock;
            existingItem.UnitPrice = itemDto.UnitPrice;
            existingItem.Description = itemDto.Description;

            _context.Items.Update(existingItem);
            await _context.SaveChangesAsync();

            return existingItem;
        }
    }
}
