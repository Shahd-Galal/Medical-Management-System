using MedicalManagementSystem.Dtos.Common;

namespace MedicalManagementSystem.Services.Common
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationResponseDto>> GetAllNotificationsAsync();
        Task<NotificationResponseDto> GetNotificationByIdAsync(int id);
        Task CreateNotificationAsync(CreateNotificationDto dto);
        Task<bool> DeleteNotificationByIdAsync(int id);
    }
}
