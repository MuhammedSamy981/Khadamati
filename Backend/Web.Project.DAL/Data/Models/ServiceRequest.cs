using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Dal
{
    [PrimaryKey("Id")]
    public class ServiceRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
        public string? ProviderId { get; set; }
        public User? Provider { get; set; }
        public string RequestText { get; set; } = string.Empty;
        public DateTime date { get; set; }   
        public string Status { get; set; }
}
}
