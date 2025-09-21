using Application.UseCases.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentations.DTOs;
using Presentations.DTOs.Responses;

namespace Presentations.Controllers;


/// <summary>
/// Controlador de autenticación, maneja login y registro de usuarios.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    private readonly LoginUser _loginUser;

    public AuthController(LoginUser loginUser)
    {
        
        _loginUser = loginUser;
    }
    
    /// <summary>
    /// Realiza el login de un usuario y devuelve un token JWT.
    /// </summary>
    /// <param name="request">DTO con email y contraseña del usuario.</param>
    /// <returns>Retorna un objeto con datos del usuario y token JWT.</returns>
    /// <response code="200">Login exitoso</response>
    /// <response code="401">Credenciales inválidas</response>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
            var response = await _loginUser.ExecuteAsync(request);
            return Ok(ApiResponse<LoginResponseDto>.CreateSuccess(
                    data: response,
                    message: "Login Successful"
                )
            );
    }
}