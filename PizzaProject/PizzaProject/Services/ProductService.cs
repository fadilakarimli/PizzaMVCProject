using Microsoft.EntityFrameworkCore;
using PizzaProject.Data;
using PizzaProject.Models;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.Product;

namespace PizzaProject.Services
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task CreateAsync(ProductCreateVM model)
        {
            // Category yoxlaması
            var category = await _context.Categories.FindAsync(model.CategoryId);
            if (category == null) throw new Exception("Category not found");

            // Image upload
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
            string path = Path.Combine(_env.WebRootPath, "images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.Image.CopyToAsync(stream);
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = "/images/" + fileName,
                CategoryId = model.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new Exception("Product not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductVM>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.Name
                })
                .ToListAsync();
        }

        public async Task<ProductDetailVM> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) throw new Exception("Product not found");

            return new ProductDetailVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category?.Name
            };
        }

        public async Task UpdateAsync(ProductEditVM model)
        {
            var product = await _context.Products.FindAsync(model.Id);
            if (product == null) throw new Exception("Product not found");

            // Category yoxlaması
            var category = await _context.Categories.FindAsync(model.CategoryId);
            if (category == null) throw new Exception("Category not found");

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;

            if (model.NewImage != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewImage.FileName);
                string path = Path.Combine(_env.WebRootPath, "images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.NewImage.CopyToAsync(stream);
                }

                product.ImageUrl = "/images/" + fileName;
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
