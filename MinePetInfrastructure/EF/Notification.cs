namespace Infrastructure.EF;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int UserId { get; set; }

    public int? PetId { get; set; }

    public int? ConsultationId { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? NotificationType { get; set; }

    public bool? IsRead { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Consultation? Consultation { get; set; }

    public virtual Infrastructure.EF.User? CreatedByNavigation { get; set; }

    public virtual Infrastructure.EF.Pet? Pet { get; set; }

    public virtual Infrastructure.EF.User? UpdatedByNavigation { get; set; }

    public virtual Infrastructure.EF.User User { get; set; } = null!;
}
