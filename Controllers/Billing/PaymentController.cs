using MedicalManagementSystem.Dtos.Billing;
using MedicalManagementSystem.Services.Billing;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Billing
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                var payments = await _service.GetAllPaymentsAsync();

                return Ok(payments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            try
            {
                var payment = await _service.GetPaymentByIdAsync(id);

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto dto)
        {
            try
            {
                await _service.CreatePaymentAsync(dto);

                return Ok("Payment created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                await _service.DeletePaymentByIdAsync(id);

                return Ok("Payment deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
