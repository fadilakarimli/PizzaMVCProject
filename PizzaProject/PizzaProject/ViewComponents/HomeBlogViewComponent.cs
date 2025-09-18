using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
	public class HomeBlogViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
