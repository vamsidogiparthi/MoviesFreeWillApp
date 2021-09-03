using Microsoft.Extensions.DependencyInjection;
using MoviesWebAPI.Logic.Business.Interfaces;
using MoviesWebAPI.Logic.Business.Persistance;
using System;
using System.Reflection;

namespace MoviesWebAPI.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IBusinessGetMovies, BusinessGetMovies>();
            services.AddTransient<IBusinessGetUsers, BusinessGetUsers>();
            services.AddTransient<IBusinessAddOrUpdateUserMovieRating, BusinessAddOrUpdateUserMovieRatingLogic>();         
            return services;
        }
    }
}
