namespace FinalProject.Dal;
    public class UserChildNotificationDTO
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public bool seen { get; set; }
    }

