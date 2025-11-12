using System.Xml.Linq;
using Application.common;
using Application.Common;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repo;

namespace Application.UseCases.module;

public class CreatePrecription
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IMapper _mapper;

    public CreatePrecription(IMapper mapper, IPrescriptionRepository prescriptionRepository)
    {
        _mapper = mapper;
        _prescriptionRepository = prescriptionRepository;
        
    }
    
    
    //Crearemos el caso de uso 
    //en este caso registrar eso

    public async Task<BaseResponse<CreatePrescriptionResponse>> ExecuteAsync(CreatePrescriptionRequest request)
    {

        var prescriptionRegister = _mapper.Map<Prescription>(request);
        prescriptionRegister.CreatedAt = DateTime.Now;
        
        var saved = await _prescriptionRepository.CreatePrescriptionAsync(prescriptionRegister);

        var responseDto = _mapper.Map<CreatePrescriptionResponse>(saved);
        
        

        return BaseResponse<CreatePrescriptionResponse>.Ok(responseDto, "Receta creada xd");

    }


}