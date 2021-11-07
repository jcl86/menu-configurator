using MenuConfigurator.Domain;
using MenuConfigurator.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            foreach (var serviceType in FindFromAssemblies(
                typeof(DishFinder).Assembly, typeof(MenuContext).Assembly
                ))
            {
                services.AddScoped(serviceType);
            }
            return services;
        }

        public static IEnumerable<Type> FindFromAssemblies(params Assembly[] assemblies)
        {
            if (!assemblies.Any())
            {
                throw new ArgumentException("At least one assembly should be provided");
            }

            var types = assemblies
                .SelectMany(x => x.GetTypes())
                .Where(t => t.IsService());
            return types;
        }
        public static bool IsService(this Type type) => Attribute.IsDefined(type, typeof(ServiceAttribute));
        
    }

  
}
