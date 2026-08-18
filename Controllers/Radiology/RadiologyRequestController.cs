using MedicalManagementSystem.Dtos.Radiology;
using MedicalManagementSystem.Services.Radiology;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Radiology
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadiologyRequestController : ControllerBase
    {
        private readonly IRadiologyRequestService _service;
        public RadiologyRequestController(IRadiologyRequestService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRadiologyRequests()
        {
            try
            {
                var radiologyRequests = await _service.GetAllRadiologyRequestsAsync();
                return Ok(radiologyRequests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRadiologyRequestById(int id)
        {
            try
            {
                var radiologyRequest = await _service.GetRadiologyRequestByIdAsync(id);
                return Ok(radiologyRequest);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateRadiologyRequest(CreateRadiologyRequestDto dto)
        {
            try
            {
                await _service.CreateRadiologyRequestAsync(dto);
                return Ok("Radiology request created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRadiologyRequest(int id, UpdateRadiologyRequestDto dto)
        {
            try
            {
                await _service.UpdateRadiologyRequestAsync(id, dto);
                return Ok("Radiology request updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRadiologyRequest(int id)
        {
            try
            {
                await _service.DeleteRadiologyRequestByIdAsync(id);
                return Ok("Radiology request deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
