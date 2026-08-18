using MedicalManagementSystem.Model.Billing;

namespace MedicalManagementSystem.Repositories.Billing
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<Invoice?> GetInvoiceByIdAsync(int id);
        Task CreateInvoiceAsync(Invoice invoice);
        Task UpdateInvoiceAsync(Invoice invoice);
        Task<bool> DeleteInvoiceByIdAsync(int id);
    }
}
