using FinalProject.Dal;
using FinalProject.Dal.Models;
public class NotificationManager : INotificationManager
{
    private readonly IUnitofWork _repo;

    public NotificationManager(IUnitofWork nr)
    {
        _repo = nr;
    }
    public void AddNotification(NotificationAddDto notification)
    {
        _repo.NotificationRepo.AddNotification(new Notification
        {
            UserId = notification.UserId,
            date = notification.date,
            Text = notification.Text,
            seen = notification.seen,
        });
    }
    public void DeleteNotification(int id)
    {
        {
            _repo.NotificationRepo.DeleteNotification(id);
        }
    }
    public void UpdateNotification(NotificationDto notification)
    {
        _repo.NotificationRepo.UpdateNotification(new Notification
        {
            Id = notification.Id,
            UserId = notification.UserId,
            date = notification.date,
            Text = notification.Text,
            seen = notification.seen,
        });
    }
    public NotificationDto GetNotificationById(int id)
    {
        {
            var notification = _repo.NotificationRepo.GetNotificationById(id);
            return new NotificationDto
            {
                Id = notification.Id,
                UserId = notification.UserId,
                date = notification.date,
                Text = notification.Text,
                seen = notification.seen,
            };
        }
    }
    public List<NotificationDto> GetNotificationByUserId(string id)
    {
        {
            var notification = _repo.NotificationRepo.GetNotificationByUserId(id);
            return notification.Select(n => new NotificationDto
            {
                Id = n.Id,
                UserId = n.UserId,
                date = n.date,
                Text = n.Text,
                seen = n.seen,

            }).ToList();
        }
    }

}



