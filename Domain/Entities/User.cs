namespace Domain.Entities;

public class User
{
    public int UserId { get; private set; } 
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    
    public virtual UserProfile UserProfile { get; set; }

    private User() { }
    public User(string email, string passwordHash, int roleId)
    {
        
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("El email no puede estar vacío.");

        Email = email;
        PasswordHash = passwordHash;

        RoleId = roleId;
        IsActive = true; 
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void UpdateProfile(string newEmail)
    {
        Email = newEmail;
    }
}