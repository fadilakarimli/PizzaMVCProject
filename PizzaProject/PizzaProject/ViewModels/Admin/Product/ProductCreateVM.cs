namespace PizzaProject.ViewModels.Admin.Product
{
    public class ProductCreateVM
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }  // upload üçün
        public int CategoryId { get; set; }
    }
}
