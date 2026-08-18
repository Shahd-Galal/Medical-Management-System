using MedicalManagementSystem.Dtos.Laboratory;
using MedicalManagementSystem.Services.Laboratory;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Laboratory
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabRequestController : ControllerBase
    {
        private readonly ILabRequestService _service;
        public LabRequestController(ILabRequestService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLabRequests()
        {
            try
            {
                var labRequests = await _service.GetAllLabRequestsAsync();
                return Ok(labRequests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLabRequestById(int id)
        {
            try
            {
                var labRequest = await _service.GetLabRequestByIdAsync(id);
                return Ok(labRequest);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateLabRequest(CreateLabRequestDto dto)
        {
            try
            {
                await _service.CreateLabRequestAsync(dto);
                return Ok("Lab request created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLabRequest(int id, UpdateLabRequestDto dto)
        {
            try
            {
                await _service.UpdateLabRequestAsync(id, dto);
                return Ok("Lab request updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabRequest(int id)
        {
            try
            {
                await _service.DeleteLabRequestByIdAsync(id);
                return Ok("Lab request deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
