using Microsoft.AspNetCore.Mvc;
using PizzaProject.Services.Interfaces;

namespace PizzaProject.ViewComponents
{
    public class HomeInfoViewComponent : ViewComponent
    {
        private readonly IHomeInfoService _homeInfoService;

        public HomeInfoViewComponent(IHomeInfoService homeInfoService)
        {
            _homeInfoService = homeInfoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var homeInfos = await _homeInfoService.GetAllAsync();

            return View(homeInfos);
        }
    }
}
