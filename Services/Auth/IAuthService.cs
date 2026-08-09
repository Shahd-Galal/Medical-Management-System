using MedicalManagementSystem.Dtos.Auth;

namespace MedicalManagementSystem.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        Task RegisterDoctorAsync(RegisterDoctorDto dto);
    }
}
