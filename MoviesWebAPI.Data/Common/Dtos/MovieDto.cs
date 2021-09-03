using AutoMapper;
using MoviesWebAPI.Data.Common.Mappings;
using MoviesWebAPI.Data.Datalayer.Models;
using System.Collections.Generic;

namespace MoviesWebAPI.Data.Common.Dtos
{
    public class MovieDto : IMapFrom<Movie>
    {
        public MovieDto()
        {
            MovieRatings = new List<MovieRatingDto>();
            Genres = new List<GenreDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public long RunningTime { get; set; }
        public List<MovieRatingDto> MovieRatings { get; set; }
        public List<GenreDto> Genres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Movie, MovieDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.YearOfRelease, opt => opt.MapFrom(s => s.YearOfRelease))
                .ForMember(d => d.RunningTime, opt => opt.MapFrom(s => s.RunningTime))
                .ForMember(d => d.MovieRatings, opt => opt.MapFrom(s => s.MovieUserRatings))
                .ForMember(d => d.Genres, opt => opt.MapFrom(s => s.MovieGenres));
        }


    }


}
