using Microsoft.AspNetCore.Mvc;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.Slider;

namespace PizzaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(ISliderService sliderService, IWebHostEnvironment webHostEnvironment)
        {
            _sliderService = sliderService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Slider/Index
        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.GetAllAsync();
            return View(sliders);
        }

        // GET: Slider/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Slider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _sliderService.CreateAsync(model, _webHostEnvironment.WebRootPath);
            return RedirectToAction(nameof(Index));
        }

        // GET: Slider/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var slider = await _sliderService.GetEditAsync(id);
            return View(slider);
        }

        // POST: Slider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SliderEditVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _sliderService.EditAsync(id, model, _webHostEnvironment.WebRootPath);
            return RedirectToAction(nameof(Index));
        }

        // GET: Slider/Details/5
        public async Task<IActionResult> Detail(int id)
        {
            var slider = await _sliderService.GetDetailAsync(id);
            return View(slider);
        }

        // POST: Slider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderService.DeleteAsync(id, _webHostEnvironment.WebRootPath);
            return RedirectToAction(nameof(Index));
        }
    }
}
