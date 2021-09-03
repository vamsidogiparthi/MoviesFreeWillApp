using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoviesWebAPI.Data.Repository.Interfaces
{
    public interface IGetUsersRepository
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUsersByIdAsync(int id);

    }
}
