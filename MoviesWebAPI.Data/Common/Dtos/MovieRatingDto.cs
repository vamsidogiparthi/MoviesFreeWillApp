using AutoMapper;
using JGHHubInstructor.Common.Mappings;
using MoviesWebAPI.Data.Datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebAPI.Data.Common.Dtos
{
    public class MovieRatingDto : IMapFrom<MovieUserRating>
    {
        public MovieRatingDto()
        {
            User = new UserDto();
        }
        public int Id { get; set; }
        public int MovieId { get; set; }
        public UserDto User { get; set; }
        public int Rating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MovieUserRating, MovieRatingDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.User, opt => opt.MapFrom(s => s.User))
                 .ForMember(d => d.MovieId, opt => opt.MapFrom(s => s.MovieId))
                .ForMember(d => d.Rating, opt => opt.MapFrom(s => s.RatingId));
        }
    }
}
