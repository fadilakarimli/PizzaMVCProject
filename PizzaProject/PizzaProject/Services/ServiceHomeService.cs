using Microsoft.EntityFrameworkCore;
using PizzaProject.Data;
using PizzaProject.Models;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.HomeService;

namespace PizzaProject.Services
{
    public class ServiceHomeService : IServiceHomeService
    {
        private readonly AppDbContext _context;

        public ServiceHomeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ServiceCreateVM request)
        {
            var service = new HomeService
            {
                Icon = request.Icon,
                Title = request.Title,
                Description = request.Description
            };

            await _context.HomeServices.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await _context.HomeServices.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null) throw new Exception("Service not found");

            _context.HomeServices.Remove(service);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, ServiceEditVM request)
        {
            var service = await _context.HomeServices.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null) throw new Exception("Service not found");

            service.Icon = request.Icon;
            service.Title = request.Title;
            service.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        public async Task<List<ServiceVM>> GetAllAsync()
        {
            return await _context.HomeServices
                .Select(s => new ServiceVM
                {
                    Id = s.Id,
                    Icon = s.Icon,
                    Title = s.Title,
                    Description = s.Description
                })
                .ToListAsync();
        }

        public async Task<ServiceDetailVM> GetDetailAsync(int id)
        {
            var service = await _context.HomeServices.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null) throw new Exception("Service not found");

            return new ServiceDetailVM
            {
                Icon = service.Icon,
                Title = service.Title,
                Description = service.Description
            };
        }
        public async Task<ServiceEditVM> GetEditAsync(int id)
        {
            var service = await _context.HomeServices.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null) throw new Exception("Service not found");

            return new ServiceEditVM
            {
                Id = service.Id,
                Icon = service.Icon,
                Title = service.Title,
                Description = service.Description
            };
        }
    }
}
