using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace MenuConfigurator.Host
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Api.ApiConfiguration
                .ConfigureServices(services, environment, Configuration)
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MenuConfiguratorApi", Version = "v1" });
                })
                .AddCustomDbContext(Configuration)
                .AddCustomAuthentication(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            var allowedOrigins = Configuration.GetSection("AllowedOrigins").Get<IEnumerable<string>>();
            Serilog.Log.Logger.Information("Origins: " + string.Join(", ", allowedOrigins));

            Api.ApiConfiguration.Configure(app, host =>
            {
                var builder = host
                    .UseCors(policy =>
                         policy.WithOrigins(allowedOrigins.ToArray())
                         .AllowAnyMethod()
                         .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
                         .AllowCredentials())
                    .UseDefaultFiles()
                    .UseStaticFiles();

                if (environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MenuConfigurator Api"));
                }
                return builder;
            });
        }
    }
}
