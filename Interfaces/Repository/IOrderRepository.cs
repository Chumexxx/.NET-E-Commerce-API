using ECommerce.DTOs.Order;
using ECommerce.Models;

namespace ECommerce.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetAllUserOrdersAsync(AppUser user);
        Task<Order?> GetOrderByIdAsync(AppUser appUser, int id);
        Task<Order> CreateOrderAsync(Order orderModel);
        Task<Order> ReturnOrderAsync(AppUser appUser, int id);
        Task<Order> CancelOrderAsync(AppUser appUser, int id);
    }
}
