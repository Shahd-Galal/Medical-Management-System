using MedicalManagementSystem.Dtos.Common;
using MedicalManagementSystem.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _service;

        public AttachmentController(IAttachmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttachments()
        {
            try
            {
                var attachments = await _service.GetAllAttachmentsAsync();

                return Ok(attachments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttachmentById(int id)
        {
            try
            {
                var attachment = await _service.GetAttachmentByIdAsync(id);

                return Ok(attachment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttachment(CreateAttachmentDto dto)
        {
            try
            {
                await _service.CreateAttachmentAsync(dto);

                return Ok("Attachment created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttachment(int id, UpdateAttachmentDto dto)
        {
            try
            {
                await _service.UpdateAttachmentAsync(id, dto);

                return Ok("Attachment updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            try
            {
                await _service.DeleteAttachmentByIdAsync(id);

                return Ok("Attachment deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
