using MedicalManagementSystem.Dtos.Doctors;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Models.Doctors;
using MedicalManagementSystem.Repositories.Doctors;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Doctors
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;


        public DoctorService(IDoctorRepository doctorRepository,IUnitOfWork unitOfWork)
        {
            _doctorRepository = doctorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllDoctorsAsync();

            return doctors.Select(d => new DoctorResponseDto
            {
                DoctorId = d.DoctorId,
                UserId = d.UserId,
                DepartmentId = d.DepartmentId,
                LicenseNumber = d.LicenseNumber,
                ExperienceYears = d.ExperienceYears,
                ConsultationFee = d.ConsultationFee
            });
        }

        public async Task<DoctorResponseDto> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);

            if (doctor == null)
                throw new NotFoundException("Doctor not found");

            return new DoctorResponseDto
            {
                DoctorId = doctor.DoctorId,
                UserId = doctor.UserId,
                DepartmentId = doctor.DepartmentId,
                LicenseNumber = doctor.LicenseNumber,
                ExperienceYears = doctor.ExperienceYears,
                ConsultationFee = doctor.ConsultationFee
            };
        }

        public async Task CreateDoctorAsync(CreateDoctorDto dto)
        {

            var doctor = new Doctor
            {
                UserId = dto.UserId,
                DepartmentId = dto.DepartmentId,
                LicenseNumber = dto.LicenseNumber,
                ExperienceYears = dto.ExperienceYears,
                ConsultationFee = dto.ConsultationFee
            };


            await _doctorRepository.CreateDoctorAsync(doctor);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task UpdateDoctorAsync(int id, UpdateDoctorDto dto)
        {

            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);

            if (doctor == null)
                throw new NotFoundException("Doctor not found");

            doctor.DepartmentId = dto.DepartmentId;
            doctor.LicenseNumber = dto.LicenseNumber;
            doctor.ExperienceYears = dto.ExperienceYears;
            doctor.ConsultationFee = dto.ConsultationFee;

            await _doctorRepository.UpdateDoctorAsync(doctor);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<bool> DeleteDoctorByIdAsync(int id)
        {

            var result = await _doctorRepository.DeleteDoctorByIdAsync(id);

            if (!result)
                throw new NotFoundException("Doctor not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}