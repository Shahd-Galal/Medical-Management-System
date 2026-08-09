namespace MedicalManagementSystem.Abstractions
{
    public abstract class SoftDeletableEntity : ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
