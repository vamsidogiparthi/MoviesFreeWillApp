using AutoMapper;
using AutoMapper.QueryableExtensions;
using MoviesWebAPI.Common.Exceptions;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using MoviesWebAPI.Data.Repository;
using MoviesWebAPI.Logic.Business.Interfaces;
using MoviesWebAPI.Logic.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebAPI.Logic.Business.Persistance
{
    public class BusinessGetUsers : IBusinessGetUsers
    {
        private readonly MoviesAppContext _context;
        private readonly IMapper _mapper;
        private readonly UserMoviesRepositoryEF userMoviesRepositoryEF = null;

        public BusinessGetUsers(MoviesAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            userMoviesRepositoryEF = new UserMoviesRepositoryEF(_context, _mapper);
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            var query = await userMoviesRepositoryEF._getUsersRepository.GetAllUsersAsync();

            return query.AsQueryable().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public async Task<UserViewModel> GetUsersByIdAsync(int id)
        {
            var query = await userMoviesRepositoryEF._getUsersRepository.GetUsersByIdAsync(id);
            if (query == null)
                throw new NotFoundException();

            UserViewModel userViewModel = new UserViewModel();
            _mapper.Map(query, userViewModel);
            return userViewModel;
        }
    }
}
