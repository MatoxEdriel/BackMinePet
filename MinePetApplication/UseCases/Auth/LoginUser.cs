using Domain.Interfaces;



namespace Application.UseCases.Auth;

public class LoginUser
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public LoginUser(
        IUserRepository userRepository
        , IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;

    }
    public async Task<LoginResponseDto> ExecuteAsync(LoginRequestDto request)
    {
        var user = await _userRepo.GetByEmailAsync(request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        var token = _jwtService.GenerateToken(user);

        return new LoginResponseDto
        {
            UserId = user.Id,
            Email = user.Email,
            Role = user.Role,
            Token = token
        };
    }


}