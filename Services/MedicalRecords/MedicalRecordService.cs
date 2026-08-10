using MedicalManagementSystem.Dtos.MedicalRecords;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.MedicalRecords;
using MedicalManagementSystem.Repositories.MedicalRecords;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.MedicalRecords
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicalRecordService(
            IMedicalRecordRepository medicalRecordRepository,
            IUnitOfWork unitOfWork)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MedicalRecordResponseDto>> GetAllMedicalRecordsAsync()
        {
            var medicalRecords = await _medicalRecordRepository.GetAllMedicalRecordsAsync();

            return medicalRecords.Select(m => new MedicalRecordResponseDto
            {
                MedicalRecordId = m.MedicalRecordId,
                AppointmentId = m.AppointmentId,
                PatientId = m.PatientId,
                DoctorId = m.DoctorId,
                Diagnosis = m.Diagnosis,
                TreatmentPlan = m.TreatmentPlan,
                Notes = m.Notes,
                CreatedAt = m.CreatedAt
            });
        }
        public async Task<MedicalRecordResponseDto> GetMedicalRecordByIdAsync(int id)
        {
            var medicalRecord = await _medicalRecordRepository.GetMedicalRecordByIdAsync(id);

            if (medicalRecord == null)
                throw new NotFoundException("Medical record not found");

            return new MedicalRecordResponseDto
            {
                MedicalRecordId = medicalRecord.MedicalRecordId,
                AppointmentId = medicalRecord.AppointmentId,
                PatientId = medicalRecord.PatientId,
                DoctorId = medicalRecord.DoctorId,
                Diagnosis = medicalRecord.Diagnosis,
                TreatmentPlan = medicalRecord.TreatmentPlan,
                Notes = medicalRecord.Notes,
                CreatedAt = medicalRecord.CreatedAt
            };
        }
        public async Task CreateMedicalRecordAsync(CreateMedicalRecordDto dto)
        {
            var medicalRecord = new MedicalRecord
            {
                AppointmentId = dto.AppointmentId,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                Diagnosis = dto.Diagnosis,
                TreatmentPlan = dto.TreatmentPlan,
                Notes = dto.Notes
            };

            await _medicalRecordRepository.CreateMedicalRecordAsync(medicalRecord);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateMedicalRecordAsync(int id, UpdateMedicalRecordDto dto)
        {
            var medicalRecord = await _medicalRecordRepository.GetMedicalRecordByIdAsync(id);

            if (medicalRecord == null)
                throw new NotFoundException("Medical record not found");

            medicalRecord.Diagnosis = dto.Diagnosis;
            medicalRecord.TreatmentPlan = dto.TreatmentPlan;
            medicalRecord.Notes = dto.Notes;

            await _medicalRecordRepository.UpdateMedicalRecordAsync(medicalRecord);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteMedicalRecordByIdAsync(int id)
        {
            var result = await _medicalRecordRepository.DeleteMedicalRecordByIdAsync(id);

            if (!result)
                throw new NotFoundException("Medical record not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}