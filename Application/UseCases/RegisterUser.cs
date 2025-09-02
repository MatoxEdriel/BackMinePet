using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class RegisterUser
{
    private readonly IUserRepository _userRepository;



    public RegisterUser(IUserRepository userRepository)
    {
        
        _userRepository = userRepository;
    }


    public async Task<User> ExecuteAsync(string name, string lastName, string email, string password, int roleId )
    {
        var user = new User
        {
            Name = name,
            LastName = lastName,
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            RoleId = roleId,
            IsActive = true,
            CreatedAt = DateTime.Now
        };
        return await _userRepository.AddAsync(user);

    }
}