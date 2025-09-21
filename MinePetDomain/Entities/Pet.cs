namespace Domain.Entities;

public class Pet
{
    public int PetId { get; private set; }
    public string Name { get; private set; }
    public string Species { get; private set; }
    public string Breed { get; private set; }
    public DateTime CreatedAt { get; set; }
    
    public DateOnly BirthDate { get; private set; }
    public string Gender { get; private set; }
    public bool IsActive { get; set; }

    public int OwnerId { get; private set; }
    public virtual User Owner { get; private set; }
    

    public virtual ICollection<User> Veterinarians { get; set; } = new List<User>();
    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age)) age--;
            return age;
        }
    }
    
    private Pet() { }

    public Pet(User owner, string name, string species, string breed, DateOnly birthDate, string gender)
    {
        if (owner == null)
            throw new ArgumentNullException(nameof(owner), "Una mascota debe tener un dueño.");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre de la mascota es requerido.", nameof(name));
        
        Owner = owner;
        OwnerId = owner.UserId;
        Name = name;
        Species = species;
        Breed = breed;
        BirthDate = birthDate;
        Gender = gender;
        IsActive = true;
    }
    
    public void AssignVeterinarian(User veterinarian)
    {
        if (veterinarian == null)
            throw new ArgumentNullException(nameof(veterinarian));
        if (!Veterinarians.Contains(veterinarian))
            Veterinarians.Add(veterinarian);
    }

    public void RemoveVeterinarian(User veterinarian)
    {
        if (veterinarian != null && Veterinarians.Contains(veterinarian))
            Veterinarians.Remove(veterinarian);
    }

    public void UpdateDetails(string newName, string newBreed)
    {
        if (!string.IsNullOrWhiteSpace(newName))
        {
            Name = newName;
        }
        if (!string.IsNullOrWhiteSpace(newBreed))
        {
            Breed = newBreed;
        }
    }



    public void Deactivate()
    {
        IsActive = false;
    }
}