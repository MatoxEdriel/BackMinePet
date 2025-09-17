using Domain.Entities;
using Domain.Interfaces.Repo; // Asegúrate de que este 'using' es correcto
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PetRepository : IPetRepository 
{
    private readonly MinePetContext _context;

    public PetRepository(MinePetContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
        await _context.SaveChangesAsync();
    }

    public async Task<Pet?> GetByIdAsync(int id)
    {
        return await _context.Pets.FindAsync(id);
    }
    
    public async Task<IEnumerable<Pet>> GetAllAsync()
    {
        return await _context.Pets.ToListAsync();
    }
}