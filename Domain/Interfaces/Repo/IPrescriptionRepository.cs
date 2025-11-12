using Domain.Entities;

namespace Domain.Interfaces.Repo;

public interface IPrescriptionRepository
{

    Task<IEnumerable<Prescription>> GetAllPrescriptions();
    
    Task<Prescription> GetByIdAsync(int id);
    
    Task<Prescription> CreatePrescriptionAsync(Prescription prescription);

    Task<Prescription> UpdatePrescriptionAsync(Prescription prescription);
    
    
}