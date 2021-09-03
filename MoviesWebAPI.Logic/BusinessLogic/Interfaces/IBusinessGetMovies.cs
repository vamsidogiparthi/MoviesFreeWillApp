using MoviesWebAPI.Common.Filter.MovieSearchFilters;
using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.Models;
using MoviesWebAPI.Logic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoviesWebAPI.Logic.Business.Interfaces
{
    public interface IBusinessGetMovies
    {
        Task<List<MovieViewModel>> GetAllMoviesAsync();
        Task<List<MovieViewModel>> GetMoviesByFilter(MovieSearchFilter movieSearchFilter);
        Task<MovieViewModel> GetMovieByIdAsync(int id);
        Task<List<MovieViewModel>> GetMovieByPagingAsync(int pageNumber=0, int pageSize = 5);
        Task<List<MovieViewModel>> GetMoviesByUserAsync(int userId);

    }
}
