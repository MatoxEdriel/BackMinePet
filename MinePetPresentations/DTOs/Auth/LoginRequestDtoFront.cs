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
        this.email = email;
        this.password = password;
    }

    public string email { get; set; }
    public string password { get; set; }
}