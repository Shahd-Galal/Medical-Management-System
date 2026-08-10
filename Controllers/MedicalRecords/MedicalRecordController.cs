using MedicalManagementSystem.Dtos.MedicalRecords;
using MedicalManagementSystem.Services.MedicalRecords;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.MedicalRecords
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _service;

        public MedicalRecordController(IMedicalRecordService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecords()
        {
            try
            {
                var records = await _service.GetAllMedicalRecordsAsync();

                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalRecordById(int id)
        {
            try
            {
                var record = await _service.GetMedicalRecordByIdAsync(id);

                return Ok(record);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMedicalRecord(CreateMedicalRecordDto dto)
        {
            try
            {
                await _service.CreateMedicalRecordAsync(dto);

                return Ok("Medical record created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalRecord(int id, UpdateMedicalRecordDto dto)
        {
            try
            {
                await _service.UpdateMedicalRecordAsync(id, dto);

                return Ok("Medical record updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalRecord(int id)
        {
            try
            {
                await _service.DeleteMedicalRecordByIdAsync(id);

                return Ok("Medical record deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
