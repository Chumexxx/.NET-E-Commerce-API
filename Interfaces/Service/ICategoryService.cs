using ECommerce.DTOs.Category;

namespace ECommerce.Interfaces.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryRequestDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryRequestDto categoryDto);
        Task<CategoryDto> DeleteCategoryAsync(int id);
    }
}
