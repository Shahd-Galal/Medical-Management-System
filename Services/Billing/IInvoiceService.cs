using MedicalManagementSystem.Dtos.Billing;

namespace MedicalManagementSystem.Services.Billing
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceResponseDto>> GetAllInvoicesAsync();
        Task<InvoiceResponseDto> GetInvoiceByIdAsync(int id);
        Task CreateInvoiceAsync(CreateInvoiceDto dto);
        Task UpdateInvoiceAsync(int id, UpdateInvoiceDto dto);
        Task<bool> DeleteInvoiceByIdAsync(int id);
    }
}
