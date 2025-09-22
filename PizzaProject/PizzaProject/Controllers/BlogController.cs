using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
