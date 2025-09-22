using Microsoft.AspNetCore.Mvc;
using PizzaProject.Services.Interfaces;

namespace PizzaProject.ViewComponents
{
    public class HomeGaleryViewComponent : ViewComponent
    {
        private readonly IHomeGaleryService _service;

        public HomeGaleryViewComponent(IHomeGaleryService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }
    }
}
