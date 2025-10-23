    using Application.DTOs.Auth;
    using Application.UseCases.Auth;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Presentations.DTOs.Responses;
    using LoginResponseDto = Application.DTOs.Auth.LoginResponseDto;

    namespace Presentations.Controllers;


    /// <summary>
    /// Controlador de autenticación, maneja login y registro de usuarios.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly LoginUser _loginUser;
        private readonly IMapper _mapper;

        public AuthController(LoginUser loginUser, IMapper mapper)
        {
            _mapper = mapper;
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
            //la necesidad de usar dos dto no tiene sentido
                var response = await _loginUser.ExecuteAsync(request);
                return Ok(ApiResponse<LoginResponseDto>.CreateSuccess(
                        data: response,
                        message: "Login Successful"
                    )
                );
        }
    }