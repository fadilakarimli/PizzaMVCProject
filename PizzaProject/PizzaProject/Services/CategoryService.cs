using Microsoft.EntityFrameworkCore;
using PizzaProject.Data;
using PizzaProject.Models;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.Category;

namespace PizzaProject.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CategoryCreateVM model)
        {
            var category = new Category
            {
                Name = model.Name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new Exception("Category not found");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryVM>> GetAllAsync()
        {
            return await _context.Categories
                .Select(x => new CategoryVM
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }

        public async Task<CategoryDetailVM> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null) throw new Exception("Category not found");

            return new CategoryDetailVM
            {
                Id = category.Id,
                Name = category.Name,
                ProductNames = category.Products.Select(p => p.Name).ToList()
            };
        }

        public async Task UpdateAsync(CategoryEditVM model)
        {
            var category = await _context.Categories.FindAsync(model.Id);
            if (category == null) throw new Exception("Category not found");

            category.Name = model.Name;
            _context.Categories.Update(category);

            await _context.SaveChangesAsync();
        }

    }
}



