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
        private readonly IOrderedItemRepository _orderedItemRepo;
        private readonly IOrderService _orderService;
        private readonly ApplicationDBContext _context;
        public OrderController(UserManager<AppUser> userManager, IItemRepository itemRepo, IOrderService orderService,
            IOrderedItemRepository orderedItemRepo, ApplicationDBContext context)
        {
            _userManager = userManager;
            _itemRepo = itemRepo;
            _orderService = orderService;
            _orderedItemRepo = orderedItemRepo;
            _context = context;
        }

        [HttpGet("getAllOrders")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            var allOrders = await _orderService.GetAllOrdersAsync();
            return Ok(allOrders);
        }


        [HttpGet("getAllUserOrders")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllUserOrders()
        {
            var username = User.GetUsername();
            var userOrders = await _orderService.GetAllUserOrdersAsync(username);
            return Ok(userOrders);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var username = User.GetUsername();
            var order = await _orderService.GetOrderByIdAsync(username, id);
            return Ok(order);
        }

        [HttpPost("addOrder")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderRequestDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var createOrder = await _orderService.CreateOrderAsync(username, orderDto);
            return Ok(createOrder);
        }


        [HttpPut("returnOrder")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> ReturnOrder(int id)
        {
            var username = User.GetUsername();
            var returnItem = await _orderService.ReturnOrderAsync(username, id);
            return Ok(returnItem);
        }

        [HttpPut("cancelOrder")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var username = User.GetUsername();
            var cancelOrder = await _orderService.CancelOrderAsync(username, id);
            return Ok(cancelOrder);
        }
    }
}

