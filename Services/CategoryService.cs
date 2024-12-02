using ECommerce.DTOs.Category;
using ECommerce.Interfaces.Repository;
using ECommerce.Interfaces.Service;
using ECommerce.Mappers;
using ECommerce.Repository;

namespace ECommerce.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryRequestDto categoryDto)
        {
            var existingCategory = await _categoryRepo.GetCategoryByNameAsync(categoryDto.CategoryName);
            if (existingCategory != null)
                throw new Exception("Category already exists");

            var categoryModel = categoryDto.ToCategoryFromCreateDto();
            categoryModel.CreatedOn = DateTime.Now;

            await _categoryRepo.CreateCategoryAsync(categoryModel);
            return categoryModel.ToCategoryDto();
        }

        public async Task<CategoryDto> DeleteCategoryAsync(int id)
        {
            var deletedCategory = await _categoryRepo.DeleteCategoryAsync(id);
            if (deletedCategory == null)
                throw new Exception("Categor not found");
            return deletedCategory.ToCategoryDto();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var category = await _categoryRepo.GetAllCategoriesAsync();
            return category.Select(a => a.ToCategoryDto());
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepo.GetCategoryByIdAsync(id);
            if (category == null)
                throw new Exception("Category not found");
            return category.ToCategoryDto();
        }

        public async Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryRequestDto categoryDto)
        {
            var updatedCategory = await _categoryRepo.UpdateCategoryAsync(id, categoryDto);
            if (updatedCategory == null)
                throw new Exception("Category not found");
            return updatedCategory.ToCategoryDto();
        }
    }
}
