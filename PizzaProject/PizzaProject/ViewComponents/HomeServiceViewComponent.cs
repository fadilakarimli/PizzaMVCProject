using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
	public class HomeServiceViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

