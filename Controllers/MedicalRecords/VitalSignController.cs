using MedicalManagementSystem.Dtos.MedicalRecords;
using MedicalManagementSystem.Services.MedicalRecords;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.MedicalRecords
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalSignController : ControllerBase
    {
        private readonly IVitalSignService _service;

        public VitalSignController(IVitalSignService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVitalSigns()
        {
            try
            {
                var vitalSigns = await _service.GetAllVitalSignsAsync();

                return Ok(vitalSigns);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVitalSignById(int id)
        {
            try
            {
                var vitalSign = await _service.GetVitalSignByIdAsync(id);

                return Ok(vitalSign);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateVitalSign(CreateVitalSignDto dto)
        {
            try
            {
                await _service.CreateVitalSignAsync(dto);

                return Ok("Vital sign created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVitalSign(int id, UpdateVitalSignDto dto)
        {
            try
            {
                await _service.UpdateVitalSignAsync(id, dto);

                return Ok("Vital sign updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVitalSign(int id)
        {
            try
            {
                await _service.DeleteVitalSignByIdAsync(id);

                return Ok("Vital sign deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
