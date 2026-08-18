using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Billing;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Billing
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly AppDbContext _context;
        public InvoiceItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InvoiceItem>> GetAllInvoiceItemsAsync()
        {
            return await _context.InvoiceItems.ToListAsync();
        }
        public async Task<InvoiceItem?> GetInvoiceItemByIdAsync(int id)
        {
            return await _context.InvoiceItems.FirstOrDefaultAsync(i => i.InvoiceItemId == id);
        }
        public async Task CreateInvoiceItemAsync(InvoiceItem invoiceItem)
        {
            await _context.InvoiceItems.AddAsync(invoiceItem);
        }
        public async Task UpdateInvoiceItemAsync(InvoiceItem invoiceItem)
        {
            _context.InvoiceItems.Update(invoiceItem);
        }
        public async Task<bool> DeleteInvoiceItemByIdAsync(int id)
        {
            var invoiceItem = await _context.InvoiceItems.FirstOrDefaultAsync(i => i.InvoiceItemId == id);

            if (invoiceItem == null)
                return false;

            invoiceItem.IsDeleted = true;
            return true;
        }
    }
}
