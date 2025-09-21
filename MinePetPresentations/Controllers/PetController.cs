using Application.DTOs.Pet;
using Application.UseCases.Pets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentations.DTOs;

namespace Presentations.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetController: ControllerBase
{
    private readonly RegisterPet _registerPet;
    private readonly IMapper _mapper;

    public PetController(RegisterPet registerPet,  IMapper mapper)
    {
        _registerPet = registerPet;
        _mapper = mapper;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] PetRegisterDtoFront dto)
    {
        var command = _mapper.Map<PetRegisterDto>(dto);
        var newPet = await _registerPet.ExecuteAsync(command);
        var petResponse = new PetRegisterDtoResponse()
        {
            Name  = newPet.Name,
            breed = newPet.Breed
        };
        return Ok(petResponse);

//Hay que corregir el dto de register 
    }
    
    
    
    
}