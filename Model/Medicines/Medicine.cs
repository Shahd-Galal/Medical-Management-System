using System.ComponentModel.DataAnnotations;
using MedicalManagementSystem.Model.Prescriptions;
namespace MedicalManagementSystem.Models.Medicine;
public class Medicine : SoftDeletableEntity
{
    [Key]
    public int MedicineId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [MaxLength(1000)]
    public string? Description { get; set; }
    [Range(0,double.MaxValue)]
    public decimal UnitPrice { get; set; }
    [MaxLength(100)]
    public string? Manufacturer { get; set; }
    public ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();

    public ICollection<MedicineStock> MedicineStocks { get; set; } = new List<MedicineStock>();
}