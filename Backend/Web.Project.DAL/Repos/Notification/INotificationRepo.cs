using FinalProject.Dal;
using FinalProject.Dal.Models;
public interface INotificationRepo : IGenericRepo<Notification>
{
    void AddNotification(Notification notification);
    void DeleteNotification(int id);
    void UpdateNotification(Notification notification);
    Notification GetNotificationById(int id);
    List<Notification> GetNotificationByUserId(string id);
    Notification GetNotification(int id);

}
