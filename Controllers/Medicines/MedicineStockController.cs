using MedicalManagementSystem.Dtos.Medicines;
using MedicalManagementSystem.Services.Medicines;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Medicines
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineStockController : ControllerBase
    {
        private readonly IMedicineStockService _service;
        public MedicineStockController(IMedicineStockService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMedicineStocks()
        {
            try
            {
                var medicineStocks = await _service.GetAllMedicineStocksAsync();
                return Ok(medicineStocks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicineStockById(int id)
        {
            try
            {
                var medicineStock = await _service.GetMedicineStockByIdAsync(id);
                return Ok(medicineStock);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMedicineStock(CreateMedicineStockDto dto)
        {
            try
            {
                await _service.CreateMedicineStockAsync(dto);
                return Ok("Medicine stock created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicineStock(int id,UpdateMedicineStockDto dto)
        {
            try
            {
                await _service.UpdateMedicineStockAsync(id, dto);
                return Ok("Medicine stock updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicineStock(int id)
        {
            try
            {
                await _service.DeleteMedicineStockByIdAsync(id);
                return Ok("Medicine stock deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}