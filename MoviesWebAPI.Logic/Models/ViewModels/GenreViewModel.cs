using AutoMapper;
using JGHHubInstructor.Common.Mappings;
using MoviesWebAPI.Data.Common.Dtos;

namespace MoviesWebAPI.Logic.Models.ViewModels
{
    public class GenreViewModel : IMapFrom<GenreDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
