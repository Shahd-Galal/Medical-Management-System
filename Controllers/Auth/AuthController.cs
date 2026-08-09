using MedicalManagementSystem.Dtos.Auth;
using MedicalManagementSystem.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            return Ok(result);
        }
        [Authorize(Roles = AppRoles.Admin)]
        [HttpPost("admin/create-doctor")]
        public async Task<IActionResult> CreateDoctor(RegisterDoctorDto dto)
        {
            await _authService.RegisterDoctorAsync(dto);

            return Ok("Doctor account created successfully.");
        }
    }
}
