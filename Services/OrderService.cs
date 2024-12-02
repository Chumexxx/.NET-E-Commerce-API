using ECommerce.Data;
using ECommerce.DTOs.Item;
using ECommerce.DTOs.Order;
using ECommerce.Interfaces.Repository;
using ECommerce.Interfaces.Service;
using ECommerce.Mappers;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderRepository _orderRepo;
        private readonly IItemRepository _itemRepo;
        private readonly ApplicationDBContext _context;

        public OrderService(UserManager<AppUser> userManager, IOrderRepository orderRepo, IItemRepository itemRepo,
            ApplicationDBContext context)
        {
            _userManager = userManager;
            _orderRepo = orderRepo;
            _itemRepo = itemRepo;
            _context = context;

        }

        public async Task<object> CancelOrderAsync(string username, int id)
        {
            var user = await _userManager.FindByNameAsync(username);

            var order = await _orderRepo.GetOrderByIdAsync(user, id);

            if (order == null)
                return ("Order not found");

            if (order.IsCancelled)
                return ("Order is already cancelled");

            if (order.IsReturned)
                return ("Cannot cancel an order that has already been returned. Kindly verify your OrderId");

            await _orderRepo.CancelOrderAsync(user, id);

            foreach (var orderedItem in order.OrderedItems)
            {
                var item = await _itemRepo.GetItemByIdAsync(orderedItem.ItemId);

                if (item == null)
                    return ($"Item with ID {orderedItem.ItemId} not found");

                item.QuantityInStock += orderedItem.QtyNeeded;

                var itemDto = new UpdateItemRequestDto
                {
                    QuantityInStock = item.QuantityInStock,
                    Description = item.Description,
                    UnitPrice = item.UnitPrice,
                };

                await _itemRepo.UpdateItemAsync(item.ItemId, itemDto);
            }

            return (new { message = "Order successfully cancelled" });
        }
    

        public async Task<object> CreateOrderAsync(string username, CreateOrderRequestDto orderDto)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return ("User not found");

            var orderedItems = new List<OrderedItem>();
            decimal orderBill = 0;
            var errorMessages = new List<string>();

            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                foreach (var checkedItem in orderDto.Items)
                {
                    var item = await _itemRepo.GetItemByIdAsync(checkedItem.ItemId);

                    if (item == null)
                    {
                        await transaction.RollbackAsync();
                        return (new
                        {
                            Message = $"Item with ID {checkedItem.ItemId} does not exist.",
                        });
                    }

                    item.QuantityInStock -= checkedItem.QtyNeeded;

                    if (checkedItem.QtyNeeded <= 0)
                    {
                        await transaction.RollbackAsync();
                        return (new
                        {
                            Message = $"Quantity for item with ID {checkedItem.ItemId} must be at least 1.",
                        });
                    }

                    if (checkedItem.QtyNeeded > item.QuantityInStock)
                    {
                        await transaction.RollbackAsync();
                        return (new
                        {
                            Message = $"Item with ID {checkedItem.ItemId} is out of stock. Only {item.QuantityInStock} units available.",
                        });
                    }

                    var itemDto = new UpdateItemRequestDto
                    {
                        QuantityInStock = item.QuantityInStock,
                        Description = item.Description,
                        Store = item.Store,
                        UnitPrice = item.UnitPrice,
                    };

                    await _itemRepo.UpdateItemAsync(item.ItemId, itemDto);

                    var itemBill = item.UnitPrice * checkedItem.QtyNeeded;
                    orderBill += itemBill;

                    var orderedItem = new OrderedItem
                    {
                        Bill = itemBill,
                        ItemName = item.ItemName,
                        ItemId = item.ItemId,
                        QtyNeeded = checkedItem.QtyNeeded,
                    };

                    orderedItems.Add(orderedItem);
                }

                var orderModel = new Order
                {
                    AppUserId = user.Id,
                    TotalBill = orderBill,
                    OrderedBy = user.UserName,
                    OrderedItems = orderedItems,
                    ShippingAddress = orderDto.ShippingAddress,
                    PaymentMethod = orderDto.PaymentMethod
                };

                await _orderRepo.CreateOrderAsync(orderModel);

                await transaction.CommitAsync();
                return ("Order placed successfully");
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return (500, "An error occurred while placing the order.");
            }
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.GetAllOrdersAsync();
            return orders.Select(o => o.ToOrderDto());
        }

        public async Task<IEnumerable<OrderDto>> GetAllUserOrdersAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null) 
                throw new Exception("User not found");

            var orders = await _orderRepo.GetAllUserOrdersAsync(user);
            return orders.Select(o => o.ToOrderDto());
        }

        public async Task<OrderDto> GetOrderByIdAsync(string username, int id)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null) 
                throw new Exception("User not found");

            var order = await _orderRepo.GetOrderByIdAsync(user, id);
            if (order == null) throw new Exception($"No order found with ID {id}");

            return order.ToOrderDto();
        }

        public async Task<object> ReturnOrderAsync(string username, int id)
        {
            var user = await _userManager.FindByNameAsync(username);

            var order = await _orderRepo.GetOrderByIdAsync(user, id);

            if (order == null)
                return ("Order not found");

            if (order.IsReturned)
                return ("Order has already been returned");

            if (order.IsCancelled)
                return ("Cannot return an order that has already been cancelled. Kindly verify your OrderId");

            await _orderRepo.ReturnOrderAsync(user, id);

            foreach (var orderedItem in order.OrderedItems)
            {
                var item = await _itemRepo.GetItemByIdAsync(orderedItem.ItemId);

                if (item == null)
                    return ($"Item with ID {orderedItem.ItemId} not found");

                item.QuantityInStock += orderedItem.QtyNeeded;

                var itemDto = new UpdateItemRequestDto
                {
                    QuantityInStock = item.QuantityInStock,
                    Description = item.Description,
                    UnitPrice = item.UnitPrice,
                };

                await _itemRepo.UpdateItemAsync(item.ItemId, itemDto);
            }

            return (new { message = "Order successfully returned" });
        }
    }   
}
