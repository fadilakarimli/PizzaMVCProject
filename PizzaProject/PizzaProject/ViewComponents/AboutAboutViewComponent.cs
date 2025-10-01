using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
    public class AboutAboutViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
