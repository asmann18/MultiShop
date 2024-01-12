using MultiShop.Repositories.Implementations;
using MultiShop.Repositories.Interfaces;
using MultiShop.Services.Implementations;
using MultiShop.Services.Interfaces;
using System.Reflection;

namespace MultiShop.Utilities
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddScoppedRegister(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();


            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IServiceService, ServiceService>();



            return services;
        }
    }
}
