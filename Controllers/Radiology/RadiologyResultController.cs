using MedicalManagementSystem.Dtos.Radiology;
using MedicalManagementSystem.Services.Radiology;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Radiology
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadiologyResultController : ControllerBase
    {
        private readonly IRadiologyResultService _service;

        public RadiologyResultController(IRadiologyResultService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRadiologyResults()
        {
            try
            {
                var radiologyResults = await _service.GetAllRadiologyResultsAsync();

                return Ok(radiologyResults);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRadiologyResultById(int id)
        {
            try
            {
                var radiologyResult = await _service.GetRadiologyResultByIdAsync(id);

                return Ok(radiologyResult);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRadiologyResult(CreateRadiologyResultDto dto)
        {
            try
            {
                await _service.CreateRadiologyResultAsync(dto);

                return Ok("Radiology result created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRadiologyResult(int id, UpdateRadiologyResultDto dto)
        {
            try
            {
                await _service.UpdateRadiologyResultAsync(id, dto);

                return Ok("Radiology result updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRadiologyResult(int id)
        {
            try
            {
                await _service.DeleteRadiologyResultByIdAsync(id);

                return Ok("Radiology result deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
