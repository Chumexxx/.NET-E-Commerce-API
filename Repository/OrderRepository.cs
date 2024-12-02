using ECommerce.Data;
using ECommerce.DTOs.Item;
using ECommerce.DTOs.Order;
using ECommerce.Interfaces.Repository;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order orderModel)
        {
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;

        }

        public async Task<Order> ReturnOrderAsync(AppUser appUser, int id)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);

            if (orderModel == null)
            {
                return null;
            }

            orderModel.IsReturned = true;
            orderModel.ReturnDate = DateTime.Now;

            _context.Orders.Update(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<Order?> GetOrderByIdAsync(AppUser appUser, int id)
        {
            return await _context.Orders.Include(i => i.OrderedItems).FirstOrDefaultAsync(c => c.AppUserId == appUser.Id && c.OrderId == id && !c.IsReturned && !c.IsCancelled);
        }

        public async Task<List<Order>> GetAllUserOrdersAsync(AppUser user)
        {
            return await _context.Orders.Include(i => i.OrderedItems).Where(o => o.AppUserId == user.Id && !o.IsReturned && !o.IsCancelled).ToListAsync();
        }

        public async Task<Order> CancelOrderAsync(AppUser appUser, int id)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);

            if (orderModel == null)
            {
                return null;
            }

            orderModel.IsCancelled = true;
            orderModel.CancelDate = DateTime.Now;

            _context.Orders.Update(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(o => o.AppUser).Include(o => o.OrderedItems).ToListAsync();
        }
    }

}
