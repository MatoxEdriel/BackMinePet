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

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDTO dto)
    {
        var user = await _registerUser.ExecuteAsync(
            dto.Name,
            dto.LastName,
            dto.Email,
            dto.Password,
            dto.RoleId
        );
        return Ok(user); 
    }



}