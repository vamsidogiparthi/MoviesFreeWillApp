using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using System;

namespace MoviesWebAPI.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAndRepository(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<MoviesAppContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("MoviesAppConn"));
            });
            return services;
        }

    }
}
