using MedicalManagementSystem.Dtos.Prescriptions;
using MedicalManagementSystem.Services.Prescriptions;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Prescriptions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _service;
        public PrescriptionController(IPrescriptionService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            try
            {
                var prescriptions = await _service.GetAllPrescriptionsAsync();
                return Ok(prescriptions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionById(int id)
        {
            try
            {
                var prescription =await _service.GetPrescriptionByIdAsync(id);
                return Ok(prescription);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreatePrescription(CreatePrescriptionDto dto)
        {
            try
            {
                await _service.CreatePrescriptionAsync(dto);
                return Ok("Prescription created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            try
            {
                await _service.DeletePrescriptionByIdAsync(id);
                return Ok("Prescription deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}