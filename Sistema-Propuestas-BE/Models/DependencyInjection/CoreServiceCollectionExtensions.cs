using Core.Data.Context;
using Core.Repositories;
using Core.RepositoryImplementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyInjection
{
    public static class CoreServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Conexion")));

            services.AddScoped<IPropuestaRepository, PropuestaRepositoryImpl>();
            services.AddScoped<IRevisorRepository, RevisorRepositoryImpl>();
        }
    }
}
