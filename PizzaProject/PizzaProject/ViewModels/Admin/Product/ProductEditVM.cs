namespace PizzaProject.ViewModels.Admin.Product
{
    public class ProductEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }   // köhnə şəkil göstərmək üçün
        public IFormFile? NewImage { get; set; } // update zamanı yeni şəkil seçilə bilər
        public int CategoryId { get; set; }
    }
}
