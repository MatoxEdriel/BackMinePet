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
        var user = await _registerUser.ExecuteAsync(
          dto
        );
        return Ok(user); 
    }



}