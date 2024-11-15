using ECommerce.Data;
using ECommerce.DTOs.Category;
using ECommerce.Interfaces;
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
        private readonly ICategoryRepository _categoryRepo;
        private readonly ApplicationDBContext _context;
        public CategoryController(ApplicationDBContext context, ICategoryRepository categoryRepo)
        {
            _context = context;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();

            var categoryDto = categories.Select(s => s.ToCategoryDto()).ToList();

            return Ok(categoryDto);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound("The Id you entered does not exist");
            }

            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepo.GetByNameAsync(categoryDto.CategoryName);

            if (category != null)
            {
                return BadRequest("This category already exists");
            }

            var categoryModel = categoryDto.ToCategoryFromCreateDto();

            categoryModel.CreatedOn = DateTime.Now;

            await _categoryRepo.CreateAsync(categoryModel);

            return CreatedAtAction(nameof(CreateCategory), new { id = categoryModel.CategoryId }, categoryModel.ToCategoryDto());
        }


        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category not found");
            }

            var categoryModel = await _categoryRepo.UpdateAsync(id, updateDto);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return Ok(category.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = await _categoryRepo.DeleteByIdAsync(id);

            if (categoryModel == null)
            {
                return NotFound("Category not found");
            }

            return Ok(categoryModel);
        }
    }
}
