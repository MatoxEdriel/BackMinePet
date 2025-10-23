using AutoMapper;
using Infrastructure.EF;
using DomainUser = Domain.Entities.User;
using EfUser = Infrastructure.EF.User;
using UserProfileDomain = Domain.Entities.UserProfile;
using PetDomain = Domain.Entities.Pet;

namespace Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DomainUser, EfUser>()
                .ForMember(dest => dest.UserProfileUser, opt => opt.MapFrom(src => src.UserProfile))
                .ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserProfile, opt => opt.MapFrom(src => src.UserProfileUser))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserProfileDomain, UserProfile>()
                .ForMember(dest => dest.User, opt => opt.Ignore()) // Evita loop y private set
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<PetDomain, Pet>().ReverseMap();
        }
    }
}