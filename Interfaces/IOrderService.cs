using ECommerce.DTOs.Order;
using ECommerce.Models;

namespace ECommerce.Interfaces
{
    public interface IOrderService
    {
        //Task<List<Order>> GetAllOrdersAsync();
        //Task<List<OrderDto>> GetAllUserOrdersAsync(string username);
        //Task<Order?> GetOrderByIdAsync(AppUser appUser, int id);
        //Task<Order> CreateOrderAsync(Order orderModel);
        //Task<Order> ReturnOrderAsync(AppUser appUser, int Id);
        //Task<Order> CancelOrderAsync(AppUser appUser, int Id);

        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<IEnumerable<OrderDto>> GetAllUserOrdersAsync(string username);
        Task<OrderDto> GetOrderByIdAsync(string username, int id);
        Task<Object> CreateOrderAsync(string username, CreateOrderRequestDto orderDto);
        Task<Object> ReturnOrderAsync(string username, int id);
        Task<Object> CancelOrderAsync(string username, int id);
    }
}
