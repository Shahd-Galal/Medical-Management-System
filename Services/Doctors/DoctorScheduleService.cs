using MedicalManagementSystem.Dtos.Doctors;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Models.Doctors;
using MedicalManagementSystem.Repositories.Doctors;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Doctors
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IDoctorScheduleRepository _scheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorScheduleService(IDoctorScheduleRepository scheduleRepository,IUnitOfWork unitOfWork)
        {
            _scheduleRepository = scheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DoctorScheduleResponseDto>> GetAllSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllDoctorSchedulesAsync();

            return schedules.Select(s => new DoctorScheduleResponseDto
            {
                ScheduleId = s.ScheduleId,
                DoctorId = s.DoctorId,
                DayOfWeek = s.DayOfWeek,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                MaxPatients = s.MaxPatients
            });
        }

        public async Task<DoctorScheduleResponseDto> GetScheduleByIdAsync(int id)
        {
            var schedule = await _scheduleRepository.GetDoctorScheduleByIdAsync(id);

            if (schedule == null)
                throw new NotFoundException("Doctor schedule not found");

            return new DoctorScheduleResponseDto
            {
                ScheduleId = schedule.ScheduleId,
                DoctorId = schedule.DoctorId,
                DayOfWeek = schedule.DayOfWeek,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                MaxPatients = schedule.MaxPatients
            };
        }

        public async Task CreateScheduleAsync(CreateDoctorScheduleDto dto)
        {
            var schedule = new DoctorSchedule
            {
                DoctorId = dto.DoctorId,
                DayOfWeek = dto.DayOfWeek,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                MaxPatients = dto.MaxPatients
            };

            await _scheduleRepository.CreateDoctorScheduleAsync(schedule);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateScheduleAsync(int id, UpdateDoctorScheduleDto dto)
        {
            var schedule = await _scheduleRepository.GetDoctorScheduleByIdAsync(id);

            if (schedule == null)
                throw new NotFoundException("Doctor schedule not found");

            schedule.DayOfWeek = dto.DayOfWeek;
            schedule.StartTime = dto.StartTime;
            schedule.EndTime = dto.EndTime;
            schedule.MaxPatients = dto.MaxPatients;

            await _scheduleRepository.UpdateDoctorScheduleAsync(schedule);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteScheduleByIdAsync(int id)
        {
            var result = await _scheduleRepository.DeleteDoctorScheduleByIdAsync(id);

            if (!result)
                throw new NotFoundException("Doctor schedule not found");

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}