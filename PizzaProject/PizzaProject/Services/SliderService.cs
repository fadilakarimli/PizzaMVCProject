using Microsoft.EntityFrameworkCore;
using PizzaProject.Data;
using PizzaProject.Models;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.Slider;

namespace PizzaProject.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;

        public SliderService(AppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<List<SliderVM>> GetAllAsync()
        {
            return await _context.Sliders
                .Select(s => new SliderVM
                {
                    Id = s.Id,
                    Subheading = s.Subheading,
                    Title = s.Title,
                    Description = s.Description,
                    Image = s.Image
                })
                .ToListAsync();
        }

        public async Task<SliderDetailVM> GetDetailAsync(int id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) throw new Exception("Slider not found");

            return new SliderDetailVM
            {
                Subheading = slider.Subheading,
                Title = slider.Title,
                Description = slider.Description,
                Image = slider.Image
            };
        }

        public async Task CreateAsync(SliderCreateVM request, string webRootPath)
        {
            string fileName = await _fileService.UploadAsync(request.Image, webRootPath, "images");

            var slider = new Slider
            {
                Subheading = request.Subheading,
                Title = request.Title,
                Description = request.Description,
                Image = fileName
            };

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<SliderEditVM> GetEditAsync(int id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) throw new Exception("Slider not found");

            return new SliderEditVM
            {
                Id = slider.Id,
                Subheading = slider.Subheading,
                Title = slider.Title,
                Description = slider.Description,
                ImagePath = slider.Image
            };
        }

        public async Task EditAsync(int id, SliderEditVM request, string webRootPath)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) throw new Exception("Slider not found");

            slider.Subheading = request.Subheading;
            slider.Title = request.Title;
            slider.Description = request.Description;

            if (request.Image != null)
            {
                if (!string.IsNullOrEmpty(slider.Image))
                {
                    string oldImagePath = Path.Combine(webRootPath, "images", slider.Image);
                    _fileService.Delete(oldImagePath);
                }

                slider.Image = await _fileService.UploadAsync(request.Image, webRootPath, "images");
            }

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id, string webRootPath)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) throw new Exception("Slider not found");

            if (!string.IsNullOrEmpty(slider.Image))
            {
                string path = Path.Combine(webRootPath, "images", slider.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }
    }
}

