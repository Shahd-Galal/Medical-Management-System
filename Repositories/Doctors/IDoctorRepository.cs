using MedicalManagementSystem.Models.Doctors;

namespace MedicalManagementSystem.Repositories.Doctors
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor?> GetDoctorByIdAsync(int id);
        Task CreateDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(Doctor doctor);
        Task<bool> DeleteDoctorByIdAsync(int id);
    }
}
