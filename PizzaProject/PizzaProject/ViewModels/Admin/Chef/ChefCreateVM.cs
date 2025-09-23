namespace PizzaProject.ViewModels.Admin.Chef
{
    public class ChefCreateVM
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
