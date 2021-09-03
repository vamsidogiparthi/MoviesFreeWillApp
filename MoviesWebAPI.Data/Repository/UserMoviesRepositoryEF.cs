using AutoMapper;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using MoviesWebAPI.Data.Repository.Interfaces;
using MoviesWebAPI.Data.Repository.Persistance;


namespace MoviesWebAPI.Data.Repository
{
    public class UserMoviesRepositoryEF
    {
        private readonly MoviesAppContext _moviesAppContext;
        private readonly IMapper _mapper;

        public IAddOrUpdateUserMovieRating _addOrUpdateUserMovieRating;
        public IGetUsersRepository _getUsersRepository;
        public IGetMoviesRepository getMoviesRepository;
        public UserMoviesRepositoryEF(MoviesAppContext moviesAppContext, IMapper mapper)
        {
            _moviesAppContext = moviesAppContext;
            _mapper = mapper;
            _addOrUpdateUserMovieRating = new AddOrUpdateUserMovieRatingRepository(moviesAppContext , _mapper);
            _getUsersRepository = new GetUsersRepository(_moviesAppContext, _mapper);
            getMoviesRepository = new GetMoviesRepository(_moviesAppContext, _mapper);
        }

    }
}
