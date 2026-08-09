using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalManagementSystem.Models.Medicine;
public class MedicineStock : SoftDeletableEntity
{
    [Key]
    public int MedicineStockId { get; set; }
    public int MedicineId { get; set; }
    [MaxLength(50)]
    public string? BatchNumber { get; set; }
    [Range(0,int.MaxValue)]
    public int Quantity { get; set; }
    public DateTime? ExpiryDate { get; set; }
    [ForeignKey(nameof(MedicineId))]
    public Medicine Medicine { get; set; } = null!;
}