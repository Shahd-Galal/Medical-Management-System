using MedicalManagementSystem.Dtos.Doctors;

namespace MedicalManagementSystem.Services.Doctors
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync();
        Task<DoctorResponseDto> GetDoctorByIdAsync(int id);
        Task CreateDoctorAsync(CreateDoctorDto dto);
        Task UpdateDoctorAsync(int id, UpdateDoctorDto dto);
        Task<bool> DeleteDoctorByIdAsync(int id);
    }
}
