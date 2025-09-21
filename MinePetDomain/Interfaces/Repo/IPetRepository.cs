using Domain.Entities;

namespace Domain.Interfaces.Repo;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAllPetsAsync();

    Task<Pet?> GetByIdAsync(int id);

    Task<Pet> CreatePetAsync(Pet pet);

    Task<Pet> UpdatePetAsync(Pet pet);

    Task DeletePetAsync(int id);
    
}