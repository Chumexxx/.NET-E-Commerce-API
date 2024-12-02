using ECommerce.Data;
using ECommerce.DTOs.Order;
using ECommerce.Interfaces.Repository;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class OrderedItemRepository : IOrderedItemRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderedItemRepository(ApplicationDBContext conntext)
        {
            _context = conntext;
        }
        public async Task<OrderedItem> CreateAsync(OrderedItem orderedItemModel)
        {
            await _context.OrderedItems.AddAsync(orderedItemModel);
            await _context.SaveChangesAsync();
            return orderedItemModel;
        }

        public async Task<OrderedItem?> GetOrderedItemAsync(int itemId)
        {
            return await _context.OrderedItems.FirstOrDefaultAsync(oi => oi.ItemId == itemId);
        }

        public async Task<OrderedItem> UpdateOrderedItemAsync(int itemId, UpdateOrderRequestDto updateDto)
        {
            var existingItem = await _context.OrderedItems.FirstOrDefaultAsync(oi => oi.ItemId == itemId);

            if (existingItem == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();

            return existingItem;
        }
    }
}
