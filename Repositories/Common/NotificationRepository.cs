using MedicalManagementSystem.Data;
using MedicalManagementSystem.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Repositories.Common
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;
        public NotificationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _context.Notifications.ToListAsync();
        }
        public async Task<Notification?> GetNotificationByIdAsync(int id)
        {
            return await _context.Notifications.FirstOrDefaultAsync(n => n.NotificationId == id);
        }
        public async Task CreateNotificationAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
        }
        public async Task<bool> DeleteNotificationByIdAsync(int id)
        {
            var notification = await _context.Notifications
                .FirstOrDefaultAsync(n => n.NotificationId == id);

            if (notification == null)
                return false;

            notification.IsDeleted = true;
            return true;
        }
    }
}
