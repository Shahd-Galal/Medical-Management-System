using MedicalManagementSystem.Dtos.Medicines;
using MedicalManagementSystem.Services.Medicines;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Controllers.Medicines
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _service;

        public MedicineController(IMedicineService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMedicines()
        {
            try
            {
                var medicines = await _service.GetAllMedicinesAsync();
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicineById(int id)
        {
            try
            {
                var medicine = await _service.GetMedicineByIdAsync(id);
                return Ok(medicine);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMedicine(CreateMedicineDto dto)
        {
            try
            {
                await _service.CreateMedicineAsync(dto);
                return Ok("Medicine created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicine(int id,UpdateMedicineDto dto)
        {
            try
            {
                await _service.UpdateMedicineAsync(id, dto);
                return Ok("Medicine updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            try
            {
                await _service.DeleteMedicineByIdAsync(id);
                return Ok("Medicine deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}