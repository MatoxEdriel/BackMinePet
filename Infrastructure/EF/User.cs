using System;
using System.Collections.Generic;

namespace Infrastructure.EF;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public bool? EmailConfirmed { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<Consultation> ConsultationCreatedByNavigations { get; set; } = new List<Consultation>();

    public virtual ICollection<Consultation> ConsultationUpdatedByNavigations { get; set; } = new List<Consultation>();

    public virtual ICollection<Consultation> ConsultationVeterinarians { get; set; } = new List<Consultation>();

    public virtual ICollection<Notification> NotificationCreatedByNavigations { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationUpdatedByNavigations { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationUsers { get; set; } = new List<Notification>();

    public virtual ICollection<Pet> PetCreatedByNavigations { get; set; } = new List<Pet>();

    public virtual ICollection<Pet> PetOwners { get; set; } = new List<Pet>();

    public virtual ICollection<Pet> PetUpdateByNavigations { get; set; } = new List<Pet>();

    public virtual ICollection<PetVeterinarian> PetVeterinarians { get; set; } = new List<PetVeterinarian>();

    public virtual ICollection<Prescription> PrescriptionCreatedByNavigations { get; set; } = new List<Prescription>();

    public virtual ICollection<Prescription> PrescriptionOwners { get; set; } = new List<Prescription>();

    public virtual ICollection<Prescription> PrescriptionVeterinarians { get; set; } = new List<Prescription>();

    public virtual ICollection<UserProfile> UserProfileCreatedByNavigations { get; set; } = new List<UserProfile>();

    public virtual ICollection<UserProfile> UserProfileUpdatedByNavigations { get; set; } = new List<UserProfile>();

    public virtual UserProfile? UserProfileUser { get; set; }

    public virtual ICollection<UserRole> UserRoleCreatedByNavigations { get; set; } = new List<UserRole>();

    public virtual ICollection<UserRole> UserRoleUsers { get; set; } = new List<UserRole>();
}
