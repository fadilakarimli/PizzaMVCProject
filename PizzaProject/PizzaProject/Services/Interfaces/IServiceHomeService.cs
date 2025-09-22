using PizzaProject.ViewModels.Admin.HomeService;

namespace PizzaProject.Services.Interfaces
{
    public interface IServiceHomeService
    {
        Task<List<ServiceVM>> GetAllAsync();
        Task<ServiceDetailVM> GetDetailAsync(int id);
        Task CreateAsync(ServiceCreateVM request);
        Task<ServiceEditVM> GetEditAsync(int id);
        Task EditAsync(int id, ServiceEditVM request);
        Task DeleteAsync(int id);
    }
}
