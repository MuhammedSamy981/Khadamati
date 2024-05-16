using System.Security.Claims;
using FinalProject.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Khadamati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationManager _notificationRepo;
        public NotificationController(INotificationManager notificationRepo)
        {
            _notificationRepo = notificationRepo;
        }
        [HttpGet("{id}")]
        public ActionResult<NotificationDto> GetNotificationById(int id)
        {
            return _notificationRepo.GetNotificationById(id);
        }
        [HttpGet("User/{id}")]
        public ActionResult<List<NotificationDto>> GetNotificationByUserId(string id)
        {
            return _notificationRepo.GetNotificationByUserId(id);
        }
        [HttpPut]
        public ActionResult UpdateNotification(NotificationDto notification)
        {
            _notificationRepo.UpdateNotification(notification);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteNotification(int id)
        {
            _notificationRepo.DeleteNotification(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult AddNotification(NotificationAddDto notification)
        {
            _notificationRepo.AddNotification(notification);
            return StatusCode(StatusCodes.Status201Created);
        }





    }
}
