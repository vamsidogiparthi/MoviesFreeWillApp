using MoviesWebAPI.Logic.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesWebAPI.Logic.Business.Interfaces
{
    public interface IBusinessGetUsers
    {
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<UserViewModel> GetUsersByIdAsync(int id);

    }
}
