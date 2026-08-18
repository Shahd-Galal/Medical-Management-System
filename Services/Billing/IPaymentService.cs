using MedicalManagementSystem.Dtos.Billing;

namespace MedicalManagementSystem.Services.Billing
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentResponseDto>> GetAllPaymentsAsync();
        Task<PaymentResponseDto> GetPaymentByIdAsync(int id);
        Task CreatePaymentAsync(CreatePaymentDto dto);
        Task<bool> DeletePaymentByIdAsync(int id);
    }
}
