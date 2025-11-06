using AutoMapper;
using Domain.Interfaces.Repo;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Pet = Domain.Entities.Pet;

namespace Infrastructure.Repositories;

public class PetRepository: IPetRepository
{
    private readonly IMapper _mapper; 
    private readonly MinePetContext _context;

    public PetRepository(IMapper mapper, MinePetContext context)
    {
        _mapper = mapper;
        _context = context;
        
    }
    
    
    
    public async Task<IEnumerable<Pet>> GetAllPetsAsync()
    {
        var petsFroDb = await _context.Pets.ToListAsync();
        var domainPets  = _mapper.Map<IEnumerable<Pet>>(petsFroDb);
        return domainPets;
    }

    
    
    public async Task<Pet?> GetByIdAsync(int id)
    {
        var petFromDb = await _context.Pets.FindAsync(id);
        return _mapper.Map<Pet>(petFromDb);
        //Es decir quiero que se transforme el petFromDb que es EF 
        //a mi domain entities es deci Pet 

    }

    public async Task<Pet> CreatePetAsync(Pet pet)
    {
        //Aqui necesito otro mapeo 
        var petToDb = _mapper.Map<Infrastructure.EF.Pet>(pet);
        //En este caso necesito hacer el mapeo
        //Porque usre ese metodo 
        //entrara un dato Domain --> EF 
        //Recordemos <> lo que deseo transformar
        //() lo que recibo o pongo
        await _context.Pets.AddAsync(petToDb);
        await _context.SaveChangesAsync();
        
        //Aqui debo devolver un Pet 
        return _mapper.Map<Pet>(petToDb);
    }

    public async Task<Pet> UpdatePetAsync(Pet pet)
    {
        var petToDb = _mapper.Map<Infrastructure.EF.Pet>(pet);
        _context.Pets.Update(petToDb);
        await _context.SaveChangesAsync();

        return _mapper.Map<Pet>(petToDb);
    }

    public async Task DeletePetAsync(int id)
    {
        throw new NotImplementedException();
    }
}