
namespace Infrastructure.EF;

public partial class Pet
{
    public int PetId { get; set; }

    public int OwnerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Species { get; set; }

    public string? Breed { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Gender { get; set; }

    public int? VeterinarianId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

    public virtual Infrastructure.EF.User? CreatedByNavigation { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual Infrastructure.EF.User Owner { get; set; } = null!;

    public virtual ICollection<PetVeterinarian> PetVeterinarians { get; set; } = new List<PetVeterinarian>();

    public virtual Infrastructure.EF.User? UpdateByNavigation { get; set; }

    public virtual Infrastructure.EF.User? Veterinarian { get; set; }
}
