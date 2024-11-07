using Domain.Models.Users;
using Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 25;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
            })
            .AddEntityFrameworkStores<E2EMessagingDatabaseContext>();

            return services;
        }

    }
}
