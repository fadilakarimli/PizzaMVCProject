using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
	public class HomeInfoViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
