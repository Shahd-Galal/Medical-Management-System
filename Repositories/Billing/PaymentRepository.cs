using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Billing;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Billing
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);
        }
        public async Task CreatePaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }
        public async Task<bool> DeletePaymentByIdAsync(int id)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);

            if (payment == null)
                return false;

            payment.IsDeleted = true;
            return true;
        }
    }
}
