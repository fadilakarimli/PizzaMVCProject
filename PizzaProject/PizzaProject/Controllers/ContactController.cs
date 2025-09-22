using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
