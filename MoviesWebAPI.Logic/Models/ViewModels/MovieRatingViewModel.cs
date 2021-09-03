using AutoMapper;
using MoviesWebAPI.Common.Mappings;
using MoviesWebAPI.Data.Common.Dtos;


namespace MoviesWebAPI.Logic.Models.ViewModels
{
    public class MovieRatingViewModel : IMapFrom<MovieRatingDto>
    {
        public MovieRatingViewModel()
        {
          
        }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MovieRatingDto, MovieRatingViewModel>()
                //.ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.User.Id))
                .ForMember(d => d.MovieId, opt => opt.MapFrom(s => s.MovieId))
                .ForMember(d => d.Rating, opt => opt.MapFrom(s => s.Rating));
        }
    }
}
