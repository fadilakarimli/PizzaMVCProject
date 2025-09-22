using Microsoft.AspNetCore.Mvc;
using PizzaProject.Helpers.Icon;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.HomeService;

namespace PizzaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeServiceController : Controller
    {
        private readonly IServiceHomeService _serviceService;

        public HomeServiceController(IServiceHomeService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var services = await _serviceService.GetAllAsync();
            return View(services);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.Icons = IconList.Icons; // dropdown üçün göndəririk
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Icons = IconList.Icons;
                return View(model);
            }

            await _serviceService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var service = await _serviceService.GetEditAsync(id);
            ViewBag.Icons = IconList.Icons;
            return View(service);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceEditVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Icons = IconList.Icons;
                return View(model);
            }

            await _serviceService.EditAsync(id, model);
            return RedirectToAction(nameof(Index));
        }

        // GET: Details
        public async Task<IActionResult> Detail(int id)
        {
            var service = await _serviceService.GetDetailAsync(id);
            return View(service);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
