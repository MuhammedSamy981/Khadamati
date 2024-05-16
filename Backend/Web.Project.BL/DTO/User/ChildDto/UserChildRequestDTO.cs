namespace FinalProject.Dal;
    public class UserChildRequestDTO
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string RequestText { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public string Status { get; set; }
    }
    public class ProviderChildRequestDTO
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string RequestText { get; set; } = string.Empty;
        public string RequesterName { get; set; }
        public DateTime date { get; set; }
        public string Status { get; set; }
    }

