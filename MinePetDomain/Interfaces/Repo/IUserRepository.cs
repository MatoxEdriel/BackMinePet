using Domain.Entities;

namespace Domain.Interfaces.Repo;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync(); 
    Task<User?> GetByIdAsync(int id); 
    Task<User> CreateUserAsync(User user); 
    Task<User> UpdateAsync(User user); 
    Task DeleteUserAsync(int id); 
    Task<User?> GetByEmailAsync(string email);
}