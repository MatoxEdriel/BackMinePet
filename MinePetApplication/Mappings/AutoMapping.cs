using AutoMapper;
using Domain.Entities;
using Infrastructure.EF;
using Presentations.DTOs;
using User = Domain.Entities.User;
using UserProfile = Domain.Entities.UserProfile;

namespace Application.Mappings;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
      
        CreateMap<RegisterUsertDto, User>();

      
        CreateMap<User, Infrastructure.EF.User>()
            .ForMember(dest => dest.UserProfileUser, opt => opt.MapFrom(src => src.UserProfile));
        CreateMap<Infrastructure.EF.User, User>()
            .ForPath(src => src.UserProfile, opt => opt.MapFrom(dest => dest.UserProfileUser));


       
        CreateMap<UserProfile, Infrastructure.EF.UserProfile>();

        CreateMap<Infrastructure.EF.UserProfile, UserProfile>()
         
            .ForMember(dest => dest.User, opt => opt.Ignore());
            
    }
}