namespace Presentations.DTOs.Auth;
/// <summary>
/// Este dto es el que envia AL FRONT y esta ene el presentation
/// </summary>
public class LoginRequestDtoFront
{
    
    public LoginRequestDtoFront()
    {
        
    }
    public LoginRequestDtoFront(string email, string password)
    {
        this.Email = email;
        this.Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}