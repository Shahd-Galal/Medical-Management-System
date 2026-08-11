using MedicalManagementSystem.Dtos.Medicines;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Models.Medicine;
using MedicalManagementSystem.Repositories.Medicines;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Medicines
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MedicineService(IMedicineRepository medicineRepository,IUnitOfWork unitOfWork)
        {
            _medicineRepository = medicineRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MedicineResponseDto>> GetAllMedicinesAsync()
        {
            var medicines = await _medicineRepository.GetAllMedicinesAsync();

            return medicines.Select(m => new MedicineResponseDto
            {
                MedicineId = m.MedicineId,
                Name = m.Name,
                Description = m.Description,
                UnitPrice = m.UnitPrice,
                Manufacturer = m.Manufacturer
            });
        }
        public async Task<MedicineResponseDto> GetMedicineByIdAsync(int id)
        {
            var medicine = await _medicineRepository.GetMedicineByIdAsync(id);

            if (medicine == null)
                throw new NotFoundException("Medicine not found");

            return new MedicineResponseDto
            {
                MedicineId = medicine.MedicineId,
                Name = medicine.Name,
                Description = medicine.Description,
                UnitPrice = medicine.UnitPrice,
                Manufacturer = medicine.Manufacturer
            };
        }
        public async Task CreateMedicineAsync(CreateMedicineDto dto)
        {
            var medicine = new Medicine
            {
                Name = dto.Name,
                Description = dto.Description,
                UnitPrice = dto.UnitPrice,
                Manufacturer = dto.Manufacturer
            };

            await _medicineRepository.CreateMedicineAsync(medicine);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateMedicineAsync(int id,UpdateMedicineDto dto)
        {
            var medicine = await _medicineRepository.GetMedicineByIdAsync(id);

            if (medicine == null)
                throw new NotFoundException("Medicine not found");

            medicine.Name = dto.Name;
            medicine.Description = dto.Description;
            medicine.UnitPrice = dto.UnitPrice;
            medicine.Manufacturer = dto.Manufacturer;

            await _medicineRepository.UpdateMedicineAsync(medicine);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteMedicineByIdAsync(int id)
        {
            var result = await _medicineRepository.DeleteMedicineByIdAsync(id);

            if (!result)
                throw new NotFoundException("Medicine not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}