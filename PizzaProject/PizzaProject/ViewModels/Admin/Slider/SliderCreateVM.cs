using System.ComponentModel.DataAnnotations;

namespace PizzaProject.ViewModels.Admin.Slider
{
    public class SliderCreateVM
    {

        [Required]
        public string Subheading { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IFormFile Image { get; set; } 
    }
}
