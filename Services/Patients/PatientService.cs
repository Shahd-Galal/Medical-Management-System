using MedicalManagementSystem.Dtos.Patients;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Patients;
using MedicalManagementSystem.Repositories.Patients;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Patients
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService( IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();

            return patients.Select(p => new PatientResponseDto
            {
                PatientId = p.PatientId,
                UserId = p.UserId,
                DOB = p.DOB,
                Gender = p.Gender,
                BloodType = p.BloodType,
                Address = p.Address,
                EmergencyContact = p.EmergencyContact
            });
        }
        public async Task<PatientResponseDto> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);

            if (patient == null)
                throw new NotFoundException("Patient not found");

            return new PatientResponseDto
            {
                PatientId = patient.PatientId,
                UserId = patient.UserId,
                DOB = patient.DOB,
                Gender = patient.Gender,
                BloodType = patient.BloodType,
                Address = patient.Address,
                EmergencyContact = patient.EmergencyContact
            };
        }
        public async Task CreatePatientAsync(CreatePatientDto dto)
        {
            var patient = new Patient
            {
                UserId = dto.UserId,
                DOB = dto.DOB,
                Gender = dto.Gender,
                BloodType = dto.BloodType,
                Address = dto.Address,
                EmergencyContact = dto.EmergencyContact
            };

            await _patientRepository.CreatePatientAsync(patient);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdatePatientAsync(int id, UpdatePatientDto dto)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);

            if (patient == null)
                throw new NotFoundException("Patient not found");

            patient.DOB = dto.DOB;
            patient.Gender = dto.Gender;
            patient.BloodType = dto.BloodType;
            patient.Address = dto.Address;
            patient.EmergencyContact = dto.EmergencyContact;

            await _patientRepository.UpdatePatientAsync(patient);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeletePatientByIdAsync(int id)
        {
            var result = await _patientRepository.DeletePatientByIdAsync(id);

            if (!result)
                throw new NotFoundException("Patient not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}