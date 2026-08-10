using MedicalManagementSystem.Dtos.Patients;
using MedicalManagementSystem.Services.Patients;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Patients
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyService _service;

        public AllergyController(IAllergyService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAllergies()
        {
            try
            {
                var allergies = await _service.GetAllAllergiesAsync();

                return Ok(allergies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllergyById(int id)
        {
            try
            {
                var allergy = await _service.GetAllergyByIdAsync(id);

                return Ok(allergy);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAllergy(CreateAllergyDto dto)
        {
            try
            {
                await _service.CreateAllergyAsync(dto);

                return Ok("Allergy created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllergy(int id, UpdateAllergyDto dto)
        {
            try
            {
                await _service.UpdateAllergyAsync(id, dto);

                return Ok("Allergy updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergy(int id)
        {
            try
            {
                await _service.DeleteAllergyByIdAsync(id);

                return Ok("Allergy deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}