using PizzaProject.ViewModels.Admin.Category;

namespace PizzaProject.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllAsync();
        Task<CategoryDetailVM> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateVM model);
        Task UpdateAsync(CategoryEditVM model);
        Task DeleteAsync(int id);
    }
}
