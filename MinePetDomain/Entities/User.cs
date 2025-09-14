namespace Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? CreatedAt { get; set; }
    
   public virtual UserProfile UserProfile { get; set; } = null!;
   public User() {}
   public User(string email, string passwordHash, UserProfile userProfile)
   {
       Email = email;
       PasswordHash = passwordHash;
       UserProfile = userProfile;
       IsActive = true;
   }

   public void desactiveUser()
   {
       IsActive = false;
   }
   



}