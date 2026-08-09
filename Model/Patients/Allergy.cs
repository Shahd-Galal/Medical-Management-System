using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalManagementSystem.Enums.Patients;
using MedicalManagementSystem.Model.Patients;
namespace MedicalManagementSystem.Models.Patients;

public class Allergy : SoftDeletableEntity
{
    [Key]
    public int AllergyId { get; set; }
    public int PatientId { get; set; }
    [Required]
    [MaxLength(100)]
    public string AllergyName { get; set; } = null!;
    public AllergySeverity? Severity { get; set; }
    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;
}