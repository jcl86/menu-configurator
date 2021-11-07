using Legacy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            //services.Configure<IdentityServerConfiguration>(configuration.GetSection("IdentityServerConfiguration"));
            //services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<IdentityServerConfiguration>>().Value);

            return services;
        }
    }
}
