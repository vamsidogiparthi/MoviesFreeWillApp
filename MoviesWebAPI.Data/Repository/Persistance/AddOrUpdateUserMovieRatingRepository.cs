using AutoMapper;
using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using MoviesWebAPI.Data.Datalayer.Models;
using MoviesWebAPI.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebAPI.Data.Repository.Persistance
{
    public class AddOrUpdateUserMovieRatingRepository : IAddOrUpdateUserMovieRating
    {
        private readonly MoviesAppContext _context;
        private readonly IMapper _Imapper;

        public AddOrUpdateUserMovieRatingRepository(MoviesAppContext context, IMapper mapper)
        {
            _context = context;
            _Imapper = mapper;
        }

        public async void AddMovieRating(MovieRatingDto movieRating)
        {
            try
            {
                MovieUserRating movieUserRating = new MovieUserRating()
                {
                    UserId = movieRating.User.Id,
                    MovieId = movieRating.MovieId,
                    RatingId = movieRating.Rating


                };
                await _context.MovieUserRatings.AddAsync(movieUserRating);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void UpdateMovieRating(MovieRatingDto movieRating)
        {
            var movieRatingObj = _context.MovieUserRatings.Where(x => x.UserId == movieRating.User.Id && x.MovieId == movieRating.MovieId).FirstOrDefault();
            if (movieRatingObj != null)
                movieRatingObj.RatingId = movieRating.Rating;
        }
    }
}
