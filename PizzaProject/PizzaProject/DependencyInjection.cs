using PizzaProject.Services;
using PizzaProject.Services.Interfaces;

namespace PizzaProject
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IHomeInfoService, HomeInfoService>();
            services.AddScoped<IServiceHomeService, ServiceHomeService>();
            services.AddScoped<IHomeGaleryService, HomeGaleryService>();
            services.AddScoped<IChefService, ChefService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;

        }
    }
}
