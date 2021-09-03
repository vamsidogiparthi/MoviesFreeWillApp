using AutoMapper;
using JGHHubInstructor.Common.Mappings;
using MoviesWebAPI.Data.Common.Dtos;
using System;
using System.Linq;


namespace MoviesWebAPI.Logic.Models.ViewModels
{
    public class MovieViewModel : IMapFrom<MovieDto>
    {
        public MovieViewModel()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public long RunningTime { get; set; }
        public double? AverageRating { get; set; }
        public string Genres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MovieDto, MovieViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.YearOfRelease, opt => opt.MapFrom(s => s.YearOfRelease))
                .ForMember(d => d.RunningTime, opt => opt.MapFrom(s => s.RunningTime > 0 ? s.RunningTime / 60 : 0))
                .ForMember(d => d.AverageRating, opt => opt.MapFrom(s => Math.Round(s.MovieRatings.Select(x => x.Rating).Average(), 1)))
                .ForMember(d => d.Genres, opt => opt.MapFrom(s => string.Join(",", s.Genres.Select(x => x.Name).ToArray())));
        }


    }


}
