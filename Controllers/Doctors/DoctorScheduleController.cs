using MedicalManagementSystem.Dtos.Doctors;
using MedicalManagementSystem.Services.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Doctors
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleService _service;
        public DoctorScheduleController(IDoctorScheduleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            try
            {
                var schedules = await _service.GetAllSchedulesAsync();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            try
            {
                var schedule = await _service.GetScheduleByIdAsync(id);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateSchedule(CreateDoctorScheduleDto dto)
        {
            try
            {
                await _service.CreateScheduleAsync(dto);
                return Ok("Doctor schedule created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, UpdateDoctorScheduleDto dto)
        {
            try
            {
                await _service.UpdateScheduleAsync(id, dto);
                return Ok("Doctor schedule updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            try
            {
                await _service.DeleteScheduleByIdAsync(id);
                return Ok("Doctor schedule deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}