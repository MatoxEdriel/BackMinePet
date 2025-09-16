using AutoMapper;
using Domain.Entities;
using Presentations.DTOs;

namespace Application.Mappings;

//Esto hara los mapeos (source ---> Destination)
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        //Source va a ser los Dtos que viene del front el que cree para recibir 
        //En mi caso seria -------  es decir cuando me entreguen a registerUserDto me lo convierta en uSER
        //es lo que hacia manualmente 
        CreateMap<RegisterUsertDto, User>();

    }
    
    
    
    
    
}