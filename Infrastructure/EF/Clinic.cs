using System;
using System.Collections.Generic;

namespace Infrastructure.EF;

public partial class Clinic
{
    public int ClinicId { get; set; }

    public string Ruc { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
