using Domain.Interfaces;
using Domain.Interfaces.Repo;
using Domain.Interfaces.Services;
using Domain.Services;
using Presentations.DTOs;


namespace Application.UseCases.Auth;

public class LoginUser
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtService _jwtService;
    private readonly IPasswordService _passwordService;

    public LoginUser(IUserRepository userRepository, IJwtService jwtService, IPasswordService passwordService)
    {
        _userRepo = userRepository;
        _jwtService = jwtService;
        _passwordService = passwordService;
    }


    public async Task<LoginResponseDto> ExecuteAsync(LoginRequestDto request)
    {
        var user = await _userRepo.GetByEmailAsync(request.email);
        if(user == null || !_passwordService.VerifyPassword(request.password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");
        
        var token = _jwtService.GenerateToken(user);
        return new LoginResponseDto
        {
            UserId = user.UserId,
            Email = user.Email,
            Role = user.RoleId.ToString(),
            Token = token,
            Alias = user.UserProfile.Alias,
            Phone = user.UserProfile.Phone,
        };
    }
}