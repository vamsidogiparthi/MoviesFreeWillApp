using AutoMapper;
using MoviesWebAPI.Common.Exceptions;
using MoviesWebAPI.Common.Filter.MovieSearchFilters;
using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using MoviesWebAPI.Data.Repository;
using MoviesWebAPI.Logic.Business.Interfaces;
using MoviesWebAPI.Logic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebAPI.Logic.Business.Persistance
{
    public class BusinessGetMovies : IBusinessGetMovies
    {
        private readonly MoviesAppContext _context;
        private readonly IMapper _mapper;
        private readonly UserMoviesRepositoryEF userMoviesRepositoryEF = null;

        public BusinessGetMovies(MoviesAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            userMoviesRepositoryEF = new UserMoviesRepositoryEF(_context, _mapper);
        }

        public async Task<List<MovieViewModel>> GetAllMoviesAsync()
        {
            var query = await userMoviesRepositoryEF.getMoviesRepository.GetAllMoviesAsync();
            var result = await GetMovieViewModel(query);
            return result.OrderByDescending(x => x.AverageRating).ThenBy(x => x.Title).ToList();
        }

        public async Task<List<MovieViewModel>> GetMoviesByFilter(MovieSearchFilter filter)
        {
            var validationResult = await ValidateMovieSearchFilter(filter);

            try
            {
                if (validationResult)
                {
                    var query = await userMoviesRepositoryEF.getMoviesRepository.GetAllMoviesAsync();
                    if (!string.IsNullOrEmpty(filter.Title))
                        query = query.Where(x => x.Title.ToUpper().Contains(filter.Title.ToUpper()));
                    if (filter.YearOfRelease.HasValue)
                        query = query.Where(x => x.YearOfRelease == filter.YearOfRelease);
                    if (filter.Genres != null && filter.Genres.Count() > 0)
                    {
                        filter.Genres = filter.Genres.ConvertAll(x => x.ToUpper());
                        query = query.Where(x => x.Genres.Any(t1 => filter.Genres.Contains(t1.Name.ToUpper())));
                    }
                    if (query.Count() == 0)
                        throw new NotFoundException("No Movies");

                    var result = await GetMovieViewModel(query);

                    return result.OrderByDescending(x => x.AverageRating).ThenBy(x => x.Title).ToList();
                }
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return new List<MovieViewModel>();
        }

        public async Task<List<MovieViewModel>> GetMovieByPagingAsync(int pageNumber = 0, int pageSize = 5)
        {
            var query = await userMoviesRepositoryEF.getMoviesRepository.GetAllMoviesAsync();
            if (query.Count() == 0)
                throw new NotFoundException();

            query = query.Skip((pageSize) * pageNumber).Take(pageSize);
            var result = await GetMovieViewModel(query);
            return result.OrderByDescending(x => x.AverageRating).ThenBy(x => x.Title).ToList();
        }

        public async Task<MovieViewModel> GetMovieByIdAsync(int id)
        {
            var movieDto = await userMoviesRepositoryEF.getMoviesRepository.GetMovieByIdAsync(id);
            MovieViewModel movieViewModel = new MovieViewModel();
            if (movieDto != null)
            {
                _mapper.Map(movieDto, movieViewModel);
            }
            return movieViewModel;
        }

        public async Task<List<MovieViewModel>> GetMoviesByUserAsync(int userId)
        {
            var query = await userMoviesRepositoryEF.getMoviesRepository.GetMoviesByUserAsync(userId);
            if (query.Count() == 0)
                throw new NotFoundException();
            var result = await GetMovieViewModel(query, userId);
            return result.OrderByDescending(x => x.AverageRating).ThenBy(x => x.Title).Skip((5) * 0).Take(5).ToList();
        }

        private async Task<bool> ValidateMovieSearchFilter(MovieSearchFilter filter)
        {
            bool valid = false;

            if (string.IsNullOrEmpty(filter.Title) && !filter.YearOfRelease.HasValue && (filter.Genres == null || filter.Genres.Count() == 0))
            {
                throw new ValidationException(new List<FluentValidation.Results.ValidationFailure>()
                {
                    new FluentValidation.Results.ValidationFailure("InvalidFilter", "The filter should have one or more filters"),
                });
            }
            valid = true;

            return await Task.Run(() => { return valid; }); ;
        }

        private async Task<List<MovieViewModel>> GetMovieViewModel(IEnumerable<MovieDto> movieDtos, int userId = 0)
        {
            return await Task.Run(() =>
            {
                double CalculateAverage(List<MovieRatingDto> movieRatingDtos)
                {

                    double average = 0.0;
                    if (movieRatingDtos != null && movieRatingDtos.Count() > 0)
                    {
                        average = movieRatingDtos.Select(x => x.Rating).Average();
                        var abso = Math.Abs(average);
                        var integ = (long)abso;
                        var decimalpar = abso - integ;
                        average = integ;
                        var middistance = (decimalpar - 0.5) < 0 ? -(decimalpar - 0.5) : (decimalpar - 0.5);
                        var highDistance = (1 - decimalpar);
                        var min = Math.Min(decimalpar, Math.Min(middistance, highDistance));
                        if (decimalpar == min)
                            average = integ + 0.0;
                        if (middistance == min)
                            average = integ + 0.5;
                        if (highDistance == min)
                            average = integ + 1.0;
                    }

                    return average;
                }
                return (from movie in movieDtos
                        select new MovieViewModel()
                        {
                            Id = movie.Id,
                            Title = movie.Title,
                            RunningTime = movie.RunningTime > 0 ? (movie.RunningTime / 60) : 0,
                            AverageRating = userId == 0 ? CalculateAverage(movie.MovieRatings) : movie.MovieRatings.Where(x => x.User.Id == userId).FirstOrDefault().Rating,
                            Genres = movie.Genres != null && movie.Genres.Count() > 0 ? string.Join(",", movie.Genres.Select(x => x.Name).ToArray()) : null,
                            YearOfRelease = movie.YearOfRelease
                        }).ToList();

            });
        }
    }
}
