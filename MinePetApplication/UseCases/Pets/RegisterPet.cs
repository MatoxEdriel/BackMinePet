using Application.DTOs.Pet;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repo;

namespace Application.UseCases.Pets;

public class RegisterPet
{
    private readonly IMapper _mapper;
    private readonly IPetRepository _petRepository;

    public RegisterPet(IMapper mapper, IPetRepository petRepository)
    {
        _mapper = mapper;
        _petRepository = petRepository;
    }

    public async Task<Pet> ExecuteAsync(PetRegisterDto dto)
    {
    
;        var petRegister = _mapper.Map<Pet>(dto);
        petRegister.CreatedAt = DateTime.Now;
        petRegister.IsActive = true;
        
        //Por ahora no hare las relaciones pero es un dato que/
        //necesito evaluarlo 

        return await _petRepository.CreatePetAsync(petRegister);
    }
    
    
    
}