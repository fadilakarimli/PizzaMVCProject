namespace PizzaProject.ViewModels.Admin.HomeInfo
{
    public class HomeInfoEditVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
    }
}
