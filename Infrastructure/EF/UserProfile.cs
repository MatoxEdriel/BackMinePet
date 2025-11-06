using System;
using System.Collections.Generic;

namespace Infrastructure.EF;

public partial class UserProfile
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Alias { get; set; }

    public string? Phone { get; set; }

    public string? IdentityNumber { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
