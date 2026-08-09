using MedicalManagementSystem.Dtos.Doctors;
using MedicalManagementSystem.Services.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Doctors
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctors = await _service.GetAllDoctorsAsync();

                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _service.GetDoctorByIdAsync(id);

                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto dto)
        {
            try
            {
                await _service.CreateDoctorAsync(dto);

                return Ok("Doctor created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id,UpdateDoctorDto dto)
        {
            try
            {
                await _service.UpdateDoctorAsync(id, dto);

                return Ok("Doctor updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            try
            {
                await _service.DeleteDoctorByIdAsync(id);

                return Ok("Doctor deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}