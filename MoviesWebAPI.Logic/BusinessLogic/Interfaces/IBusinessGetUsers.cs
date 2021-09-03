using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.Models;
using MoviesWebAPI.Logic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoviesWebAPI.Logic.Business.Interfaces
{
    public interface IBusinessGetUsers
    {
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<UserViewModel> GetUsersByIdAsync(int id);

    }
}
