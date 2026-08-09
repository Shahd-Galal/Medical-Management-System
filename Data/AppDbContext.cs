using System.Linq.Expressions;
using MedicalManagementSystem.Model.Appointments;
using MedicalManagementSystem.Model.Auth;
using MedicalManagementSystem.Model.Billing;
using MedicalManagementSystem.Model.Common;
using MedicalManagementSystem.Model.Hospital;
using MedicalManagementSystem.Model.Insurance;
using MedicalManagementSystem.Model.Laboratory;
using MedicalManagementSystem.Model.MedicalRecords;
using MedicalManagementSystem.Model.Patients;
using MedicalManagementSystem.Model.Prescriptions;
using MedicalManagementSystem.Model.Radiology;
using MedicalManagementSystem.Models.Doctors;
using MedicalManagementSystem.Models.MedicalRecords;
using MedicalManagementSystem.Models.Medicine;
using MedicalManagementSystem.Models.Patients;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //Hospital
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }

        //Doctors
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }

        //Patients
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Allergy> Allergies { get; set; }

        //Appointments
        public DbSet<Appointment> Appointments { get; set; }

        //MedicalRecords
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }

        //Prescriptions
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }

        //Medicine
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineStock> MedicineStocks { get; set; }

        //Laboratory
        public DbSet<LabRequest> LabRequests { get; set; }
        public DbSet<LabResult> LabResults { get; set; }

        //Radiology
        public DbSet<RadiologyRequest> RadiologyRequests { get; set; }
        public DbSet<RadiologyResult> RadiologyResults { get; set; }

        //Insurance
        public DbSet<InsuranceProvider> InsuranceProviders { get; set; }
        public DbSet<PatientInsurance> PatientInsurances { get; set; }

        //Common 
        public DbSet<Attachment> Attachments { get; set; } 
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        //Billing
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<VitalSign>()
                .Property(x => x.Temperature)
                .HasPrecision(5, 2);

            modelBuilder.Entity<VitalSign>()
                .Property(x => x.Weight)
                .HasPrecision(6, 2);

            modelBuilder.Entity<VitalSign>()
                .Property(x => x.Height)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Doctor>()
                .Property(x => x.ConsultationFee)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Medicine>()
                .Property(x => x.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .Property(x => x.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<InvoiceItem>()
                .Property(x => x.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<InvoiceItem>()
                .Property(x => x.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            foreach (var foreignKey in modelBuilder.Model
                         .GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Not(
                        Expression.Property(parameter, nameof(ISoftDeletable.IsDeleted)));

                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(Expression.Lambda(body, parameter));
                }
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplySoftDelete();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            ApplySoftDelete();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplySoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries<ISoftDeletable>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                }
            }
        }
    }
}