using AutoMapper;
using Infrastructure.EF;
using DomainUser = Domain.Entities.User;
using EfUser = Infrastructure.EF.User;
using UserProfileDomain = Domain.Entities.UserProfile;
using PetDomain = Domain.Entities.Pet;
namespace Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DomainUser, EfUser>()
            .ForMember(dest => dest.UserProfileUser, opt => opt.MapFrom(src => src.UserProfile))
            .ReverseMap()
            .ForPath(src => src.UserProfile, opt => opt.MapFrom(dest => dest.UserProfileUser));

        CreateMap<UserProfileDomain, UserProfile>()
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<PetDomain, Pet>().ReverseMap();

    }
}