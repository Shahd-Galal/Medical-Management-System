using MedicalManagementSystem.Dtos.Medicines;

namespace MedicalManagementSystem.Services.Medicines
{
    public interface IMedicineService
    {
        Task<IEnumerable<MedicineResponseDto>> GetAllMedicinesAsync();
        Task<MedicineResponseDto> GetMedicineByIdAsync(int id);
        Task CreateMedicineAsync(CreateMedicineDto dto);
        Task UpdateMedicineAsync(int id, UpdateMedicineDto dto);
        Task<bool> DeleteMedicineByIdAsync(int id);
    }
}