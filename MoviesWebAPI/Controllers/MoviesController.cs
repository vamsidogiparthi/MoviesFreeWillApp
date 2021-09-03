using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Logic.Business.Interfaces;
using MoviesWebAPI.Logic.Models.ViewModels;
using System.Threading.Tasks;

namespace MoviesWebAPI.Controllers
{
    [Route("api/Movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IBusinessAddOrUpdateUserMovieRating _businessAddOrUpdateUserMovieRating;
        private readonly IBusinessGetMovies _businessGetMovies;
        private readonly IBusinessGetUsers _businessGetUsers;
        public MovieController(IBusinessAddOrUpdateUserMovieRating businessAddOrUpdateUserMovieRating, IBusinessGetMovies businessGetMovies, IBusinessGetUsers businessGetUsers)
        {
            _businessAddOrUpdateUserMovieRating = businessAddOrUpdateUserMovieRating;
            _businessGetMovies = businessGetMovies;
            _businessGetUsers = businessGetUsers;
        }


        [HttpGet]
        [Route("getallmovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _businessGetMovies.GetAllMoviesAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }


        [HttpGet]
        [Route("getmoviebypaging")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMovieByPaging([FromQuery] int pageNumber = 0, [FromQuery] int pageSize = 5)
        {
            var result = await _businessGetMovies.GetMovieByPagingAsync(pageNumber, pageSize);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }


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
