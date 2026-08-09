namespace MedicalManagementSystem.Dtos.Billing
{
    public class InvoiceItemResponseDto
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
