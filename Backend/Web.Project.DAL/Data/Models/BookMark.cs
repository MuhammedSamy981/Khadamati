using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Dal
{
    [PrimaryKey("ServiceId", "UserId")]
    public class BookMark
    {
        [Range(0,100)]
        public int ServiceId { get; set; }      
        public string UserId { get; set; } 

        public Service? Service { get; set; }
        public User? User { get; set; }
    }
}
