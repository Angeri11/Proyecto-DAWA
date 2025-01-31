using Core.DependencyInjection;

namespace Presentation.Extensions.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationModules(this IServiceCollection services, IConfiguration configuration)
        {
            CoreServiceCollectionExtensions.AddInfrastructureServices(services, configuration);
        }
    }
}
