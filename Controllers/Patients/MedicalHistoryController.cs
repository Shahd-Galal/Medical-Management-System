using MedicalManagementSystem.Dtos.Patients;
using MedicalManagementSystem.Services.Patients;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Patients
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryService _service;

        public MedicalHistoryController(IMedicalHistoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMedicalHistories()
        {
            try
            {
                var medicalHistories = await _service.GetAllMedicalHistoriesAsync();

                return Ok(medicalHistories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalHistoryById(int id)
        {
            try
            {
                var medicalHistory = await _service.GetMedicalHistoryByIdAsync(id);

                return Ok(medicalHistory);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMedicalHistory(CreateMedicalHistoryDto dto)
        {
            try
            {
                await _service.CreateMedicalHistoryAsync(dto);

                return Ok("Medical history created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalHistory(int id, UpdateMedicalHistoryDto dto)
        {
            try
            {
                await _service.UpdateMedicalHistoryAsync(id, dto);

                return Ok("Medical history updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalHistory(int id)
        {
            try
            {
                await _service.DeleteMedicalHistoryByIdAsync(id);

                return Ok("Medical history deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}