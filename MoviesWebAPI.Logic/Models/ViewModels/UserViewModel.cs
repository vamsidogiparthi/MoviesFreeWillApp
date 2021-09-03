using AutoMapper;
using MoviesWebAPI.Data.Common.Dtos;

namespace MoviesWebAPI.Logic.Models.ViewModels
{
    public class UserViewModel : Common.Mappings.IMapFrom<UserDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserDto, UserViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => Name));
        }
    }
}
