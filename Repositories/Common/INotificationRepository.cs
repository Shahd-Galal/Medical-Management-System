using MedicalManagementSystem.Model.Common;

namespace MedicalManagementSystem.Repositories.Common
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task<Notification?> GetNotificationByIdAsync(int id);
        Task CreateNotificationAsync(Notification notification);
        Task<bool> DeleteNotificationByIdAsync(int id);
    }
}
