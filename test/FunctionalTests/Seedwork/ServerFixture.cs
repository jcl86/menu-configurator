using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Bogus;
using MenuConfigurator.Infraestructure;

namespace MenuConfigurator.FunctionalTests
{
    public class ServerFixture
    {
        public IConfiguration Configuration { get; }
        public TestServer Server { get; private set; }

        public ServerFixture()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(Serilog.Events.LogEventLevel.Warning)
                .CreateLogger();

            var host = new HostBuilder()
              .ConfigureWebHost(webBuilder =>
              {
                  webBuilder
                    .UseTestServer()
                    .UseSerilog()
                    .UseStartup<TestStartup>()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureAppConfiguration(app =>
                    {
                        app.AddJsonFile("funtionalTestsSettings.json", optional: true);
                        app.AddUserSecrets(typeof(ServerFixture).Assembly, optional: true);
                        app.AddEnvironmentVariables();
                    });
              })
              .Start();

            host.MigrateDbContext<MenuContext>();
            Server = host.GetTestServer();
            Configuration = Server.Services.GetService<IConfiguration>();

            Randomizer.Seed = new Random();
            InitializeDatabase();
        }

        protected virtual void InitializeDatabase()
        {
            var context = Server.Services.GetService<MenuContext>();

            //Here populate database
        }
    }

}
