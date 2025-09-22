using Microsoft.AspNetCore.Mvc;
using PizzaProject.Services.Interfaces;

namespace PizzaProject.ViewComponents
{
	public class HomeServiceViewComponent : ViewComponent
	{
        private readonly IServiceHomeService _serviceService;

        public HomeServiceViewComponent(IServiceHomeService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _serviceService.GetAllAsync();
            return View(services); // Services listini view-a göndəririk
        }
    }
}

