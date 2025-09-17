
using Domain.Entities;

namespace Domain.Interfaces.Repo;

public interface IPetRepository
{
    Task AddAsync(Pet pet); 
    Task<Pet?> GetByIdAsync(int id);
    Task<IEnumerable<Pet>> GetAllAsync();
}