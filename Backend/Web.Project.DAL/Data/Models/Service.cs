using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Dal
{
    [PrimaryKey("Id")]
    public class Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public float Rating { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Approved { get; set; }
        public DateTime date { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public string ProviderId { get; set; }=string.Empty;
        public User Provider { get; set; } = null!;
        public ICollection<Picture> Pictures { get; set; }=new HashSet<Picture>();
        public ICollection<Rating> Ratings { get; set; }= new HashSet<Rating>();
        public ICollection<ServiceRequest> Requests { get; set; } = new HashSet<ServiceRequest>();
        public ICollection<BookMark> BookMarks { get; set; } = new HashSet<BookMark>();
    }
}
