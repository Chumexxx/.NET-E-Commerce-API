using ECommerce.DTOs.Category;
using ECommerce.Models;

namespace ECommerce.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                CategoryId = categoryModel.CategoryId,
                CategoryName = categoryModel.CategoryName,
                CreatedOn = categoryModel.CreatedOn,
                Items = categoryModel.Item.Select(p => p.ToItemDto()).ToList(),
            };

        }

        public static Category ToCategoryFromCreateDto(this CreateCategoryRequestDto categoryDto)
        {
            return new Category
            {

                CategoryName = categoryDto.CategoryName,
            };
        }

        public static Category ToCategoryFromUpdate(this UpdateCategoryRequestDto categoryDto)
        {
            return new Category
            {
                CategoryName = categoryDto.CategoryName,
            };

        }
    }
}
