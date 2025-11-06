using System;
using System.Collections.Generic;

namespace Infrastructure.EF;

public partial class PrescriptionItem
{
    public int PrescriptionItemId { get; set; }

    public int PrescriptionId { get; set; }

    public string MedicineName { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public string? Route { get; set; }

    public string? Frequency { get; set; }

    public string? Duration { get; set; }

    public string? Posology { get; set; }

    public string? Warning { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Prescription Prescription { get; set; } = null!;
}
