using MedicalManagementSystem.Dtos.Medicines;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Models.Medicine;
using MedicalManagementSystem.Repositories.Medicines;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Medicines
{
    public class MedicineStockService : IMedicineStockService
    {
        private readonly IMedicineStockRepository _medicineStockRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MedicineStockService(IMedicineStockRepository medicineStockRepository,IUnitOfWork unitOfWork)
        {
            _medicineStockRepository = medicineStockRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MedicineStockResponseDto>> GetAllMedicineStocksAsync()
        {
            var medicineStocks = await _medicineStockRepository.GetAllMedicineStocksAsync();

            return medicineStocks.Select(m => new MedicineStockResponseDto
            {
                MedicineStockId = m.MedicineStockId,
                MedicineId = m.MedicineId,
                BatchNumber = m.BatchNumber,
                Quantity = m.Quantity,
                ExpiryDate = m.ExpiryDate
            });
        }
        public async Task<MedicineStockResponseDto> GetMedicineStockByIdAsync(int id)
        {
            var medicineStock = await _medicineStockRepository.GetMedicineStockByIdAsync(id);

            if (medicineStock == null)
                throw new NotFoundException("Medicine stock not found");

            return new MedicineStockResponseDto
            {
                MedicineStockId = medicineStock.MedicineStockId,
                MedicineId = medicineStock.MedicineId,
                BatchNumber = medicineStock.BatchNumber,
                Quantity = medicineStock.Quantity,
                ExpiryDate = medicineStock.ExpiryDate
            };
        }
        public async Task CreateMedicineStockAsync(CreateMedicineStockDto dto)
        {
            var medicineStock = new MedicineStock
            {
                MedicineId = dto.MedicineId,
                BatchNumber = dto.BatchNumber,
                Quantity = dto.Quantity,
                ExpiryDate = dto.ExpiryDate
            };

            await _medicineStockRepository.CreateMedicineStockAsync(medicineStock);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateMedicineStockAsync(int id,UpdateMedicineStockDto dto)
        {
            var medicineStock = await _medicineStockRepository.GetMedicineStockByIdAsync(id);

            if (medicineStock == null)
                throw new NotFoundException("Medicine stock not found");

            medicineStock.BatchNumber = dto.BatchNumber;
            medicineStock.Quantity = dto.Quantity;
            medicineStock.ExpiryDate = dto.ExpiryDate;

            await _medicineStockRepository.UpdateMedicineStockAsync(medicineStock);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteMedicineStockByIdAsync(int id)
        {
            var result = await _medicineStockRepository.DeleteMedicineStockByIdAsync(id);

            if (!result)
                throw new NotFoundException("Medicine stock not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}