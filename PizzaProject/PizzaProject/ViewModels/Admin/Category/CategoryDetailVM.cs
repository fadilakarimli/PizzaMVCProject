namespace PizzaProject.ViewModels.Admin.Category
{
    public class CategoryDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<string>? ProductNames { get; set; }
    }
}
