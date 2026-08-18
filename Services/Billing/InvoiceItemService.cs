using MedicalManagementSystem.Dtos.Billing;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Billing;
using MedicalManagementSystem.Repositories.Billing;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Billing
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceItemService(
            IInvoiceItemRepository invoiceItemRepository,
            IInvoiceRepository invoiceRepository,
            IServiceRepository serviceRepository,
            IUnitOfWork unitOfWork)
        {
            _invoiceItemRepository = invoiceItemRepository;
            _invoiceRepository = invoiceRepository;
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InvoiceItemResponseDto>> GetAllInvoiceItemsAsync()
        {
            var invoiceItems = await _invoiceItemRepository.GetAllInvoiceItemsAsync();

            return invoiceItems.Select(MapToDto);
        }

        public async Task<InvoiceItemResponseDto> GetInvoiceItemByIdAsync(int id)
        {
            var invoiceItem = await _invoiceItemRepository.GetInvoiceItemByIdAsync(id);

            if (invoiceItem == null)
                throw new NotFoundException("Invoice item not found");

            return MapToDto(invoiceItem);
        }

        public async Task CreateInvoiceItemAsync(CreateInvoiceItemDto dto)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(dto.InvoiceId);

            if (invoice == null)
                throw new NotFoundException("Invoice not found");

            var service = await _serviceRepository.GetServiceByIdAsync(dto.ServiceId);

            if (service == null)
                throw new NotFoundException("Service not found");

            // The price comes from the service; the line total is price * quantity.
            var invoiceItem = new InvoiceItem
            {
                InvoiceId = dto.InvoiceId,
                ServiceId = dto.ServiceId,
                Quantity = dto.Quantity,
                UnitPrice = service.Price,
                TotalPrice = service.Price * dto.Quantity
            };

            await _invoiceItemRepository.CreateInvoiceItemAsync(invoiceItem);

            // Keep the invoice total in sync.
            invoice.TotalAmount += invoiceItem.TotalPrice;
            await _invoiceRepository.UpdateInvoiceAsync(invoice);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateInvoiceItemAsync(int id, UpdateInvoiceItemDto dto)
        {
            var invoiceItem = await _invoiceItemRepository.GetInvoiceItemByIdAsync(id);

            if (invoiceItem == null)
                throw new NotFoundException("Invoice item not found");

            var oldTotal = invoiceItem.TotalPrice;

            invoiceItem.Quantity = dto.Quantity;
            invoiceItem.TotalPrice = invoiceItem.UnitPrice * dto.Quantity;

            await _invoiceItemRepository.UpdateInvoiceItemAsync(invoiceItem);

            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(invoiceItem.InvoiceId);

            if (invoice != null)
            {
                invoice.TotalAmount += invoiceItem.TotalPrice - oldTotal;
                await _invoiceRepository.UpdateInvoiceAsync(invoice);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteInvoiceItemByIdAsync(int id)
        {
            var invoiceItem = await _invoiceItemRepository.GetInvoiceItemByIdAsync(id);

            if (invoiceItem == null)
                throw new NotFoundException("Invoice item not found");

            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(invoiceItem.InvoiceId);

            if (invoice != null)
            {
                invoice.TotalAmount -= invoiceItem.TotalPrice;
                await _invoiceRepository.UpdateInvoiceAsync(invoice);
            }

            invoiceItem.IsDeleted = true;
            await _invoiceItemRepository.UpdateInvoiceItemAsync(invoiceItem);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        private static InvoiceItemResponseDto MapToDto(InvoiceItem item)
        {
            return new InvoiceItemResponseDto
            {
                InvoiceItemId = item.InvoiceItemId,
                InvoiceId = item.InvoiceId,
                ServiceId = item.ServiceId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.TotalPrice
            };
        }
    }
}
