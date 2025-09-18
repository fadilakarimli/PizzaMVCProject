using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PizzaProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
