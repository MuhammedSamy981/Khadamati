using FinalProject.Dal;
    public interface INotificationManager
    {
        void AddNotification(NotificationAddDto notification);
        void DeleteNotification(int id);
        void UpdateNotification(NotificationDto notification);
        NotificationDto GetNotificationById(int id);
        List<NotificationDto> GetNotificationByUserId(string id);
    }

