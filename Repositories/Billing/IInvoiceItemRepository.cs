using MedicalManagementSystem.Model.Billing;

namespace MedicalManagementSystem.Repositories.Billing
{
    public interface IInvoiceItemRepository
    {
        Task<IEnumerable<InvoiceItem>> GetAllInvoiceItemsAsync();
        Task<InvoiceItem?> GetInvoiceItemByIdAsync(int id);
        Task CreateInvoiceItemAsync(InvoiceItem invoiceItem);
        Task UpdateInvoiceItemAsync(InvoiceItem invoiceItem);
        Task<bool> DeleteInvoiceItemByIdAsync(int id);
    }
}
