using Microsoft.AspNetCore.Mvc;
using PizzaProject.Services.Interfaces;
using PizzaProject.ViewModels.Admin.HomeInfo;

namespace PizzaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeInfoController : Controller
    {
        private readonly IHomeInfoService _homeInfoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeInfoController(IHomeInfoService homeInfoService, IWebHostEnvironment webHostEnvironment)
        {
            _homeInfoService = homeInfoService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: HomeInfo/Index
        public async Task<IActionResult> Index()
        {
            var infos = await _homeInfoService.GetAllAsync();
            return View(infos);
        }

        // GET: HomeInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeInfo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeInfoCreateVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _homeInfoService.CreateAsync(model, _webHostEnvironment.WebRootPath);
            return RedirectToAction(nameof(Index));
        }

        // GET: HomeInfo/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var info = await _homeInfoService.GetEditAsync(id);
            return View(info);
        }

        // POST: HomeInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HomeInfoEditVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _homeInfoService.EditAsync(id, model, _webHostEnvironment.WebRootPath);
            return RedirectToAction(nameof(Index));
        }

        // GET: HomeInfo/Detail/5
        public async Task<IActionResult> Detail(int id)
        {
            var info = await _homeInfoService.GetDetailAsync(id);
            return View(info);
        }

        // POST: HomeInfo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _homeInfoService.DeleteAsync(id, _webHostEnvironment.WebRootPath);
            return RedirectToAction(nameof(Index));
        }
    }
}
