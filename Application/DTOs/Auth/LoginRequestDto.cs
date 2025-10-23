namespace Application.DTOs.Auth;

public class LoginRequestDto
{
    public string Email { get; }
    public string Password { get; }

    public LoginRequestDto(string email, string password)
    {
        Email = email;
        Password = password;
    }
}