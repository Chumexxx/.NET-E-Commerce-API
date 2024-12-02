using ECommerce.Data;
using ECommerce.DTOs.Category;
using ECommerce.Interfaces.Repository;
using ECommerce.Interfaces.Service;
using ECommerce.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getAllCategories")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                Console.WriteLine("user called the get all categories endpoint");
                return Ok(categories);

            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                Console.WriteLine("user called the get category by id endpoint");
                return Ok(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("createACategory")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdCategory = await _categoryService.CreateCategoryAsync(categoryDto);
                Console.WriteLine("user called the create category endpoint");
                return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryId }, createdCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedCategory = await _categoryService.UpdateCategoryAsync(id, updateDto);
                Console.WriteLine("user called the update category endpoint");
                return Ok(updatedCategory);
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
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var deletedCategory = await _categoryService.DeleteCategoryAsync(id);
                Console.WriteLine("user called the delete category endpoint");
                return Ok(deletedCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
