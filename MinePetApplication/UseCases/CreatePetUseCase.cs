
using Domain.Interfaces;
using Domain.Interfaces.Repo;
using Domain.Interfaces.Repository;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Pet = Domain.Entities.Pet;

namespace Application.UseCases;

public class CreatePetUseCase
{
    private readonly IPetRepository _petRepository;

    public CreatePetUseCase(IPetRepository petRepository)
    {
        
        _petRepository = petRepository;
    }


    
    
    public void Execute(Pet petData)
    {
        if(string.IsNullOrWhiteSpace(petData.Name))
            throw new ArgumentException("Name is required");
        _petRepository.Add(petData);
        
        
    }


}