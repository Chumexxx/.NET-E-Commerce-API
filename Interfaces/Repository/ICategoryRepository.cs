using ECommerce.DTOs.Category;
using ECommerce.Models;

namespace ECommerce.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category?> GetCategoryByNameAsync(string categoryName);
        Task<Category> CreateCategoryAsync(Category categotyModel);
        Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryRequestDto categoryDto);
        Task<Category?> DeleteCategoryAsync(int id);
        Task<bool> CategoryExists(int id);
    }
}
