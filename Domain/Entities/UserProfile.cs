namespace Domain.Entities;

public class UserProfile
{
    public int UserId { get; set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string? Alias { get; set; }
    public string? Phone { get; set; }
    public string? IdentityNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }

    public virtual User User { get; set; }

    public string FullName => $"{Name} {LastName}";

    private UserProfile() { }

    public UserProfile(User user, string name, string lastName, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre es requerido.");
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("El apellido es requerido.");

        User = user ?? throw new ArgumentNullException(nameof(user));
        UserId = user.UserId;
        Name = name;
        LastName = lastName;
        Phone = phone;
        
        Alias = $"{Name} " +" "+ $"{LastName}".Replace(" ", "").ToLower();
    }

  

    public void UpdateContactInfo(string? newPhone, string? newAlias)
    {
        Phone = newPhone;
        Alias = newAlias;
    }

    public void ChangeProfilePicture(string? newPictureUrl)
    {
        ProfilePictureUrl = newPictureUrl;
    }

    public void UpdateIdentity(string? newIdentityNumber)
    {
        IdentityNumber = newIdentityNumber;
    }
}