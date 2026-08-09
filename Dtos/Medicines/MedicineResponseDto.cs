namespace MedicalManagementSystem.Dtos.Medicines
{
    public class MedicineResponseDto
    {
        public int MedicineId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Manufacturer { get; set; }
    }
}
