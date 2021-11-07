using Legacy;
using Legacy.Analytes.Domain;
using Legacy.Common.Domain;
using Legacy.Data;
using Legacy.Equipment.Domain;
using Legacy.HumanResources.Domain;
using Legacy.Labnet;
using Legacy.ModuloSat;
using Legacy.Production.Domain;
using Legacy.Results.Domain;
using Legacy.Sales.Domain;
using Legacy.SatModule.Domain;
using Legacy.Supplies.Domain;
using MenuConfigurator.Domain;
using MenuConfigurator.Infraestructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomRepositoriesExtensions
    {
        public static IServiceCollection AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, MenuContext>();
            services.AddScoped<IDishRepository, DishRepository>();
            return services;
        }

    }
}
