using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repo;
using Infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    
    private readonly MinePetContext  _context;
    private readonly IMapper _mapper; 

    public UserRepository(MinePetContext context, IMapper mapper) 
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var usersFromDb = await _context.Users.ToListAsync();
        
        var domainUsers = _mapper.Map<IEnumerable<User>>(usersFromDb);

        return domainUsers;
    }
    
    

    public async Task<User?> GetByIdAsync(int id)
    {
        var userFromDb = await _context.Users.FindAsync(id);
        return _mapper.Map<User?>(userFromDb);    }

    public async Task<User> CreateUserAsync(User user)
    {
        var userToDb = _mapper.Map<Infrastructure.EF.User>(user); 

        await _context.Users.AddAsync(userToDb);
        await _context.SaveChangesAsync();

        return _mapper.Map<User>(userToDb);
    }

    public async Task<User> UpdateAsync(User user)
    {
        var userToDb = _mapper.Map<Infrastructure.EF.User>(user);

        _context.Users.Update(userToDb);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task DeleteUserAsync(int id)
    {
        var userToDelete = await _context.Users.FindAsync(id);
        if (userToDelete != null)
        {
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var userFromDb = await _context.Users
            .Include(u => u.UserProfileUser)
            .FirstOrDefaultAsync(u => u.Email == email);
        return _mapper.Map<User?>(userFromDb);
    }
   
    
}