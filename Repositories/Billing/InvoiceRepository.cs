using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Billing;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Billing
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;
        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }
        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices.FirstOrDefaultAsync(i => i.InvoiceId == id);
        }
        public async Task CreateInvoiceAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
        }
        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
        }
        public async Task<bool> DeleteInvoiceByIdAsync(int id)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.InvoiceId == id);

            if (invoice == null)
                return false;

            invoice.IsDeleted = true;
            return true;
        }
    }
}
