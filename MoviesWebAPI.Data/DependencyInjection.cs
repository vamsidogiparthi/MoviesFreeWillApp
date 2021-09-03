using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using System.Reflection;

namespace MoviesWebAPI.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAndRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<MoviesAppContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("MoviesAppConn"));
            });
            return services;
        }

    }
}
