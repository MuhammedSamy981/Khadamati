namespace FinalProject.Dal;
public class RequestDetailsDTO
{
    public int Id { get; set; }
    public string RequestText { get; set; } = string.Empty;
    public DateTime date { get; set; }
    public string Status { get; set; }
    public RequestChildServiceDetailsDTO? ServiceDetails { get; set; }
    public RequestChildProviderDetailsDTO? ProviderDetails { get; set; }
    public RequestChildUserDetailsDTO? UserDetails { get; set; }
}
