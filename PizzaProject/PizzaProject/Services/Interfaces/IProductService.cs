using PizzaProject.ViewModels.Admin.Product;

namespace PizzaProject.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetAllAsync();
        Task<ProductDetailVM> GetByIdAsync(int id);
        Task CreateAsync(ProductCreateVM model);
        Task UpdateAsync(ProductEditVM model);
        Task DeleteAsync(int id);
    }

}
