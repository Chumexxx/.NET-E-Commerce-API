using ECommerce.Data;
using ECommerce.DTOs.Category;
using ECommerce.DTOs.Item;
using ECommerce.Helpers;
using ECommerce.Interfaces;
using ECommerce.Mappers;
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
        private readonly IItemRepository _itemRepo;
        public ItemController(ApplicationDBContext context, IItemRepository itemRepo)
        {
            _context = context;
            _itemRepo = itemRepo;
        }

        [HttpGet]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllItems([FromQuery] QueryObject query)
        {
            var items = await _itemRepo.GetAllAsync(query);

            var itemDto = items.Select(p => p.ToItemDto()).ToList();

            return Ok(itemDto);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetItemById([FromRoute] int id)
        {
            var item = await _itemRepo.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.ToItemDto());
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> CreateItem([FromBody] Items itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _itemRepo.GetByNameAsync(itemDto.ItemName);

            if (item != null)
            {
                return BadRequest("This item already exists");
            }

            var itemModel = itemDto.ToItemFromCreateDto();

            itemModel.CreatedOn = DateTime.Now;

            await _itemRepo.CreateAsync(itemModel);

            return CreatedAtAction(nameof(CreateItem), new { id = itemModel.ItemId }, itemModel.ToItemDto());

        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> UpdateItem([FromRoute] int id, [FromBody] UpdateItemRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var itemModel = await _itemRepo.UpdateAsync(id, updateDto);

            if (itemModel == null)
            {
                return NotFound("Item does not exist");
            }

            return Ok(itemModel.ToItemDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var itemModel = await _itemRepo.DeleteAsync(id);

            if (itemModel == null)
            {
                return NotFound("Item does not exist");
            }

            return Ok(new { message = "Item had been deleted successfully" });
        }
    }
}
