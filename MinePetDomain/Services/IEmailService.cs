namespace Domain.Services;

public interface IEmailService
{
    bool IsValidEmail(string email);   
}