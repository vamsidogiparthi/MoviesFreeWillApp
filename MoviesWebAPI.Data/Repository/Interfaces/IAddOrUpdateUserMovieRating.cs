using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.Models;

namespace MoviesWebAPI.Data.Repository.Interfaces
{
    public interface IAddOrUpdateUserMovieRating
    {
        void AddMovieRating(MovieRatingDto movieRating);
        void UpdateMovieRating(MovieRatingDto movieRating);
        Task<int> Complete();
    }
}
