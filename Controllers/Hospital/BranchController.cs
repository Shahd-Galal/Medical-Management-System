using MedicalManagementSystem.Dtos.Hospital;
using MedicalManagementSystem.Services.Hospital;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Hospital
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _service;

        public BranchController(IBranchService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            try
            {
                var branches = await _service.GetAllBranchesAsync();
                return Ok(branches);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchById(int id)
        {
            try
            {
                var branch = await _service.GetBranchByIdAsync(id);
                return Ok(branch);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto dto)
        {
            try
            {
                await _service.CreateBranchAsync(dto);
                return Ok("Branch created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, UpdateBranchDto dto)
        {
            try
            {
                await _service.UpdateBranchAsync(id, dto);
                return Ok("Branch updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            try
            {
                await _service.DeleteBranchAsync(id);
                return Ok("Branch deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}