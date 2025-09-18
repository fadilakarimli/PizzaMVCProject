using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
	public class SliderViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
