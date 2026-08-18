using MedicalManagementSystem.Dtos.Common;
using MedicalManagementSystem.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            try
            {
                var notifications = await _service.GetAllNotificationsAsync();

                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            try
            {
                var notification = await _service.GetNotificationByIdAsync(id);

                return Ok(notification);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto dto)
        {
            try
            {
                await _service.CreateNotificationAsync(dto);

                return Ok("Notification created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            try
            {
                await _service.DeleteNotificationByIdAsync(id);

                return Ok("Notification deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
