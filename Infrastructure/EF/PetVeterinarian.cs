using System;
using System.Collections.Generic;

namespace Infrastructure.EF;

public partial class PetVeterinarian
{
    public int PetVeterinarianId { get; set; }

    public int PetId { get; set; }

    public int VeterinarianId { get; set; }

    public DateTime? AssignedAt { get; set; }

    public DateTime? EndedAt { get; set; }

    public bool? IsCurrent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Pet Pet { get; set; } = null!;

    public virtual User Veterinarian { get; set; } = null!;
}
