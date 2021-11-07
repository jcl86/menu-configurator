using Acheve.AspNetCore.TestHost.Security;
using Acheve.TestHost;
using Hellang.Middleware.ProblemDetails;
using MenuConfigurator.Api;
using MenuConfigurator.Infraestructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MenuConfigurator.FunctionalTests
{
    public class TestStartup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public TestStartup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ApiConfiguration.ConfigureServices(services, environment, configuration)
                .AddProblemDetails(configure =>
                {
                    configure.IncludeExceptionDetails = (context, exception) => true;
                })
                .AddDbContextPool<MenuContext>(setup =>
                {
                    string connectionString = configuration.GetConnectionString("SqlServer");
                    setup.UseSqlServer(connectionString, sqlServerOptions =>
                    {
                        sqlServerOptions.MigrationsAssembly(typeof(MenuContext).Assembly.FullName);
                    });
                })
                .AddAuthorization()
                .AddAuthentication(setup =>
                {
                    setup.DefaultAuthenticateScheme = TestServerDefaults.AuthenticationScheme;
                    setup.DefaultChallengeScheme = TestServerDefaults.AuthenticationScheme;
                })
                .AddTestServer();
        }


        public void Configure(IApplicationBuilder app)
        {
            ApiConfiguration.Configure(app, host => host);
        }
    }
}
