using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Presentations.DTOs;

namespace Application.UseCases;

public class RegisterUser
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;



    public RegisterUser(IUserRepository userRepository,  IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
//en el caso de uso se debe hacer el mapping 

    public async Task<User> ExecuteAsync(RegisterUsertDto dto)
    {
      var userRegister = _mapper.Map<User>(dto);
      
      userRegister.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
      userRegister.IsActive = true;
      userRegister.CreatedAt = DateTime.Now;
        // var userRegister = new User
        // {
        //     
        //     Email = dto.Email,
        //     PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
        //     UserProfileUser = new UserProfile
        //     {
        //         Name = dto.Name,
        //         LastName = dto.LastName,
        //         Phone = dto.PhoneNumber,
        //     },
        //     IsActive = true,
        //     CreatedAt = DateTime.Now
        // };
        userRegister.UserProfileUser = new UserProfile
        {
            Name = dto.Name,
            LastName = dto.LastName,
            Phone = dto.PhoneNumber
        };
        return await _userRepository.AddAsync(userRegister);

    }

 
}