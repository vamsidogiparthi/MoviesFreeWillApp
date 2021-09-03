using MoviesWebAPI.Common.Filter.MovieSearchFilters;
using MoviesWebAPI.Logic.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesWebAPI.Logic.Business.Interfaces
{
    public interface IBusinessGetMovies
    {
        // Method to get all the movies async without parameters
        Task<List<MovieViewModel>> GetAllMoviesAsync();
        Task<List<MovieViewModel>> GetMoviesByFilter(MovieSearchFilter movieSearchFilter);
        Task<MovieViewModel> GetMovieByIdAsync(int id);
        Task<List<MovieViewModel>> GetMovieByPagingAsync(int pageNumber=0, int pageSize = 5);
        Task<List<MovieViewModel>> GetMoviesByUserAsync(int userId);

    }
}
