using Application.DTOs.Auth;
using Application.DTOs.Pet;
using AutoMapper;
using Domain.Entities;
using Infrastructure.EF;
using Microsoft.AspNetCore.Identity.Data;
using Presentations.DTOs;

using Pet = Domain.Entities.Pet;
using User = Domain.Entities.User;
using UserProfile = Domain.Entities.UserProfile;

namespace Application.Mappings;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Infrastructure.EF.Pet, Pet>();
        
        //recordemos como era esto del mapeo
        // la parte izquierda es del soruce y derecha
        //destinartion 
        
        CreateMap<PetRegisterDto, Pet>();
        
        //OJO CASO DE USO ESPECIAL
        
        CreateMap<Pet, Infrastructure.EF.Pet>();
        
        
        CreateMap<User, LoginResponseDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.RoleId.ToString()))
            .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.UserProfile.Alias))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.UserProfile.Phone));
        
        
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