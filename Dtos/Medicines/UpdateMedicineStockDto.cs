using System.ComponentModel.DataAnnotations;

namespace MedicalManagementSystem.Dtos.Medicines
{
    public class UpdateMedicineStockDto
    {
        [MaxLength(50)]
        public string? BatchNumber { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
