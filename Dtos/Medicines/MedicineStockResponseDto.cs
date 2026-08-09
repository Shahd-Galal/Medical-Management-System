namespace MedicalManagementSystem.Dtos.Medicines
{
    public class MedicineStockResponseDto
    {
        public int MedicineStockId { get; set; }
        public int MedicineId { get; set; }
        public string? BatchNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
