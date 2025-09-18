using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
	public class HomeMenuViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
