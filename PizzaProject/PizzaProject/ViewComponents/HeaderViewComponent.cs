using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
