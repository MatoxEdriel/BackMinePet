using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Presentations.DTOs;

namespace Application.UseCases;

public class RegisterUser
{
    private readonly IUserRepository _userRepository;



    public RegisterUser(IUserRepository userRepository)
    {
        
        _userRepository = userRepository;
    }


    public async Task<User> ExecuteAsync(RegisterUsertDto dto)
    {
        //De aqui crear la entidad que trabajara con los casos de uso 
        //crear entidades apartir de los datos Dto 
        var userRegister = new User
        {
            
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            //y aqui comenzaria mapear los demas datos
            UserProfileUser = new UserProfile
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Phone = dto.PhoneNumber,
            },
            IsActive = true,
            CreatedAt = DateTime.Now
        };
        return await _userRepository.AddAsync(userRegister);

    }

 
}