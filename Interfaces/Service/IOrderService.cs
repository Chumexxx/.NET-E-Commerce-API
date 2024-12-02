using ECommerce.DTOs.Order;
using ECommerce.Models;

namespace ECommerce.Interfaces.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<IEnumerable<OrderDto>> GetAllUserOrdersAsync(string username);
        Task<OrderDto> GetOrderByIdAsync(string username, int id);
        Task<object> CreateOrderAsync(string username, CreateOrderRequestDto orderDto);
        Task<object> ReturnOrderAsync(string username, int id);
        Task<object> CancelOrderAsync(string username, int id);
    }
}
