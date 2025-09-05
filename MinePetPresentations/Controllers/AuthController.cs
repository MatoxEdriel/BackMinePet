using Application.UseCases.Auth;
using Microsoft.AspNetCore.Mvc;
using Presentations.DTOs;
using Presentations.DTOs.Responses;

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
            return Ok(ApiResponse<LoginResponseDto>.CreateSuccess(
                    data: response,
                    message: "Login Successful"
                )
            );
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized(
                ApiResponse<LoginResponseDto>.Unauthorized("Credentials Invalids")
                );
        }
    }
    







}