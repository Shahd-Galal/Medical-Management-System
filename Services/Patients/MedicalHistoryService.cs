using MedicalManagementSystem.Dtos.Patients;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Patients;
using MedicalManagementSystem.Repositories.Patients;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Patients
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicalHistoryService(IMedicalHistoryRepository medicalHistoryRepository, IUnitOfWork unitOfWork)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MedicalHistoryResponseDto>> GetAllMedicalHistoriesAsync()
        {
            var medicalHistories = await _medicalHistoryRepository.GetAllMedicalHistoriesAsync();

            return medicalHistories.Select(m => new MedicalHistoryResponseDto
            {
                MedicalHistoryId = m.MedicalHistoryId,
                PatientId = m.PatientId,
                Disease = m.Disease,
                Surgery = m.Surgery,
                StartDate = m.StartDate,
                EndDate = m.EndDate
            });
        }
        public async Task<MedicalHistoryResponseDto> GetMedicalHistoryByIdAsync(int id)
        {
            var medicalHistory = await _medicalHistoryRepository.GetMedicalHistoryByIdAsync(id);

            if (medicalHistory == null)
                throw new NotFoundException("Medical history not found");

            return new MedicalHistoryResponseDto
            {
                MedicalHistoryId = medicalHistory.MedicalHistoryId,
                PatientId = medicalHistory.PatientId,
                Disease = medicalHistory.Disease,
                Surgery = medicalHistory.Surgery,
                StartDate = medicalHistory.StartDate,
                EndDate = medicalHistory.EndDate
            };
        }
        public async Task CreateMedicalHistoryAsync(CreateMedicalHistoryDto dto)
        {
            var medicalHistory = new MedicalHistory
            {
                PatientId = dto.PatientId,
                Disease = dto.Disease,
                Surgery = dto.Surgery,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };

            await _medicalHistoryRepository.CreateMedicalHistoryAsync(medicalHistory);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateMedicalHistoryAsync(int id, UpdateMedicalHistoryDto dto)
        {
            var medicalHistory = await _medicalHistoryRepository.GetMedicalHistoryByIdAsync(id);

            if (medicalHistory == null)
                throw new NotFoundException("Medical history not found");

            medicalHistory.Disease = dto.Disease;
            medicalHistory.Surgery = dto.Surgery;
            medicalHistory.StartDate = dto.StartDate;
            medicalHistory.EndDate = dto.EndDate;

            await _medicalHistoryRepository.UpdateMedicalHistoryAsync(medicalHistory);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteMedicalHistoryByIdAsync(int id)
        {
            var result = await _medicalHistoryRepository.DeleteMedicalHistoryByIdAsync(id);

            if (!result)
                throw new NotFoundException("Medical history not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}