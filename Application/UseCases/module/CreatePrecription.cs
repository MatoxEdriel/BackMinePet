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
        if (string.IsNullOrWhiteSpace(request.Notes))
        {

            return ResponseHelper.Fail<CreatePrescriptionResponse>(
                "Error de validacion",
                "ValidationError"
            );
            
            
            
    }
        var prescipttion = _
        
        


        try
        {
            var entity = new Prescription(
                request.ClinicId,
                request.PetId,
                request.Notes
                
                );


        }
        catch (Exception ex)
        {
            return ResponseHelper.Exception()>()
        }


        

    }



}