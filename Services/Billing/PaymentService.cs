using MedicalManagementSystem.Dtos.Billing;
using MedicalManagementSystem.Enums.Billing;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Billing;
using MedicalManagementSystem.Repositories.Billing;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Billing
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentService(IPaymentRepository paymentRepository,IInvoiceRepository invoiceRepository,IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PaymentResponseDto>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllPaymentsAsync();

            return payments.Select(p => new PaymentResponseDto
            {
                PaymentId = p.PaymentId,
                InvoiceId = p.InvoiceId,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentDate = p.PaymentDate,
                Status = p.Status
            });
        }
        public async Task<PaymentResponseDto> GetPaymentByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);

            if (payment == null)
                throw new NotFoundException("Payment not found");

            return new PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                InvoiceId = payment.InvoiceId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentDate = payment.PaymentDate,
                Status = payment.Status
            };
        }
        public async Task CreatePaymentAsync(CreatePaymentDto dto)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(dto.InvoiceId);

            if (invoice == null)
                throw new NotFoundException("Invoice not found");

            var payment = new Payment
            {
                InvoiceId = dto.InvoiceId,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod,
                PaymentDate = DateTime.UtcNow,
                Status = PaymentStatus.Pending
            };

            await _paymentRepository.CreatePaymentAsync(payment);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeletePaymentByIdAsync(int id)
        {
            var result = await _paymentRepository.DeletePaymentByIdAsync(id);

            if (!result)
                throw new NotFoundException("Payment not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
