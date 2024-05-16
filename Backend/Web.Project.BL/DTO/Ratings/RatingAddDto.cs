
 namespace FinalProject.Dal;
 
    public class RatingAddDto
    {
        public int ServiceId { get; set; }
        public string? UserId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public float rating { get; set; }
        public DateTime? date { get; set; }
    }
