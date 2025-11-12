using AutoMapper;
using Domain.Interfaces.Repo;
using Infrastructure.EF;
using Microsoft.AspNetCore.Components.Forms;
using Prescription = Domain.Entities.Prescription;

namespace Infrastructure.Repositories;

public class PrescriptionRepositoryRepository: IPrescriptionRepository
{
    private readonly MinePetContext _context;
    private readonly IMapper _mapper;
    
    public PrescriptionRepositoryRepository(MinePetContext context, IMapper mapper)
    {
     _context = context; 
     _mapper = mapper;
        
    }

    public async Task<IEnumerable<Prescription>> GetAllPrescriptions()
    {
        throw new NotImplementedException();
    }

    public async Task<Prescription> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Prescription> CreatePrescriptionAsync(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public async Task<Prescription> UpdatePrescriptionAsync(Prescription prescription)
    {
        throw new NotImplementedException();
    }
}