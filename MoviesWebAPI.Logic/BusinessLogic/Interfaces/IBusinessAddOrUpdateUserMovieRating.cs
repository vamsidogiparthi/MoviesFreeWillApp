using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesWebAPI.Logic.Models.ViewModels;

namespace MoviesWebAPI.Logic.Business.Interfaces
{
    public interface IBusinessAddOrUpdateUserMovieRating
    {
        Task<bool> AddOrUpdateMovieRating(MovieRatingViewModel movieRating);
    }
}
