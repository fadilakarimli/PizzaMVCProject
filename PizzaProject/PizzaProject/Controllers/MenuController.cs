using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
