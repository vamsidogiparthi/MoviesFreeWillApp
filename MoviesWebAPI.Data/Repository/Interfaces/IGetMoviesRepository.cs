using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoviesWebAPI.Data.Repository.Interfaces
{
    public interface IGetMoviesRepository
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<IEnumerable<MovieDto>> GetMoviesByFilter(Expression<Func<Movie, bool>> filter);
        Task<MovieDto> GetMovieByIdAsync(int id);
        Task<IEnumerable<MovieDto>> GetMoviesByUserAsync(int userId);
        Task<MovieRatingDto> GetMovieUserRatingByMovieAndUserIdAsync(int userId, int movieId);


    }
}
