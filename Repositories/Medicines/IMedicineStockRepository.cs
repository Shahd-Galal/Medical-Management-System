using MedicalManagementSystem.Models.Medicine;

namespace MedicalManagementSystem.Repositories.Medicines
{
    public interface IMedicineStockRepository
    {
        Task<IEnumerable<MedicineStock>> GetAllMedicineStocksAsync();
        Task<MedicineStock?> GetMedicineStockByIdAsync(int id);
        Task CreateMedicineStockAsync(MedicineStock medicineStock);
        Task UpdateMedicineStockAsync(MedicineStock medicineStock);
        Task<bool> DeleteMedicineStockByIdAsync(int id);
    }
}