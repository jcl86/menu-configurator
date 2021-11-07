using MenuConfigurator.Api;
using MenuConfigurator.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services) =>
            services
                .AddControllers()
                .AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly)
                .Services;

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
            services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<ApiSettings>>().Value);

            services.Configure<DefaultAdministrator>(configuration.GetSection("DefaultAdministrator"));
            services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<DefaultAdministrator>>().Value);

            return services;
        }
    }
}
