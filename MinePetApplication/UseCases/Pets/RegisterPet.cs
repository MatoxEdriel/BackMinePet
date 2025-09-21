using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repo;
using Infrastructure.Repositories;

namespace Application.UseCases.Pets;

public class RegisterPet
{
    private readonly IMapper _mapper;
    private readonly IPetRepository _petRepository;

    public RegisterPet(IMapper mapper, PetRepository petRepository)
    {
        _mapper = mapper;
        _petRepository = petRepository;
    }

    public async Task<Pet> ExecuteAsync(Pet pet)
    {
        //dto 
        var petRegister = _mapper.Map<Infrastructure.EF.Pet>(pet);



    }
    
    
    
}