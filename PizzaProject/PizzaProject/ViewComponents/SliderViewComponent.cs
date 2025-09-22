using Microsoft.AspNetCore.Mvc;
using PizzaProject.Services.Interfaces;

namespace PizzaProject.ViewComponents
{
	public class SliderViewComponent : ViewComponent
	{
        private readonly ISliderService _sliderService;

        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _sliderService.GetAllAsync();
            return View(sliders);
        }
    }
}
