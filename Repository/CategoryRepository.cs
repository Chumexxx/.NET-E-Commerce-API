﻿using ECommerce.Data;
using ECommerce.DTOs.Category;
using ECommerce.Interfaces;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> CategoryExists(int id)
        {
            return await _context.Categories.AnyAsync(i => i.CategoryId == id);
        }

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            var categoryName = categoryModel.CategoryName;
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == categoryName);

            if (existingCategory == null)
            {
                return null;
            }
            await _context.Categories.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteByIdAsync(int id)
        {
            var categoryModel = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

            if (categoryModel == null)
            {
                return null;
            }

            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(p => p.Item).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(i => i.Item).FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (existingCategory == null)
            {
                return null;
            }


            existingCategory.CategoryName = categoryDto.CategoryName;

            await _context.SaveChangesAsync();

            return existingCategory;
        }
    }
}
