using Microsoft.AspNetCore.Mvc;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.Chef;

namespace PizzaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChefController : Controller
    {
        private readonly IChefService _service;

        public ChefController(IChefService service)
        {
            _service = service;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // CREATE (GET)
        public IActionResult Create() => View();

        // CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(ChefCreateVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _service.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.GetByIdForEditAsync(id); // indi ChefEditVM qaytarır
            if (model == null) return NotFound();

            return View(model); // view ilə tip uyğunlaşdı
        }


        // EDIT (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(ChefEditVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _service.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var chef = await _service.GetByIdAsync(id);
            if (chef == null) return NotFound();

            return View(chef); // ChefVM ilə uyğun
        }


    }
}
