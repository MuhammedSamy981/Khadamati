namespace FinalProject.Dal;

public class RequestReadDTO
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public string? NameUser { get; set; } 
    public int? ServiceId { get; set; }
    public string? NameService { get; set; }
    public string? ProviderId { get; set; }
    public string? NameProvider { get; set; }
    public string RequestText { get; set; } = string.Empty;
    public DateTime date { get; set; }
    public string Status { get; set; }
}
