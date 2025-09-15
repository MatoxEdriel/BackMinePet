using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Presentations.DTOs;


namespace Application.UseCases.Auth;

public class LoginUser
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtService _jwtService;

    public LoginUser(
        IUserRepository userRepository
        , IJwtService jwtService)
    {
        _userRepo = userRepository;
        _jwtService = jwtService;

    }
    public async Task<LoginResponseDto> ExecuteAsync(LoginRequestDto request)
    {
        var user = await _userRepo.GetByEmailAsync(request.email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        var token = _jwtService.GenerateToken(user);

        return new LoginResponseDto
        {
            UserId = user.UserId,
            Email = user.Email,
            Role = user.RoleId.ToString(),
            Token = token
        };
    }


}