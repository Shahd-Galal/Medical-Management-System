using MedicalManagementSystem.Data;
using MedicalManagementSystem.Models.Medicine;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Medicines
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _context;
        public MedicineRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Medicine>> GetAllMedicinesAsync()
        {
            return await _context.Medicines.ToListAsync();
        }
        public async Task<Medicine?> GetMedicineByIdAsync(int id)
        {
            return await _context.Medicines.FirstOrDefaultAsync(m => m.MedicineId == id);
        }
        public async Task CreateMedicineAsync(Medicine medicine)
        {
            await _context.Medicines.AddAsync(medicine);
        }
        public async Task UpdateMedicineAsync(Medicine medicine)
        {
            _context.Medicines.Update(medicine);
        }
        public async Task<bool> DeleteMedicineByIdAsync(int id)
        {
            var medicine = await _context.Medicines.FirstOrDefaultAsync(m => m.MedicineId == id);

            if (medicine == null)
                return false;

            medicine.IsDeleted = true;
            return true;
        }
    }
}