namespace Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Alias { get; set; }
    public string? Phone { get; set; }
    public int RoleId { get; set; }
    public bool? EmailConfirmed { get; set; }
    public DateTime? CreatedAt { get; set; }
    
    public bool? IsActive { get; set; }
    public string PasswordHash { get; set; } = null!;
    
    
    
    
}