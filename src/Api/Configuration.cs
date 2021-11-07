using System;

namespace MenuConfigurator.Api
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            return services
                .AddHttpContextAccessor()
                .AddCustomMvc()
                //.AddAuthorization(ApiPolicies.Configure)
                .AddCustomConfiguration(configuration)
                .AddCustomHttpClients(configuration)
                .AddProblemDetails(environment, configuration)
                .AddMemoryCache()
                .AddCustomApiBehaviour()
                .AddCustomRepositories()
                .AddCustomServices();
        }

        public static IApplicationBuilder Configure(IApplicationBuilder app, Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            return configureHost(app)
                .UseProblemDetails()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync($"Welcome to Menu configuratorfrom {Environment.MachineName}");
                    });
                });
        }
    }
}