using Microsoft.AspNetCore.Mvc;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.HomeGalery;

namespace PizzaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeGaleryController : Controller
    {
        private readonly IHomeGaleryService _service;

        public HomeGaleryController(IHomeGaleryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(HomeGaleryCreateVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _service.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.GetByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HomeGaleryEditVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _service.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null) return NotFound();

            return View(model);
        }

    }
}
