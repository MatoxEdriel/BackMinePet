namespace Domain.Entities;

public class Prescription
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public int PetId { get; private set; }
    public string Notes { get; private set; } = string.Empty;
    public string CreatedBy { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    

    protected Prescription() { }

    public Prescription(int clinicId, int petId, string notes, string createdBy)
    {
        if (string.IsNullOrWhiteSpace(notes))
            throw new ArgumentException("Las notas no pueden estar vacías.", nameof(notes));

        ClinicId = clinicId;
        PetId = petId;
        Notes = notes;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateNotes(string newNotes)
    {
        if (string.IsNullOrWhiteSpace(newNotes))
            throw new ArgumentException("Las notas no pueden estar vacías.");
        Notes = newNotes;
    }
}