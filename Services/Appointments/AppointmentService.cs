using MedicalManagementSystem.Dtos.Appointments;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Appointments;
using MedicalManagementSystem.Repositories.Appointments;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsAsync();

            return appointments.Select(a => new AppointmentResponseDto
            {
                AppointmentId = a.AppointmentId,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                DepartmentId = a.DepartmentId,
                ScheduleId = a.ScheduleId,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                Reason = a.Reason,
                Notes = a.Notes
            });
        }
        public async Task<AppointmentResponseDto> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);

            if (appointment == null)
                throw new NotFoundException("Appointment not found");

            return new AppointmentResponseDto
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                DepartmentId = appointment.DepartmentId,
                ScheduleId = appointment.ScheduleId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                Reason = appointment.Reason,
                Notes = appointment.Notes
            };
        }
        public async Task CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                DepartmentId = dto.DepartmentId,
                ScheduleId = dto.ScheduleId,
                AppointmentDate = dto.AppointmentDate,
                Status = dto.Status,
                Reason = dto.Reason,
                Notes = dto.Notes
            };

            await _appointmentRepository.CreateAppointmentAsync(appointment);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAppointmentAsync(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);

            if (appointment == null)
                throw new NotFoundException("Appointment not found");

            appointment.AppointmentDate = dto.AppointmentDate;
            appointment.Status = dto.Status;
            appointment.Reason = dto.Reason;
            appointment.Notes = dto.Notes;

            await _appointmentRepository.UpdateAppointmentAsync(appointment);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteAppointmentByIdAsync(int id)
        {
            var result = await _appointmentRepository.DeleteAppointmentByIdAsync(id);

            if (!result)
                throw new NotFoundException("Appointment not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
