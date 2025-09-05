using Application.UseCases.Auth;
using Microsoft.AspNetCore.Mvc;
using Presentations.DTOs;

namespace Presentations.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    

    private readonly LoginUser _loginUser;

    public AuthController(LoginUser loginUser)
    {
        
        _loginUser = loginUser;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        try
        {
            var response = await _loginUser.ExecuteAsync(request);
            return Ok(new
            {
                data = response,
                statusCode = 200,
                message = "Login Successful",
                error = ""
                
                
            });
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }
    }
    







}