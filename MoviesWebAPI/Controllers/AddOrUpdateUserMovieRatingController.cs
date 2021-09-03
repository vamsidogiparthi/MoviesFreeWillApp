using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Logic.Business.Interfaces;
using MoviesWebAPI.Logic.Models.ViewModels;
using System.Threading.Tasks;

namespace MoviesWebAPI.Controllers
{
    [Route("api/addorupdatemovierating")]
    [ApiController]
    public class AddOrUpdateUserMovieRatingController : ControllerBase
    {

        private readonly IBusinessAddOrUpdateUserMovieRating _businessAddOrUpdateUserMovieRating;
        public AddOrUpdateUserMovieRatingController(IBusinessAddOrUpdateUserMovieRating businessAddOrUpdateUserMovieRating)
        {
            _businessAddOrUpdateUserMovieRating = businessAddOrUpdateUserMovieRating;
        }

        [HttpPost]
        [Route("addorupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOrUpdateMovieRating([FromBody] MovieRatingViewModel movieRatingViewModel)
        {
            var result = await _businessAddOrUpdateUserMovieRating.AddOrUpdateMovieRating(movieRatingViewModel);
            if (result)
                return Ok("Success");
            return BadRequest();
        }

    }
}
