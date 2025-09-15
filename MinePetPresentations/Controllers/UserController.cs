using Application.UseCases;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentations.DTOs;


namespace Presentations.Controllers;



[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly RegisterUser _registerUser;

    public UserController(RegisterUser registerUser)
    {
        _registerUser = registerUser;  
    }

    /// <summary>
    /// here using dto from to front 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUsertDto dto)
    {
        var newUser = await _registerUser.ExecuteAsync(dto);

        // NO HAGAS ESTO: return Ok(newUser); <-- Esto es la entidad con referencias circulares

        // HAZ ESTO: Mapea a un DTO
        var userResponse = new UserResponseDto
        {
            UserId = newUser.UserId,
            Email = newUser.Email,
            Name = newUser.UserProfileUser?.Name // Asumiendo que UserProfile está cargado
        };
        return Ok(userResponse); 
    }

    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
    }


}