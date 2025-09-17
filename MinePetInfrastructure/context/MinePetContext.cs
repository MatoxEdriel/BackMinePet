using Domain.Entities;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Pet = Infrastructure.EF.Pet;
using User = Infrastructure.EF.User;
using UserProfile = Infrastructure.EF.UserProfile;

namespace Infrastructure.context;

public partial class MinePetContext : DbContext
{
    public MinePetContext()
    {
    }

    public MinePetContext(DbContextOptions<MinePetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Consultation> Consultations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetVeterinarian> PetVeterinarians { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=minePet;User Id=sa;Password='Dragoncity5*';TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.ClinicId).HasName("PK__Clinics__3347C2DD6F76301C");

            entity.HasIndex(e => e.Ruc, "UQ__Clinics__CAF0367384A1632A").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Ruc).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasKey(e => e.ConsultationId).HasName("PK__Consulta__5D014A988DA327B2");

            entity.Property(e => e.ConsultationCode)
                .HasMaxLength(26)
                .HasComputedColumnSql("((((CONVERT([nvarchar](10),[ClinicId])+'-')+CONVERT([nvarchar](10),[PetId]))+'-')+right('0000'+CONVERT([nvarchar](10),[SequentialNumber]),(4)))", true);
            entity.Property(e => e.ConsultationDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NextAppointment).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultat__Clini__59063A47");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ConsultationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultat__Creat__5BE2A6F2");

            entity.HasOne(d => d.Pet).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultat__PetId__59FA5E80");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ConsultationUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Consultat__Updat__5CD6CB2B");

            entity.HasOne(d => d.Veterinarian).WithMany(p => p.ConsultationVeterinarians)
                .HasForeignKey(d => d.VeterinarianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultat__Veter__5AEE82B9");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E1293303097");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.NotificationType).HasMaxLength(50);
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Consultation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.ConsultationId)
                .HasConstraintName("FK_Notifications_Consultation");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Notifications_CreatedBy");

            entity.HasOne(d => d.Pet).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK_Notifications_Pet");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.NotificationUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Notifications_UpdatedBy");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_User");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__Pets__48E53862EBA6A6E4");

            entity.Property(e => e.Breed).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Species).HasMaxLength(50);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PetCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Pets__CreatedBy__49C3F6B7");

            entity.HasOne(d => d.Owner).WithMany(p => p.PetOwners)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pets__OwnerId__4BAC3F29");

            entity.HasOne(d => d.UpdateByNavigation).WithMany(p => p.PetUpdateByNavigations)
                .HasForeignKey(d => d.UpdateBy)
                .HasConstraintName("FK__Pets__UpdateBy__4AB81AF0");

            entity.HasOne(d => d.Veterinarian).WithMany(p => p.PetVeterinarians)
                .HasForeignKey(d => d.VeterinarianId)
                .HasConstraintName("FK__Pets__Veterinari__4CA06362");
        });

        modelBuilder.Entity<PetVeterinarian>(entity =>
        {
            entity.HasKey(e => e.PetVeterinarianId).HasName("PK__PetVeter__9FB497FABA1322FD");

            entity.Property(e => e.AssignedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndedAt).HasColumnType("datetime");
            entity.Property(e => e.IsCurrent).HasDefaultValue(true);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Pet).WithMany(p => p.PetVeterinarians)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PetVeteri__PetId__52593CB8");

            entity.HasOne(d => d.Veterinarian).WithMany(p => p.PetVeterinariansNavigation)
                .HasForeignKey(d => d.VeterinarianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PetVeteri__Veter__534D60F1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A80E44CD8");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61602CFC1F15").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RoleName).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C53829BD6");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105343E38D990").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.EmailConfirmed).HasDefaultValue(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserProf__1788CC4CF4E6CB47");

            entity.ToTable("UserProfile");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Alias).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdentityNumber).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(13);
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(500);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserProfileCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_UserProfile_CreatedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.UserProfileUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_UserProfile_UpdatedBy");

            entity.HasOne(d => d.User).WithOne(p => p.UserProfileUser)
                .HasForeignKey<UserProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserProfile_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
