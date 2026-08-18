using MedicalManagementSystem.Model.Billing;

namespace MedicalManagementSystem.Repositories.Billing
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task CreatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentByIdAsync(int id);
    }
}
