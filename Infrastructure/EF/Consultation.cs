using Domain.Entities;

namespace Infrastructure.EF;

public partial class Consultation
{
    public int ConsultationId { get; set; }

    public int PetId { get; set; }

    public int ClinicId { get; set; }

    public int VeterinarianId { get; set; }

    public DateTime ConsultationDate { get; set; }

    public string? Notes { get; set; }

    public DateTime? NextAppointment { get; set; }

    public bool? IsActive { get; set; }

    public int SequentialNumber { get; set; }

    public string? ConsultationCode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual Pet Pet { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual User Veterinarian { get; set; } = null!;
}
