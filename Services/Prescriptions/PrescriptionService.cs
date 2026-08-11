using MedicalManagementSystem.Dtos.Prescriptions;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Prescriptions;
using MedicalManagementSystem.Repositories.Prescriptions;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Prescriptions
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IUnitOfWork unitOfWork)
        {
            _prescriptionRepository = prescriptionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PrescriptionResponseDto>> GetAllPrescriptionsAsync()
        {
            var prescriptions = await _prescriptionRepository.GetAllPrescriptionsAsync();

            return prescriptions.Select(p => new PrescriptionResponseDto
            {
                PrescriptionId = p.PrescriptionId,
                RecordId = p.RecordId,
                DoctorId = p.DoctorId,
                CreatedAt = p.CreatedAt
            });
        }
        public async Task<PrescriptionResponseDto> GetPrescriptionByIdAsync(int id)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionByIdAsync(id);

            if (prescription == null)
                throw new NotFoundException("Prescription not found");

            return new PrescriptionResponseDto
            {
                PrescriptionId = prescription.PrescriptionId,
                RecordId = prescription.RecordId,
                DoctorId = prescription.DoctorId,
                CreatedAt = prescription.CreatedAt
            };
        }
        public async Task CreatePrescriptionAsync(CreatePrescriptionDto dto)
        {
            var prescription = new Prescription
            {
                RecordId = dto.RecordId,
                DoctorId = dto.DoctorId
            };
            await _prescriptionRepository.CreatePrescriptionAsync(prescription);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeletePrescriptionByIdAsync(int id)
        {
            var result = await _prescriptionRepository.DeletePrescriptionByIdAsync(id);

            if (!result)
                throw new NotFoundException("Prescription not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}