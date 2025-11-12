using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CreatePrescriptionRequest
{
    public int ConsultationId { get; set; }
    public int ClinicId { get; set; }
    [Required]
    [StringLength(200)]
    public int PetId { get; set; }
    public string? Notes { get; set; }
    public int OwnerId { get; set; }

    [Required]
    public string? Warnings { get; set; } 
    
    public int Refills { get; set; }

   
}