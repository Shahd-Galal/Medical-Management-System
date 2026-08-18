using MedicalManagementSystem.Dtos.Insurance;
using MedicalManagementSystem.Services.Insurance;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Insurance
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceProviderController : ControllerBase
    {
        private readonly IInsuranceProviderService _service;

        public InsuranceProviderController(IInsuranceProviderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInsuranceProviders()
        {
            try
            {
                var providers = await _service.GetAllInsuranceProvidersAsync();

                return Ok(providers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsuranceProviderById(int id)
        {
            try
            {
                var provider = await _service.GetInsuranceProviderByIdAsync(id);

                return Ok(provider);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsuranceProvider(CreateInsuranceProviderDto dto)
        {
            try
            {
                await _service.CreateInsuranceProviderAsync(dto);

                return Ok("Insurance provider created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInsuranceProvider(int id, UpdateInsuranceProviderDto dto)
        {
            try
            {
                await _service.UpdateInsuranceProviderAsync(id, dto);

                return Ok("Insurance provider updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceProvider(int id)
        {
            try
            {
                await _service.DeleteInsuranceProviderByIdAsync(id);

                return Ok("Insurance provider deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
