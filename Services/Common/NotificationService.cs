using MedicalManagementSystem.Dtos.Common;
using MedicalManagementSystem.Exceptions;
using MedicalManagementSystem.Model.Common;
using MedicalManagementSystem.Repositories.Common;
using MedicalManagementSystem.UnitOfWork;

namespace MedicalManagementSystem.Services.Common
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public NotificationService(INotificationRepository notificationRepository,IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<NotificationResponseDto>> GetAllNotificationsAsync()
        {
            var notifications = await _notificationRepository.GetAllNotificationsAsync();

            return notifications.Select(n => new NotificationResponseDto
            {
                NotificationId = n.NotificationId,
                UserId = n.UserId,
                Title = n.Title,
                Message = n.Message,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt
            });
        }
        public async Task<NotificationResponseDto> GetNotificationByIdAsync(int id)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(id);

            if (notification == null)
                throw new NotFoundException("Notification not found");

            return new NotificationResponseDto
            {
                NotificationId = notification.NotificationId,
                UserId = notification.UserId,
                Title = notification.Title,
                Message = notification.Message,
                IsRead = notification.IsRead,
                CreatedAt = notification.CreatedAt
            };
        }
        public async Task CreateNotificationAsync(CreateNotificationDto dto)
        {
            var notification = new Notification
            {
                UserId = dto.UserId,
                Title = dto.Title,
                Message = dto.Message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            await _notificationRepository.CreateNotificationAsync(notification);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteNotificationByIdAsync(int id)
        {
            var result = await _notificationRepository.DeleteNotificationByIdAsync(id);

            if (!result)
                throw new NotFoundException("Notification not found");

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
