using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using User = Domain.Entities.User;

namespace Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    
    private readonly MinePetContext  _context;


    public UserRepository(MinePetContext context)
    {
        _context = context; 
        
    }

    
    
    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> AddAsync(User userRegister)
    {
        _context.User.Add(userRegister);
        await _context.SaveChangesAsync();
        return userRegister;
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.User
            .FirstOrDefaultAsync(u=> u.Email == email); 
    }
}