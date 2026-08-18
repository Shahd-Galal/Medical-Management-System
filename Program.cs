using System.Diagnostics;
using System.Text;
using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Auth;
using MedicalManagementSystem.Repositories.Appointments;
using MedicalManagementSystem.Repositories.Billing;
using MedicalManagementSystem.Repositories.Common;
using MedicalManagementSystem.Repositories.Insurance;
using MedicalManagementSystem.Repositories.Doctors;
using MedicalManagementSystem.Repositories.Hospital;
using MedicalManagementSystem.Repositories.Laboratory;
using MedicalManagementSystem.Repositories.MedicalRecords;
using MedicalManagementSystem.Repositories.Medicines;
using MedicalManagementSystem.Repositories.Patients;
using MedicalManagementSystem.Repositories.Prescriptions;
using MedicalManagementSystem.Repositories.Radiology;
using MedicalManagementSystem.Services.Appointments;
using MedicalManagementSystem.Services.Billing;
using MedicalManagementSystem.Services.Common;
using MedicalManagementSystem.Services.Insurance;
using MedicalManagementSystem.Services.Auth;
using MedicalManagementSystem.Services.Doctors;
using MedicalManagementSystem.Services.Hospital;
using MedicalManagementSystem.Services.Laboratory;
using MedicalManagementSystem.Services.MedicalRecords;
using MedicalManagementSystem.Services.Medicines;
using MedicalManagementSystem.Services.Patients;
using MedicalManagementSystem.Services.Prescriptions;
using MedicalManagementSystem.Services.Radiology;
using MedicalManagementSystem.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

//DI

builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IBranchService, BranchService>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();

builder.Services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
builder.Services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
builder.Services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();

builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();
builder.Services.AddScoped<IAllergyService, AllergyService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();

builder.Services.AddScoped<IVitalSignRepository, VitalSignRepository>();
builder.Services.AddScoped<IVitalSignService, VitalSignService>();

builder.Services.AddScoped<ILabRequestRepository, LabRequestRepository>();
builder.Services.AddScoped<ILabRequestService, LabRequestService>();

builder.Services.AddScoped<ILabResultRepository, LabResultRepository>();
builder.Services.AddScoped<ILabResultService, LabResultService>();

builder.Services.AddScoped<IRadiologyRequestRepository, RadiologyRequestRepository>();
builder.Services.AddScoped<IRadiologyRequestService, RadiologyRequestService>();

builder.Services.AddScoped<IRadiologyResultRepository, RadiologyResultRepository>();
builder.Services.AddScoped<IRadiologyResultService, RadiologyResultService>();

builder.Services.AddScoped<IInsuranceProviderRepository, InsuranceProviderRepository>();
builder.Services.AddScoped<IInsuranceProviderService, InsuranceProviderService>();
builder.Services.AddScoped<IPatientInsuranceRepository, PatientInsuranceRepository>();
builder.Services.AddScoped<IPatientInsuranceService, PatientInsuranceService>();

builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
builder.Services.AddScoped<IInvoiceItemService, InvoiceItemService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();

builder.Services.AddScoped<IPrescriptionItemRepository, PrescriptionItemRepository>();
builder.Services.AddScoped<IPrescriptionItemService, PrescriptionItemService>();

builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IMedicineService, MedicineService>();

builder.Services.AddScoped<IMedicineStockRepository, MedicineStockRepository>();
builder.Services.AddScoped<IMedicineStockService, MedicineStockService>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Identity
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();
// JWT Authentication
var jwtSection = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSection["Issuer"],
        ValidAudience = jwtSection["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSection["Key"]!))
    };
});

builder.Services.AddAuthorization();
// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Medical Management System API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Paste ONLY your token here."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("Bearer", document),
            new List<string>()
        }
    });
});

var app = builder.Build();
// Seed roles + default admin
using (var scope = app.Services.CreateScope())
{
    await IdentitySeeder.SeedAsync(scope.ServiceProvider, app.Configuration);
}
// Swagger
app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        "Medical Management System API v1"
    );

    options.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"))
    .ExcludeFromDescription();
// Open Swagger automatically in Development
if (app.Environment.IsDevelopment())
{
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        var url = app.Urls.FirstOrDefault(u => u.StartsWith("https"))
                  ?? app.Urls.FirstOrDefault();

        if (url is not null)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = $"{url}/swagger",
                    UseShellExecute = true
                });
            }
            catch
            {
            }
        }
    });
}

app.Run();