using PizzaProject.ViewModels.Admin.Chef;

namespace PizzaProject.Services.Interfaces
{
    public interface IChefService
    {
        Task<List<ChefVM>> GetAllAsync();
        Task<ChefVM> GetByIdAsync(int id);
        Task CreateAsync(ChefCreateVM model);
        Task UpdateAsync(ChefEditVM model);
        Task DeleteAsync(int id);
        Task<ChefEditVM> GetByIdForEditAsync(int id);
    }
}
