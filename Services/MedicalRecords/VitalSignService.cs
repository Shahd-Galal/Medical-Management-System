using MedicalManagementSystem.Dtos.MedicalRecords;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Models.MedicalRecords;
using MedicalManagementSystem.Repositories.MedicalRecords;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.MedicalRecords
{
    public class VitalSignService : IVitalSignService
    {
        private readonly IVitalSignRepository _vitalSignRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VitalSignService(
            IVitalSignRepository vitalSignRepository,
            IUnitOfWork unitOfWork)
        {
            _vitalSignRepository = vitalSignRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<VitalSignResponseDto>> GetAllVitalSignsAsync()
        {
            var vitalSigns = await _vitalSignRepository.GetAllVitalSignsAsync();

            return vitalSigns.Select(v => new VitalSignResponseDto
            {
                VitalSignId = v.VitalSignId,
                RecordId = v.RecordId,
                Temperature = v.Temperature,
                BloodPressure = v.BloodPressure,
                Pulse = v.Pulse,
                RespiratoryRate = v.RespiratoryRate,
                Weight = v.Weight,
                Height = v.Height
            });
        }
        public async Task<VitalSignResponseDto> GetVitalSignByIdAsync(int id)
        {
            var vitalSign = await _vitalSignRepository.GetVitalSignByIdAsync(id);

            if (vitalSign == null)
                throw new NotFoundException("Vital sign not found");

            return new VitalSignResponseDto
            {
                VitalSignId = vitalSign.VitalSignId,
                RecordId = vitalSign.RecordId,
                Temperature = vitalSign.Temperature,
                BloodPressure = vitalSign.BloodPressure,
                Pulse = vitalSign.Pulse,
                RespiratoryRate = vitalSign.RespiratoryRate,
                Weight = vitalSign.Weight,
                Height = vitalSign.Height
            };
        }
        public async Task CreateVitalSignAsync(CreateVitalSignDto dto)
        {
            var vitalSign = new VitalSign
            {
                RecordId = dto.RecordId,
                Temperature = dto.Temperature,
                BloodPressure = dto.BloodPressure,
                Pulse = dto.Pulse,
                RespiratoryRate = dto.RespiratoryRate,
                Weight = dto.Weight,
                Height = dto.Height
            };

            await _vitalSignRepository.CreateVitalSignAsync(vitalSign);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateVitalSignAsync(int id, UpdateVitalSignDto dto)
        {
            var vitalSign = await _vitalSignRepository.GetVitalSignByIdAsync(id);

            if (vitalSign == null)
                throw new NotFoundException("Vital sign not found");

            vitalSign.Temperature = dto.Temperature;
            vitalSign.BloodPressure = dto.BloodPressure;
            vitalSign.Pulse = dto.Pulse;
            vitalSign.RespiratoryRate = dto.RespiratoryRate;
            vitalSign.Weight = dto.Weight;
            vitalSign.Height = dto.Height;

            await _vitalSignRepository.UpdateVitalSignAsync(vitalSign);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteVitalSignByIdAsync(int id)
        {
            var result = await _vitalSignRepository.DeleteVitalSignByIdAsync(id);

            if (!result)
                throw new NotFoundException("Vital sign not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
