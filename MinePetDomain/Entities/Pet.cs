namespace Domain.Entities;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Species { get; set; }
    public DateOnly? BirthDate { get; set; }

    public Pet(int id, string name, string? species, DateOnly birthdate)
    {
        
        Id = id;
        Name = name;
        Species = species;
        BirthDate = birthdate;
        
    }

    public int? GetAge()
    {
        if (!BirthDate.HasValue) return null; 
        var today = DateOnly.FromDateTime(DateTime.Today);
        int age = today.Year - BirthDate.Value.Year;
        if (BirthDate.Value > today.AddYears(-age)) age--;

        return age;
    }




}