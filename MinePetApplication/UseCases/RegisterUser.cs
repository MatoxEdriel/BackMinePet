using Application.DTOs.Auth;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repo;
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

    
    public async Task<User> ExecuteAsync(RegisterUsertDto dto)
    { 
      var userRegister = _mapper.Map<User>(dto);
      userRegister.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
      userRegister.IsActive = true;
      userRegister.CreatedAt= DateTime.Now;
      var newUserProfile = new UserProfile(userRegister, dto.Name, dto.LastName, dto.Phone);
      
      userRegister.UserProfile = newUserProfile;
      Console.WriteLine("prueba " + userRegister.UserProfile.Phone);
      return await _userRepository.CreateUserAsync(userRegister);

    }
}