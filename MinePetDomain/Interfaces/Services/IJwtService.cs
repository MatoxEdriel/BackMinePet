using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IJwtService
{
    
    string GenerateToken(User user);
    
}