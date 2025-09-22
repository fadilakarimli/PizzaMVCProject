namespace PizzaProject.ViewModels.Admin.HomeGalery
{
    public class HomeGaleryEditVM
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}
