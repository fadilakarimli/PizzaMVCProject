using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
    public class AboutSliderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
