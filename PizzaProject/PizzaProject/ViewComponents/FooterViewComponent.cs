using Microsoft.AspNetCore.Mvc;

namespace PizzaProject.ViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
