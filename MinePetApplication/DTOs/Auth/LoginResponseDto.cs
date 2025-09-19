namespace Presentations.DTOs;

public class LoginResponseDto
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }

    public string Alias { get; set; }
    
    public string Phone { get; set; }
}