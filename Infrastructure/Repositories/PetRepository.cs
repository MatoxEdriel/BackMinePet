using Domain.Interfaces;
using Infrastructure.Data;
using Pet = Domain.Entities.Pet;

namespace Infrastructure.Repositories;

public class PetRepository : IPetRepository {
    
    private readonly MinePetContext _context;


    public PetRepository(MinePetContext context)
    {
        _context = context;
    }
    
    public void Add(Pet pet)
    {
        var petData = new Infrastructure.Data.Pet()
        {
            Name = pet.Name,
            Species = pet.Species,
            BirthDate = pet.BirthDate,

        };
            _context.Pets.Add(petData);
            _context.SaveChanges();

        
    }

    public Pet? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pet> GetAll()
    {
        throw new NotImplementedException();
    }
}