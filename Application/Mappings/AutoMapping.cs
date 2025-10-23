using Application.DTOs.Auth;
using Application.DTOs.Pet;
using AutoMapper;
using Domain.Entities;
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
        CreateMap<User, LoginResponseDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.RoleId.ToString()))
            .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.UserProfile.Alias))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.UserProfile.Phone))
            .ReverseMap();
        CreateMap<RegisterUsertDto, User>();
    }
}