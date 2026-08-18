using MedicalManagementSystem.Dtos.Billing;

namespace MedicalManagementSystem.Services.Billing
{
    public interface IInvoiceItemService
    {
        Task<IEnumerable<InvoiceItemResponseDto>> GetAllInvoiceItemsAsync();
        Task<InvoiceItemResponseDto> GetInvoiceItemByIdAsync(int id);
        Task CreateInvoiceItemAsync(CreateInvoiceItemDto dto);
        Task UpdateInvoiceItemAsync(int id, UpdateInvoiceItemDto dto);
        Task<bool> DeleteInvoiceItemByIdAsync(int id);
    }
}
