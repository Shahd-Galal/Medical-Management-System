using MedicalManagementSystem.Dtos.Billing;
using MedicalManagementSystem.Services.Billing;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Billing
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItemService _service;

        public InvoiceItemController(IInvoiceItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoiceItems()
        {
            try
            {
                var invoiceItems = await _service.GetAllInvoiceItemsAsync();

                return Ok(invoiceItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceItemById(int id)
        {
            try
            {
                var invoiceItem = await _service.GetInvoiceItemByIdAsync(id);

                return Ok(invoiceItem);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoiceItem(CreateInvoiceItemDto dto)
        {
            try
            {
                await _service.CreateInvoiceItemAsync(dto);

                return Ok("Invoice item created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoiceItem(int id, UpdateInvoiceItemDto dto)
        {
            try
            {
                await _service.UpdateInvoiceItemAsync(id, dto);

                return Ok("Invoice item updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceItem(int id)
        {
            try
            {
                await _service.DeleteInvoiceItemByIdAsync(id);

                return Ok("Invoice item deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
