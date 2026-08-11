using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Prescriptions;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Prescriptions
{
    public class PrescriptionItemRepository : IPrescriptionItemRepository
    {
        private readonly AppDbContext _context;
        public PrescriptionItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PrescriptionItem>> GetAllPrescriptionItemsAsync()
        {
            return await _context.PrescriptionItems.ToListAsync();
        }
        public async Task<PrescriptionItem?> GetPrescriptionItemByIdAsync(int id)
        {
            return await _context.PrescriptionItems.FirstOrDefaultAsync(p => p.PrescriptionItemId == id);
        }
        public async Task CreatePrescriptionItemAsync(PrescriptionItem prescriptionItem)
        {
            await _context.PrescriptionItems.AddAsync(prescriptionItem);
        }
        public async Task UpdatePrescriptionItemAsync(PrescriptionItem prescriptionItem)
        {
            _context.PrescriptionItems.Update(prescriptionItem);
        }
        public async Task<bool> DeletePrescriptionItemByIdAsync(int id)
        {
            var prescriptionItem = await _context.PrescriptionItems.FirstOrDefaultAsync(p => p.PrescriptionItemId == id);

            if (prescriptionItem == null)
                return false;

            prescriptionItem.IsDeleted = true;
            return true;
        }
    }
}