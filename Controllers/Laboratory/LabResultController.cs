using MedicalManagementSystem.Dtos.Laboratory;
using MedicalManagementSystem.Services.Laboratory;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Laboratory
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabResultController : ControllerBase
    {
        private readonly ILabResultService _service;

        public LabResultController(ILabResultService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLabResults()
        {
            try
            {
                var labResults = await _service.GetAllLabResultsAsync();
                return Ok(labResults);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLabResultById(int id)
        {
            try
            {
                var labResult = await _service.GetLabResultByIdAsync(id);
                return Ok(labResult);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateLabResult(CreateLabResultDto dto)
        {
            try
            {
                await _service.CreateLabResultAsync(dto);
                return Ok("Lab result created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLabResult(int id, UpdateLabResultDto dto)
        {
            try
            {
                await _service.UpdateLabResultAsync(id, dto);
                return Ok("Lab result updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabResult(int id)
        {
            try
            {
                await _service.DeleteLabResultByIdAsync(id);
                return Ok("Lab result deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
