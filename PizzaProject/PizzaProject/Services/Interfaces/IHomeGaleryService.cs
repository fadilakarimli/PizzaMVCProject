using PizzaProject.ViewModels.Admin.HomeGalery;

namespace PizzaProject.Services.Interfaces
{
    public interface IHomeGaleryService
    {
        Task<List<HomeGaleryVM>> GetAllAsync();
        Task<HomeGaleryEditVM> GetByIdAsync(int id);
        Task CreateAsync(HomeGaleryCreateVM model);
        Task UpdateAsync(HomeGaleryEditVM model);
        Task DeleteAsync(int id);
    }
}
