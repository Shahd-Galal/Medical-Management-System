using MedicalManagementSystem.Models.Medicine;

namespace MedicalManagementSystem.Repositories.Medicines
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetAllMedicinesAsync();
        Task<Medicine?> GetMedicineByIdAsync(int id);
        Task CreateMedicineAsync(Medicine medicine);
        Task UpdateMedicineAsync(Medicine medicine);
        Task<bool> DeleteMedicineByIdAsync(int id);
    }
}