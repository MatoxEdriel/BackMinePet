using Application.DTOs.Auth;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repo;
using Domain.Interfaces.Services;
using Domain.Services;
using Presentations.DTOs;


namespace Application.UseCases.Auth;

public class LoginUser
{
    private readonly IUserRepository _userRepo;
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IMapper _mapper;

    public LoginUser(IUserRepository userRepository, IPasswordService passwordService, ITokenService tokenService, IMapper mapper)
    {
        _userRepo = userRepository;
        _tokenService = tokenService;
        _passwordService = passwordService;
        _mapper = mapper;
    }


    public async Task<LoginResponseDto> ExecuteAsync(LoginRequestDto request)
    {
        var user = await _userRepo.GetByEmailAsync(request.Email);
        if(user == null || !_passwordService.VerifyPassword(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");
        var token = _tokenService.GenerateToken(user);
        var responseDto = _mapper.Map<LoginResponseDto>(user);
        responseDto.Token = token;
        return responseDto;
        
    }
}