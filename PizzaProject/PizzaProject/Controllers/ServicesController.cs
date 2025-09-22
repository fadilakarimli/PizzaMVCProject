using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
