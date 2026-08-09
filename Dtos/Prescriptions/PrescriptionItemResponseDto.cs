namespace MedicalManagementSystem.Dtos.Prescriptions
{
    public class PrescriptionItemResponseDto
    {
        public int PrescriptionItemId { get; set; }
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public int DurationDays { get; set; }
        public string? Instructions { get; set; }
    }
}
