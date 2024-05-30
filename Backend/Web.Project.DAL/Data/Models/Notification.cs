using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Dal.Models
{
    [PrimaryKey("Id")]
    public class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public bool seen { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
