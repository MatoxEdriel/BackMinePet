namespace Presentations.DTOs;

public class RegisterUsertDto
{
    public RegisterUsertDto()
    {
        
        
    }
    public RegisterUsertDto(string email, string password, string name, string lastName, string? phoneNumber)
    {
        Email = email;
        Password = password;
        Name = name;
        LastName = lastName;
        Phone= phoneNumber;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    
    public string? Phone { get; set; }
    
}