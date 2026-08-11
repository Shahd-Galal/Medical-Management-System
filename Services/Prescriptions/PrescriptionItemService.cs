using MedicalManagementSystem.Dtos.Prescriptions;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Prescriptions;
using MedicalManagementSystem.Repositories.Prescriptions;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Prescriptions
{
    public class PrescriptionItemService : IPrescriptionItemService
    {
        private readonly IPrescriptionItemRepository _prescriptionItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PrescriptionItemService(IPrescriptionItemRepository prescriptionItemRepository,IUnitOfWork unitOfWork)
        {
            _prescriptionItemRepository = prescriptionItemRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PrescriptionItemResponseDto>>GetAllPrescriptionItemsAsync()
        {
            var prescriptionItems =await _prescriptionItemRepository.GetAllPrescriptionItemsAsync();

            return prescriptionItems.Select(p => new PrescriptionItemResponseDto
            {
                PrescriptionItemId = p.PrescriptionItemId,
                PrescriptionId = p.PrescriptionId,
                MedicineId = p.MedicineId,
                Dosage = p.Dosage,
                Frequency = p.Frequency,
                DurationDays = p.DurationDays,
                Instructions = p.Instructions
            });
        }
        public async Task<PrescriptionItemResponseDto>GetPrescriptionItemByIdAsync(int id)
        {
            var prescriptionItem = await _prescriptionItemRepository.GetPrescriptionItemByIdAsync(id);

            if (prescriptionItem == null)
                throw new NotFoundException("Prescription item not found");

            return new PrescriptionItemResponseDto
            {
                PrescriptionItemId = prescriptionItem.PrescriptionItemId,
                PrescriptionId = prescriptionItem.PrescriptionId,
                MedicineId = prescriptionItem.MedicineId,
                Dosage = prescriptionItem.Dosage,
                Frequency = prescriptionItem.Frequency,
                DurationDays = prescriptionItem.DurationDays,
                Instructions = prescriptionItem.Instructions
            };
        }
        public async Task CreatePrescriptionItemAsync(CreatePrescriptionItemDto dto)
        {
            var prescriptionItem = new PrescriptionItem
            {
                PrescriptionId = dto.PrescriptionId,
                MedicineId = dto.MedicineId,
                Dosage = dto.Dosage,
                Frequency = dto.Frequency,
                DurationDays = dto.DurationDays,
                Instructions = dto.Instructions
            };

            await _prescriptionItemRepository.CreatePrescriptionItemAsync(prescriptionItem);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdatePrescriptionItemAsync(int id,UpdatePrescriptionItemDto dto)
        {
            var prescriptionItem = await _prescriptionItemRepository.GetPrescriptionItemByIdAsync(id);

            if (prescriptionItem == null)
                throw new NotFoundException("Prescription item not found");

            prescriptionItem.Dosage = dto.Dosage;
            prescriptionItem.Frequency = dto.Frequency;
            prescriptionItem.DurationDays = dto.DurationDays;
            prescriptionItem.Instructions = dto.Instructions;

            await _prescriptionItemRepository.UpdatePrescriptionItemAsync(prescriptionItem);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeletePrescriptionItemByIdAsync(int id)
        {
            var result = await _prescriptionItemRepository.DeletePrescriptionItemByIdAsync(id);

            if (!result)
                throw new NotFoundException("Prescription item not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}