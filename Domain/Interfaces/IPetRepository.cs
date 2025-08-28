using Domain.Entities;

namespace Domain.Interfaces;

public interface IPetRepository
{
    
    void Add(Pet pet);
    Pet? GetById(int id);
    IEnumerable<Pet> GetAll();
    
    
}