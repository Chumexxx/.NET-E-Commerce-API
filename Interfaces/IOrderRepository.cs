using ECommerce.DTOs.Order;
using ECommerce.Models;

namespace ECommerce.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetUserOrder(AppUser user);
        Task<Order?> GetOrderById(AppUser appUser, int id);
        Task<Order> CreateOrderAsync(Order orderModel);
        Task<Order> ReturnOrderAsync(AppUser appUser, int Id);
        Task<Order> CancelOrderAsync(AppUser appUser, int Id);
    }
}
