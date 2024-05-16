using System.Linq;
using FinalProject.Dal;
using FinalProject.Dal.Models;
using Microsoft.EntityFrameworkCore;
using WebApplications4.DAL;
    public class NotificationRepo :GenericRepo<Notification>,INotificationRepo
    {
        private readonly KhadamatiContext _db;

        public NotificationRepo(KhadamatiContext db):base(db)
        {
            _db = db;
        }
        public void AddNotification(Notification notification)
        {
            {
                _db.Notifications.Add(notification);
                _db.SaveChanges();
            }
        }
        public void DeleteNotification(int id)
        {
            {
                var notification = _db.Notifications.Find(id);
                _db.Notifications.Remove(notification);
                _db.SaveChanges();
            }
        }
        public void UpdateNotification(Notification notification)
        {
            {
                _db.Notifications.Update(notification);
                _db.SaveChanges();
            }
        }
        public Notification GetNotificationById(int id)
        {
            {
                var notification = _db.Notifications.Find(id);
                return notification;
                
            }
        }
        public List<Notification> GetNotificationByUserId(string id)
        {
            {
                
                var notification = _db.Notifications.Where(n => n.UserId == id).ToList();
                return notification;
                
            }
        }
        public Notification GetNotification(int id)
        {
            {
                Notification? notification = _db.Notifications.Find(id);
                return notification;

            }
        }
    }

    
