using AutoMapper;
using MoviesWebAPI.Common.Exceptions;
using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using MoviesWebAPI.Data.Repository;
using MoviesWebAPI.Logic.Business.Interfaces;
using MoviesWebAPI.Logic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesWebAPI.Logic.Business.Persistance
{
    public class BusinessAddOrUpdateUserMovieRatingLogic : IBusinessAddOrUpdateUserMovieRating
    {
        private readonly MoviesAppContext _context;
        private readonly IMapper _Imapper;
        private readonly UserMoviesRepositoryEF userMoviesRepositoryEF = null;

        public BusinessAddOrUpdateUserMovieRatingLogic(MoviesAppContext context, IMapper mapper)
        {
            _context = context;
            _Imapper = mapper;
            userMoviesRepositoryEF = new UserMoviesRepositoryEF(_context, _Imapper);
        }

        public async Task<bool> AddOrUpdateMovieRating(MovieRatingViewModel movieRating)
        {
            try
            {
                var validationResult = await ValidateMovieRatingViewModel(movieRating);

                if (validationResult.Item1)
                {
                    MovieRatingDto movieRatingDto = new MovieRatingDto()
                    {
                        MovieId = movieRating.MovieId,
                        Rating = movieRating.Rating,
                        User = new UserDto()
                        {
                            Id = movieRating.UserId
                        }

                    };
                    if (validationResult.Item2.HasValue)
                        userMoviesRepositoryEF._addOrUpdateUserMovieRating.UpdateMovieRating(movieRatingDto);
                    else
                        userMoviesRepositoryEF._addOrUpdateUserMovieRating.AddMovieRating(movieRatingDto);

                    var count = await userMoviesRepositoryEF._addOrUpdateUserMovieRating.Complete();
                    if (count > 0)
                        return true;
                    else
                        return false;
                }
                return false;
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
        }

        private async Task<(bool, int?)> ValidateMovieRatingViewModel(MovieRatingViewModel movieRating)
        {
            bool isValid = false;
            int? isAlreadyExists = null;
            if (movieRating.Rating > 5 || movieRating.Rating <= 0)
            {
                throw new ValidationException(new List<FluentValidation.Results.ValidationFailure>()
                {
                    new FluentValidation.Results.ValidationFailure("InvalidRating", "Rating value needs to be between 1 to 5"),
                });
            }

            var movie = await userMoviesRepositoryEF.getMoviesRepository.GetMovieByIdAsync(movieRating.MovieId);
            if (movie == null)
                throw new NotFoundException();

            var user = await userMoviesRepositoryEF._getUsersRepository.GetUsersByIdAsync(movieRating.UserId);
            if (user == null)
                throw new NotFoundException();

            var movieRatingRec = await userMoviesRepositoryEF.getMoviesRepository.GetMovieUserRatingByMovieAndUserIdAsync(movieRating.UserId, movieRating.MovieId);
            if (movieRatingRec != null)
                isAlreadyExists = movieRatingRec.Id;

            isValid = true;

            return await Task.Run(() => { return (isValid, isAlreadyExists); });
        }
    }
}
