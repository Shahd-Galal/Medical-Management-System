using MedicalManagementSystem.Dtos.Medicines;

namespace MedicalManagementSystem.Services.Medicines
{
    public interface IMedicineStockService
    {
        Task<IEnumerable<MedicineStockResponseDto>> GetAllMedicineStocksAsync();

        Task<MedicineStockResponseDto> GetMedicineStockByIdAsync(int id);

        Task CreateMedicineStockAsync(CreateMedicineStockDto dto);

        Task UpdateMedicineStockAsync(int id, UpdateMedicineStockDto dto);

        Task<bool> DeleteMedicineStockByIdAsync(int id);
    }
}