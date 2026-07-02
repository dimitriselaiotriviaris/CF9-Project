using AutoMapper;
using CF9Project.Models;
using CF9Project.DTO;

namespace CF9Project.Configuration
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<User, UserReadOnlyDTO>()
                .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<GameCompanySignupDTO, User>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId!.Value));

            CreateMap<GameCompanySignupDTO, GameCompany>();
        }
    }
}
