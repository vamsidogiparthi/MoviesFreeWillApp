using AutoMapper;
using AutoMapper.QueryableExtensions;
using MoviesWebAPI.Common.Exceptions;
using MoviesWebAPI.Common.Filter.MovieSearchFilters;
using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using MoviesWebAPI.Data.Datalayer.Models;
using MoviesWebAPI.Data.Repository;
using MoviesWebAPI.Data.Repository.Interfaces;
using MoviesWebAPI.Logic.Business.Interfaces;
using MoviesWebAPI.Logic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            userMoviesRepositoryEF = new UserMoviesRepositoryEF(context, mapper);
        }

        public async Task<List<MovieViewModel>> GetAllMoviesAsync()
        {
            var query = await userMoviesRepositoryEF.getMoviesRepository.GetAllMoviesAsync();
            var result = await GetMovieViewModel(query);
            return result.OrderByDescending(x => x.AverageRating).ThenBy(x=>x.Title).ToList();
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
                        query = query.Where(x => x.Title.Contains(filter.Title));
                    if (filter.YearOfRelease.HasValue)
                        query = query.Where(x => x.YearOfRelease == filter.YearOfRelease);
                    if (filter.Genres != null && filter.Genres.Length > 0)
                    {
                        query = query.Where(x => x.Genres.Select(x => x.Name).ToList().Any(t1 => filter.Genres.ToList().Contains(t1)));
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
            if(movieDto !=null)
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
            //query = query.Where(x => x.MovieRatings.Select(r => r.User.Id).ToList().Contains(userId));
            var result = await GetMovieViewModel(query, userId);
            return result.OrderByDescending(x=>x.AverageRating).ThenBy(x=>x.Title).Skip((5) * 0).Take(5).ToList();
        }


        //public async Task<MovieRatingViewModel> GetMovieUserRatingByMovieAndUserIdAsync(int userId, int movieId)
        //{
        //    MovieRatingViewModel movieRatingViewModel = new MovieRatingViewModel();

        //    var query = await userMoviesRepositoryEF.getMoviesRepository.GetMovieUserRatingByMovieAndUserIdAsync(userId, movieId);
        //    _mapper.Map(query, movieRatingViewModel);

        //    return movieRatingViewModel;
        //}


        private async Task<bool> ValidateMovieSearchFilter(MovieSearchFilter filter)
        {
            bool valid = false;

            if (string.IsNullOrEmpty(filter.Title) && !filter.YearOfRelease.HasValue && (filter.Genres == null || filter.Genres.Length == 0))
            {
                throw new ValidationException(new List<FluentValidation.Results.ValidationFailure>()
                {
                    new FluentValidation.Results.ValidationFailure("InvalidFilter", "The filter should have one or more filters"),
                });
            }    

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
                        average = Math.Round(movieRatingDtos.Select(x => x.Rating).Average(), 1);

                    return average;
                }
                return (from movie in movieDtos
                        select new MovieViewModel()
                        {
                            Id = movie.Id,
                            Title = movie.Title,
                            RunningTime = movie.RunningTime > 0 ? (movie.RunningTime / 60) : 0,
                            AverageRating = userId == 0 ? CalculateAverage(movie.MovieRatings): CalculateAverage(movie.MovieRatings.Where(x => x.User.Id == userId).ToList()),
                            Genres = movie.Genres != null && movie.Genres.Count() > 0 ? string.Join(",", movie.Genres.Select(x => x.Name).ToArray()) : null,
                            YearOfRelease = movie.YearOfRelease
                        }).ToList();

            });
        }
    }
}
