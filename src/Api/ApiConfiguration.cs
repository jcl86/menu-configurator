using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace MenuConfigurator.Api
{
    public static class ApiConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, 
            IWebHostEnvironment environment, 
            IConfiguration configuration)
        {
            return services
                .AddHttpContextAccessor()
                .AddCustomMvc()
                //.AddAuthorization(ApiPolicies.Configure)
                .AddCustomConfiguration(configuration)
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
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync($"Welcome to Menu configurator from {Environment.MachineName}");
                    });
                });
        }
    }
}