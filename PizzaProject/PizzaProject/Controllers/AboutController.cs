using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
