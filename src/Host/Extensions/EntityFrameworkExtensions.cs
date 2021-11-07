using System.Reflection;
using MenuConfigurator.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MenuConfigurator.Host
{
    public static class EntityFrameworkExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, 
            IConfiguration configuration)
        {
            string migrationsAssembly = typeof(MenuContext).GetTypeInfo().Assembly.GetName().Name;
            string connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContextPool<MenuContext>(options =>
            {
                options.UseSqlServer(connectionString, options =>
                {
                    options.MigrationsAssembly(migrationsAssembly);
                });
            });
            return services;
        }
    }
}
