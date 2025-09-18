using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
	public class HomeGaleryViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
