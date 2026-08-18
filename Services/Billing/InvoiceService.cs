using MedicalManagementSystem.Dtos.Billing;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Billing;
using MedicalManagementSystem.Repositories.Billing;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Billing
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceService(IInvoiceRepository invoiceRepository,IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<InvoiceResponseDto>> GetAllInvoicesAsync()
        {
            var invoices = await _invoiceRepository.GetAllInvoicesAsync();

            return invoices.Select(i => new InvoiceResponseDto
            {
                InvoiceId = i.InvoiceId,
                PatientId = i.PatientId,
                AppointmentId = i.AppointmentId,
                TotalAmount = i.TotalAmount,
                Status = i.Status
            });
        }
        public async Task<InvoiceResponseDto> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);

            if (invoice == null)
                throw new NotFoundException("Invoice not found");

            return new InvoiceResponseDto
            {
                InvoiceId = invoice.InvoiceId,
                PatientId = invoice.PatientId,
                AppointmentId = invoice.AppointmentId,
                TotalAmount = invoice.TotalAmount,
                Status = invoice.Status
            };
        }
        public async Task CreateInvoiceAsync(CreateInvoiceDto dto)
        {
            var invoice = new Invoice
            {
                PatientId = dto.PatientId,
                AppointmentId = dto.AppointmentId,
                Status = dto.Status,
                TotalAmount = 0
            };

            await _invoiceRepository.CreateInvoiceAsync(invoice);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateInvoiceAsync(int id, UpdateInvoiceDto dto)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);

            if (invoice == null)
                throw new NotFoundException("Invoice not found");

            invoice.Status = dto.Status;

            await _invoiceRepository.UpdateInvoiceAsync(invoice);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteInvoiceByIdAsync(int id)
        {
            var result = await _invoiceRepository.DeleteInvoiceByIdAsync(id);

            if (!result)
                throw new NotFoundException("Invoice not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
