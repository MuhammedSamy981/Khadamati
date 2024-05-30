namespace FinalProject.Dal;
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public bool seen { get; set; }
        public string? UserId { get; set; }
        public NotificationUserDto? User { get; set; }
    }
    public class NotificationUserDto
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

    }
    public class NotificationAddDto
    {

        public string Text { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public bool seen { get; set; }
        public string? UserId { get; set; }
    }
    

