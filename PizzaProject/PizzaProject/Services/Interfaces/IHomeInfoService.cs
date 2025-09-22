using PizzaProject.Models;
using PizzaProject.ViewModels.Admin.HomeInfo;

namespace PizzaProject.Services.Interfaces
{
    public interface IHomeInfoService
    {
        Task<List<HomeInfoVM>> GetAllAsync();
        Task<HomeInfoDetailVM> GetDetailAsync(int id);
        Task CreateAsync(HomeInfoCreateVM request, string webRootPath);
        Task<HomeInfoEditVM> GetEditAsync(int id);
        Task EditAsync(int id, HomeInfoEditVM request, string webRootPath);
        Task DeleteAsync(int id, string webRootPath);
    }
}
