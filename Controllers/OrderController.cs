using ECommerce.Data;
using ECommerce.DTOs.Item;
using ECommerce.DTOs.Order;
using ECommerce.Extensions;
using ECommerce.Helpers;
using ECommerce.Interfaces.Repository;
using ECommerce.Interfaces.Service;
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
        private readonly IOrderService _orderService;
        private readonly ApplicationDBContext _context;
        public OrderController(UserManager<AppUser> userManager, IOrderService orderService, ApplicationDBContext context)
        {
            _userManager = userManager;
            _orderService = orderService;
            _context = context;
        }

        [HttpGet("getAllOrders")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var allOrders = await _orderService.GetAllOrdersAsync();
                Console.WriteLine("user called the get all orders endpoint");
                return Ok(allOrders);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("getAllUserOrders")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllUserOrders()
        {
            try
            {
                var username = User.GetUsername();
                var userOrders = await _orderService.GetAllUserOrdersAsync(username);
                Console.WriteLine("user called the get all user orders endpoint");
                return Ok(userOrders);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            try
            {
                var username = User.GetUsername();
                var order = await _orderService.GetOrderByIdAsync(username, id);
                Console.WriteLine("user called the get order by id endpoint");
                return Ok(order);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
          
        }

        [HttpPost("createOrder")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto orderDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var username = User.GetUsername();
                var createOrder = await _orderService.CreateOrderAsync(username, orderDto);
                return Ok(createOrder);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
 
        }


        [HttpPut("returnOrder")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> ReturnOrder(int id)
        {
            try
            {
                var username = User.GetUsername();
                var returnItem = await _orderService.ReturnOrderAsync(username, id);
                return Ok(returnItem);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("cancelOrder")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            try
            {
                var username = User.GetUsername();
                var cancelOrder = await _orderService.CancelOrderAsync(username, id);
                return Ok(cancelOrder);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }
    }
}

