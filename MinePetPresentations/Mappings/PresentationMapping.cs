using Application.DTOs.Auth;
using Application.DTOs.Pet;
using AutoMapper;
using Presentations.DTOs.Auth;

namespace Presentations.Mappings;

//Seria buena practica hacer esto/?


public class PresentationMapping: Profile
{
    public PresentationMapping()
    {
        CreateMap<LoginRequestDtoFront,LoginRequestDto >();
        //Source ---> detinatios
    }
    
}