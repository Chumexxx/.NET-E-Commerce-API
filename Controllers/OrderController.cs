using ECommerce.Data;
using ECommerce.DTOs.Item;
using ECommerce.DTOs.Order;
using ECommerce.Extensions;
using ECommerce.Helpers;
using ECommerce.Interfaces;
using ECommerce.Mappers;
using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IItemRepository _itemRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderedItemRepository _orderedItemRepo;
        private readonly ApplicationDBContext _context;
        public OrderController(UserManager<AppUser> userManager, IItemRepository itemRepo, IOrderRepository orderRepo,
            IOrderedItemRepository orderedItemRepo, ApplicationDBContext context)
        {
            _userManager = userManager;
            _itemRepo = itemRepo;
            _orderRepo = orderRepo;
            _orderedItemRepo = orderedItemRepo;
            _context = context;
        }

        [HttpGet("getAllOrders")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orders = await _orderRepo.GetAllOrders();

            var orderDto = orders.Select(s => s.ToOrderDto());

            return Ok(orderDto);
        }


        [HttpGet("getUserOrders")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetUserOrders()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);


            var orders = await _orderRepo.GetUserOrder(appUser);

            var orderDto = orders.Select(s => s.ToOrderDto());

            return Ok(orderDto);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();

            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
                return NotFound("User not found");

            var userOrder = await _orderRepo.GetOrderById(appUser, id);

            if (userOrder == null)
                return NotFound($"No order found for the user with ID {id}");


            return Ok(userOrder.ToOrderDto());

        }


        [HttpPost("addOrder")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderRequestDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            if (appUser == null)
                return NotFound("User not found");

            var orderedItems = new List<OrderedItem>();
            decimal orderBill = 0;
            var errorMessages = new List<string>();

            // Begin transaction
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // First, validate all items without updating the database
                foreach (var checkedItem in orderDto.Items)
                {
                    var item = await _itemRepo.GetByIdAsync(checkedItem.ItemId);
                    if (item == null)
                    {
                        errorMessages.Add($"Item with ID {checkedItem.ItemId} does not exist.");
                        continue;
                    }

                    if (checkedItem.QtyNeeded <= 0)
                    {
                        errorMessages.Add($"Quantity for item with ID {checkedItem.ItemId} must be at least 1.");
                        continue;
                    }

                    if (checkedItem.QtyNeeded > item.QuantityInStock)
                    {
                        errorMessages.Add($"Item with ID {checkedItem.ItemId} is out of stock. Only {item.QuantityInStock} units available.");
                    }
                }

                if (errorMessages.Any())
                {
                    await transaction.RollbackAsync();
                    return BadRequest(new
                    {
                        Message = "Order could not be placed because some item IDs were invalid.",
                        Errors = errorMessages
                    });
                }

                foreach (var checkedItem in orderDto.Items)
                {
                    var item = await _itemRepo.GetByIdAsync(checkedItem.ItemId);
                    item.QuantityInStock -= checkedItem.QtyNeeded;

                    var itemDto = new UpdateItemRequestDto
                    {
                        QuantityInStock = item.QuantityInStock,
                        Description = item.Description,
                        Store = item.Store,
                        UnitPrice = item.UnitPrice,
                    };

                    await _itemRepo.UpdateAsync(item.ItemId, itemDto);

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

                // Create the order model
                var orderModel = new Order
                {
                    AppUserId = appUser.Id,
                    TotalBill = orderBill,
                    OrderedBy = appUser.UserName,
                    OrderedItems = orderedItems,
                    ShippingAddress = orderDto.ShippingAddress,
                    PaymentMethod = orderDto.PaymentMethod
                };

                await _orderRepo.CreateOrderAsync(orderModel);

                // Commit transaction
                await transaction.CommitAsync();
                return Ok("Order placed successfully");
            }
            catch (Exception)
            {
                // If any exception occurs, rollback the transaction
                await transaction.RollbackAsync();
                return StatusCode(500, "An error occurred while placing the order.");
            }
        }


        [HttpPut("returnOrder")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> ReturnOrder(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var order = await _orderRepo.GetOrderById(appUser, Id);

            if (order == null)
                return NotFound("Order not found");

            if (order.IsReturned)
                return BadRequest("Order has already been returned");

            if (order.IsCancelled)
                return BadRequest("Cannot return an order that has already been cancelled. Kindly verify your OrderId");

            await _orderRepo.ReturnOrderAsync(appUser, Id);

            foreach (var orderedItem in order.OrderedItems)
            {
                var item = await _itemRepo.GetByIdAsync(orderedItem.ItemId);

                if (item == null)
                    return BadRequest($"Item with ID {orderedItem.ItemId} not found");

                item.QuantityInStock += orderedItem.QtyNeeded;

                var itemDto = new UpdateItemRequestDto
                {
                    QuantityInStock = item.QuantityInStock,
                    Description = item.Description,
                    UnitPrice = item.UnitPrice,
                };

                await _itemRepo.UpdateAsync(item.ItemId, itemDto);
            }

            return Ok(new { message = "Order successfully returned" });
        }

        [HttpPut("cancelOrder")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> CancelOrder(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var order = await _orderRepo.GetOrderById(appUser, Id);

            if (order == null)
                return NotFound("Order not found");

            if (order.IsCancelled)
                return BadRequest("Order is already cancelled");

            if (order.IsReturned)
                return BadRequest("Cannot cancel an order that has already been returned. Kindly verify your OrderId");

            await _orderRepo.CancelOrderAsync(appUser, Id);

            foreach (var orderedItem in order.OrderedItems)
            {
                var item = await _itemRepo.GetByIdAsync(orderedItem.ItemId);

                if (item == null)
                    return BadRequest($"Item with ID {orderedItem.ItemId} not found");

                item.QuantityInStock += orderedItem.QtyNeeded;

                var itemDto = new UpdateItemRequestDto
                {
                    QuantityInStock = item.QuantityInStock,
                    Description = item.Description,
                    UnitPrice = item.UnitPrice,
                };

                await _itemRepo.UpdateAsync(item.ItemId, itemDto);
            }

            return Ok(new { message = "Order successfully cancelled" });
        }

    }
}

