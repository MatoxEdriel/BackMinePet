using Domain.Interfaces;
using Infrastructure.Data;
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

    public async Task<User> AddAsync(User user)
    {

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;


    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }
}