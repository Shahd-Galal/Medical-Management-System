using MedicalManagementSystem.Dtos.Common;
using MedicalManagementSystem.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _service;

        public AuditLogController(IAuditLogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuditLogs()
        {
            try
            {
                var auditLogs = await _service.GetAllAuditLogsAsync();

                return Ok(auditLogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuditLogById(int id)
        {
            try
            {
                var auditLog = await _service.GetAuditLogByIdAsync(id);

                return Ok(auditLog);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuditLog(CreateAuditLogDto dto)
        {
            try
            {
                await _service.CreateAuditLogAsync(dto);

                return Ok("Audit log created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
