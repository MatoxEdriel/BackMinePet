using Application.DTOs.User;
using Application.UseCases;
using Domain.Entities;
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
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUsertDto dto)
    {
        var newUser = await _registerUser.ExecuteAsync(dto);
        
        
        var userResponse = new UserRegisterResponseDto()
        {
            Name = newUser.UserProfile?.Name
        };
        return Ok(userResponse);  
    }
}