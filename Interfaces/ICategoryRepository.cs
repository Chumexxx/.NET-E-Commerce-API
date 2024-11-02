using ECommerce.DTOs.Category;
using ECommerce.Models;

namespace ECommerce.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category categotyModel);
        Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto);
        Task<Category?> DeleteByIdAsync(int id);
        Task<bool> CategoryExists(int id);
    }
}
