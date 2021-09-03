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
    public class GenreDto : IMapFrom<Genre>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
