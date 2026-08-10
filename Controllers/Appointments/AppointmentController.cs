using MedicalManagementSystem.Dtos.Appointments;
using MedicalManagementSystem.Services.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Appointments
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                var appointments = await _service.GetAllAppointmentsAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            try
            {
                var appointment = await _service.GetAppointmentByIdAsync(id);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDto dto)
        {
            try
            {
                await _service.CreateAppointmentAsync(dto);
                return Ok("Appointment created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, UpdateAppointmentDto dto)
        {
            try
            {
                await _service.UpdateAppointmentAsync(id, dto);
                return Ok("Appointment updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                await _service.DeleteAppointmentByIdAsync(id);
                return Ok("Appointment deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
