using Microsoft.EntityFrameworkCore;
using PizzaProject.Data;
using PizzaProject.Models;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.HomeInfo;

namespace PizzaProject.Services
{
    public class HomeInfoService : IHomeInfoService
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;

        public HomeInfoService(AppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<List<HomeInfoVM>> GetAllAsync()
        {
            return await _context.HomeInfos
                .Select(h => new HomeInfoVM
                {
                    Id = h.Id,
                    Title = h.Title,
                    Description = h.Description,
                    Image = h.Image
                })
                .ToListAsync();
        }

        public async Task<HomeInfoDetailVM> GetDetailAsync(int id)
        {
            var homeInfo = await _context.HomeInfos.FirstOrDefaultAsync(h => h.Id == id);
            if (homeInfo == null) throw new Exception("HomeInfo not found");

            return new HomeInfoDetailVM
            {
                Title = homeInfo.Title,
                Description = homeInfo.Description,
                Image = homeInfo.Image
            };
        }

        public async Task CreateAsync(HomeInfoCreateVM request, string webRootPath)
        {
            string fileName = await _fileService.UploadAsync(request.Image, webRootPath, "images");

            var homeInfo = new HomeInfo
            {
                Title = request.Title,
                Description = request.Description,
                Image = fileName
            };

            await _context.HomeInfos.AddAsync(homeInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<HomeInfoEditVM> GetEditAsync(int id)
        {
            var homeInfo = await _context.HomeInfos.FirstOrDefaultAsync(h => h.Id == id);
            if (homeInfo == null) throw new Exception("HomeInfo not found");

            return new HomeInfoEditVM
            {
                Id = homeInfo.Id,
                Title = homeInfo.Title,
                Description = homeInfo.Description,
                ImagePath = homeInfo.Image
            };
        }

        public async Task EditAsync(int id, HomeInfoEditVM request, string webRootPath)
        {
            var homeInfo = await _context.HomeInfos.FirstOrDefaultAsync(h => h.Id == id);
            if (homeInfo == null) throw new Exception("HomeInfo not found");

            homeInfo.Title = request.Title;
            homeInfo.Description = request.Description;

            if (request.Image != null)
            {
                if (!string.IsNullOrEmpty(homeInfo.Image))
                {
                    string oldImagePath = Path.Combine(webRootPath, "images", homeInfo.Image);
                    _fileService.Delete(oldImagePath);
                }

                homeInfo.Image = await _fileService.UploadAsync(request.Image, webRootPath, "images");
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string webRootPath)
        {
            var homeInfo = await _context.HomeInfos.FirstOrDefaultAsync(h => h.Id == id);
            if (homeInfo == null) throw new Exception("HomeInfo not found");

            if (!string.IsNullOrEmpty(homeInfo.Image))
            {
                string path = Path.Combine(webRootPath, "images", homeInfo.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }

            _context.HomeInfos.Remove(homeInfo);
            await _context.SaveChangesAsync();
        }
    }
}
