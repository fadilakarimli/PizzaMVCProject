using Microsoft.EntityFrameworkCore;
using PizzaProject.Data;
using PizzaProject.Models;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.HomeGalery;

namespace PizzaProject.Services
{
    public class HomeGaleryService : IHomeGaleryService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeGaleryService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<HomeGaleryVM>> GetAllAsync()
        {
            return await _context.HomeGaleries
                .Select(x => new HomeGaleryVM
                {
                    Id = x.Id,
                    Image = x.Image
                }).ToListAsync();
        }

        public async Task<HomeGaleryEditVM> GetByIdAsync(int id)
        {
            var galery = await _context.HomeGaleries.FindAsync(id);
            if (galery == null) throw new Exception("Galery not found");

            return new HomeGaleryEditVM
            {
                Id = galery.Id,
                Image = galery.Image
            };
        }

        public async Task CreateAsync(HomeGaleryCreateVM model)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
            string path = Path.Combine(_env.WebRootPath, "images/", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.Image.CopyToAsync(stream);
            }

            var galery = new HomeGalery
            {
                Image = "/images/" + fileName
            };

            _context.HomeGaleries.Add(galery);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HomeGaleryEditVM model)
        {
            var galery = await _context.HomeGaleries.FindAsync(model.Id);
            if (galery == null) throw new Exception("Galery not found");

            if (model.NewImage != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewImage.FileName);
                string path = Path.Combine(_env.WebRootPath, "images/", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.NewImage.CopyToAsync(stream);
                }

                galery.Image = "/images/" + fileName;
            }

            _context.HomeGaleries.Update(galery);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var galery = await _context.HomeGaleries.FindAsync(id);
            if (galery == null) throw new Exception("Galery not found");

            _context.HomeGaleries.Remove(galery);
            await _context.SaveChangesAsync();
        }
    }
}
