using AutoMapper;
using MoviesWebAPI.Data.Common.Mappings;
using MoviesWebAPI.Data.Datalayer.Models;


namespace MoviesWebAPI.Data.Common.Dtos
{
    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName));
        }
    }
}
