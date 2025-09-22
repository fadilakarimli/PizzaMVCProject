using System.ComponentModel.DataAnnotations;

namespace PizzaProject.ViewModels.Admin.Slider
{
    public class SliderEditVM
    {

        public int Id { get; set; }

        [Required]
        public string Subheading { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile? Image { get; set; }

        public string? ImagePath { get; set; }
    }
}
