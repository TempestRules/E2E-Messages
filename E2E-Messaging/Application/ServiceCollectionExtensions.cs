using Application.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IJWTService, TokenService>();

            services.AddOptions<JWTOptions>();
            services.AddScoped(s => s.GetService<IConfiguration>()!.GetSection(nameof(JWTOptions)).Get<JWTOptions>()!);

            return services;
        }
    }
}
