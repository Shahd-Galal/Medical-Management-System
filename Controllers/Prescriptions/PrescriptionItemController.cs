using MedicalManagementSystem.Dtos.Prescriptions;
using MedicalManagementSystem.Services.Prescriptions;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Prescriptions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionItemController : ControllerBase
    {
        private readonly IPrescriptionItemService _service;
        public PrescriptionItemController(IPrescriptionItemService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptionItems()
        {
            try
            {
                var prescriptionItems = await _service.GetAllPrescriptionItemsAsync();
                return Ok(prescriptionItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionItemById(int id)
        {
            try
            {
                var prescriptionItem = await _service.GetPrescriptionItemByIdAsync(id);
                return Ok(prescriptionItem);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreatePrescriptionItem(CreatePrescriptionItemDto dto)
        {
            try
            {
                await _service.CreatePrescriptionItemAsync(dto);
                return Ok("Prescription item created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescriptionItem(int id,UpdatePrescriptionItemDto dto)
        {
            try
            {
                await _service.UpdatePrescriptionItemAsync(id, dto);
                return Ok("Prescription item updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescriptionItem(int id)
        {
            try
            {
                await _service.DeletePrescriptionItemByIdAsync(id);
                return Ok("Prescription item deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}