using FinalProject.Dal.Models;
using Microsoft.AspNetCore.Identity;
namespace FinalProject.Dal
{
    public class User:IdentityUser
    {
        public string Location { get; set; } = string.Empty;
        public ICollection<Service> Services { get; set; } = new HashSet<Service>();
        public ICollection<BookMark> Bookmarks { get; set; } = new HashSet<BookMark>();
        public ICollection<ServiceRequest> UserRequests { get; set; } = new HashSet<ServiceRequest>();
        public ICollection<ServiceRequest> ProviderRequests { get; set; } = new HashSet<ServiceRequest>();
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();

    }
}
