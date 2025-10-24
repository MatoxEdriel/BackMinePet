using AutoMapper;
using Infrastructure.EF;
using Domain.Entities;

namespace Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<Infrastructure.EF.User, Domain.Entities.User>()
            .ForMember(dest => dest.UserProfile, opt => opt.MapFrom(src => src.UserProfileUser))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<Infrastructure.EF.UserProfile, Domain.Entities.UserProfile>()
            .ForMember(dest => dest.User, opt => opt.Ignore()); // rompe el ciclo

        CreateMap<Domain.Entities.User, Infrastructure.EF.User>()
            .ForMember(dest => dest.UserProfileUser, opt => opt.MapFrom(src => src.UserProfile))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<Domain.Entities.UserProfile, Infrastructure.EF.UserProfile>()
            .ForMember(dest => dest.User, opt => opt.Ignore());

    }
}