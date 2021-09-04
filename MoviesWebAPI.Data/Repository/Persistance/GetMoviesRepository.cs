using AutoMapper;
using AutoMapper.QueryableExtensions;
using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using MoviesWebAPI.Data.Datalayer.Models;
using MoviesWebAPI.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoviesWebAPI.Data.Repository.Persistance
{
    public class GetMoviesRepository : IGetMoviesRepository
    {
        private readonly MoviesAppContext _context;
        private readonly IMapper _mapper;

        public GetMoviesRepository(MoviesAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var query = _context.Movies.AsQueryable();
            return await GetMovieDtos(query);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByFilter(Expression<Func<Movie, bool>> filter)
        {
            var query = _context.Movies.Where(filter).AsQueryable();

            return await GetMovieDtos(query);
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            return await Task.Run(() => { var movie = _context.Movies.Select(s => new MovieDto 
                        {
                            Id = s.Id,
                            Title = s.Title,
                            RunningTime = s.RunningTime,
                            Genres = s.MovieGenres.Select(c => new GenreDto
                            {
                                Id = c.Id,
                                Name = c.Genre.Name
                            }).ToList(),
                            MovieRatings = s.MovieUserRatings.Select(r => new MovieRatingDto
                            {
                                Id = r.Id,
                                MovieId = r.MovieId,
                                Rating = r.RatingId
                            }).ToList()
                        }).FirstOrDefault(x => x.Id == id);              
                return movie;
            });
        }


        public async Task<IEnumerable<MovieDto>> GetMoviesByUserAsync(int userId)
        {
            var query = (from movie in _context.Movies
                         join movieRatings in _context.MovieUserRatings on movie.Id equals movieRatings.MovieId
                         where movieRatings.UserId == userId
                         select movie).AsQueryable();

            return await GetMovieDtos(query);
        }

        public async Task<MovieRatingDto> GetMovieUserRatingByMovieAndUserIdAsync(int userId, int movieId)
        {
            var query = (from movie in _context.Movies
                         join movieRatings in _context.MovieUserRatings on movie.Id equals movieRatings.MovieId
                         where movieRatings.MovieId == movieId && movieRatings.UserId == userId
                         select movieRatings).Select(s => new MovieRatingDto
                         {
                             Id = s.Id,
                             Rating = s.Rating.Value,
                             MovieId = s.MovieId,
                             User = new UserDto
                             {
                                 Id = s.User.Id,
                                 Name = s.User.FirstName + " " + s.User.LastName
                             }
                         }).FirstOrDefault();

            return await Task.Run(() => { return query; });
        }      

        private async Task<IEnumerable<MovieDto>> GetMovieDtos(IQueryable<Movie> movies, int? userId = null)
        {
            return await Task.Run(() =>
            {
                return (from movie in movies
                        select new MovieDto
                        {
                            Id = movie.Id,
                            Title = movie.Title,
                            RunningTime = movie.RunningTime,
                            YearOfRelease = movie.YearOfRelease,
                            Genres = movie.MovieGenres.Select(c => new GenreDto
                            {
                                Id = c.Id,
                                Name = c.Genre.Name
                            }).ToList(),
                            MovieRatings = movie.MovieUserRatings.Where(x => x.MovieId == movie.Id && (userId == null || x.UserId == userId)).Select(r => new MovieRatingDto
                            {
                                Id = r.Id,
                                MovieId = r.MovieId,
                                Rating = r.Rating.Value,
                                User = new UserDto
                                {
                                    Id = r.User.Id,
                                    Name = r.User.FirstName + " " + r.User.LastName
                                }
                            }).ToList()                          
                        }).ToList();

            });

        }

        private async Task<IEnumerable<MovieRatingDto>> GetMovieRatingsDtos(IQueryable<MovieUserRating> movieUserRatings)
        {
            return await Task.Run(() =>
            {
                return (from movieRating in movieUserRatings
                        select new MovieRatingDto
                        {
                            Id = movieRating.Id,
                            Rating = movieRating.Rating.Value,
                            MovieId = movieRating.MovieId,
                            User =  new UserDto
                            {
                                Id = movieRating.User.Id,
                                Name = movieRating.User.FirstName + " " + movieRating.User.LastName
                            }
                        }).ToList();

            });
        }

    }
}
