using MedicalManagementSystem.Data;
using MedicalManagementSystem.Models.Medicine;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Medicines
{
    public class MedicineStockRepository : IMedicineStockRepository
    {
        private readonly AppDbContext _context;
        public MedicineStockRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MedicineStock>> GetAllMedicineStocksAsync()
        {
            return await _context.MedicineStocks.ToListAsync();
        }
        public async Task<MedicineStock?> GetMedicineStockByIdAsync(int id)
        {
            return await _context.MedicineStocks.FirstOrDefaultAsync(m => m.MedicineStockId == id);
        }
        public async Task CreateMedicineStockAsync(MedicineStock medicineStock)
        {
            await _context.MedicineStocks.AddAsync(medicineStock);
        }
        public async Task UpdateMedicineStockAsync(MedicineStock medicineStock)
        {
            _context.MedicineStocks.Update(medicineStock);
        }
        public async Task<bool> DeleteMedicineStockByIdAsync(int id)
        {
            var medicineStock = await _context.MedicineStocks.FirstOrDefaultAsync(m => m.MedicineStockId == id);

            if (medicineStock == null)
                return false;

            medicineStock.IsDeleted = true;
            return true;
        }
    }
}