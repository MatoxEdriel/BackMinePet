using System;
using System.Collections.Generic;

namespace Infrastructure.EF;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int ConsultationId { get; set; }

    public int ClinicId { get; set; }

    public int PetId { get; set; }

    public int VeterinarianId { get; set; }

    public string? Notes { get; set; }

    public int OwnerId { get; set; }

    public string? Warnings { get; set; }

    public bool? Refills { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual Consultation Consultation { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual Pet Pet { get; set; } = null!;

    public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();

    public virtual User Veterinarian { get; set; } = null!;
}
