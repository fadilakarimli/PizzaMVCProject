namespace PizzaProject.ViewModels.Admin.Chef
{
    public class ChefEditVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }

        public string? CurrentImageUrl { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}
