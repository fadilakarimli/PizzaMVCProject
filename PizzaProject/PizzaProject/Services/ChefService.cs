using Microsoft.EntityFrameworkCore;
using PizzaProject.Data;
using PizzaProject.Models;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.Chef;

namespace PizzaProject.Services
{
    public class ChefService : IChefService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ChefService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<ChefVM>> GetAllAsync()
        {
            return await _context.Chefs
                .Select(x => new ChefVM
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Position = x.Position,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description
                }).ToListAsync();
        }

        public async Task<ChefVM> GetByIdAsync(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);
            if (chef == null) throw new Exception("Chef not found");

            return new ChefVM
            {
                Id = chef.Id,
                FullName = chef.FullName,
                Position = chef.Position,
                Description = chef.Description,
                ImageUrl = chef.ImageUrl  // buranı düzəltdik
            };
        }


        public async Task CreateAsync(ChefCreateVM model)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
            string path = Path.Combine(_env.WebRootPath, "images/", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.Image.CopyToAsync(stream);
            }

            var chef = new Chef
            {
                FullName = model.FullName,
                Position = model.Position,
                Description = model.Description,
                ImageUrl = "/images/" + fileName
            };

            _context.Chefs.Add(chef);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ChefEditVM model)
        {
            var chef = await _context.Chefs.FindAsync(model.Id);
            if (chef == null) throw new Exception("Chef not found");

            chef.FullName = model.FullName;
            chef.Position = model.Position;
            chef.Description = model.Description;

            if (model.NewImage != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewImage.FileName);
                string path = Path.Combine(_env.WebRootPath, "images/", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.NewImage.CopyToAsync(stream);
                }

                chef.ImageUrl = "/images/" + fileName;
            }

            _context.Chefs.Update(chef);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);
            if (chef == null) throw new Exception("Chef not found");

            _context.Chefs.Remove(chef);
            await _context.SaveChangesAsync();
        }


        public async Task<ChefEditVM> GetByIdForEditAsync(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);
            if (chef == null) throw new Exception("Chef not found");

            return new ChefEditVM
            {
                Id = chef.Id,
                FullName = chef.FullName,
                Position = chef.Position,
                Description = chef.Description,
                CurrentImageUrl = chef.ImageUrl
            };
        }

    }
}
