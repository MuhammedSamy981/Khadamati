namespace FinalProject.Dal;
    public class UserChildRatingDTO
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Comment { get; set; } = string.Empty;
        public float rating { get; set; }
        public DateTime date { get; set; }
    }

