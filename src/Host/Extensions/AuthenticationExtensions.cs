using System.Text;
using MenuConfigurator.Api;
using MenuConfigurator.Infraestructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MenuConfigurator.Host
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            var settings = configuration.GetSection("ApiSettings").Get<ApiSettings>();

            var key = Encoding.ASCII.GetBytes(settings.Secret);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
                            var username = context.Principal.Identity.Name;
                            var user = await userManager.FindByNameAsync(username);

                            if (user is null)
                            {
                                context.Fail("Unauthorized");
                            }
                        }
                    };
                    //options.RequireHttpsMetadata = environment.EnvironmentName == "Development";
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = settings.Issuer,
                        ValidAudience = settings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                    };
                });
            return services;
        }
    }
}
