using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Common.Filter.MovieSearchFilters;
using MoviesWebAPI.Logic.Business.Interfaces;
using MoviesWebAPI.Logic.Models.ViewModels;
using System.Threading.Tasks;

namespace MoviesWebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IBusinessGetUsers _businessGetUsers;
        public UsersController(IBusinessGetUsers businessGetUsers)
        {
            _businessGetUsers = businessGetUsers;
        }


        // API End point to get all the users. No params are required
        [HttpGet]
        [Route("getallusers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _businessGetUsers.GetAllUsersAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // API End point to get the user by id. userId is required
        [HttpGet]
        [Route("getuser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var result = await _businessGetUsers.GetUsersByIdAsync(userId);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }



    }
}
