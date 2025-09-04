using Application.UseCases;
using Presentations.DTOs;
namespace Presentations.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly CreatePetUseCase _createPetUseCase;
    
    public PetController(CreatePetUseCase createPetUseCase)
    {
        _createPetUseCase = createPetUseCase;
    }
    
    
    [HttpPost]
    public IActionResult CreatePet([FromBody] PetDto dto)
    {

        var pet = new Domain.Entities.Pet(dto.Id, dto.Name, dto.Species, dto.BirthDate);
        _createPetUseCase.Execute(pet);
        return Ok(new { message = "Pet created successfully!" });
    }
    
    
    
    
}