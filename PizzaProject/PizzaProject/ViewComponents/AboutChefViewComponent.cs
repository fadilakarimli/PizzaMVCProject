using Microsoft.AspNetCore.Mvc;
using PizzaProject.Services.Interfaces;

namespace PizzaProject.ViewComponents
{
    public class AboutChefViewComponent : ViewComponent
    {

        private readonly IChefService _chefService;

        public AboutChefViewComponent(IChefService chefService)
        {
            _chefService = chefService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var chefs = await _chefService.GetAllAsync();
            return View(chefs); // ViewComponent view-inə göndərilir
        }
    }
}
