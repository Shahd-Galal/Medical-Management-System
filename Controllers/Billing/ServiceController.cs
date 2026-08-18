using MedicalManagementSystem.Dtos.Billing;
using MedicalManagementSystem.Services.Billing;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Billing
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                var services = await _service.GetAllServicesAsync();

                return Ok(services);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            try
            {
                var service = await _service.GetServiceByIdAsync(id);

                return Ok(service);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto dto)
        {
            try
            {
                await _service.CreateServiceAsync(dto);

                return Ok("Service created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, UpdateServiceDto dto)
        {
            try
            {
                await _service.UpdateServiceAsync(id, dto);

                return Ok("Service updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            try
            {
                await _service.DeleteServiceByIdAsync(id);

                return Ok("Service deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
