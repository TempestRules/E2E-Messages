using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
