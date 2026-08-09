using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Model.MedicalRecords;

namespace MedicalManagementSystem.Models.MedicalRecords;

public class VitalSign : SoftDeletableEntity
{
    [Key]
    public int VitalSignId { get; set; }
    public int RecordId { get; set; }
    [Range(30, 45)]
    public decimal? Temperature { get; set; }
    [MaxLength(20)]
    public string? BloodPressure { get; set; }
    [Range(30, 250)]
    public int? Pulse { get; set; }
    [Range(5, 60)]
    public int? RespiratoryRate { get; set; }
    [Range(0, 500)]
    public decimal? Weight { get; set; }
    [Range(20, 250)]
    public decimal? Height { get; set; }
    [ForeignKey(nameof(RecordId))]
    public MedicalRecord MedicalRecord { get; set; } = null!;
}