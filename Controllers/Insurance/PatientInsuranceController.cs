using MedicalManagementSystem.Dtos.Insurance;
using MedicalManagementSystem.Services.Insurance;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Insurance
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInsuranceController : ControllerBase
    {
        private readonly IPatientInsuranceService _service;

        public PatientInsuranceController(IPatientInsuranceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatientInsurances()
        {
            try
            {
                var patientInsurances = await _service.GetAllPatientInsurancesAsync();

                return Ok(patientInsurances);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientInsuranceById(int id)
        {
            try
            {
                var patientInsurance = await _service.GetPatientInsuranceByIdAsync(id);

                return Ok(patientInsurance);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatientInsurance(CreatePatientInsuranceDto dto)
        {
            try
            {
                await _service.CreatePatientInsuranceAsync(dto);

                return Ok("Patient insurance created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientInsurance(int id, UpdatePatientInsuranceDto dto)
        {
            try
            {
                await _service.UpdatePatientInsuranceAsync(id, dto);

                return Ok("Patient insurance updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientInsurance(int id)
        {
            try
            {
                await _service.DeletePatientInsuranceByIdAsync(id);

                return Ok("Patient insurance deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
