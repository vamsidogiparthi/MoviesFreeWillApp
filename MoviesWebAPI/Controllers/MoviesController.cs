using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Common.Filter.MovieSearchFilters;
using MoviesWebAPI.Logic.Business.Interfaces;
using MoviesWebAPI.Logic.Models.ViewModels;
using System.Threading.Tasks;

namespace MoviesWebAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IBusinessAddOrUpdateUserMovieRating _businessAddOrUpdateUserMovieRating;
        private readonly IBusinessGetMovies _businessGetMovies;
        public MoviesController(IBusinessAddOrUpdateUserMovieRating businessAddOrUpdateUserMovieRating, IBusinessGetMovies businessGetMovies)
        {
            _businessAddOrUpdateUserMovieRating = businessAddOrUpdateUserMovieRating;
            _businessGetMovies = businessGetMovies;
        }

        // End point to Get all the movies no params
        [HttpGet]
        [Route("getallmovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _businessGetMovies.GetAllMoviesAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // End point to Get the movies by paging. Default pageIndex is 0 and pageSize is 5 . Part B
        [HttpGet]
        [Route("getmoviebypaging")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovieByPaging([FromQuery] int pageNumber = 0, [FromQuery] int pageSize = 5)
        {
            var result = await _businessGetMovies.GetMovieByPagingAsync(pageNumber, pageSize);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }


        // End point to Get the movies by User Rated. Default pageIndex is 0 and pageSize is 5 . Part C
        [HttpGet]
        [Route("getmoviesbyuser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMoviesByUser([FromRoute] int userId)
        {
            var result = await _businessGetMovies.GetMoviesByUserAsync(userId);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }


        // End point to Get the movies by filters. Title full or partial match, year integer, Genres list of string full match . Part A
        [HttpGet]
        [Route("getmoviesbyfilters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMoviesByfilters([FromQuery] MovieSearchFilter movieSearchFilter)
        {
            var result = await _businessGetMovies.GetMoviesByFilter(movieSearchFilter);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // Add or Update User Ratings . Part D

        [HttpPost]
        [Route("addorupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddOrUpdateMovieRating([FromBody] MovieRatingViewModel movieRatingViewModel)
        {
            var result = await _businessAddOrUpdateUserMovieRating.AddOrUpdateMovieRating(movieRatingViewModel);
            if (result)
                return Ok("Success");
            return BadRequest();
        }

    }
}
