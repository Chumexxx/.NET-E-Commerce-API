using ECommerce.Data;
using ECommerce.DTOs.Category;
using ECommerce.DTOs.Item;
using ECommerce.Helpers;
using ECommerce.Interfaces.Repository;
using ECommerce.Interfaces.Service;
using ECommerce.Mappers;
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/Items")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IItemService _itemService;
        public ItemController(ApplicationDBContext context, IItemService itemService)
        {
            _context = context;
            _itemService = itemService;
        }

        [HttpGet("getAllItems")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllItems([FromQuery] QueryObject query)
        {
            try
            {
                var items = await _itemService.GetAllItemsAsync(query);
                Console.WriteLine("user called the get all items endpoint");
                return Ok(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetByItemId([FromRoute] int id)
        {
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                Console.WriteLine("user called the get item by id endpoint");
                return Ok(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost("createItem")]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        //public async Task<IActionResult> CreateItem([FromBody] Items itemDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        var createdItem = await _itemService.CreateItemAsync(itemDto);
        //        Console.WriteLine("user called the create item endpoint");
        //        return CreatedAtAction(nameof(GetItemById), new { id = createdItem.ItemId }, createdItem);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> UpdateItem([FromRoute] int id, [FromBody] UpdateItemRequestDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedItem = await _itemService.UpdateItemAsync(id, updateDto);
                Console.WriteLine("user called the update item endpoint");
                return Ok(updatedItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            try
            {
                var deletedItem = await _itemService.DeleteItemAsync(id);
                Console.WriteLine("user called the delete item endpoint");
                return Ok(deletedItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
