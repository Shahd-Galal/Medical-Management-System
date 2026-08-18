using MedicalManagementSystem.Dtos.Billing;
using MedicalManagementSystem.Services.Billing;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Billing
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            try
            {
                var invoices = await _service.GetAllInvoicesAsync();

                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            try
            {
                var invoice = await _service.GetInvoiceByIdAsync(id);

                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceDto dto)
        {
            try
            {
                await _service.CreateInvoiceAsync(dto);

                return Ok("Invoice created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, UpdateInvoiceDto dto)
        {
            try
            {
                await _service.UpdateInvoiceAsync(id, dto);

                return Ok("Invoice updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            try
            {
                await _service.DeleteInvoiceByIdAsync(id);

                return Ok("Invoice deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
