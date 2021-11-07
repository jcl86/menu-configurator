using MenuConfigurator.Domain;
using MenuConfigurator.Infraestructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomRepositoriesExtensions
    {
        public static IServiceCollection AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDishRepository, DishRepository>();
            return services;
        }
    }
}
